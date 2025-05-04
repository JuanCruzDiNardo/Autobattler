using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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
            Speed = 30;
            Agro = 30;
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();
            LoadCharacterImage();
        }

        protected override void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position)
        {            

            // 1. Si tiene menos de la mitad de vida, se cura
            if (Healt < MaxHealt / 2)
            {
                int healAmount = 5 + Level;
                Healt = Mathf.Min(MaxHealt, Healt + healAmount);
                Debug.Log($"El Paladín se cura {healAmount} puntos de vida.");
                return;
            }

            // 2. Si está en primera posición, ataca al primer enemigo
            if (position == 0)
            {
                Character target = enemyTeam.First(x => !x.State.Dead);
                int damage = Atack(); // ya incluye bonus de defensa
                target.TakeDamage(damage);
                Debug.Log($"El Paladín ataca al enemigo por {damage} de daño (ataque + defensa).");
            }
            // 3. Si está en otra posición, se mueve hacia adelante
            else
            {
                Move(ownTeam, position, true); // Mover hacia adelante                
            }
        }
        public override int Atack()
        {
            return Atk + Weapon.Atk + ((Def + Armor.Def) / 2);
        }
    }
}
