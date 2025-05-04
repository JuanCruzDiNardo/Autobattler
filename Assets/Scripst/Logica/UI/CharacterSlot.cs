using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripst.Clases;

public class CharacterSlot : MonoBehaviour
{
    private Character character;
    private UIManager uiManager;
    private Image characterImage;

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        characterImage = GetComponent<Image>();
    }

    public void LoadCharacter(Character c)
    {
        character = c;

        if (character != null)
        {
            // Asignar imagen del personaje, por ejemplo desde un diccionario o recurso
            characterImage.sprite = c.CharacterImage;
            characterImage.color = Color.white; // Asegura que sea visible
        }
        else
        {
            characterImage.sprite = null;
            characterImage.color = new Color(0, 0, 0, 0); // Ocultar si no hay personaje
        }
    }

    public void OnClick()
    {
        if (character != null)
        {
            uiManager.UpdateUI(character);
        }
    }
}
