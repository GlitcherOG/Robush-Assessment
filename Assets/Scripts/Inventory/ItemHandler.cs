using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemId = 0; //The id of the item
    public ItemTypes itemType; //itemType of the item
    public int amount = 1; //Ammount of the item

    //On collection of the object
    public void OnCollection()
    {
        //If the itemType is equal to type money
        if (itemType == ItemTypes.Money)
        {
            //Access the LinerInventory's money and add the ammount to it
            LinearInventory.money += amount;
        }
        //Checks if the itemType matches craftable or ingredient
        else if (itemType == ItemTypes.Craftable || itemType == ItemTypes.Ingredient) 
        {
            //Int for if the item is found
            int found = 0;
            //Index of the item
            int addIndex = 0;
            //For all inventory items
            for (int i = 0; i < LinearInventory.inv.Count; i++)
            {
                //If the itemId is equal to the linearInventory ID
                if (itemId == LinearInventory.inv[i].ID)
                {
                    //Set found to 1
                    found = 1;
                    //Set the index to i
                    addIndex = i;
                    //End the for loop
                    break;
                }
            }
            //If found equals one
            if (found == 1)
            {
                //Add add amount to the amount in the linearInventory
                LinearInventory.inv[addIndex].Amount += amount;
            }
            else
            {
                //Add item to the liner inventory
                LinearInventory.inv.Add(ItemData.CreateItem(itemId));
                //If the ammount is greater than 1
                if (amount > 1)
                {
                    //For all items in the inventory
                    for (int i = 0; i < LinearInventory.inv.Count; i++)
                    {
                        //If the item id matches the it in the inventory
                        if (itemId == LinearInventory.inv[i].ID)
                        {
                            LinearInventory.inv[i].Amount = amount;
                            i = LinearInventory.inv.Count;
                        }
                    }
                }
            }
        }
        else
        {
            //Add item to the Linear Inventory
            LinearInventory.inv.Add(ItemData.CreateItem(itemId));
        }
        //Destory the gameObject
        Destroy(gameObject);
    }
}
