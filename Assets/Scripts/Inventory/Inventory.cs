using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum ItemsType 
{
    Weapon,
    Armour,
    Consumable,
    Ingredient,
    Quest,
    Miscellaneous
};

public class Inventory : MonoBehaviour
{
    public GameObject ItemSlotPrefab;
    public GameObject Content;
    public ToggleGroup ItemSlotToggleGroup;

    private int PosX = 0;
    private int PosY = 0;

    private int TempID;

    // Inventory Lists
    private Dictionary<int, int> WeaponInv        = new Dictionary<int, int>();
    private Dictionary<int, int> ArmourInv        = new Dictionary<int, int>();
    private Dictionary<int, int> ConsumableInv    = new Dictionary<int, int>();
    private Dictionary<int, int> IngredientInv    = new Dictionary<int, int>();
    private Dictionary<int, int> QuestInv         = new Dictionary<int, int>();
    private Dictionary<int, int> MiscellaneousInv = new Dictionary<int, int>();

    // Start is called before the first frame update
    void Start()
    {
        // TESTING CODE - This will be reading from save file if anything
        for (int i = 0; i < 50; i++)
        {
            TempID = Random.Range(1, 11);
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
            TempID = Random.Range(1, 25);
            if (ArmourInv.ContainsKey(TempID))
            {
                ArmourInv[TempID]++;
            }
            else
            {
                ArmourInv.Add(TempID, 1);
            }
        }
        for (int i = 0; i < 100; i++)
        {
            TempID = Random.Range(1, 3);
            if (ConsumableInv.ContainsKey(TempID))
            {
                ConsumableInv[TempID]++;
            }
            else
            {
                ConsumableInv.Add(TempID, 1);
            }
        }
        // TESTING CODE

        CreateInventorySlotsinWindow("Weapons");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ViewInventory();
        }
    }

    public void CreateInventorySlotsinWindow(string itemsType)
    {
        ItemsType ItemsType = (ItemsType)System.Enum.Parse(typeof(ItemsType), itemsType);

        for (int i = 0; i < Content.transform.childCount; i++)
        {
            GameObject.Destroy(Content.transform.GetChild(i).gameObject);
        }

        switch (ItemsType)
        {
            case ItemsType.Weapon:
                CreateSlots(WeaponInv, ItemsType);
                break;
            case ItemsType.Armour:
                CreateSlots(ArmourInv, ItemsType);
                break;
            case ItemsType.Consumable:
                CreateSlots(ConsumableInv, ItemsType);
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
    private void CreateSlots(Dictionary<int, int> inventory, ItemsType itemsType)
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
            ItemSlot.GetComponent<InventorySlot>().AddItem(itemsType, ItemID, inventory[ItemID]);
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

    private ItemsType ParseEnum(string value)
    {
        try
        {
            return (ItemsType)System.Enum.Parse(typeof(ItemsType),value);
            //Foo(enumerable); //Now you have your enum, do whatever you want.
        }
        catch (System.Exception)
        {
            Debug.LogErrorFormat("Parse: Can't convert {0} to enum, please check the spell.", value);
            return ItemsType.Weapon;
        }
    }
}
