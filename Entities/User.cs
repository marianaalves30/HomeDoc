﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDoc.Entities
{
    public class User
    {

        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string pass { get; set; }

        public bool activated { get; set; }

        public string activationCod { get; set; }

        public string Exception { get; set; }

    }
}
