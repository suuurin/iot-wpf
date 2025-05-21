﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMqttSubApp.Models
{
    internal class SensingInfo
    {
        public int L { get; set; }

        public int R{  get; set; }
        public float T{  get; set; }
        public float H{ get; set; }

        public string F { get; set; }
        public string V{ get; set; }
        public string RL{  get; set; }
        public string CB { get; set; }
    }
}
