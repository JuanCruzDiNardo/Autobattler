using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripst.Clases.PJs
{
    internal class Arquero : Character
    {
        public Arquero()
        {
            clase = Class.Arquero;
            Level = 1;
            Healt = 12;
            MaxHealt = 12;
            Atk = 12;
            Def = 6;
            Speed = 10;
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
