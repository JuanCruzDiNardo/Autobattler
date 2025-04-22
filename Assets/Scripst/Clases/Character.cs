using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripst.Clases
{
    public abstract class Character
    {
        public Class clase { get; set; }
        public int Level { get; set; }
        public int Healt { get; set; }
        public int MaxHealt { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Speed { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public States State { get; set; }

        public abstract void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position);

        public virtual int Atack()
        {
            return Atk + Weapon.Atk;
        }

        public virtual void TakeDamage(int dmg)
        {
            Healt -= (dmg - dmg * (Def + Armor.Def)/100);
            
            Death();
        }

        protected bool CanAct()
        {
            if (State.Stuned)
            {
                Debug.Log($"{clase} está aturdido y pierde el turno.");
                State.StunedTurns--;

                if (State.StunedTurns <= 0)
                {
                    State.Stuned = false;
                    Debug.Log($"{clase} ya no está aturdido.");
                }
                return false;
            }
            return true;
        }


        private void Death()
        {
            if(Healt <= 0) State.Dead = true;
        }
    }
}
