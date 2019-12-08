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
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int saveSlot; //
    public CharacterClass characterClass;
    public Renderer character;

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
        if (!custom)
        {
            if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
            {
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
            if (curHealth <= 0 && !isDead)
            {
                Death();
            }
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.X))
            {
                DamagePlayer(5);
            }
#endif
            if (damaged && !isDead)
            {
                damageImage.color = flashColour;
                damaged = false;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            if (!canHeal && curHealth < maxHealth && curHealth > 0)
            {
                healTimer += Time.deltaTime;
                if (healTimer >= 5)
                {
                    canHeal = true;
                }
            }
            if (staminaRegain == true)
            {
                if(staminaTimer <= 3)
                {
                    staminaTimer += Time.deltaTime;
                }
            }
            else
            {
                staminaTimer = 0;
            }
        }
    }

    private void LateUpdate()
    {
        if (curHealth < maxHealth && curHealth > 0 && canHeal)
        {
            HealOverTime();
        }

        if (staminaRegain && curStamina <= maxStamina && staminaTimer >= 3)
        {
            curStamina += Time.deltaTime * 3;
        }
    }
    void Death()
    {
        isDead = true;
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        audioManager.Death();
        Invoke("Revive", 5f);
    }
    void Revive()
    {
        isDead = false;
        curHealth = maxHealth;
        curMana = maxMana;
        curStamina = maxStamina;

        transform.position = curCheckPoint.position;
        transform.rotation = curCheckPoint.rotation;

        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revive");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            curCheckPoint = other.transform;
            healRate = 10;
            PlayerBinary.SavePlayerData(this);
        }
    }

    public void DamagePlayer(float damage)
    {
        damaged = true;
        curHealth -= damage;
        canHeal = false;
        healRate = 0;
        healTimer = 0;
    }

    public void HealOverTime()
    {
        //Current Health plus deltaTime 
        curHealth += Time.deltaTime * (healRate + stats[2].value);
    }

    private void SetTexture()
    {
        Texture2D texture = null;
        int materialIndex = 0;
        for (int a = 0; a < 6; a++)
        {
            switch (a)
            {
                case 0:
                    texture = Resources.Load("Character/Skin_" + skinIndex.ToString()) as Texture2D;
                    materialIndex = 1;
                    break;
                case 1:
                    texture = Resources.Load("Character/Eyes_" + eyesIndex.ToString()) as Texture2D;
                    materialIndex = 2;
                    break;
                case 2:
                    texture = Resources.Load("Character/Mouth_" + mouthIndex.ToString()) as Texture2D;
                    materialIndex = 3;
                    break;
                case 3:
                    texture = Resources.Load("Character/Hair_" + hairIndex.ToString()) as Texture2D;
                    materialIndex = 4;
                    break;
                case 4:
                    texture = Resources.Load("Character/Clothes_" + clothesIndex.ToString()) as Texture2D;
                    materialIndex = 5;
                    break;
                case 5:
                    texture = Resources.Load("Character/Armour_" + armourIndex.ToString()) as Texture2D;
                    materialIndex = 6;
                    break;
            }
            Material[] mats = character.materials;
            mats[materialIndex].mainTexture = texture;
        }
    }
}
