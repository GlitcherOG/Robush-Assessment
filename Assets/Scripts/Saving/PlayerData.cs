[System.Serializable]

public class PlayerData
{
    public string playerName; //String for playerName
    public string checkPoint; //String for the checkpoints name
    public float maxHealth, maxMana, maxStamina; //Floats for the max heath, mana and stamina
    public float curHealth, curMana, curStamina; //Floats for the current health, mana and stamina
    public float pX, pY, pZ; //floats for the x,y,z
    public float rX, rY, rZ, rW; //floats for the x,y,z,w roatation

    public static int saveSlot; //int for the save slot

    public int[] stats = new int[6]; //New int array for stats
    public int classIndex; //int for the classIndex
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex; //Ints for skin, eyes, mouth, hair, clothes and armour index
    public PlayerData(PlayerHandler player)
    {
        //Set the playername to the name located in the script
        playerName = player.characterName;
        //If the curCheckPoint doesn't equal null 
        if (player.curCheckPoint != null)
        {
            //Set the checkPoint to the checkpoint name located in the checkpoint name
            checkPoint = player.curCheckPoint.name;
            //Set the x value to the players x position
            pX = player.transform.position.x;
            //Set the y value to the players y position
            pY = player.transform.position.y;
            //Set the z value to the players z position
            pZ = player.transform.position.z;
            //Set the x rotational value to the players x rotational value
            rX = player.transform.rotation.x;
            //Set the y rotational value to the players y rotational value
            rY = player.transform.rotation.y;
            //Set the z rotational value to the players z rotational value
            rZ = player.transform.rotation.z;
            //Set the w rotational value to the players w rotational value
            rW = player.transform.rotation.w;
        }
        else
        {
            //set the checkpoint to be the firstcheckpointname on the player
            checkPoint = player.firstCheckPointName;
            //Set the x value to 342
            pX = 342;
            //Set the y value to 5
            pY = 5;
            //Set the z value to 170
            pZ = 170;
        }
        //Set the maxHealth to the players maxHealth
        maxHealth = player.maxHealth;
        //Set the maxMana to the players maxMana
        maxMana = player.maxMana;
        //Set the maxStamina to the players maxStamina
        maxStamina = player.maxStamina;
        //Set the curHealth to the players curHealth
        curHealth = player.curHealth;
        //Set the curMana to the players curMana
        curMana = player.curMana;
        //Set the curStamina to the players curStamina
        curStamina = player.curStamina;
        //for all the player stats
        for (int i = 0; i < player.stats.Length; i++)
        {
            //Set the stats from the player stats
            stats[i] = player.stats[i].value;
        }
        //Set the skin index to the players skin index
        skinIndex = player.skinIndex;
        //Set the hair index to the players hair index
        hairIndex = player.hairIndex;
        //Set the mouth index to the players mouth index
        mouthIndex = player.mouthIndex;
        //Set the eyes index to the players eyes index
        eyesIndex = player.eyesIndex;
        //Set the clothes index to the players clothes index
        clothesIndex = player.clothesIndex;
        //Set the armour index to the players armour index
        armourIndex = player.armourIndex;
        //Set the class index to the players class
        classIndex = (int)player.characterClass;
    }
}
