using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripst.Clases;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas Battle;
    public Canvas UI;
    public Canvas Background;

    private Dictionary<string, TextMeshProUGUI> allyTexts = new Dictionary<string, TextMeshProUGUI>();
    private Dictionary<string, TextMeshProUGUI> enemyTexts = new Dictionary<string, TextMeshProUGUI>();

    public Transform allyPanel;
    public Transform enemyPanel;

    private List<Character> allyTeam;
    private List<Character> enemyTeam;
    private List<Character> turnQueue;

    public TeamDisplayManager allyDisplayManager;
    public TeamDisplayManager enemyDisplayManager;

    public void LoadData(List<Character> allies, List<Character> enemies, List<Character> turnQueue)
    {
        this.allyTeam = allies;
        this.enemyTeam = enemies;
        this.turnQueue = turnQueue;

        allyDisplayManager.LoadTeam(allyTeam.ToArray());
        enemyDisplayManager.LoadTeam(enemyTeam.ToArray());

        LoadTextFields(allyPanel, allyTexts);
        LoadTextFields(enemyPanel, enemyTexts);
    }

    void LoadTextFields(Transform panel, Dictionary<string, TextMeshProUGUI> dict)
    {
        foreach (TextMeshProUGUI text in panel.GetComponentsInChildren<TextMeshProUGUI>())
        {
            dict[text.gameObject.name.ToLower()] = text;
        }
    }

    public void UpdateUI(Character current)
    {               

        allyTexts["clase"].text = current.clase.ToString();
        allyTexts["hp"].text = $"HP: {current.Healt}/{current.MaxHealt}";
        allyTexts["ataque"].text = $"ATK: {current.Atk}";
        allyTexts["defensa"].text = $"DEF: {current.Def}";
        allyTexts["speed"].text = $"SPD: {current.Speed}";
    }

}
