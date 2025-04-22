using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    internal class Weapon
    {
        public Weapon(Class clase)
        {
            name = "arma";
            atk = 5;
            lvl = 1;
            rarity = Rarity.Comon;
            this.clase = clase;
        }

        private string name;
        private int atk;        
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
        public int Atk
        {
            get { return atk; }
            set { atk = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
