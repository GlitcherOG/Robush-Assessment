using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Customistaion : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    public int points = 15;
    public string characterName = "Adventurer";
    Texture[] textures;
    int selectedIndex = 0;
    [System.Serializable]
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    };
    public Stats[] playerStats = new Stats[6];
    public Text[] playerStatsDis;
    public Text pointsDis;
    public CharacterClass charClass;
    public Vector2 scr;
    public Text disClass;
    public void SetSkin(int dir)
    {
        SetTexture("Skin", dir);
    }
    public void SetEyes(int dir)
    {
        SetTexture("Eyes", dir);
    }
    public void SetMouth(int dir)
    {
        SetTexture("Mouth", dir);
    }
    public void SetHair(int dir)
    {
        SetTexture("Hair", dir);
    }
    public void SetClothes(int dir)
    {
        SetTexture("Clothes", dir);
    }
    public void SetArmour(int dir)
    {
        SetTexture("Armour", dir);
    }
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                matIndex = 1;
                textures = skin.ToArray();
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                matIndex = 2;
                textures = eyes.ToArray();
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                matIndex = 3;
                textures = mouth.ToArray();
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                matIndex = 4;
                textures = hair.ToArray();
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                matIndex = 5;
                textures = clothes.ToArray();
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                matIndex = 6;
                textures = armour.ToArray();
                break;
        }
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }
    }
    public void Load()
    {
        Material[] mat = characterRenderer.materials;
        textures = skin.ToArray();
        mat[1].mainTexture = textures[skinIndex];
        textures = eyes.ToArray();
        mat[2].mainTexture = textures[eyesIndex];
        textures = mouth.ToArray();
        mat[3].mainTexture = textures[mouthIndex];
        textures = hair.ToArray();
        mat[4].mainTexture = textures[hairIndex];
        textures = clothes.ToArray();
        mat[5].mainTexture = textures[clothesIndex];
        textures = armour.ToArray();
        mat[6].mainTexture = textures[armourIndex];
        characterRenderer.materials = mat;
    }

    public void Randomize()
    {
        SetTexture("Skin", Random.Range(-skinMax, skinMax));
        SetTexture("Eyes", Random.Range(-eyesMax, eyesMax));
        SetTexture("Mouth", Random.Range(-mouthMax, mouthMax));
        SetTexture("Hair", Random.Range(-hairMax, hairMax));
        SetTexture("Clothes", Random.Range(-clothesMax, clothesMax));
        SetTexture("Armour", Random.Range(-armourMax, armourMax));
    }
    public void ResetLooks()
    {
        SetTexture("Skin", -skinIndex);
        SetTexture("Eyes", -eyesIndex);
        SetTexture("Mouth", -mouthIndex);
        SetTexture("Hair", -hairIndex);
        SetTexture("Clothes", -clothesIndex);
        SetTexture("Armour", -armourIndex);
    }

    public void StatChangePos(int stat)
    {
        if (points > 0)
        {
            points--;
            playerStats[stat].tempStat++;
            playerStatsDis[stat].text = playerStats[stat].statName + ":" + (playerStats[stat].tempStat + playerStats[stat].statValue).ToString();
            pointsDis.text = "Points: "+points.ToString();
}
    }
    public void StatChangeNeg(int stat)
    {
        if (playerStats[stat].tempStat > 0)
        {
            points++;
            playerStats[stat].tempStat--;
            playerStatsDis[stat].text = playerStats[stat].statName + ": " + (playerStats[stat].tempStat + playerStats[stat].statValue).ToString();
            pointsDis.text = "Points: " + points.ToString();
        }
    }
    public void ChooseClass(int dirClass)
    {
        selectedIndex += dirClass;
        if (selectedIndex < 0)
        {
            selectedIndex = 11;
        }
        else if (selectedIndex > 11)
        {
            selectedIndex = 0;
        }
        switch (selectedIndex)
        {
            case 0:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Cleric;
                break;
            case 3:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Druid;
                break;
            case 4:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Fighter;
                break;
            case 5:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Monk;
                break;
            case 6:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Paladin;
                break;
            case 7:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Ranger;
                break;
            case 8:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Rouge;
                break;
            case 9:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 15;
                charClass = CharacterClass.Sorcerer;
                break;
            case 10:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Warlock;
                break;
            case 11:
                playerStats[0].statValue = 10;
                playerStats[1].statValue = 10;
                playerStats[2].statValue = 10;
                playerStats[3].statValue = 10;
                playerStats[4].statValue = 10;
                playerStats[5].statValue = 10;
                charClass = CharacterClass.Wizard;
                break;
        }
        disClass.text = "Class: " + charClass.ToString();
    }
    //public int strength, dexterity, constitution, wisdom. intelligence, charisma;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/eyes_" + i.ToString()) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/mouth_" + i.ToString()) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/hair_" + i.ToString()) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/clothes_" + i.ToString()) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/armour_" + i.ToString()) as Texture2D;
            armour.Add(tempTexture);
        }
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
    }
}

public enum CharacterClass
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rouge,
    Sorcerer,
    Warlock,
    Wizard
}
