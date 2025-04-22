using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripst.Clases.PJs
{
    internal class Paladin : Character
    {
        public Paladin()
        {
            clase = Class.Paladin;
            Level = 1;
            Healt = 25;
            MaxHealt = 25;
            Atk = 7;
            Def = 12;
            Speed = 5;
            weapon = new Weapon(clase);
            armor = new Armor(clase);
            State = new States();
        }

        public override void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
