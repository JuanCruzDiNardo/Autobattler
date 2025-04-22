using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripst.Clases;

namespace Assets.Scripst.Clases
{
    public class Enemy : Character
    {
        public Enemy()
        {
            clase = Class.Monstruo;
            Level = 1;
            Healt = 30;
            MaxHealt = 30;
            Atk = 5;
            Def = 5;
            Speed = 6;
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();
        }

        public override void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
