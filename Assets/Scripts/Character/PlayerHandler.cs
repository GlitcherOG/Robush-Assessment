using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerStats
    {
        public string name;
        public int value;
    }

    [Header("Value Variables")]
    public float curHealth;
    public float curMana, curStamina;
    public float maxHealth, maxMana, maxStamina;
    public PlayerStats[] stats = new PlayerStats[6];
    public float healRate;
    public bool staminaRegain;
    public float staminaTimer;
    [Header("Value Variable Objects")]    // Start is called before the first frame update
    public Slider healthBar, manaBar, staminaBar;
    public GameObject PlayerObject;
    [Header("Damage Effect Variables")]
    public Image damageImage;
    public Image deathImage;
    public float flashSpeed = 5;
    public Color flashColour = new Color(1, 0, 0, 0.2f);
    public static bool isDead;
    bool damaged;
    bool canHeal;
    float healTimer;
    [Header("Check Point")]
    public Transform curCheckPoint;
    [Header("Custom")]
    public string characterName;
    public bool custom;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int saveSlot;
    public CharacterClass characterClass;
    public string firstCheckPointName = "Beach";
    public Renderer character;

    private void Start()
    {
        if (!custom)
        {
            SetTexture();
        }
    }
    void Update()
    {
        if (!custom)
        {
            //Display Health
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
        //deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        Invoke("Revive", 3f);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            curCheckPoint = other.transform;
            healRate = 5;
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
