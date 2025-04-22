using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    public class Armor
    {
        public Armor(Class clase)
        {
            name = "armadura";
            def = 5;
            lvl = 1;
            rarity = Rarity.Comon;
            this.clase = clase;
        }

        private string name;
        private int def;
        private int lvl;
        private Rarity rarity;
        private Class Clase;
        public Class clase
        {
            get { return Clase; }
            set { Clase = value; }
        }

        public Rarity Rareza
        {
            get { return rarity; }
            set { rarity = value; }
        }
        protected int Nivel
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public int Def
        {
            get { return def; }
            set { def = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
