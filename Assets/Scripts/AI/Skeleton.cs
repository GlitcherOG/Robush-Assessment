using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Enemy
{
    [Space(5), Header("Skeleton Stats")]
    public float curStamina; //curent stamina
    public float maxStamina; //Maximun stamina

    //override the void attack as part of the script enemy
    public override void Attack()
    {
        //If player is within the distance of attackrange return
        if (Vector3.Distance(player.position, self.transform.position) > attackRange)
        {
            return;
        }
        //set state to attack
        state = AIState.Attack;
        //Set animation to attack
        anim.SetBool("Attack", true);
        //Set movement to current position
        agent.destination = self.transform.position;
    }

    public void SwordAttack()
    {
        //Random int for if the player has a critical roll
        int critChance = Random.Range(0, 21);
        //New float for critDamage
        float critDamage = 0;
        //If critChance is 20
        if (critChance == 20)
        {
            //CritDamage is to be between basedamage over 2 and baseDamage muliplyed by difficulty
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        //Damage the player by baseDamage by difficulty plus critDamage
        player.GetComponent<PlayerHandler>().DamagePlayer((baseDamage * difficulty) + critDamage);
    }
}
