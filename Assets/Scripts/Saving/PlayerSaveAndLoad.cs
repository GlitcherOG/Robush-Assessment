using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;

    private void Start()
    {
        //PlayerData.saveSlot = 1;
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
            Load();
        }
    }
    void FirstLoad()
    {
        player.maxHealth = 100;
        player.maxMana = 100;
        player.maxStamina = 100;
        player.curCheckPoint = GameObject.Find("Beach").GetComponent<Transform>();

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
        player.characterName = data.playerName;
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.GetComponent<CharacterController>().enabled = true;
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        player.skinIndex = data.skinIndex;
        player.eyesIndex = data.eyesIndex;
        player.mouthIndex = data.mouthIndex;
        player.hairIndex = data.hairIndex;
        player.clothesIndex = data.clothesIndex;
        player.armourIndex = data.armourIndex;

        for (int i = 0; i < data.stats.Length; i++)
        {
            player.stats[i].value = data.stats[i];
        }
    }
}
