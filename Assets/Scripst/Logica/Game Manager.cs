using System.Collections.Generic;
using System.Linq;
using Assets.Scripst.Clases;
using Assets.Scripst.Clases.PJs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> allyTeam = new List<Character>();
    public List<Character> enemyTeam = new List<Character>();
    private Queue<Character> turnQueue = new Queue<Character>();

    void Start()
    {
        InitializeTeams();
        SortTurnOrder();
        StartCoroutine(HandleTurns());
    }

    void InitializeTeams()
    {
        // Aquí instanciás y configurás tus personajes, por ejemplo:
        
        allyTeam.Add(new Paladin());
        allyTeam.Add(new Guerrero());
        allyTeam.Add(new Arquero());
        allyTeam.Add(new Clerigo());

        for (int i = 0; i < 4; i++)
            enemyTeam.Add(new Enemy());
    }

    void SortTurnOrder()
    {
        List<Character> allCharacters = allyTeam.Concat(enemyTeam).ToList();
        allCharacters = allCharacters.OrderByDescending(c => c.Speed).ToList();

        turnQueue.Clear();
        foreach (var character in allCharacters)
        {
            if (character.Healt > 0) // Asegurarse de que estén vivos
                turnQueue.Enqueue(character);
        }
    }

    IEnumerator<WaitForSeconds> HandleTurns()
    {
        while (allyTeam.Any(c => c.State.Dead == false) && enemyTeam.Any(c => c.State.Dead == false))
        {
            if (turnQueue.Count == 0)
            {
                SortTurnOrder();
            }

            Character current = turnQueue.Dequeue();

            if (current.State.Dead == false)
            {
                current.TakeAction(
                    allyTeam.Contains(current) ? allyTeam : enemyTeam,
                    allyTeam.Contains(current) ? enemyTeam : allyTeam,
                    allyTeam.Contains(current) ? allyTeam.IndexOf(current) : enemyTeam.IndexOf(current)
                );
                // Acción personalizada según el personaje
            }

            yield return new WaitForSeconds(1f); // Delay entre turnos
        }

        Debug.Log("Fin del combate");
    }
}

