using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Customistaion : MonoBehaviour
{
    public Renderer characterRenderer; //The Rebderer used to render the character materials
    public List<Texture2D> skin = new List<Texture2D>(); //A Texture2D list for skin textures
    public List<Texture2D> eyes = new List<Texture2D>(); //A Texture2D list for eyes textures
    public List<Texture2D> mouth = new List<Texture2D>(); //A Texture2D list for mouth textures
    public List<Texture2D> hair = new List<Texture2D>(); //A Texture2D list for hair textures
    public List<Texture2D> clothes = new List<Texture2D>(); //A Texture2D list for clothes textures
    public List<Texture2D> armour = new List<Texture2D>(); //A Texture2D list for armour textures
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex; //Indexes used for selecting textures
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax; //The highest the index can go
    public int points = 15; //The points used to select 
    public string characterName = "Adventurer"; //The character name
    Texture[] textures; //An array of Textures
    int selectedIndex = 0; //The selectedIndex
    [System.Serializable]
    public struct Stats
    {
        public string statName; //Stat name
        public int statValue; //The stat value
        public int tempStat; //The temp stat
    };
    public Stats[] playerStats = new Stats[6]; //New Stats array
    public Text[] playerStatsDis; //Public text array for displaying stats
    public Text pointsDis; //Text for Displaying points
    public CharacterClass charClass; //CharacterClass Storing
    public Text disClass; //Text to display class
    public void SetSkin(int dir)
    {
        //Change the texture of the skin
        SetTexture("Skin", dir);
    }
    public void SetEyes(int dir)
    {
        //Change the texture of the eyes
        SetTexture("Eyes", dir);
    }
    public void SetMouth(int dir)
    {
        //Change the texture of the mouth
        SetTexture("Mouth", dir);
    }
    public void SetHair(int dir)
    {
        //Change the texture of the hair
        SetTexture("Hair", dir);
    }
    public void SetClothes(int dir)
    {
        //Change the texture of the clothes
        SetTexture("Clothes", dir);
    }
    public void SetArmour(int dir)
    {
        //Change the texture of the armour
        SetTexture("Armour", dir);
    }
    public void SetTexture(string type, int dir)
    {
        //Set the Index, Max and matIndex to 0
        int index = 0, max = 0, matIndex = 0;
        //Switch which switches based on type
        switch (type)
        {
            //If case is skin
            case "Skin":
                //Set the index to be Skin Index
                index = skinIndex;
                //Set the max to the skin Max
                max = skinMax;
                //Set the mat Index to 1
                matIndex = 1;
                textures = skin.ToArray();
                break;
            //If case is eyes
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                //Set the mat Index to 2
                matIndex = 2;
                textures = eyes.ToArray();
                break;
            //If case is mouth
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                //Set the mat Index to 3
                matIndex = 3;
                textures = mouth.ToArray();
                break;
            //If case is hair
            case "Hair":
                index = hairIndex;
                max = hairMax;
                //Set the mat Index to 4
                matIndex = 4;
                textures = hair.ToArray();
                break;
            //If case is clothes
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                //Set the mat Index to 5
                matIndex = 5;
                textures = clothes.ToArray();
                break;
            //If case is armour
            case "Armour":
                index = armourIndex;
                max = armourMax;
                //Set the mat Index to 6
                matIndex = 6;
                textures = armour.ToArray();
                break;
        }
        //Add dir to index
        index += dir;
        //If the index is less than zero
        if (index < 0)
        {
            //Set the index to max minus 1
            index = max - 1;
        }
        //if the index is greater than max minus 1
        if (index > max - 1)
        {
            //Set index to zero
            index = 0;
        }
        //Set the material array to be the the materials in characterRender
        Material[] mat = characterRenderer.materials;
        //Change the matIndex in the material arrays texture to the array textures at index
        mat[matIndex].mainTexture = textures[index];
        //Set the characterRenderers materials to mat
        characterRenderer.materials = mat;
        //Switch for the type of change
        switch (type)
        {
            //If case is skin
            case "Skin":
                //Set skinIndex to the index
                skinIndex = index;
                break;
            //If case is eyes
            case "Eyes":
                //Set the eyesIndex to the index
                eyesIndex = index;
                break;
            //If case is mouth
            case "Mouth":
                //Set the mouthIndex to the index
                mouthIndex = index;
                break;
            //IF case is hair
            case "Hair":
                //Set the hairIndex to the index
                hairIndex = index;
                break;
            //If case is clothes
            case "Clothes":
                //Set the clothesIndex to the index
                clothesIndex = index;
                break;
            //If case is armour
            case "Armour":
                //Set the armourIndex to the index
                armourIndex = index;
                break;
        }
    }

    //Randomize the texutres
    public void Randomize()
    {
        //Set the Skin texture to be somewhere between negative skinMax and skinMax
        SetTexture("Skin", Random.Range(-skinMax, skinMax));
        //Set the Eyes texture to be somewhere between negative eyesMax and eyesMax
        SetTexture("Eyes", Random.Range(-eyesMax, eyesMax));
        //Set the Mouth texture to be somewhere between negative mouthMax and mouthMax
        SetTexture("Mouth", Random.Range(-mouthMax, mouthMax));
        //Set the Hair texture to be somewhere between negative hairMax and hairMax
        SetTexture("Hair", Random.Range(-hairMax, hairMax));
        //Set the Clothes texture to be somewhere between negative clothesMax and clothesMax
        SetTexture("Clothes", Random.Range(-clothesMax, clothesMax));
        //Set the Armour texture to be somewhere between negative armourMax and armourMax
        SetTexture("Armour", Random.Range(-armourMax, armourMax));
    }

    //Reset the looks of the character
    public void ResetLooks()
    {
        //Set the texture of the skin back to the first in the list
        SetTexture("Skin", -skinIndex);
        //Set the texture of the Eyes back to the first in the list
        SetTexture("Eyes", -eyesIndex);
        //Set the texture of the mouth back to the first in the list
        SetTexture("Mouth", -mouthIndex);
        //Set the texture of the hair back to the first in the list
        SetTexture("Hair", -hairIndex);
        //Set the texture of the clothes back to the first in the list
        SetTexture("Clothes", -clothesIndex);
        //Set the texture of the armour back to the first in the list
        SetTexture("Armour", -armourIndex);
    }

    public void StatChangePos(int stat)
    {
        //If the points are greater than 0 and playerStats value plus the temp stat doesnt equal 20
        if (points > 0 && playerStats[stat].statValue + playerStats[stat].tempStat != 20)
        {
            //Remove 1 from points
            points--;
            //Add one to the temp stat
            playerStats[stat].tempStat++;
            //Set the display for the stat to display the statname with the combined tempstat and statvalue 
            playerStatsDis[stat].text = playerStats[stat].statName + ": " + (playerStats[stat].tempStat + playerStats[stat].statValue).ToString();
            //Changes the points display to display the points left
            pointsDis.text = "Points: " + points.ToString();
        }
    }
    public void StatChangeNeg(int stat)
    {
        //If the temp stat is greater than 0 or statValue plus tempstat is greater than or equal to 2
        if (playerStats[stat].tempStat > 0 || playerStats[stat].statValue + playerStats[stat].tempStat >= 2)
        {
            //Plus 1 point
            points++;
            //Remove one from the temp stat
            playerStats[stat].tempStat--;
            //Changes the display text to display the stat name plus the tempStat and statValue
            playerStatsDis[stat].text = playerStats[stat].statName + ": " + (playerStats[stat].tempStat + playerStats[stat].statValue).ToString();
            //Change the the point display to display the new ammount of points
            pointsDis.text = "Points: " + points.ToString();
        }
    }
    public void ChooseClass(int dirClass)
    {
        //Adds dirClass to selectedIndex
        selectedIndex += dirClass;
        //If the selectedIndex is less that 0
        if (selectedIndex < 0)
        {
            //Set the index to 11
            selectedIndex = 11;
        }
        //else if the Index is greater than 11
        else if (selectedIndex > 11)
        {
            //Set index to zero
            selectedIndex = 0;
        }
        //Switch basied on the selectedIndex
        switch (selectedIndex)
        {
            //If the case is 0
            case 0:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the charaterClass to barbarian
                charClass = CharacterClass.Barbarian;
                break;
            //If the case is 1
            case 1:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to bard
                charClass = CharacterClass.Bard;
                break;
            //If the case is 2
            case 2:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to cleric
                charClass = CharacterClass.Cleric;
                break;
            //If the case is 3
            case 3:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to druid
                charClass = CharacterClass.Druid;
                break;
            //If the case is 4
            case 4:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to fighter
                charClass = CharacterClass.Fighter;
                break;
            //If the case is 5
            case 5:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to monk
                charClass = CharacterClass.Monk;
                break;
            //If the case is 6
            case 6:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to paladin
                charClass = CharacterClass.Paladin;
                break;
            //If the case is 7
            case 7:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to ranger
                charClass = CharacterClass.Ranger;
                break;
            //If the case is 8
            case 8:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to rouge
                charClass = CharacterClass.Rouge;
                break;
            //If the case is 9
            case 9:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 15;
                //Change the character class to sorcerer
                charClass = CharacterClass.Sorcerer;
                break;
            //If the case is 10
            case 10:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to scorcerer
                charClass = CharacterClass.Warlock;
                break;
            //If the case is 11
            case 11:
                //Change the defult StatValue in array postion 0
                playerStats[0].statValue = 10;
                //Change the defult StatValue in array postion 1
                playerStats[1].statValue = 10;
                //Change the defult StatValue in array postion 2
                playerStats[2].statValue = 10;
                //Change the defult StatValue in array postion 3
                playerStats[3].statValue = 10;
                //Change the defult StatValue in array postion 4
                playerStats[4].statValue = 10;
                //Change the defult StatValue in array postion 5
                playerStats[5].statValue = 10;
                //Change the character class to wizard
                charClass = CharacterClass.Wizard;
                break;
        }
        //Change the display of the class to display the new character class
        disClass.text = "Class: " + charClass.ToString();
    }

    void Start()
    {
        //For all skin indexs 
        for (int i = 0; i < skinMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/Skin_ with the i int
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the skin list
            skin.Add(tempTexture);
        }
        //For all eye indexs
        for (int i = 0; i < eyesMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/eyes_ with the i int
            Texture2D tempTexture = Resources.Load("Character/eyes_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the eyes list
            eyes.Add(tempTexture);
        }
        //For all mouth indexs
        for (int i = 0; i < mouthMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/mouth_ with the i int
            Texture2D tempTexture = Resources.Load("Character/mouth_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the mouth list
            mouth.Add(tempTexture);
        }
        //For all hair indexs
        for (int i = 0; i < hairMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/hair_ with the i int
            Texture2D tempTexture = Resources.Load("Character/hair_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the hair list
            hair.Add(tempTexture);
        }
        //For all clothes indexs
        for (int i = 0; i < clothesMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/clothes_ with the i int
            Texture2D tempTexture = Resources.Load("Character/clothes_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the clothes list
            clothes.Add(tempTexture);
        }
        //For all armour indexs
        for (int i = 0; i < armourMax; i++)
        {
            //Change the tempTexture to load the resource from Charater/armour_ with the i int
            Texture2D tempTexture = Resources.Load("Character/armour_" + i.ToString()) as Texture2D;
            //Add the tempTexture to the armour list
            armour.Add(tempTexture);
        }
        //Set the skin texture
        SetTexture("Skin", 0);
        //Set the Eyes texture
        SetTexture("Eyes", 0);
        //Set the mouth texture
        SetTexture("Mouth", 0);
        //Set the hair texture
        SetTexture("Hair", 0);
        //Set the clothes texture
        SetTexture("Clothes", 0);
        //Set the armour texture
        SetTexture("Armour", 0);
    }
}

public enum CharacterClass //Public enum for holding all teh characterClass
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
