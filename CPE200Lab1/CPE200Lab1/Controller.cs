﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{

    class Controller
    {
        Model model = new Model();
        public string Process(string str)
        {
            return model.Process(str);
        }
    }
}
