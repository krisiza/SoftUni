using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;

        public EventController(HomiesDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> All()
        {
            var events = await context.Events
                .AsNoTracking()
                .Select(e => new EventInfoViewModel(
                    e.Id, e.Name, e.Start, e.Type.Name, e.Organiser.UserName
                    ))
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var myEvent = await context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (myEvent == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!myEvent.EventsParticipants.Any(p => p.HelperId == userId)) 
            {
                myEvent.EventsParticipants.Add(new EventParticipant()
                {
                    EventsId = myEvent.Id,
                    HelperId = userId
                });

                await context.SaveChangesAsync();
            }
                return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string usedUserId = GetUserId();

            var model = await context.EventsParticipants
                .Where(ep => ep.HelperId == usedUserId)
                .AsNoTracking()
                .Select(ep => new EventInfoViewModel(ep.EventsId, ep.Event.Name,ep.Event.Start, ep.Event.Type.Name, ep.Event.Organiser.UserName))
                .ToListAsync(); 

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var myEvent = await context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (myEvent == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();
            var ep = myEvent.EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            myEvent.EventsParticipants.Remove(ep);

            await context.SaveChangesAsync();

           return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();
            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if(DateTime.TryParseExact(
                model.Start, 
                DataConstants.EventCreatedOnFormat, 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.EventCreatedOnFormat}");
            }

            if (DateTime.TryParseExact(
                model.End,
                DataConstants.EventCreatedOnFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.EventCreatedOnFormat}");
            }

            if(!ModelState.IsValid)
            {
                model.Types = await GetTypes();

                return View(model);
            }

            var entity = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
                Start = start,
                End = end,
            };

            await context.Events.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var e = await context.Events
                .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if(e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new EventFormViewModel()
            {
                Description = e.Description,
                Name = e.Name,
                End = e.End.ToString(DataConstants.EventCreatedOnFormat),
                Start = e.Start.ToString(DataConstants.EventCreatedOnFormat),
                TypeId = e.TypeId,
            };

            model.Types = await GetTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var e = await context.Events
                    .FindAsync(id);

            if (e == null)
            {
                return BadRequest();
            }

            if (e.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (DateTime.TryParseExact(
                model.Start,
                DataConstants.EventCreatedOnFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.EventCreatedOnFormat}");
            }

            if (DateTime.TryParseExact(
                model.End,
                DataConstants.EventCreatedOnFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.EventCreatedOnFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetTypes();
                return View(model);
            }

            e.Start = start;
            e.End = end;
            e.Description = model.Description;
            e.Name = model.Name;
            e.TypeId = model.TypeId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Events
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.EventCreatedOnFormat),
                    End = e.End.ToString(DataConstants.EventCreatedOnFormat),
                    CreatedOn = e.CreatedOn.ToString(DataConstants.EventCreatedOnFormat),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;    
        }

        private async Task<IEnumerable<TypeViewModel>> GetTypes()
        {
            return await context.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
    }
}
