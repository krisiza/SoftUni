using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static readonly List<KeyValuePair<string, string>> s_messages = new();

        public IActionResult Show()
        {
            if (s_messages.Count == 0)
                return View();

            var chatModel = new ChatViewModel()
            {
                Messages = s_messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            s_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
