using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot: MonoBehaviour
{
    private int ItemID;
    private ItemsType ItemType;
    private GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ItemEquip);
    }

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ItemEquip()
    {
        Player.GetComponent<WeaponEquip>().Equip(ItemID);
    }

    public void AddItem(Item item, ItemsType itemType)
    {
        ItemID = item.ID;
        ItemType = itemType;
        transform.GetChild(0).GetComponent<Text>().text = item.Name;
        transform.GetChild(1).GetComponent<Text>().text = item.Stack.ToString();
        SetQuality(item.ItemQuality);
        switch (itemType)
        {
            case ItemsType.Weapon:
                SlotInfoExtra((Weapon)item);
                break;
            case ItemsType.Armour:
                SlotInfoExtra((Armour)item);
                break;
            case ItemsType.Consumable:
                SlotInfoExtra((Consumable)item);
                break;
        }
    }

    private void SlotInfoExtra(Weapon item)
    {
        transform.GetChild(2).GetComponent<Text>().text = item.BaseMinDamage.ToString();
        transform.GetChild(3).GetComponent<Text>().text = item.BaseMaxDamage.ToString();
    }

    private void SlotInfoExtra(Armour item)
    {
        transform.GetChild(2).GetComponent<Text>().text = item.Defence.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "";
    }
    
    private void SlotInfoExtra(Consumable item)
    {
        transform.GetChild(2).GetComponent<Text>().text = "";
        transform.GetChild(3).GetComponent<Text>().text = "";
    }

    //private void SetupSlotInfo()
    //{
    //    transform.GetChild(0).GetComponent<Text>().text = WeaponItem.Name;
    //    transform.GetChild(1).GetComponent<Text>().text = count.ToString();
    //}


    //private void SetupSlotInfo()
    //{
    //    transform.GetChild(0).GetComponent<Text>().text = WeaponItem.Name;
    //    transform.GetChild(1).GetComponent<Text>().text = count.ToString();
    //}

    private void SetQuality(string quality)
    {
        Image SlotBackground = GetComponent<Image>();

        switch(quality)
        {
            case "Common":
                SlotBackground.color = Color.white;
                break;
            case "Rare":
                SlotBackground.color = new Color32(40,142,225,255);
                break;
            case "Epic":
                SlotBackground.color = new Color32(130,40,225,255);
                break;
            case "Legendary":
                SlotBackground.color = new Color32(225,71,0,255);
                break;

        }
    }
}
