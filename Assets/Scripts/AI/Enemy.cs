using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum AIState  //State of the enemy
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    [Header("BaseStats")]
    public AIState state; //Variable
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange; //Base Stats for health, speed, attackRage, Attack Speed and how far it can see
    public float difficulty = 1; //Difficulty of the enemy
    public float baseDamage = 1; //Base damage of the enemy
    public bool isDead; //If the enemy is dead
    [Space(5)]
    [Header("Base References")]
    public GameObject self; //Self referance
    public Transform player; //Player referance
    public Transform waypointParent; //Parent Waypoint
    protected Transform[] waypoints; //All waypoints
    private int curWaypoint; //Current waypoint
    public NavMeshAgent agent; //NavMeshAgent for movement
    public Animator anim; //Enemy Animator

    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>(); //Get componets in children and put them into the array waypoints
        agent = self.GetComponent<NavMeshAgent>(); //Get the NavMeshAgent from self
        curWaypoint = 1; //Set current waypoint to 1
        agent.speed = moveSpeed; //Chance the agent speed to match movement speed
        anim = self.GetComponent<Animator>(); //Get component animator and set it into anim
        Patrol(); //Start Patrolling to next waypoint
    }

    private void Update()
    {
        //Set all animation bools to false
        anim.SetBool("Walk", false); 
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);
        //Run through all states of enemy
        Patrol();
        Seek();
        Attack();
        Die();
    }
    public void Patrol()
    {
        //If there are no way points stop and if the player is not within sightrange
        if (waypoints.Length == 0 || sightRange > Vector3.Distance(player.position, self.transform.position))
        {
            //Return to update
            return;
        }
        //Change state of AI to patrol
        state = AIState.Patrol;
        //Change the agent speed to movement speed
        agent.speed = moveSpeed;
        //Set animation movement bool to true
        anim.SetBool("Walk", true);
        //Change desitnation of movement to current waypoint
        agent.destination = waypoints[curWaypoint].position;
        //If Enemy is on the x and z cords of the waypoint
        if(self.transform.position.x.Equals(agent.destination.x) && self.transform.position.z == agent.destination.z)
        {
            //If curWaypoint is less than waypoint length
            if(curWaypoint < waypoints.Length-1)
            {
                //Add 1 to waypoint
                curWaypoint++;
            }
            else 
            {
                //Set curWaypoint to 0
                curWaypoint = 0;
            }
        }
    }

    public void Seek()
    {
        //If player is not within sight range or attack Range
        if (Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange)
        {
            //Return to update
            return;
        }
        //Set AIState to seek
        state = AIState.Seek;
        //Change agent speed to attack speed
        agent.speed = attackSpeed;
        //Start run animation
        anim.SetBool("Run", true);
        //Change the agent destination 
        agent.destination = player.position;
    }

    public virtual void Attack()
    {
        //if player isnt within attack range
        if (Vector3.Distance(player.position, self.transform.position) > attackRange)
        {
            //Return to update
            return;
        }
        //Change AIState to attack
        state = AIState.Attack;
        //Change animation boolof attack to true
        anim.SetBool("Attack", true);
    }

    public void Die()
    {
        //if we are alive and health is greater than 0
        if (curHealth > 0)
        {
            //Return to update
            return;
        }
        //Change animation state to die
        state = AIState.Die;
        //If dead is false
        if (!isDead)
        {
            //Trigger animation die
            anim.SetTrigger("Die");
        }
        //is dead to true
        isDead = true;
        //Change the destiation to current location
        agent.destination = self.transform.position;
    }
}
