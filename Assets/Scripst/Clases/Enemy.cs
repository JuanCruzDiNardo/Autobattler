using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripst.Clases;

namespace Assets.Scripst.Clases
{
    internal abstract class Enemy : Character
    {
        protected Enemy()
        {
            clase = Class.Monstruo;
            Level = 1;
            Healt = 30;
            MaxHealt = 30;
            Atk = 5;
            Def = 5;
            Speed = 6;
            weapon = new Weapon(clase);
            armor = new Armor(clase);
            State = new States();
        }
    }
}
