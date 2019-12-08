using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomSave : MonoBehaviour
{
    public InputField playerName; //Used to refrence the inputfield
    public PlayerHandler player; //Used to access the PlayerHandler script
    public Customistaion custom; //Used to access the customisation script
    public void Save()
    {
        //Set the playerSlot on the player Handler to the saveSlot in the PlayerData
        player.saveSlot = PlayerData.saveSlot;
        //For all the custom playerStats
        for (int i = 0; i < custom.playerStats.Length; i++)
        {
            //Set the player's Stats name to the name in the custom statName
            player.stats[i].name = custom.playerStats[i].statName;
            //Set the player Stats value to be equal to the custom stats stat value plus the custom tempStat
            player.stats[i].value = custom.playerStats[i].statValue + custom.playerStats[i].tempStat;
        }
        //Change the Player's Character Name to be equal to the name on the inputField PlayerName
        player.characterName = playerName.text;
        //Set the skin index for the player to the value in the Customistaion scripts skinIndex
        player.skinIndex = custom.skinIndex;
        //Set the hair index for the player to the value in the Customistaion scripts hairIndex
        player.hairIndex = custom.hairIndex;
        //Set the eyes index for the player to the value in the Customistaion scripts eyesIndex
        player.eyesIndex = custom.eyesIndex;
        //Set the mouth index for the player to the value in the Customistaion scripts mouthIndex
        player.mouthIndex = custom.mouthIndex;
        //Set the clothes index for the player to the value in the Customistaion scripts clothesIndex
        player.clothesIndex = custom.clothesIndex;
        //Set the armour index for the player to the value in the Customistaion scripts armourIndex
        player.armourIndex = custom.armourIndex;
        //Set the characterClass for the player to the value in the Customistaion scripts characterClass
        player.characterClass = custom.charClass;
        //Set the maxHealth to equal 10 times the Constitution stat
        player.maxHealth = 10 * player.stats[2].value;
        //Set the maxMana to equal 10 times the Wisdom stat
        player.maxMana = 10 * player.stats[3].value;
        //Set the maxStamina to equal 10 times the Dexterity stat
        player.maxStamina = 10 * player.stats[1].value;
        //Access the PlayerBinary script and Save the player data
        PlayerBinary.SavePlayerData(player);
        //Change the scene to the main game
        GameManager.ChangeScene(2);
    }
}
