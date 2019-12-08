using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [System.Serializable]
    //A Strut for containing the Player Stats
    //E.g. Strength, Intelligence, Wisdom, Dexterity, Constitution, and Charisma
    public struct PlayerStats 
    {
        public string name;
        public int value;
    }

    [Header("Value Variables")]
    public float curHealth; //Public Float for the current health
    public float curMana, curStamina; //Public Float for the current Mana and Current Stamina
    public float maxHealth, maxMana, maxStamina; //Public Floats for the Maximum Health, Mana and Stamina
    public PlayerStats[] stats = new PlayerStats[6]; //Array for player stats that contains 6 stats
    public float healRate; //Public float for the healingRate of the player
    public bool staminaRegain; //Bool for if the player is going to Regain Stamina
    public float staminaTimer; //StaminaTimer to count down how long till stamina can be replenished
    [Header("Value Variable Objects")]
    public Slider healthBar, manaBar, staminaBar; //All the sliders for the health bar, Mana Bar, Stamina Bar
    public GameObject PlayerObject; //The gameObject for the player
    [Header("Damage Effect Variables")]
    public Image damageImage; //Image for the damage effect
    public GameObject deathImage; //GameObject for the deathImage
    public AudioManager audioManager; //Script used to handle the sounds
    public float flashSpeed = 5; //Flash speed for the damage effects
    public Color flashColour = new Color(1, 0, 0, 0.2f); //Flash colour for the damage effects
    public static bool isDead; //Bool for if the player is dead
    bool damaged; //Bool for if the player is damaged
    bool canHeal; //Bool for if the player canHeal
    float healTimer; //Heal timer for how long till the character can heal
    [Header("Check Point")]
    public Transform curCheckPoint; //The transform object for the checkpoint
    public string firstCheckPointName = "Beach"; //The string for the first checkpoints name
    [Header("Custom")]
    public string characterName; //String for the characters name
    public bool custom; //Bool for if the script is located outside of normal play
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex; //The indexs for skin, eyes, mouth, hair, clothes, armour
    public int saveSlot; //Int for the saveSlot
    public CharacterClass characterClass; //Players Character Class
    public Renderer character; //The Renderer for the character

    private void Start()
    {
        //If custom is false
        if (!custom)
        {
            //Run the void SetTexture
            SetTexture();
        }
    }
    void Update()
    {
        //If custom is false
        if (!custom)
        {
            //If the healthbar value doesnt equal the clamp between curHealth and maxHealth
            if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
            {
                //curHealht to equal
                curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
                healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            }
            if (manaBar.value != Mathf.Clamp01(curMana / maxMana))
            {
                curMana = Mathf.Clamp(curMana, 0, maxMana);
                manaBar.value = Mathf.Clamp01(curMana / maxMana);
            }
            if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
            {
                curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
                staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
            }
            //If the current health is less than or equal to 0 and is dead is false
            if (curHealth <= 0 && !isDead)
            {
                //Run death
                Death();
            }
            //If using the unity editor
#if UNITY_EDITOR
            //If input for key x is pushed
            if (Input.GetKeyDown(KeyCode.X))
            {
                //Damage the player by 5
                DamagePlayer(5);
            }
#endif
            //If damaged is true and isDead is false
            if (damaged && !isDead)
            {
                //Change the image color to the flash colour
                damageImage.color = flashColour;
                //Set damaged to false
                damaged = false;
            }
            else
            {
                //Change the image damaged color to the image colour going from clear to flash speed by deltatime
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            //If canHeal is false and curHealth is less than max health and curHealth Greater than zero
            if (!canHeal && curHealth < maxHealth && curHealth > 0)
            {
                //Healtimer plus deltaTime
                healTimer += Time.deltaTime;
                //If the healTimer is greater than 5
                if (healTimer >= 5)
                {
                    //Can heal to true
                    canHeal = true;
                }
            }
            //If stamina regain is true
            if (staminaRegain == true)
            {
                //If the timer is less than or equal to 3
                if(staminaTimer <= 3)
                {
                    //StaminaTimer plus time deltaTime
                    staminaTimer += Time.deltaTime;
                }
            }
            else
            {
                //StaminaTimer equals zero
                staminaTimer = 0;
            }
        }
    }

    private void LateUpdate()
    {
        //If current Health is less than max health and current health is greater than zero and can heal
        if (curHealth < maxHealth && curHealth > 0 && canHeal)
        {
            //Run Heal over time
            HealOverTime();
        }
        //If StaminaRegain is true and current stamina is less than max stamina and stamiantimer is greater than 3 
        if (staminaRegain && curStamina <= maxStamina && staminaTimer >= 3)
        {
            //Current Stamina plus deltaTime muliplied by three
            curStamina += Time.deltaTime * 3;
        }
    }
    void Death()
    {
        //isDead is true
        isDead = true;
        //Get the animator on deathImage and set the isDead
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        //Trigger sound death
        audioManager.Death();
        //Invoke Revive after 5 seconds
        Invoke("Revive", 5f);
    }
    void Revive()
    {
        //isDead is false
        isDead = false;
        //Current Health to equal max Health 
        curHealth = maxHealth;
        //Current Health to equal to max Mana
        curMana = maxMana;
        //current Mana to equal to max Stamina
        curStamina = maxStamina;
        //transform the position of the gameobject to the checkpoint position
        transform.position = curCheckPoint.position;
        //transform the roation to the rotation of the current checkpoint
        transform.rotation = curCheckPoint.rotation;
        //Set trigger revive on the animator death image 
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revive");
    }

    private void OnTriggerStay(Collider other)
    {
        //Compare the object other to see if it has tag Checkpoint
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            //Set the current checkpoint to the other transform
            curCheckPoint = other.transform;
            //Set the healRate to 10
            healRate = 10;
            //Save the Player data
            PlayerBinary.SavePlayerData(this);
        }
    }

    public void DamagePlayer(float damage)
    {
        //Damaged to true
        damaged = true;
        //Current Health to minus damage
        curHealth -= damage;
        //canhHeal to false
        canHeal = false;
        //healRate to equal zero
        healRate = 0;
        //healTimer to equal zero
        healTimer = 0;
    }

    public void HealOverTime()
    {
        //Current Health plus deltaTime 
        curHealth += Time.deltaTime * (healRate + stats[2].value);
    }

    private void SetTexture()
    {
        //New texture2D texture to equal null
        Texture2D texture = null;
        //New int MaterialIndex to equal zero
        int materialIndex = 0;
        //For all 5 cases
        for (int a = 0; a < 6; a++)
        {
            //Switch using a
            switch (a)
            {
                //If case is zero
                case 0:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Skin_" + skinIndex.ToString()) as Texture2D;
                    //Set the material index to one
                    materialIndex = 1;
                    break;
                //If case is one
                case 1:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Eyes_" + eyesIndex.ToString()) as Texture2D;
                    //Set the material index to two
                    materialIndex = 2;
                    break;
                //If case is two
                case 2:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Mouth_" + mouthIndex.ToString()) as Texture2D;
                    //Set the material index to three
                    materialIndex = 3;
                    break;
                //If case is three
                case 3:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Hair_" + hairIndex.ToString()) as Texture2D;
                    //Set the material index to four
                    materialIndex = 4;
                    break;
                //If case is four
                case 4:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Clothes_" + clothesIndex.ToString()) as Texture2D;
                    //Set the material index to five
                    materialIndex = 5;
                    break;
                //If case is five
                case 5:
                    //Load the texture from the resources 
                    texture = Resources.Load("Character/Armour_" + armourIndex.ToString()) as Texture2D;
                    //Set the material index to six
                    materialIndex = 6;
                    break;
            }
            //Get the material mats from character materials
            Material[] mats = character.materials;
            //Change the materials mainTexture to the new texture
            mats[materialIndex].mainTexture = texture;
        }
    }
}
