using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
                return $"Robot type {typeName} cannot be created.";

            if (typeName == nameof(DomesticAssistant))
                robots.AddNew(new DomesticAssistant(model));
            else
                robots.AddNew(new IndustrialAssistant(model));

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
                return $"{typeName} is not compatible with our robots.";

            if (typeName == nameof(SpecializedArm))
                supplements.AddNew(new SpecializedArm());
            else
                supplements.AddNew(new LaserRadar());

            return $"{typeName} is created and added to the SupplementRepository.";

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsSupprotingInterfaceStandards = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();

            if (!robotsSupprotingInterfaceStandards.Any())
                return $"Unable to perform service, {intefaceStandard} not supported!";

            robotsSupprotingInterfaceStandards = robotsSupprotingInterfaceStandards
                                                    .OrderByDescending(r => r.BatteryLevel)
                                                    .ToList();

            int availablePower = robotsSupprotingInterfaceStandards.Sum(r => r.BatteryLevel);

            if (availablePower < totalPowerNeeded)
                return $"{serviceName} cannot be executed! {totalPowerNeeded - availablePower} more power needed.";

            int counterRobots = 0;

            foreach (var r in robotsSupprotingInterfaceStandards)
            {
                if (r.ExecuteService(totalPowerNeeded))
                {
                    counterRobots++;

                    return $"{serviceName} is performed successfully with {counterRobots} robots.";
                }
                else
                {
                    totalPowerNeeded -= r.BatteryLevel;
                    r.ExecuteService(r.BatteryLevel);
                    counterRobots++;
                }
            }

            return null;
        }

        public string Report()
        {
            List<IRobot> orderedList = robots.Models().OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity)
                .ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var robot in orderedList)
            {
                stringBuilder.AppendLine(robot.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotsToFeed = robots.Models().Where(r => r.Model == model).ToList();

            int fedCount = 0;
            foreach (var robot in robotsToFeed)
            {
                if (robot.BatteryLevel < robot.BatteryCapacity / 2)
                {
                    robot.Eating(minutes);
                    fedCount++;
                }
            }

            return $"Robots fed: {fedCount}";

        }


        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int standard = supplement.InterfaceStandard;

            List<IRobot> robotsNotSupportingInterfaceValue = robots.Models().Where(r => !r.InterfaceStandards.Contains(standard)).ToList();

            if (robotsNotSupportingInterfaceValue.Any())
            {
                robotsNotSupportingInterfaceValue = robotsNotSupportingInterfaceValue.Where(r => r.Model == model).ToList();
            }

            if (!robotsNotSupportingInterfaceValue.Any())
                return $"All {model} are already upgraded!";

            IRobot robotToUpGrade = robotsNotSupportingInterfaceValue.First();
            robotToUpGrade.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);
            return $"{model} is upgraded with {supplementTypeName}.";

        }
    }
}

