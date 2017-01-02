using System.Collections.Generic;
using System.Collections.Immutable;

namespace ArenaDraftAssistant.Model
{
    public class ArenaPickOdds
    {
        public string Description { get; }

        public double CommonPickProbability { get; }

        public double RarePickProbability { get; }

        public double EpicPickProbability { get; }

        public double LegendaryPickProbability { get; }

        private ArenaPickOdds(string description, double commonPickProbability, double rarePickProbability,
            double epicPickProbability, double legendaryPickProbability)
        {
            Description = description;
            CommonPickProbability = commonPickProbability;
            RarePickProbability = rarePickProbability;
            EpicPickProbability = epicPickProbability;
            LegendaryPickProbability = legendaryPickProbability;
        }

        public static ArenaPickOdds Normal { get; } = new ArenaPickOdds("Common", 0.9087d, 0.0731d, 0.0146d, 0.0036d);
        public static ArenaPickOdds Special { get; } = new ArenaPickOdds("Special", 0d, 0.7975d, 0.1616d, 0.0485d);

        public static IList<ArenaPickOdds> AllArenaPickOdds { get; } = new List<ArenaPickOdds>
        {
            Normal,
            Special
        }.ToImmutableList();
    }
}