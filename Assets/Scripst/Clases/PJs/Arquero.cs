using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
            Agro = 10;
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();
        }
        protected override void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position)
        {            

            Character target;

            if (position >= 2 && enemyTeam.Count > 0) // Tercera o cuarta posición
            {
                target = enemyTeam.Last(); // Ataca al enemigo más alejado
                int damage = Atack();
                Debug.Log($"El arquero dispara una flecha al último enemigo por {damage} de daño.");
                target.TakeDamage(damage);
            }
            else
            {
                bool moved = Move(ownTeam, position, false); // intenta ir hacia atrás

                if (!moved)
                {
                    target = enemyTeam.First(); // Ataca al más cercano
                    int damage = Atack() / 2; // Daño reducido                
                    target.TakeDamage(damage);
                    Debug.Log($"El arquero golpea al primer enemigo por {damage} de daño.");
                }
                    
            }
        }
    }
}
