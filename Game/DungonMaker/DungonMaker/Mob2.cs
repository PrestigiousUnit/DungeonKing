﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Mob2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int MaximumDamage { get; set; }

        public Mob2(int id, string name, int maximumDamage, int currentHitPoints, int maximumHitPoints) 
        {
            ID = id;
            Name = name;
            MaximumDamage = maximumDamage;
        }
    }
}
