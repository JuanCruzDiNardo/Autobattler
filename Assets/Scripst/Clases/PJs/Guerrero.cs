using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
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
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();

        }

        public override void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position)
        {
            if (!CanAct()) return;

            if (position <= 1)
            {
                int count = Mathf.Min(2, enemyTeam.Count);
                for (int i = 0; i < count; i++)
                {
                    Character target = enemyTeam[i];
                    int damage = Atack();
                    target.TakeDamage(damage);
                    target.State.Stuned = true;
                    target.State.StunedTurns = 1;
                    Debug.Log($"El Guerrero golpea a {target.clase} por {damage} de daño y lo aturde por 1 turno.");
                }
            }
            else // Posición 2 o 3 => moverse hacia adelante
            {
                Move(ownTeam, position, true); // Mover hacia adelante
            }
        }
    }
}
