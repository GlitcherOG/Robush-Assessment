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
    public float curHealth, curMana, curStamina;
    public float maxHealth, maxMana, maxStamina;
 
    public PlayerStats[] stats;
    //[SerializeField] public Stats[] stats;
    public float heatRate;
    [Header("Value Variables")]    // Start is called before the first frame update
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
    public bool custom;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int saveSlot;
    //public CharacterClass characterClass;
    public string characterName;
    public string firstCheckPointName = "First CheckPoint";

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
                curStamina = Mathf.Clamp(curStamina, 0.0f, maxStamina);
                staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
            }
            if (curHealth <= 0 && !isDead)
            {
                Death();
            }
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.X))
            {
                damaged = true;
                curHealth -= 5;
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

        }
    }
    private void LateUpdate()
    {
        if(curHealth < maxHealth && curHealth > 0 && canHeal)
        {
            HealOverTime();
        }
    }
    void Death()
    {
        isDead = true;
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
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
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            curCheckPoint = other.transform;
            heatRate = 5;
            //saveAndLoad.Save();
        }
    }

    void DamagePlayer(float damage)
    {
        damaged = true;
        curHealth -= damage;
        canHeal = false;
        heatRate = 0;
    }

    public void HealOverTime()
    {
        curHealth += Time.deltaTime * (heatRate /*+ stats[2].statValue*/);
    }
}
