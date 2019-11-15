using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public PlayerHandler player;
    public bool newGame;
    [System.Serializable]
    public struct LoadData
    {
        public string name;
        public bool blank;
        public int characterclass;
        public string checkpoint;
        public float health;
        public Text desName;
        public Text desCheckpoint;
        public Text desHealth;

    };
    public LoadData[] data;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        player.characterName = "Blank";
        player.curHealth = 100;
        player.curCheckPoint = this.transform;
        for (int i = 1; i < 4; i++)
        {
            PlayerData.saveSlot = i;
            PlayerBinary.LoadData();
            data[i].name = player.characterName;
            data[i].checkpoint = player.curCheckPoint.name;
            data[i].health = player.curHealth;
            player.characterName = "Blank";
            player.curHealth = 100;
            player.curCheckPoint = this.transform;
        }
        for (int i = 1; i < 4; i++)
        {
            if (data[i].checkpoint == "ScriptHolder")
            {
                data[i].blank = true;
                data[i].checkpoint = "Beach";
            }
            data[i].desName.text = data[i].name;
            data[i].desCheckpoint.text = data[i].checkpoint;
            data[i].desHealth.text = data[i].health.ToString();
        }
    }

    public void LoadGame(int slot)
    {
        PlayerData.saveSlot = slot;
        if (!data[slot].blank && !newGame)
        {
            PlayerPrefs.SetInt("Loaded", 0);
            GameManager.ChangeScene(2);
        }
        GameManager.ChangeScene(1);
    }

    public void NewGame(bool newSave)
    {
        newGame = newSave;
    }

}
