using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public bool newGame; //used to check if its a new game
    [System.Serializable]
    public struct LoadData //Strut used for save file data
    {
        public string name; //players name 
        public bool blank; //If the file is blank
        public int characterclass; //Whats the characterclass
        public string checkpoint; //Checkpoint name
        public float health; //Health of the character
        public Text desName; //Text used to display the name
        public Text desCheckpoint; //Text used to display the checkpoint
        public Text desHealth; //Text used to display the ammount of health
    };
    public LoadData[] data; //stuct LoadData data
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll(); //Delete All PlayerPrefs
        //For 3 save slots
        for (int i = 1; i < 4; i++)
        {
            //Set the PlayerData saveslot int to i
            PlayerData.saveSlot = i;
            //Set the datas blank state to true
            data[i].blank = true;
            //Load the player data into the variable player
            PlayerData player = PlayerBinary.LoadData();
            //If player doesnt equal null
            if (player != null)
            {
                //Set blank to false
                data[i].blank = false;
                //Set the name to the players name on the save file
                data[i].name = player.playerName;
                //Change the checkpoint to the checkpoint on the save file
                data[i].checkpoint = player.checkPoint;
                //Change the health to the health on the player save file
                data[i].health = player.curHealth;
            }
            else
            {
                //Set blank to true
                data[i].blank = true;
                //Change the name to blank
                data[i].name = "Blank";
                //Change the checkpoint to be beach
                data[i].checkpoint = "Beach";
                //Change the health to be 100
                data[i].health = 100f;
            }
            //Change the display name to be the name in data
            data[i].desName.text = data[i].name;
            //Change the display checkpoint to be the checkpoint in data
            data[i].desCheckpoint.text = data[i].checkpoint;
            //Change the display health to the health in data
            data[i].desHealth.text = data[i].health.ToString();
        }
    }

    //Used to Load a game
    public void LoadGame(int slot)
    {
        //Change the playerData save slot to the int slot
        PlayerData.saveSlot = slot;
        //If the blank slot is false and new game is false
        if (!data[slot].blank && !newGame)
        {
            //
            PlayerPrefs.SetInt("Loaded", 0);
            //Change the Scene to the index 2
            GameManager.ChangeScene(2);
        }
        //Change the Scene to index 1
        GameManager.ChangeScene(1);
    }

    public void NewGame(bool newSave)
    {
        //Change the new game bool to the state of newSave
        newGame = newSave;
    }

}
