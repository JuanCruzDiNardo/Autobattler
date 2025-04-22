using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    internal class States
    {
        public bool Dead { get; set; } = false;

        public bool Stuned { get; set; } = false;

        public int StunedTurns { get; set; } = 0;
    }
}
