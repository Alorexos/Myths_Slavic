using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    private int ItemID;
    private GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ItemEquip);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ItemEquip()
    {
        Player.GetComponent<WeaponEquip>().Equip(ItemID);
    }

    public void AddItem(string itemType, int id, int count)
    {
        ItemID = id;

        switch (itemType)
        {
            case "Weapon":
                SetupSlotInfo(ItemDatabase.Instance.GetWeaponItem(id), count);
                break;
            case "Armour":
                SetupSlotInfo(ItemDatabase.Instance.GetArmourItem(id), count);
                break;
            case "Consumables":
                //    CreateSlotForConsum();
                break;
            case "Ingredients":
                //   CreateSlotForIngred();
                break;
            case "Quest":
                //     CreateSlotForQuest();
                break;
            case "Miscellaneous":
                //   CreateSlotForMisc();
                break;
        }
    }

    private void SetupSlotInfo(Weapon data, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();
    }


    private void SetupSlotInfo(Armour data, int count)
    {
        transform.GetChild(0).GetComponent<Text>().text = data.Name;
        transform.GetChild(1).GetComponent<Text>().text = count.ToString();
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

}
