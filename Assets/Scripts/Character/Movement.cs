using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
namespace RPG.Player
{
    //Have the script to require a CharacterControler
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        public float moveSpeed; //Public float for the current movement speed of the character
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed; //walk speed, run speed, crouch speed and jump speed of the character
        private float _gravity = 20; //The ammount of gravity applyed to the character
        private Vector3 _moveDir; //Vector3 for the move direction of the character
        private CharacterController _charC; //The Character Controller used for movement
        private PlayerHandler player; //The PlayerHandler script 

        private void Start()
        {
            //Get the component CharacterController and set it into the Refrence _charC
            _charC = GetComponent<CharacterController>();
            //Get the Script PlayerHandler and set it into the Refrence _charC
            player = GetComponent<PlayerHandler>();
        }
        private void Move()
        {
            //If the character controller is grounded
            if (_charC.isGrounded)
            {
                //if the button input Sprint and the player curStamina is greater than zero
                if (Input.GetButton("Sprint") && player.curStamina > 0)
                {
                    //Change the moveSpeed float to be equal to run speed plus the Dexterity value on the PlayerHandler script divided by 10
                    moveSpeed = runSpeed + ((float)player.stats[1].value / 10);
                    //Set the staminaRgain on the PlayerHandler Script to false
                    player.staminaRegain = false;
                    //Minus the current Stamina by deltaTime Multiplied by 10
                    player.curStamina -= Time.deltaTime * 10;
                }
                //Else if the Input of the button Crouch is true
                else if (Input.GetButton("Crouch"))
                {
                    //Change the move speed to the crouch speed
                    moveSpeed = crouchSpeed;
                    //Set the Player Handlers StaminaRegain to true
                    player.staminaRegain = true;
                }
                else
                {
                    //Change the movement speed to the walkspeed
                    moveSpeed = walkSpeed;
                    //Set the PlayerHandlers StaminaRegain to true
                    player.staminaRegain = true;
                }
                //Apply a new transform direction to the Vector3 using the Horizontal movement keys Multiplied by movement speed, and the Vertical Axis keys also Multiplied by the moveSpeed 
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, (Input.GetAxis("Vertical") * moveSpeed)));
                //If the button jump is pushed
                if (Input.GetButton("Jump"))
                {
                    //Change the moveDir vertical value to have the jumpSpeed
                    _moveDir.y = jumpSpeed;
                }
            }
            //Minus gravity Multiplied by deltaTime from the vertical Y value of moveDir
            _moveDir.y -= _gravity * Time.deltaTime;
            //Change the movement of the Character controller to use moveDir Multiplied by deltaTime
            _charC.Move(_moveDir * Time.deltaTime);
        }
        private void Update()
        {
            //Start the Move void
            Move();
        }
    }
}

