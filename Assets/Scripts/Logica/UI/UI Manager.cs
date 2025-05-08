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

    public List<TextMeshProUGUI> TurnList = new List<TextMeshProUGUI>();

    private Dictionary<string, TextMeshProUGUI> allyTexts = new Dictionary<string, TextMeshProUGUI>();
    private Dictionary<string, TextMeshProUGUI> enemyTexts = new Dictionary<string, TextMeshProUGUI>();

    public Transform allyPanel;
    public Transform enemyPanel;

    public TeamDisplayManager allyDisplayManager;
    public TeamDisplayManager enemyDisplayManager;

    public void LoadData()
    {        

        allyDisplayManager.LoadTeam(GameManager.allyTeam.ToArray());
        enemyDisplayManager.LoadTeam(GameManager.enemyTeam.ToArray());

        LoadTextFields(allyPanel, allyTexts);
        LoadTextFields(enemyPanel, enemyTexts);

        LoadTurnUI();
    }

    public void LoadTurnUI()
    {
        for (int i = 0; i < GameManager.turnQueue.Count; i++)
        {
            TurnList.ElementAt(i).text = GameManager.turnQueue.ElementAt(i).clase.ToString();
        }
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
        //Character in turn
        allyTexts["clase"].text = current.clase.ToString();
        allyTexts["hp"].text = $"HP: {current.Healt}/{current.MaxHealt}";
        allyTexts["ataque"].text = $"ATK: {current.Atk}";
        allyTexts["defensa"].text = $"DEF: {current.Def}";
        allyTexts["speed"].text = $"SPD: {current.Speed}";
    }

}
