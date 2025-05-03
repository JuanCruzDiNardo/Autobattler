using System.Collections.Generic;
using Assets.Scripst.Clases;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private List<Character> allyTeam;
    private List<Character> enemyTeam;
    private Queue<Character> turnQueue;

    public void LoadData(List<Character> allies, List<Character> enemies, Queue<Character> turnQueue)
    {
        this.allyTeam = allies;
        this.enemyTeam = enemies;
        this.turnQueue = turnQueue;
    }

    public void UpdateUI()
    {
        Debug.Log("=== Aliados ===");
        for (int i = 0; i < allyTeam.Count; i++)
        {
            Character c = allyTeam[i];
            Debug.Log($"[{i}] {c.clase} - HP: {c.Healt}/{c.MaxHealt} - Estado: {(c.State.Dead ? "Muerto" : "Vivo")}");
        }

        Debug.Log("=== Enemigos ===");
        for (int i = 0; i < enemyTeam.Count; i++)
        {
            Character c = enemyTeam[i];
            Debug.Log($"[{i}] {c.Name} - HP: {c.Healt}/{c.MaxHealt} - Estado: {(c.State.Dead ? "Muerto" : "Vivo")}");
        }

        Debug.Log("=== Orden de Turnos ===");
        foreach (Character c in turnQueue)
        {
            Debug.Log($"{c.Name} - Tiempo para actuar: {c.NextActionTime}");
        }
    }
}
