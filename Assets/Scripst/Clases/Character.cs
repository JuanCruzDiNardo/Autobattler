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
        public int Agro { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public States State { get; set; }        

        protected abstract void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position);

        public virtual void StartTurn(List<Character> allyTeam, List<Character> enemyTeam, int position)
        {
            // Actualiza todos los estados
            State.Tick();

            // Si está envenenado, aplica el daño
            if (State.Poison.Active)
            {
                TakeTrueDamage(State.Poison.DamagePerTurn);
                Debug.Log($"{clase} sufre {State.Poison.DamagePerTurn} de daño por veneno.");
            }

            if (!this.State.Dead && this.CanAct())
            {
                this.TakeAction(allyTeam, enemyTeam, position);
                // Acción personalizada según el personaje
            }
        }

        public void TakeState(StatusEffect effect, int turns)
        {
            int roll = UnityEngine.Random.Range(0, 100);

            if(effect.Resistence < roll)
            {
                effect.Active = true;
                effect.Duration = turns;
                if(effect is BuffEffect)
                    Debug.Log($"{clase} Gana el efecto {effect.Name} durante {turns} turnos.");                
                else                
                    Debug.Log($"{clase} Sufre el efecto {effect.Name} durante {turns} turnos.");
            }
            else
                Debug.Log($"{clase} Resiste el efecto {effect.Name}");
        }

        public virtual int Atack()
        {
            return Atk + Weapon.Atk + (State.AtkBuff.Active ? State.AtkBuff.Value : 0);
        }

        public virtual void TakeDamage(int dmg)
        {
            Healt -= (dmg - dmg * (Def + Armor.Def + (State.DefBuff.Active? State.DefBuff.Value : 0))/100);
            
            Death();
        }

        public virtual void TakeTrueDamage(int dmg)
        {
            Healt -= dmg;

            Death();
        }

        protected bool CanAct()
        {
            if (State.Stun.Active)
            {
                Debug.Log($"{clase} está aturdido y pierde el turno.");                               
                return false;
            }
            return true;
        }

        public bool Move(List<Character> team, int thisIndex, bool forward)
        {
            int targetIndex = thisIndex + (forward? -1: 1);//-1 mueve hacia adelante y +1 hacia atras

            if (targetIndex < 0 || targetIndex >= team.Count)
                return false;

            if (team[targetIndex].State.Dead)
                return false;

            Character temp = team[targetIndex];
            team[targetIndex] = this;
            team[thisIndex] = temp;

            Debug.Log($"{clase} cambia posición con {temp.clase}.");
            return true;
        }

        private void Death()
        {
            if(Healt <= 0)
            {
                State.Dead = true;
                Healt = 0;
                Debug.Log($"{clase} ah muerto.");
            }
            
        }
    }
}
