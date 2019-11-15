using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerHandler>();

        if (!PlayerPrefs.HasKey("Loaded"))
        {
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
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
        player.name = data.playerName;
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        player.skinIndex = data.skinIndex;
        player.eyesIndex = data.eyesIndex;
        player.mouthIndex = data.mouthIndex;
        player.hairIndex = data.hairIndex;
        player.clothesIndex = data.clothesIndex;
        player.armourIndex = data.armourIndex;
    }
    /*public void Start()
    {
        if(PlayerPrefs.HasKey("Loaded"))
        {
            Load(GameObject.FindWithTag("Player").GetComponent<PlayerHandler>());
            PlayerPrefsSave.SetInt("Loaded", 0);
            Save();
        }
    }
    // Start is called before the first frame update
    public void Save(PlayerHandler player)
    {
        PlayerPrefs.SetFloat("CurHealth", player.curHealth);
        PlayerPrefs.SetFloat("CurMana", player.curMana);
        PlayerPrefs.SetFloat("CurStamina", player.curStamina);
        PlayerPrefs.SetFloat("LocationX", player.transform.localPosition.x);
        PlayerPrefs.SetFloat("LocationY", player.transform.localPosition.y);
        PlayerPrefs.SetFloat("LocationZ", player.transform.localPosition.z);
        PlayerPrefs.SetFloat("RotationX", player.transform.localRotation.x);
        PlayerPrefs.SetFloat("RotationY", player.transform.GetChild(0).localRotation.y);
        PlayerPrefs.SetFloat("RotationZ", player.transform.GetChild(0).localRotation.z);
        PlayerPrefs.SetFloat("RotationW", player.transform.GetChild(0).localRotation.w);
    }

    public void Load(PlayerHandler player)
    {
        player.curHealth = PlayerPrefs.GetFloat("CurHealth", player.maxHealth);
        player.curMana = PlayerPrefs.GetFloat("CurMana", player.maxMana);
        player.curStamina = PlayerPrefs.GetFloat("CurStamina", player.maxStamina);
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("LocationX", 3.82f), PlayerPrefs.GetFloat("LocationY", 1.18f), PlayerPrefs.GetFloat("LocationZ", 3.92f));
        player.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("RotationX", 0f), 0,0,0);
        player.transform.GetChild(0).rotation = new Quaternion(0, PlayerPrefs.GetFloat("RotationY", 0f), PlayerPrefs.GetFloat("RotationZ", 0f), PlayerPrefs.GetFloat("RotationW", 0f));
    }*/

}
