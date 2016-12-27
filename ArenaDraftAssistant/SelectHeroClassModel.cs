using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class SelectHeroClassModel
    {
        public IList<HeroClass> AllHeroClasses { get; } = HeroClass.AllHeroClasses;

        public HeroClass SelectedHeroClass { get; set; }
    }
}
