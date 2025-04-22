using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripst.Clases.PJs
{
    internal class Guerrero : Character
    {
        public Guerrero()
        {
            clase = Class.Guerrero;
            Level = 1;
            Healt = 18;
            MaxHealt = 18;
            Atk = 10;
            Def = 10;
            Speed = 7;
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
