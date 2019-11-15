using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Normally General Game Settings like Sound
public class PlayerPrefsSave : MonoBehaviour
{
    public PlayerHandler player;
    float x, y, z;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            Load();
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binary Data
            Save();
        }
        else
        {
            //Load Binary shiz
            Load();
        }
    }
    void FirstLoad()
    {
        player.maxHealth = 100;
        player.maxMana = 100;
        player.maxStamina = 100;
        player.curCheckPoint = GameObject.Find("First CheckPoint").GetComponent<Transform>();

        player.curHealth = player.maxHealth;
        player.curMana = player.maxMana;
        player.curStamina = player.maxStamina;

        player.transform.position = new Vector3(124.5f, 2, 228.5f);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Save()
    {
        PlayerBinary.SavePlayerData(player);
    }

    public void Load()
    {
        PlayerData data = PlayerBinary.LoadData();
        //player.name = data.playerName;

        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW/*, data.rW*/);
        player.skinIndex = data.skinIndex;
        player.eyesIndex = data.eyesIndex;
        player.mouthIndex = data.mouthIndex;
        player.hairIndex = data.hairIndex;
        player.clothesIndex = data.clothesIndex;
        player.armourIndex = data.armourIndex;
    }
}
