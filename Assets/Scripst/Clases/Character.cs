using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripst.Clases
{
    internal abstract class Character
    {
        public Class clase { get; set; }
        public int Level { get; set; }
        public int Healt { get; set; }
        public int MaxHealt { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Speed { get; set; }
        public Weapon weapon { get; set; }
        public Armor armor { get; set; }
        public States State { get; set; }

        public abstract void TakeAction();

        public virtual int Atack()
        {
            return Atk + weapon.Atk;
        }

        public virtual bool TakeDamage(int dmg)
        {
            Healt -= (dmg - dmg * (Def + armor.Def));
            
            return Death();
        }

        private bool Death()
        {
            return Healt <= 0? true: false;
        }
    }
}
