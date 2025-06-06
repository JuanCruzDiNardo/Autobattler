﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

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
            Speed = 70;
            Agro = 15;
            Weapon = new Weapon(clase);
            Armor = new Armor(clase);
            State = new States();
            LoadCharacterImage();
        }
        protected override void TakeAction(List<Character> ownTeam, List<Character> enemyTeam, int position)
        {            

            // Si está en las dos últimas posiciones puede curar o buffear
            if (position >= ownTeam.Count - 2)
            {
                // Buscar aliado más herido
                Character lowestHpAlly = ownTeam
                    .Where(c => !c.State.Dead && c.Healt < c.MaxHealt)
                    .OrderBy(c => (float)c.Healt / c.MaxHealt)
                    .FirstOrDefault();

                if (lowestHpAlly != null && ((float)lowestHpAlly.Healt / lowestHpAlly.MaxHealt) < 0.75f)
                {
                    int healAmount = (int)(MaxHealt * 0.2f) + Def;
                    lowestHpAlly.Healt = Mathf.Min(lowestHpAlly.MaxHealt, lowestHpAlly.Healt + healAmount);
                    GameManager.CharacterTarget = lowestHpAlly;
                    Debug.Log($"El Clérigo cura a {lowestHpAlly.clase} por {healAmount} puntos de vida.");
                    return;
                }

                // Nadie necesita curación -> buffea al aliado con más ataque
                Character highestAtkAlly = ownTeam
                    .Where(c => c != this && !c.State.Dead)
                    .OrderByDescending(c => c.Atk + c.Weapon.Atk)
                    .FirstOrDefault();

                if (highestAtkAlly != null)
                {
                    int buffAmount = Level * 5;
                    highestAtkAlly.TakeState(highestAtkAlly.State.AtkBuff,3,buffAmount);
                    GameManager.CharacterTarget = highestAtkAlly;
                    Debug.Log($"El Clérigo bendice a {highestAtkAlly.clase}, aumentando su ataque en {buffAmount}.");
                }

                return;
            }

            // Si no está en las últimas posiciones, intenta retroceder
            bool moved = Move(ownTeam, position, false); // intenta ir hacia atrás

            if (!moved)
            {
                // Si no puede moverse, ataca al primer enemigo por la mitad de su ataque
                Character target = enemyTeam.FirstOrDefault(c => !c.State.Dead);
                if (target != null)
                {
                    int damage = Atack() / 2;
                    target.TakeDamage(damage);
                    GameManager.CharacterTarget = target;
                    Debug.Log($"El Clérigo ataca al enemigo con un golpe débil por {damage} de daño.");
                }
            }
        }

    }
}
