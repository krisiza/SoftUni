using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private List<int> interfaceStandards;

        protected Robot(string _model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = _model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            int energy = minutes * ConvertionCapacityIndex;

            BatteryLevel += energy;

            if (BatteryLevel >= BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
                return;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType().Name} {Model}:");
            stringBuilder.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            stringBuilder.AppendLine($"--Current battery level: {BatteryLevel}");

            if (InterfaceStandards.Any())
                stringBuilder.AppendLine($"--Supplements installed: {string.Join(" ", InterfaceStandards)}");
            else
                stringBuilder.AppendLine("--Supplements installed: none");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
