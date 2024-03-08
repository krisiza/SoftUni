using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> boothRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
        }

        public IFormatProvider OutputMessags { get; private set; }

        public string AddBooth(int capacity)
        {
            int boothId = boothRepository.Models.Count + 1;

            Booth booth = new Booth(boothId, capacity);
            boothRepository.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var boothFound = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            var cocktailFound = boothFound.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktailFound != null)
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            else
            {
                if (cocktailTypeName == nameof(Hibernation))
                    boothFound.CocktailMenu.AddModel(new Hibernation(cocktailName, size));
                else
                    boothFound.CocktailMenu.AddModel(new MulledWine(cocktailName, size));

                return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            }
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            var boothFound = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            var delicacyFound = boothFound.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (delicacyFound != null)
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            else
            {
                if (delicacyTypeName == nameof(Gingerbread))
                    boothFound.DelicacyMenu.AddModel(new Gingerbread(delicacyName));
                else
                    boothFound.DelicacyMenu.AddModel(new Stolen(delicacyName));

                return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }
        }

        public string BoothReport(int boothId)
        {
            var boothFound = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);

            return boothFound.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var boothFound = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = boothFound.CurrentBill;
            boothFound.Charge();
            boothFound.ChangeStatus();

            return $"{String.Format(OutputMessages.GetBill, $"{currentBill:F2}")}{Environment.NewLine}{String.Format(OutputMessages.BoothIsAvailable, boothId)}";
        }

        public string ReserveBooth(int countOfPeople)
        {
            IEnumerable<IBooth> boothList = boothRepository.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderByDescending(b => b.BoothId);

            if (boothList.Any())
            {
                IBooth booth = boothList.First();
                booth.ChangeStatus();

                return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
            }
            else
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orders = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orders[0];
            string itemName = orders[1];
            int countOfTheOrderedPieces = int.Parse(orders[2]);

            if (itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            var boothFound = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            var delicacyFound = boothFound.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);
            var cocktailFound = boothFound.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName);

            if (delicacyFound == null && cocktailFound == null) 
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }


            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                string size = orders[3];

               cocktailFound = boothFound.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);

                if (cocktailFound == null) 
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                boothFound.UpdateCurrentBill(cocktailFound.Price * countOfTheOrderedPieces); 
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfTheOrderedPieces, itemName);
            }
            else
            {
                boothFound.UpdateCurrentBill(delicacyFound.Price * countOfTheOrderedPieces);
                return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfTheOrderedPieces, itemName);
            }

        }
    }
}
