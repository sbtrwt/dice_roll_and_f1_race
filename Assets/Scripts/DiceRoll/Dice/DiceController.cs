﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Dice
{
    public class DiceController
    {
        private DiceView diceView;
        public DiceController(DiceView diceView)
        {
            diceView = UnityEngine.Object.Instantiate(diceView);
            diceView.Controller = this;
        }
    }
}
