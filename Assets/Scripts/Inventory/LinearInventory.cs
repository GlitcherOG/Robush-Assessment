using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    [Header("Global Script Variables")]
    public static List<Item> inv = new List<Item>(); //New list for all the items in the inventory 
    public static bool showInv; //Bool for if the inventroy is shown
    public Item selectedItem; //Item for the selected item
    public static int money; //Int used for the money
    public string sortType = "All"; //string used for the sortType
    public Transform dropLocation; //dropLocation for the items

    [System.Serializable]
    public struct EquippedItems
    {
        public string slotName;
        public Item item;
        public Transform location;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItems; //Used for the equipment 
    [Header("Stat Panel")]
    public GameObject statPanel; //The statPanel gameobject
    public RawImage itemImage; //The Item Image
    public Text itemText; //The Item name text
    public Text itemDes; //The item Description text
    public GameObject useButton; //The useButton gameobject
    [Header("Main Panel")]
    public List<GameObject> itemButtons = new List<GameObject>(); //List for the itemButtons 
    public GameObject button; //Prefab used for the buttons
    public GameObject canvas; //Gameobject used for the canvas
    public GameObject invPanel; //Gameobject for the inventory items
    [Header("Item Prefab")]
    public GameObject sack; //The gameobject prefab for items
    #endregion

    private void Start()
    {
        //Add 100 to the money
        money += 100;
        //Used to add Items to the inventory 
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(3));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
    }

    private void Update()
    {
        //If the tab key is pushed down and the bool is false
        if (Input.GetKeyDown("tab") && !PauseMenu.isPaused)
        {
            //Switch the state of showInv
            showInv = !showInv;
            //If showInv is true
            if (showInv)
            {
                //Set the cursor visible 
                Cursor.visible = true;
                //Set the lockState for the cursor to none
                Cursor.lockState = CursorLockMode.None;
                //Set the timeScale to zero
                Time.timeScale = 0;
                //Run void TurnOnGUI
                TurnOnGUI();
            }
            else
            {
                //Set the cursor visible state to false
                Cursor.visible = false;
                //Set the cursor lockState to be locked
                Cursor.lockState = CursorLockMode.Locked;
                //Set the timeScale to one
                Time.timeScale = 1;
                //New GameObject array to be the ammount of itemButtons
                GameObject[] temp = new GameObject[itemButtons.Count];
                //For all itemButtons
                for (int i = 0; i < itemButtons.Count; i++)
                {
                    //Set the temp to the itemButtons gameObject 
                    temp[i] = itemButtons[i].gameObject;
                }
                //For all temp
                for (int i = 0; i < temp.Length; i++)
                {
                    //Destroy temp
                    Destroy(temp[i]);
                }
                //Remove all the buttons from the list
                itemButtons.RemoveRange(0, itemButtons.Count);
                //Set sortType to All
                sortType = "All";
                //Set Displaystats to true
                DisplayStats(true);
                //Set inventory panel active state to false
                invPanel.SetActive(false);
            }
        }
        //If the key I is pushed
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Add an item to the invintory between item id 0 and 3
            inv.Add(ItemData.CreateItem(UnityEngine.Random.Range(0, 3)));
        }
        //If Keypad PLus is pushed
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            //Set the inv amount to 52
            inv[0].Amount = 52;
        }
    }
    private void TurnOnGUI()
    {
        //Set the invPanel state to true
        invPanel.SetActive(true);
        //For all inventory Items
        for (int i = 0; i < inv.Count; i++)
        {
            //Add a itemButton by instantiat the button on the canvas
            itemButtons.Add(Instantiate(button, canvas.transform));
            //Get the component button from the itembutton and add a listener for displayData
            itemButtons[i].GetComponent<Button>().onClick.AddListener(DisplayData);
            //Change the object name to the location of the item
            itemButtons[i].gameObject.name = i.ToString();
            //New text and get the component Text
            Text text = itemButtons[i].GetComponentInChildren<Text>();
            //Set the text to the inventory item name
            text.text = inv[i].Name;
        }
    }

    public void DropItem()
    {
        //for all equiped items
        for (int i = 0; i < equippedItems.Length; i++)
        {
            //If the equippedItem doesnt equal null and the selected item name to the equippeditem name
            if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
            {
                //Destroy the equipped Item
                Destroy(equippedItems[i].equippedItem);
            }
        }

        //Spawn item at drop location
        GameObject itemToDrop = Instantiate(sack, dropLocation.position, Quaternion.identity);
        //Change the item name 
        itemToDrop.name = selectedItem.Name;
        //Adds the compnent to rigidbody and set gravity to true
        itemToDrop.AddComponent<Rigidbody>().useGravity = true;

        //is the amount > 1 if so reduce from list
        if (selectedItem.Amount > 1)
        {
            //Remove 1 from ammount
            selectedItem.Amount--;
        }
        else 
        {
            //Remove the item from the list
            inv.Remove(selectedItem);
            //Set selectedItem to null
            selectedItem = null;
            //Set the displayStats to true
            DisplayStats(true);
            //Reload the GUI
            ReloadGUI();
        }

    }

    public void UseItem()
    {
        //If the selectedItem's Type is armour or weapon
        if (selectedItem.ItemType == ItemTypes.Armour || selectedItem.ItemType == ItemTypes.Weapon)
        {
            //Add the selectedItem to the equippedItems
            equippedItems[0].item = selectedItem;
            //Reload's the GUI
            ReloadGUI();
        }
        //If the selectedItem's Type is potion or food
        if(selectedItem.ItemType == ItemTypes.Potion || selectedItem.ItemType == ItemTypes.Food)
        {
            //Remove the selectedItem from the invientory
            inv.Remove(selectedItem);
            //Trim the excess from the inventory
            inv.TrimExcess();
            //Set the displayStats to hidded
            DisplayStats(true);
            //Reaload the GUI
            ReloadGUI();
        }
    }

    private void DisplayStats(bool hide = false)
    {
        //statPanel's active state to the opposite of hide
        statPanel.SetActive(!hide);
        //If hide is false
        if (!hide)
        {
            //Set the item image to the selected item image
            itemImage.texture = selectedItem.IconName;
            //Set the item text to the selected item name
            itemText.text = selectedItem.Name;
            //Set the item description text to selecteditem description
            itemDes.text = selectedItem.Description;
            //If the itemType is armour, weapon, potion or food
            if (selectedItem.ItemType == ItemTypes.Armour || selectedItem.ItemType == ItemTypes.Weapon || selectedItem.ItemType == ItemTypes.Potion || selectedItem.ItemType == ItemTypes.Food)
            {
                //Set the useButton state to true
                useButton.SetActive(true);
                //If the itemType is armour or weapon
                if(selectedItem.ItemType == ItemTypes.Armour || selectedItem.ItemType == ItemTypes.Weapon)
                {
                    //For all equippedItems
                    for (int i = 0; i < equippedItems.Length; i++)
                    {
                        //If selectedItem matches the equippedItem
                        if (selectedItem == equippedItems[i].item)
                        {
                            //Get the useButtons child Text and set it to De-Equip
                            useButton.GetComponentInChildren<Text>().text = "De-Equip";
                        }
                    }
                    //If the selectedItem type matches potion or food
                    if (selectedItem.ItemType == ItemTypes.Potion || selectedItem.ItemType == ItemTypes.Food)
                    {
                        //Get the useButtons child Text and set it to Consume
                        useButton.GetComponentInChildren<Text>().text = "Consume";
                    }
                    //Id the selectedItem's text matches nothing
                    if (useButton.GetComponentInChildren<Text>().text == "")
                    {
                        //Get the useButtons child Text and set it to Equip
                        useButton.GetComponentInChildren<Text>().text = "Equip";
                    }
                }
            }
            else
            {
                //Set the state of useButton to false
                useButton.SetActive(false);
            }
        }
        else
        {
            //Set the item image to null
            itemImage.texture = null;
            //Set the item text to Nothing
            itemText.text = "";
            //Set the item Description to nothing
            itemDes.text = "";
            //Set the useButton text to nothing
            useButton.GetComponentInChildren<Text>().text = "";
        }
    }

    public void ItemFilter(int filter = 0)
    {
        //Switch using filter
        switch (filter)
        {
            //If case is zero
            case 0:
                //Set the sortType to All
                sortType = "All";
                break;
            //If case is one
            case 1:
                //Set the sortType to armour
                sortType = "Armour";
                break;
            //If case is two
            case 2:
                //Set the sortType to weapon
                sortType = "Weapon";
                break;
            //If case is three
            case 3:
                //Set the sortType to potion
                sortType = "Potion";
                break;
            //If case is four
            case 4:
                //Set the sortType to food
                sortType = "Food";
                break;
            //If case is five
            case 5:
                //Set the sortType to ingredients
                sortType = "Ingredient";
                break;
            //If case is six
            case 6:
                //Set the sortType to craftable
                sortType = "Craftable";
                break;
            //If case is seven
            case 7:
                //Set the sortType to quest
                sortType = "Quest";
                break;
            //If case is eight
            case 8:
                //Set the sortType to misc
                sortType = "Misc";
                break;
        }
        //Reload the GUI
        ReloadGUI();
    }

    private void ReloadGUI()
    {
        //New GameObject array to be the ammount of itemButtons
        GameObject[] temp = new GameObject[itemButtons.Count];
        //For all itemButtons
        for (int i = 0; i < itemButtons.Count; i++)
        {
            //Set the temp to the itemButtons gameObject 
            temp[i] = itemButtons[i].gameObject;
        }
        //For all temp
        for (int i = 0; i < temp.Length; i++)
        {
            //Destroy temp
            Destroy(temp[i]);
        }
        //Remove all the buttons from the list
        itemButtons.RemoveRange(0, itemButtons.Count);
        //New bool test and set it to false
        bool test = false;
        //If the sortType is not all
        if (sortType != "All")
        {
            //set test to true
            test = true;
        }
        //New int b
        int b = 0;
        //For all 
        for (int i = 0; i < inv.Count; i++)
        {
            if (!test || sortType == "All")
            {
                //Add a itemButton by instantiat the button on the canvas
                itemButtons.Add(Instantiate(button, canvas.transform));
                //Get the component button from the itembutton and add a listener for displayData
                itemButtons[i].GetComponent<Button>().onClick.AddListener(DisplayData);
                //Change the object name to the location of the item
                itemButtons[i].gameObject.name = i.ToString();
                //New text and get the component Text
                Text text = itemButtons[i].GetComponentInChildren<Text>();
                //Set the text to the inventory item name
                text.text = inv[i].Name;
            }
            else
            {
                //Convert the sort type to to ItemType
                ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
                //If the iventory type of the item matches type
                if (inv[i].ItemType == type)
                {
                    //Add a itemButton by instantiat the button on the canvas
                    itemButtons.Add(Instantiate(button, canvas.transform));
                    //Get the component button from the itembutton b and add a listener for displayData
                    itemButtons[b].GetComponent<Button>().onClick.AddListener(DisplayData);
                    //Change the object b name to the location of the item
                    itemButtons[b].gameObject.name = i.ToString();
                    //New text and get the component Text
                    Text text = itemButtons[b].GetComponentInChildren<Text>();
                    //Set the text to the inventory item name
                    text.text = inv[i].Name;
                    //add 1 to b
                    b++;
                }
            }
        }
    }

    public void DisplayData()
    {
        //Set new temp for the postion of the item in the inventory
        int temp = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        //Set the selected item to the inventory item
        selectedItem = inv[temp];
        //Display the stats of the item
        DisplayStats();
    }
}
