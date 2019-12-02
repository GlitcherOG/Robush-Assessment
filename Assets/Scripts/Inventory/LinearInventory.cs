using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;
    public string sortType = "All";
    public Transform dropLocation;

    [System.Serializable]
    public struct EquippedItems
    {
        public string slotName;
        public Transform location;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItems;
    public RawImage itemImage;
    public Text itemText;
    public List<GameObject> itemButtons = new List<GameObject>(); //Button1.Click += new EventHandler(Button2_Click); 
    public GameObject button;
    public GameObject canvas;
    public ScrollRect scroll;
    public GameObject invPanel;
    public Text itemDes;
    public GameObject statPanel;
    public GameObject sack;
    #endregion

    private void Start()
    {
        money += 100;
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
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(602));
        inv.Add(ItemData.CreateItem(700));
        inv.Add(ItemData.CreateItem(701));
        inv.Add(ItemData.CreateItem(702));
    }

    private void Update()
    {
        if (Input.GetKeyDown("tab") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                TurnOnGUI();
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                GameObject[] temp = new GameObject[itemButtons.Count];
                for (int i = 0; i < itemButtons.Count; i++)
                {
                    temp[i] = itemButtons[i].gameObject;
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    Destroy(temp[i]);
                }
                itemButtons.RemoveRange(0, itemButtons.Count);
                sortType = "All";
                DisplayStats(true);
                invPanel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(UnityEngine.Random.Range(0, 3)));
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            inv[10].Amount = 52;
        }
    }
    private void TurnOnGUI()
    {
        invPanel.SetActive(true);
        for (int i = 0; i < inv.Count; i++)
        {
            itemButtons.Add(Instantiate(button, canvas.transform));
            itemButtons[i].GetComponent<Button>().onClick.AddListener(DisplayData);
            itemButtons[i].gameObject.name = i.ToString();
            Text text = itemButtons[i].GetComponentInChildren<Text>();
            text.text = inv[i].Name;
        }
    }

    public void DropItem()
    {
        //check if the item is equipped
        for (int i = 0; i < equippedItems.Length; i++)
        {
            if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
            {
                //if so destroy from scene
                Destroy(equippedItems[i].equippedItem);
            }
        }

        //spawn item at droplocation
        GameObject itemToDrop = Instantiate(sack, dropLocation.position, Quaternion.identity);
        //apply gravity and make sure its named correctly 
        itemToDrop.name = selectedItem.Name;
        itemToDrop.AddComponent<Rigidbody>().useGravity = true;

        //is the amount > 1 if so reduce from list
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else//else remove from list 
        {
            inv.Remove(selectedItem);
            selectedItem = null;
            DisplayStats(true);
            ReloadGUI();
            return;
        }

    }

    public void UseItem()
    {

    }

    private void DisplayStats(bool hide = false)
    {
        statPanel.SetActive(!hide);
        if (!hide)
        {
            itemImage.texture = selectedItem.IconName;
            itemText.text = selectedItem.Name;
            itemDes.text = selectedItem.Description;
        }
        else
        {
            itemImage.texture = null;
            itemText.text = "";
            itemDes.text = "";
        }
    }

    public void ItemFilter(int filter = 0)
    {
        switch (filter)
        {
            case 0:
                sortType = "All";
                break;
            case 1:
                sortType = "Armour";
                break;
            case 2:
                sortType = "Weapon";
                break;
            case 3:
                sortType = "Potion";
                break;
            case 4:
                sortType = "Food";
                break;
            case 5:
                sortType = "Ingredient";
                break;
            case 6:
                sortType = "Craftable";
                break;
            case 7:
                sortType = "Quest";
                break;
            case 8:
                sortType = "Misc";
                break;
        }
        ReloadGUI();
    }

    private void ReloadGUI()
    {
        GameObject[] temp = new GameObject[itemButtons.Count];
        for (int i = 0; i < itemButtons.Count; i++)
        {
            temp[i] = itemButtons[i].gameObject;
        }
        for (int i = 0; i < temp.Length; i++)
        {
            Destroy(temp[i]);
        }
        bool test = false;
        itemButtons.RemoveRange(0, itemButtons.Count);
        if (sortType != "All")
        {
            test = true;
        }
        int b = 0;
        for (int i = 0; i < inv.Count; i++)
        {
            if (!test || sortType == "All")
            {
                itemButtons.Add(Instantiate(button, canvas.transform));
                itemButtons[i].GetComponent<Button>().onClick.AddListener(DisplayData);
                itemButtons[i].gameObject.name = i.ToString();
                Text text = itemButtons[i].GetComponentInChildren<Text>();
                text.text = inv[i].Name;
            }
            else
            {
                ItemTypes type = (ItemTypes)
System.Enum.Parse(typeof(ItemTypes), sortType);
                if (inv[i].ItemType == type)
                {
                    itemButtons.Add(Instantiate(button, canvas.transform));
                    itemButtons[b].GetComponent<Button>().onClick.AddListener(DisplayData);
                    itemButtons[b].gameObject.name = i.ToString();
                    Text text = itemButtons[b].GetComponentInChildren<Text>();
                    text.text = inv[i].Name;
                    b++;
                }
            }
        }
    }

    public void DisplayData()
    {
        int temp = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        selectedItem = inv[temp];
        DisplayStats();
    }
}
