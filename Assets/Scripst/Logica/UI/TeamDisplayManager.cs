using Assets.Scripst.Clases;
using UnityEngine;

public class TeamDisplayManager : MonoBehaviour
{
    public bool isAllyTeam;
    public CharacterSlot[] characterSlots; // Arrastrás los 4 PositionX

    public void LoadTeam(Character[] team)
    {
        for (int i = 0; i < characterSlots.Length; i++)
        {
            if (i < team.Length)
                characterSlots[i].LoadCharacter(team[i], isAllyTeam);
            else
                characterSlots[i].LoadCharacter(null, false);
        }
    }
}
