using System.Collections.Generic;
using System.Linq;
using Assets.Scripst.Clases;
using Assets.Scripst.Clases.PJs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> allyTeam = new List<Character>();
    public List<Character> enemyTeam = new List<Character>();
    private List<Character> turnQueue = new List<Character>();

    private int CurrentTime = 100;
    private int Turn = 1;

    void Start()
    {
        InitializeTeams();
        InitializeTurnQueue();
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

    void InitializeTurnQueue()
    {
        turnQueue.Clear();
        foreach (var character in allyTeam.Concat(enemyTeam))
        {
            if (!character.State.Dead)
            {
                character.NextActionTime = Mathf.Max(10, CurrentTime - character.Speed);
                turnQueue.Add(character);
            }
        }

        SortQueue();
    }
    void UpdateQueueTimes(Character actedCharacter)
    {
        CurrentTime -= actedCharacter.NextActionTime;

        int interval = Mathf.Max(10, 100 - actedCharacter.Speed);

        foreach (var character in turnQueue)
        {
            character.NextActionTime -= actedCharacter.NextActionTime;
        }

        // Solo si el personaje sigue vivo, lo volvemos a agregar
        if (!actedCharacter.State.Dead)
        {
            actedCharacter.NextActionTime = interval;
            turnQueue.Add(actedCharacter);
        }

        // Si el tiempo global llegó a 0, reiniciar a 100
        if (CurrentTime <= 0)
        {
            Turn++;
            CurrentTime = 100;
            Debug.Log("¡Nuevo turno global!");
        }

        SortQueue();
    }

    void SortQueue()
    {
        turnQueue = turnQueue.OrderBy(c => c.NextActionTime).ToList();
        //ReorderTeam(turnQueue);
    }

    IEnumerator<WaitForSeconds> HandleTurns()
    {
        while (allyTeam.Any(c => !c.State.Dead) && enemyTeam.Any(c => !c.State.Dead))
        {
            if (turnQueue.Count == 0)
            {
                Debug.LogWarning("TurnQueue vacía.");
                yield break;
            }

            Character next = turnQueue.First();
            turnQueue.RemoveAt(0);

            //currentTime = next.NextActionTime;

            next.StartTurn(
                allyTeam.Contains(next) ? allyTeam : enemyTeam,
                allyTeam.Contains(next) ? enemyTeam : allyTeam,
                allyTeam.Contains(next) ? allyTeam.IndexOf(next) : enemyTeam.IndexOf(next)
            );

            UpdateQueueTimes(next);

            PrintTeamStatus();

            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Fin del combate");
    }

    public static void ReorderTeam(List<Character> team)
    {
        var vivos = team.Where(c => !c.State.Dead).ToList();
        var muertos = team.Where(c => c.State.Dead).ToList();
        team.Clear();
        team.AddRange(vivos);
        team.AddRange(muertos);
    }

    public void PrintTeamStatus()
    {
        Debug.Log($"=== Tiempo Restante del turno {Turn} es {CurrentTime} ===");
        Debug.Log("=== Estado de los Equipos ===");

        Debug.Log("--- Aliados ---");
        for (int i = 0; i < allyTeam.Count; i++)
        {
            Character c = allyTeam[i];
            Debug.Log($"Posición {i + 1}: {c.clase} - Vida: {c.Healt}/{c.MaxHealt} - Estado: {(c.State.Dead ? "Muerto" : "Vivo")} - Tiempo para actuar {c.NextActionTime}");
        }

        Debug.Log("--- Enemigos ---");
        for (int i = 0; i < enemyTeam.Count; i++)
        {
            Character c = enemyTeam[i];
            Debug.Log($"Posición {i + 1}: {c.clase} - Vida: {c.Healt}/{c.MaxHealt} - Estado: {(c.State.Dead ? "Muerto" : "Vivo")} - Tiempo para actuar {c.NextActionTime}");
        }

        Debug.Log("==========================================================");
    }
}

