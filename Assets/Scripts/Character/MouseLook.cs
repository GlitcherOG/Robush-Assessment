using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Player
{
    public class MouseLook : MonoBehaviour
    {
        //Enums allows us to create types and categories 
        public enum RotationalAxis
        {
            MouseX,
            MouseY
        }
        //Header in the debguer 
        [Header("Rotation Variavbles")]
        //Sets the roational axis
        public RotationalAxis axis = RotationalAxis.MouseX;
        //Puts slider in the debuger
        [Range(0, 200)]
        //Float for the sensitivity
        public float sensitivity = 15;
        //Min and max of the y axis look
        public float minY = -60, maxY = 60;
        //Y rotation
        private float _rotY;

        void Start()
        {
            //Checks if the player has the component rigidbody and freezes the rotation on it if it exists
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            //Locks the cursor to the center of the screen and makes it invisable
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //Checks if its attached to the camera and if so will change it so the rotational axis to the y axis
            if (GetComponent<Camera>())
            {
                axis = RotationalAxis.MouseY;
            }
        }
        void Update()
        {
            if (!PauseMenu.isPaused) {
                //Checks if the axis is mousex 
                if (axis == RotationalAxis.MouseX)
                {
                    //Changes the roation of the x axis basied on mouse movement and time
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
                }
                else
                {
                    _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                    _rotY = Mathf.Clamp(_rotY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                }
            }
        }
    }
}
