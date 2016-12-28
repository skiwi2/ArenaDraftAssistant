using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class ArenaDraftModel
    {
        public HeroClass SelectedHeroClass { get; }

        public ArenaDraftModel(HeroClass selectedHeroClass)
        {
            SelectedHeroClass = selectedHeroClass;
        }
    }
}
