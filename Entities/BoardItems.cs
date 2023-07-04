using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fifaWorldCup_app.Entities
{
    public class BoardItems
    {
        private int pj;
        private int pg;
        private int pp;
        private int pe;
        private int gf;
        private int gc;

        public int Pj { get => pj; set => pj = value; }
        public int Pg { get => pg; set => pg = value; }
        public int Pp { get => pp; set => pp = value; }
        public int Pe { get => pe; set => pe = value; }
        public int Gf { get => gf; set => gf = value; }
        public int Gc { get => gc; set => gc = value; }
    }
}