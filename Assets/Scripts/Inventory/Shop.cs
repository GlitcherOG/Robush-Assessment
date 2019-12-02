using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;
    public GameObject shopCanvas;
    public GameObject buy;
    public Text cost;
    public GameObject itemCanvas;
    public List<GameObject> itemButtons = new List<GameObject>();
    public GameObject button;

    private void Start()
    {
        itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i] = Random.Range(0, 4);
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }
    }

    private void Update()
    {

    }

    public void ShowShop()
    {
        LinearInventory.showInv = true;
        for (int i = 0; i < shopInv.Count; i++)
        {
            itemButtons.Add(Instantiate(button, itemCanvas.transform));
            itemButtons[i].GetComponent<Button>().onClick.AddListener(ShopSelect);
            itemButtons[i].gameObject.name = i.ToString();
            Text text = itemButtons[i].GetComponentInChildren<Text>();
            text.text = shopInv[i].Name;
        }
    }

    void ShopSelect()
    {
        int temp = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        selectedShopItem = shopInv[temp];
        cost.text = selectedShopItem.Value.ToString();
    }

    private void OnGUI()
    {
        if (showShop)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            GUI.Box(new Rect(6.5f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.45f * scr.y), "$" + LinearInventory.money);
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + (i * 0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                }
            }
            if (selectedShopItem == null)
            {
                return;
            }
            else
            {
                int cost = (int)((float)selectedShopItem.Value * (5f / 4f));
                GUI.Box(new Rect(6.5f * scr.x, 0.75f * scr.y, 3 * scr.x, 0.45f * scr.y), "$" + cost);
                if (LinearInventory.money >= cost)
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Buy"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        LinearInventory.money -= cost;
                        shopInv.Remove(selectedShopItem);
                        selectedShopItem = null;
                    }
                }
            }
        }
    }
}