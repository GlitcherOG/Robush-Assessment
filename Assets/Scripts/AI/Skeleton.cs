using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : Enemy
{
    [Space(5), Header("Skeleton Stats")]
    public float curStanina;
    public float maxStamina;

    public override void Attack()
    {
        if (Vector3.Distance(player.position, self.transform.position) > attackRange)
        {
            return;
        }
        state = AIState.Attack;
        anim.SetBool("Attack", true);
        agent.destination = self.transform.position;
    }

    public void SwordAttack()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if(critChance==20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().DamagePlayer((baseDamage * difficulty) + critDamage);
    }
}
