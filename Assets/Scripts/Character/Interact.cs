using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    void Update()
    {
        //If the button interact is pushed
        if (Input.GetButton("Interact"))
        {
            //New ray interactionRay
            Ray interactionRay;
            //Make the ray go from the camrea forward in the center
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //New Hit Raycast
            RaycastHit hitiInfo;
            //If the raycast hits something within 10 units
            if (Physics.Raycast(interactionRay, out hitiInfo, 10))
            {
                //Switch based on the tag of the game object it hits
                switch (hitiInfo.collider.tag)
                {
                    //If it hits npc
                    case "NPC":
                        //Get the comopent Dialogue on the object
                        Dialogue dlg = hitiInfo.transform.GetComponent<Dialogue>();
                        //if the dialouge is not null
                        if (dlg != null)
                        {
                            //Run void TurnOnGUI with the argument dialogueHandler
                            dlg.TurnOnGUI(gameObject.GetComponent<DialogueHandler>());
                            //Set the time scale to 0
                            Time.timeScale = 0;
                            //Set the cursor to visible
                            Cursor.visible = true;
                            //Set the cursor lock state to none 
                            Cursor.lockState = CursorLockMode.None;
                        }
                        break;
                    //If the case is item
                    case "Item":
                        //Set get the component ItemHandler from the object
                        ItemHandler handler = hitiInfo.transform.GetComponent<ItemHandler>();
                        //If the handler doesnt equal null
                        if (handler != null)
                        {
                            //Run void OnCollection on the item
                            handler.OnCollection();
                        }
                        break;
                }
            }
        }
    }
}
