using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripst.Clases;
using UnityEngine;

namespace Assets.Scripst.Clases
{
    public class Enemy : Character
    {
        public Enemy()
        {
            clase = Class.Monstruo;
            Level = 1;
            Healt = 30;
            MaxHealt = 30;
            Atk = 5;
            Def = 5;
            Speed = 40;
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();
        }

        protected override void TakeAction(List<Character> allies, List<Character> enemies, int position)
        {
            // Filtrar solo los enemigos vivos
            List<Character> validTargets = enemies.Where(c => !c.State.Dead).ToList();

            if (validTargets.Count == 0)
            {
                Debug.Log($"{clase} no tiene enemigos para atacar.");
                return;
            }

            // Elegir un objetivo aleatoriamente, ponderado por agro
            Character target = ChooseTargetByAgro(validTargets);

            if (target != null)
            {
                int damage = Atack();
                Debug.Log($"El {clase} ataca a {target.clase} con agro {target.Agro} por {damage} de daño.");

                target.TakeDamage(damage);

            }
        }

        private Character ChooseTargetByAgro(List<Character> targets)
        {
            int totalAgro = targets.Sum(t => t.Agro);
            int roll = UnityEngine.Random.Range(0, totalAgro);
            int cumulative = 0;

            foreach (var t in targets)
            {
                cumulative += t.Agro;
                if (roll < cumulative)
                    return t;
            }

            return targets[0]; // fallback (raro que llegue acá)
        }

    }
}
