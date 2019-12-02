using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitiInfo;
            if (Physics.Raycast(interactionRay, out hitiInfo, 10))
            {
                switch (hitiInfo.collider.tag)
                {
                    case "NPC":
                        Dialogue dlg = hitiInfo.transform.GetComponent<Dialogue>();
                        if (dlg != null)
                        {
                            dlg.TurnOnGUI(gameObject.GetComponent<DialogueHandler>());

                            Time.timeScale = 0;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        }
                        Debug.Log("Talk to Npc");
                        break;
                    case "Item":
                        Debug.Log("Pick up Item");
                        ItemHandler handler = hitiInfo.transform.GetComponent<ItemHandler>();
                        if (handler != null)
                        {
                            handler.OnCollection();
                        }
                        break;
                    case "Chest":
                        Debug.Log("Open the chest");
                        Chest chest = hitiInfo.transform.GetComponent<Chest>();
                        if(chest != null)
                        {
                            chest.showChest = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                        }
                        break;
                    case "Shop":
                        Debug.Log("Open the chest");
                        Shop shop = hitiInfo.transform.GetComponent<Shop>();
                        if (shop != null)
                        {
                            shop.showShop = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                            shop.ShowShop();
                        }
                        break;
                }
            }
        }
    }
}
