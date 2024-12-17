using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Dice
{
    public class DiceService
    {
        private DiceSO diceSO;

        public DiceService(DiceSO diceSO)
        {
            this.diceSO = diceSO;
        }
    }
}
