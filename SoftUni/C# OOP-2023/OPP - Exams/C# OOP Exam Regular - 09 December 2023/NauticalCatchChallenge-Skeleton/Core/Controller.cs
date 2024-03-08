using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishes;

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }
        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver foundDiver = divers.GetModel(diverName);
            IFish foundFish = fishes.GetModel(fishName);

            if (foundDiver == null)
            {
                return $"{divers.GetType().Name} has no {diverName} registered for the competition.";
            }

            if (foundFish == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            if (foundDiver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (foundDiver.OxygenLevel < foundFish.TimeToCatch)
            {
                foundDiver.Miss(foundFish.TimeToCatch);

                return $"{diverName} missed a good {fishName}.";
            }
            else if (foundDiver.OxygenLevel == foundFish.TimeToCatch)
            {
                if (isLucky)
                {
                    foundDiver.Hit(foundFish);

                    return $"{diverName} hits a {foundFish.Points}pt. {fishName}.";
                }
                else
                {
                    foundDiver.Miss(foundFish.TimeToCatch);

                    return $"{diverName} missed a good {fishName}.";
                }
            }
            else
            {
                foundDiver.Hit(foundFish);

                return $"{diverName} hits a {foundFish.Points}pt. {fishName}.";
            }
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in divers.Models.OrderByDescending(d => d.CompetitionPoints)
                                                .ThenByDescending(d => d.Catch.Count)
                                                .ThenBy(d => d.Name))
            {
                if(diver.HasHealthIssues == false)
                {
                    sb.AppendLine(diver.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if(diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver)) 
            {
                return $"{diverType} is not allowed in our competition.";
            }

            IDiver foundDiver = divers.GetModel(diverName);

            if(foundDiver != null) 
            {
                return $"{diverName} is already a participant -> {divers.GetType().Name}.";
            }

            if(diverType == nameof(ScubaDiver))
                divers.AddModel(new ScubaDiver(diverName));
            else
                divers.AddModel(new FreeDiver(diverName));

            return $"{diverName} is successfully registered for the competition -> {divers.GetType().Name}.";
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();

            IDiver diver = divers.GetModel(diverName);

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach(var fish in diver.Catch)
            {
                IFish fishFound = fishes.GetModel(fish);
                sb.AppendLine(fishFound.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            List<IDiver> diversWithHealthIssues = divers.Models.Where(d => d.HasHealthIssues == true).ToList();

            foreach(var diver in diversWithHealthIssues) 
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return $"Divers recovered: {diversWithHealthIssues.Count}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if(fishType != nameof(ReefFish) && fishType != nameof(DeepSeaFish) && fishType != nameof(PredatoryFish))
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            IFish foundFish = fishes.GetModel(fishName);

            if(foundFish != null) 
            {
                return $"{fishName} is already allowed -> {fishes.GetType().Name}.";
            }

            if(fishType == nameof(ReefFish))
                fishes.AddModel(new ReefFish(fishName, points));
            else if(fishType == nameof(DeepSeaFish))
                fishes.AddModel(new DeepSeaFish(fishName, points));
            else
                fishes.AddModel(new PredatoryFish(fishName, points));

            return $"{fishName} is allowed for chasing.";
        }
    }
}
