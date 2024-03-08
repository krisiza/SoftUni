using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;
        private IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot foundPilot = pilotRepository.FindByName(pilotName);

            if (foundPilot == null || foundPilot.Car != null)
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar foundCar = carRepository.FindByName(carModel);

            if (foundCar == null)
            {
                throw new NullReferenceException(
                    string.Format(
                        ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            foundPilot.AddCar(foundCar);
            carRepository.Remove(foundCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, foundCar.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace foundRace = raceRepository.FindByName(raceName);

            if (foundRace == null)
            {
                throw new NullReferenceException(
                    string.Format(
                        ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot foundPilot = pilotRepository.FindByName(pilotFullName);

            if (foundPilot == null || foundPilot.CanRace == false || foundRace.Pilots.Contains(foundPilot))
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            foundRace.AddPilot(foundPilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == nameof(Ferrari) || type == nameof(Williams))
            {
                IFormulaOneCar foundCar = carRepository.FindByName(model);

                if (foundCar != null)
                {
                    throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.CarExistErrorMessage, model));
                }

                if (type == nameof(Ferrari))
                    carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
                else
                    carRepository.Add(new Williams(model, horsepower, engineDisplacement));

                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
        }

        public string CreatePilot(string fullName)
        {
            IPilot foundPilot = pilotRepository.FindByName(fullName);
            if (foundPilot != null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace foundRace = raceRepository.FindByName(raceName);

            if (foundRace != null)
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            List<IPilot> orderedPilot = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var pilot in orderedPilot) 
            {
                stringBuilder.AppendLine(pilot.ToString());
            }

            return stringBuilder.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in raceRepository.Models)
            {
                if (race.TookPlace)
                {
                    sb.AppendLine(race.RaceInfo());
                }
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace foundRace = raceRepository.FindByName(raceName);

            if (foundRace == null)
            {
                throw new NullReferenceException(
                   string.Format(
                       ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (foundRace.Pilots.Count < 3)
            {
                throw new InvalidOperationException(
                   string.Format(
                       ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (foundRace.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilots = foundRace.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(foundRace.NumberOfLaps)).ToList();

            foundRace.TookPlace = true;
            IPilot winner = pilots.First();
            winner.WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race");
            sb.AppendLine($"Pilot {pilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
