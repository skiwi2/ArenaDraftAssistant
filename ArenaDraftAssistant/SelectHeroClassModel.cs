using System.Collections.Generic;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class SelectHeroClassModel
    {
        public IList<HeroClass> AllHeroClasses { get; } = HeroClass.AllHeroClasses;
    }
}
