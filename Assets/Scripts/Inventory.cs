using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject ItemSlotPrefab;
    public GameObject Content;
    public ToggleGroup ItemSlotToggleGroup;

    private int PosX = 0;
    private int PosY = 0;

    private int TempID;

    // Inventory Lists
    private Dictionary<int, int> WeaponInv  = new Dictionary<int, int>();
    private Dictionary<int, int> ArmourInv  = new Dictionary<int, int>();
    private Dictionary<int, int> ConsumInv  = new Dictionary<int, int>();
    private Dictionary<int, int> IngredInv  = new Dictionary<int, int>();
    private Dictionary<int, int> QuestInv   = new Dictionary<int, int>();
    private Dictionary<int, int> MiscInv    = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {

        // TESTING CODE - This will be reading from save file if anything
        for (int i = 0; i < 50; i++)
        {
            TempID = Random.Range(1, 10);
            if (WeaponInv.ContainsKey(TempID))
            {
                WeaponInv[TempID]++;
            }
            else
            {
                WeaponInv.Add(TempID, 1);
            }
        }
        for (int i = 0; i < 100; i++)
        {
            TempID = Random.Range(1, 11);
            if (ArmourInv.ContainsKey(TempID))
            {
                ArmourInv[TempID]++;
            }
            else
            {
                ArmourInv.Add(TempID, 1);
            }
        }
        // TESTING CODE

        CreateInventorySlotsinWindow("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ViewInventory();
        }
    }

    public void CreateInventorySlotsinWindow(string itemType)
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            GameObject.Destroy(Content.transform.GetChild(i).gameObject);
        }

        switch (itemType)
        {
            case "Weapon":
                CreateSlots(WeaponInv, itemType);
                break;
            case "Armour":
                CreateSlots(ArmourInv, itemType);
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
    private void CreateSlots(Dictionary<int, int> inventory, string itemType)
    {
        GameObject ItemSlot;
        int ItemID; 

        for (int i = 0; i < inventory.Count; i++)
        {
            ItemID = inventory.Keys.ElementAt(i);
            ItemSlot = Instantiate(ItemSlotPrefab);
            ItemSlot.name = "InvItem_" + i;
            //ItemSlot.GetComponent<Toggle>().group = ItemSlotToggleGroup;
            ItemSlot.transform.SetParent(Content.transform, false);
            ItemSlot.GetComponent<RectTransform>().localPosition = new Vector3(PosX, PosY, 0.0f);
            PosY -= (int)ItemSlot.GetComponent<RectTransform>().rect.height;
            ItemSlot.GetComponent<InvSlot>().AddItem(itemType, ItemID, inventory[ItemID]);
        }
    }

    public void AddItem(string itemType, int id)
    {
       // ItemDatabase.Instance.GetWeaponItem(id).Count++;
    }

    public void RemoveItem(string itemType, int id)
    {
      //  ItemDatabase.Instance.GetWeaponItem(id).Count--;
    }

    private void ViewInventory()
    {
        Canvas InvCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();

        if(InvCanvas.enabled)
        {
            InvCanvas.enabled = false; 
        }
        else
        {
            InvCanvas.enabled = true;
        }
    }
}
