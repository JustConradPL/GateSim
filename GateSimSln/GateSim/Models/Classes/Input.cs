﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    /// <summary>
    /// Klasa mająca stanowić wejście bramki
    /// </summary>
    public class Input
    {
        private event Action<Input> inputChanged;

        private bool _input;

        public bool In
        {
            get { return _input; }
            set
            {
                _input = value;
                if (inputChanged != null) inputChanged(this);
            }
        }

        public void AddActionWhenInputChange(Action<Input> action)
        {
            inputChanged += action;
        }//---------------------------------------------
    }
}
