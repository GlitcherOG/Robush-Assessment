using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
namespace RPG.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //Value Variables
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20;
        //Strut - Contains Mutiple Variables (eg...3 floats)
        private Vector3 _moveDir;
        //Reference Variables
        private CharacterController _charC;
        private PlayerHandler player;

        private void Start()
        {
            _charC = GetComponent<CharacterController>();
            player = GetComponent<PlayerHandler>();
        }
        private void Move()
        {
            if (_charC.isGrounded)
            {
                if (Input.GetButton("Sprint") && player.curStamina > 0)
                {
                    moveSpeed = runSpeed + ((float)player.stats[1].value / 10);
                    player.staminaRegain = false;
                    player.curStamina -= Time.deltaTime * 10;
                }
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = crouchSpeed;
                    player.staminaRegain = true;
                }
                else
                {
                    moveSpeed = walkSpeed;
                    player.staminaRegain = true;
                }
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, (Input.GetAxis("Vertical") * moveSpeed)));
                if(Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
        private void Update()
        {
            Move();
        }
    }
}

