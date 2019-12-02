using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum AIState
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    [Header("BaseStats")]
    public AIState state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange;
    public float difficulty = 1;
    public float baseDamage = 1;
    public bool isDead;
    [Space(5)]
    [Header("Base References")]
    public GameObject self;
    public Transform player;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public int curWaypoint;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Slider healthBar;
    public Animator anim;

    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = moveSpeed;
        anim = self.GetComponent<Animator>();
        Patrol();
    }

    private void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        Patrol();
        Seek();
        Attack();
        Die();
    }
    public void Patrol()
    {
        //If there are no way points stop
        if(waypoints.Length == 0 || sightRange > Vector3.Distance(player.position, self.transform.position))
        {
            return;
        }
        state = AIState.Patrol;
        agent.speed = moveSpeed;
        anim.SetBool("Walk", true);
        //Follow waypoints
        agent.destination = waypoints[curWaypoint].position;
        if(self.transform.position.x.Equals(agent.destination.x) && self.transform.position.z == agent.destination.z)
        {
            if(curWaypoint < waypoints.Length-1)
            {
                curWaypoint++;
            }
            else
            {
                curWaypoint = 0;
            }
        }
    }

    public void Seek()
    {
        if(Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange)
        {
            return;
        }
        state = AIState.Seek;
        agent.speed = attackSpeed;
        anim.SetBool("Run", true);
        agent.destination = player.position;
    }

    public virtual void Attack()
    {
        if(Vector3.Distance(player.position, self.transform.position) > attackRange)
        {
            return;
        }
        state = AIState.Attack;
        anim.SetBool("Attack", true);
        agent.destination = self.transform.position;
    }

    public void Die()
    {
        //if we are alive
        if (curHealth > 0)
        {
            //dont run this
            return;
        }
        //else we are dead so run this
        state = AIState.Die;
        if (!isDead)
            anim.SetTrigger("Die");
        isDead = true;
        agent.destination = self.transform.position;
    }
}
