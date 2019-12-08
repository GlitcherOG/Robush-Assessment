using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player; //refencing the playerHander

    private void Start()
    {
        //If the Key Loaded doesnt exist
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            //Delete all the PlayerPrefs
            PlayerPrefs.DeleteAll();
            //Run FirstLoad void
            FirstLoad();
            //Create the Key Loaded
            PlayerPrefs.SetInt("Loaded", 0);
            //Run Save load
            Save();
        }
        else
        {
            //Load the game
            Load();
        }
    }
    //First load
    void FirstLoad()
    {
        //Set the players maxHealth
        player.maxHealth = 100;
        //Set the players maxMana to 100
        player.maxMana = 100;
        //Set the players maxStamina
        player.maxStamina = 100;
        //Set the players current checkpoint to beach
        player.curCheckPoint = GameObject.Find("Beach").GetComponent<Transform>();
        //Set the players current health to the max health
        player.curHealth = player.maxHealth;
        //Set the players current mana to the maxMana 
        player.curMana = player.maxMana;
        //Set the players current stamina to the players max stamina
        player.curStamina = player.maxStamina;
        //Set the players current postion to the stating position
        player.transform.position = new Vector3(124.5f, 2, 228.5f);
        //Set the rotation to default
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Save()
    {
        //Saves the Player data using the script binary data
        PlayerBinary.SavePlayerData(player);
    }

    public void Load()
    {
        //Load data into a new PlayerData
        PlayerData data = PlayerBinary.LoadData();
        //Set the player character name to the name in player data
        player.characterName = data.playerName;
        //Set the max health to the max health in data
        player.maxHealth = data.maxHealth;
        //Set the max mana to the max mana in data
        player.maxMana = data.maxMana;
        //Set the max stamina to the max stamina in data
        player.maxStamina = data.maxStamina;
        //Set the current health to the current healh in data
        player.curHealth = data.curHealth;
        //Set the current mana to the current mana in data
        player.curMana = data.curMana;
        //Set the current stamina ot the currrent stamina in data
        player.curStamina = data.curStamina;
        //Set the character controller to false
        player.GetComponent<CharacterController>().enabled = false;
        //Change the position of the player using the values in data
        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        //Set the character controller to true
        player.GetComponent<CharacterController>().enabled = true;
        //Set the roation of the player to the values in data
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        //Set the skin index to the index in data
        player.skinIndex = data.skinIndex;
        //Set the eye index to the index in data
        player.eyesIndex = data.eyesIndex;
        //Set the mouth index to the index in data
        player.mouthIndex = data.mouthIndex;
        //Set the hair index to the index in data
        player.hairIndex = data.hairIndex;
        //Set the clothes index to the index in data
        player.clothesIndex = data.clothesIndex;
        //Set the armour index to the index in data
        player.armourIndex = data.armourIndex;
        //for all stats
        for (int i = 0; i < data.stats.Length; i++)
        {
            //Set the stat value to the value in data
            player.stats[i].value = data.stats[i];
        }
    }
}
