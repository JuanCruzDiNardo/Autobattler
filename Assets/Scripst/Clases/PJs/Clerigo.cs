using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripst.Clases.PJs
{
    internal class Clerigo : Character
    {
        public Clerigo()
        {
            clase = Class.Clerigo;
            Level = 1;
            Healt = 15;
            MaxHealt = 15;
            Atk = 4;
            Def = 12;
            Speed = 5;
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
