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

    public void AddItem(ItemsType itemType, int id, int count)
    {

        ItemType = itemType;
        ItemID = id;

        SlotInfo(ItemDatabase.Instance.GetItem(id, itemType), itemType, count);

        //switch (itemType)
        //{
        //    case ItemsType.Weapon:
               
        //        break;
        //    case ItemsType.Armour:
        //        SetupSlotInfo((Armour)ItemDatabase.Instance.GetItem(id, itemType), count);
        //        break;
        //    case ItemsType.Consumable:
        //        SetupSlotInfo(ItemDatabase.Instance.GetConsumableItem(id), count);
        //        break;
        //    case ItemsType.Ingredient:
        //        //   CreateSlotForIngred();
        //        break;
        //    case ItemsType.Quest:
        //        //     CreateSlotForQuest();
        //        break;
        //    case ItemsType.Miscellaneous:
        //        //   CreateSlotForMisc();
        //        break;
        //}
    }

    private void SlotInfo(Item data, ItemsType itemType, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();

        switch (itemType)
        {
            case ItemsType.Weapon:
                SlotInfoExtra((Weapon)data);
                break;
            case ItemsType.Armour:
                SlotInfoExtra((Armour)data);
                break;
            case ItemsType.Consumable:
                SlotInfoExtra((Consumable)data);
                break;
        }
        SetQuality(data.ItemQuality);
    }

    private void SlotInfoExtra(Weapon data)
    {
        transform.GetChild(2).GetComponent<Text>().text = data.BaseMinDamage.ToString();
        transform.GetChild(3).GetComponent<Text>().text = data.BaseMaxDamage.ToString();
    }

    private void SlotInfoExtra(Armour data)
    {
        transform.GetChild(2).GetComponent<Text>().text = data.Defence.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "";
    }
    
    private void SlotInfoExtra(Consumable data)
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
