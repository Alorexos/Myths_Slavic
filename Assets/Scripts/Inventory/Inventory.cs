using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
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

    private int PosX = 0;
    private int PosY = 0;

    private int TempID;

    // Inventory Lists
    private Dictionary<int, Item> WeaponInv        = new Dictionary<int, Item>();
    private Dictionary<int, Item> ArmourInv        = new Dictionary<int, Item>();
    private Dictionary<int, Item> ConsumableInv    = new Dictionary<int, Item>();
    private Dictionary<int, Item> IngredientInv    = new Dictionary<int, Item>();
    private Dictionary<int, Item> QuestInv         = new Dictionary<int, Item>();
    private Dictionary<int, Item> MiscellaneousInv = new Dictionary<int, Item>();

    // Start is called before the first frame update
    void Start()
    {
        // TESTING CODE - This will be reading from save file if anything
        for (int i = 0; i < 50; i++)
        {
            TempID = Random.Range(1, 11);
            if (WeaponInv.ContainsKey(TempID))
            {
                WeaponInv[TempID].Stack++;
            }
            else
             {
                Weapon temp = ScriptableObject.CreateInstance<Weapon>();
                temp.Initialise(ItemDatabase.Instance.GetItem(TempID, ItemsType.Weapon));
                WeaponInv.Add(temp.ID, temp);
            }
        }
        for (int i = 0; i < 100; i++)
        {
            TempID = Random.Range(1, 25);
            if (ArmourInv.ContainsKey(TempID))
            {
                ArmourInv[TempID].Stack++;
            }
            else
            {
                Armour temp = ScriptableObject.CreateInstance<Armour>();
                temp.Initialise(ItemDatabase.Instance.GetItem(TempID, ItemsType.Armour));
                ArmourInv.Add(temp.ID, temp);
            }
        }
        for (int i = 0; i < 100; i++)
        {
            TempID = Random.Range(1, 3);
            if (ConsumableInv.ContainsKey(TempID))
            {
                ConsumableInv[TempID].Stack++;
            }
            else
            {
                Consumable temp = ScriptableObject.CreateInstance<Consumable>();
                temp.Initialise(ItemDatabase.Instance.GetItem(TempID, ItemsType.Consumable));
                ConsumableInv.Add(temp.ID, temp);
            }
        }
        // TESTING CODE

        CreateInventorySlotsinWindow(ItemsType.Weapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ViewInventory();
        }
    }

    public void CreateInventorySlotsinWindow(ItemsType itemsType)
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            GameObject.Destroy(Content.transform.GetChild(i).gameObject);
        }

        switch (itemsType)
        {
            case ItemsType.Weapon:
                //WeaponInv = SortAlphabetically(WeaponInv);
                CreateSlots(WeaponInv, itemsType);
                break;
            case ItemsType.Armour:
                 CreateSlots(ArmourInv, itemsType);
                break;
            case ItemsType.Consumable:
                CreateSlots(ConsumableInv, itemsType);
                break;
            case ItemsType.Ingredient:
                CreateSlots(IngredientInv, itemsType);
                break;
            case ItemsType.Quest:
                CreateSlots(QuestInv, itemsType);
                break;
            case ItemsType.Miscellaneous:
                CreateSlots(MiscellaneousInv, itemsType);
                break;
        }
    }
    private void CreateSlots(Dictionary<int, Item> inventory, ItemsType itemsType)
    {
        GameObject ItemSlot;

        for (int i = 0; i < inventory.Count; i++)
        {
            ItemSlot = Instantiate(ItemSlotPrefab);
            ItemSlot.name = "InvItem_" + i;
            ItemSlot.transform.SetParent(Content.transform, false);
            ItemSlot.GetComponent<RectTransform>().localPosition = new Vector3(PosX, PosY, 0.0f);
            PosY -= (int)ItemSlot.GetComponent<RectTransform>().rect.height;
            ItemSlot.GetComponent<InventorySlot>().AddItem(inventory.Values.ElementAt(i), itemsType);
        }
    }

    public void AddItem(ItemsType itemType, int id)
    {
        switch (itemType)
        {
            case ItemsType.Weapon:
                WeaponInv[id].Stack++;
                break;
            case ItemsType.Armour:
                ArmourInv[id].Stack++;
                break;
            case ItemsType.Consumable:
                ConsumableInv[id].Stack++;
                break;
            case ItemsType.Ingredient:
                IngredientInv[id].Stack++;
                break;
            case ItemsType.Quest:
                QuestInv[id].Stack++;
                break;
            case ItemsType.Miscellaneous:
                MiscellaneousInv[id].Stack++;
                break;
        }
    }

    public void RemoveItem(ItemsType itemType, int id)
    {
        switch (itemType)
        {
            case ItemsType.Weapon:
                WeaponInv[id].Stack--;
                break;
            case ItemsType.Armour:
                ArmourInv[id].Stack--;
                break;
            case ItemsType.Consumable:
                ConsumableInv[id].Stack--;
                break;
            case ItemsType.Ingredient:
                IngredientInv[id].Stack--;
                break;
            case ItemsType.Quest:
                QuestInv[id].Stack--;
                break;
            case ItemsType.Miscellaneous:
                MiscellaneousInv[id].Stack--;
                break;
        }
    }

    //private Dictionary<int, int> SortAlphabetically(Dictionary<int, int> inventory)
    //{
    //    Dictionary<int, int> Temp = new Dictionary<int, int>();
    //    string CurrVal;
    //    string NextVal;
    //    int CurrKey;
    //    int NextKey;

    //    int EmebrgencyCnt = 0;

    //    do
    //    {
    //        CurrVal = "";
    //        CurrKey = 0;

    //        for (int i = 0; i < inventory.Count; i++)
    //        {
    //            NextKey = inventory.Keys.ElementAt(i);
    //            NextVal = ItemDatabase.Instance.GetWeaponItem(NextKey).Name;

    //            if (CurrVal == "")
    //            {
    //                CurrVal = NextVal;
    //                CurrKey = NextKey;
    //            }
    //            else if (NextVal.CompareTo(CurrVal) < 0) 
    //            {
    //                CurrVal = NextVal;
    //                CurrKey = NextKey;
    //            }
    //        }

    //        if (CurrKey != 0)
    //        {
    //            Temp.Add(CurrKey, inventory[CurrKey]);
    //            inventory.Remove(CurrKey);
    //        }

    //        EmebrgencyCnt++;
    //        if (EmebrgencyCnt > 5000)
    //            break;

    //    } while (inventory.Count > 0);

    //    return Temp; 
    //}

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
