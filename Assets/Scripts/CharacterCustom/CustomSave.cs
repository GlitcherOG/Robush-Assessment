using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomSave : MonoBehaviour
{
    public InputField playerName;
    public PlayerHandler player;
    public Customistaion custom;
    public void Save()
    {
        player.saveSlot = PlayerData.saveSlot;
        for (int i = 0; i < custom.playerStats.Length; i++)
        {
            player.stats[i].name = custom.playerStats[i].statName;
            player.stats[i].value = custom.playerStats[i].statValue + custom.playerStats[i].tempStat;
        }
        player.characterName = playerName.text;
        player.skinIndex = custom.skinIndex;
        player.hairIndex = custom.hairIndex;
        player.eyesIndex = custom.eyesIndex;
        player.mouthIndex = custom.mouthIndex;
        player.clothesIndex = custom.clothesIndex;
        player.armourIndex = custom.armourIndex;
        player.characterClass = custom.charClass;
        PlayerBinary.SavePlayerData(player);
    }
}
