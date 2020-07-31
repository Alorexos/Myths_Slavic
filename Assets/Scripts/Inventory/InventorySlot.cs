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

        switch (itemType)
        {
            case ItemsType.Weapon:
                SetupSlotInfo(ItemDatabase.Instance.GetWeaponItem(id), count);
                break;
            case ItemsType.Armour:
                SetupSlotInfo(ItemDatabase.Instance.GetArmourItem(id), count);
                break;
            case ItemsType.Consumable:
                SetupSlotInfo(ItemDatabase.Instance.GetConsumableItem(id), count);
                break;
            case ItemsType.Ingredient:
                //   CreateSlotForIngred();
                break;
            case ItemsType.Quest:
                //     CreateSlotForQuest();
                break;
            case ItemsType.Miscellaneous:
                //   CreateSlotForMisc();
                break;
        }
    }

    private void SetupSlotInfo(Weapon data, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();
        transform.GetChild(2).GetComponent<Text>().text = data.BaseMinDamage.ToString();
        transform.GetChild(3).GetComponent<Text>().text = data.BaseMaxDamage.ToString();

        SetQuality(data.ItemQuality);
    }


    private void SetupSlotInfo(Armour data, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();
        transform.GetChild(2).GetComponent<Text>().text = data.Defence.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "";

        SetQuality(data.ItemQuality);
    }

    private void SetupSlotInfo(Consumable data, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "";

        SetQuality(data.ItemQuality);
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
