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

    private ItemsType CurrentInventory;
    Canvas InvCanvas;

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

        InvCanvas = GameObject.Find("Inventory").GetComponent<Canvas>();
        // TESTING CODE - This will be reading from save file if anything
        for (int i = 0; i < 50; i++)
        {
            AddItem(ItemsType.Weapon, Random.Range(1, 11));
        }
        for (int i = 0; i < 100; i++)
        {
            AddItem(ItemsType.Armour, Random.Range(1, 25));
        }
        for (int i = 0; i < 100; i++)
        {
            AddItem(ItemsType.Consumable, Random.Range(1, 3));
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(ItemsType.Consumable, 1);
        }
    }

    public void CreateInventorySlotsinWindow(ItemsType itemType)
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            GameObject.Destroy(Content.transform.GetChild(i).gameObject);
        }

        Dictionary<int, Item> InvRef = SelectInventory(itemType);
        InvRef = SortAlphabetically(InvRef);
        CreateSlots(InvRef);
        CurrentInventory = itemType;
    }
    private void CreateSlots(Dictionary<int, Item> inventory)
    {
        GameObject ItemSlot;

        for (int i = 0; i < inventory.Count; i++)
        {
            ItemSlot = Instantiate(ItemSlotPrefab);
            ItemSlot.name = "InvItem_" + i;
            ItemSlot.transform.SetParent(Content.transform, false);
            ItemSlot.GetComponent<RectTransform>().localPosition = new Vector3(PosX, PosY, 0.0f);
            PosY -= (int)ItemSlot.GetComponent<RectTransform>().rect.height;
            ItemSlot.GetComponent<InventorySlot>().AddSlot(inventory.Values.ElementAt(i));
        }
    }

    public void AddItem(ItemsType itemType, int id)
    {
        Dictionary<int, Item> InvRef = SelectInventory(itemType);

        if (InvRef.ContainsKey(id))
        {
            InvRef[id].Stack++;
        }
        else
        {
            CreateInventoryItem(itemType, id, ref InvRef);
        }

        if (InvCanvas.enabled)
        {
            CreateInventorySlotsinWindow(CurrentInventory);
        }
    }

    private void CreateInventoryItem(ItemsType itemType, int id, ref Dictionary<int, Item> inventory)
    {
        dynamic TempItem;

        switch (itemType)
        {
            case ItemsType.Weapon:
                TempItem = ScriptableObject.CreateInstance<Weapon>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
            case ItemsType.Armour:
                TempItem = ScriptableObject.CreateInstance<Armour>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
            case ItemsType.Consumable:
                TempItem = ScriptableObject.CreateInstance<Consumable>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
            case ItemsType.Ingredient:
                TempItem = ScriptableObject.CreateInstance<Ingredient>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
            case ItemsType.Quest:
                TempItem = ScriptableObject.CreateInstance<QuestItem>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
            case ItemsType.Miscellaneous:
                TempItem = ScriptableObject.CreateInstance<Miscellaneous>();
                TempItem.Initialise(id);
                inventory.Add(id, TempItem);
                break;
        }
    }

    public void AddItem(Item item)
    {
        Dictionary<int, Item> InvRef = SelectInventory(item.Type);

        if(InvRef.ContainsKey(item.ID))
        {
            InvRef[item.ID].Stack++;
        }
        else
        {
            InvRef.Add(item.ID, item);
        }

        if (InvCanvas.enabled)
        {
            CreateInventorySlotsinWindow(CurrentInventory);
        }
    }

    public void RemoveItem(ItemsType itemType, int id)
    {
        Dictionary<int, Item> InvRef = SelectInventory(itemType);
        InvRef[id].Stack--;

        if(InvRef[id].Stack == 0)
        {
            InvRef.Remove(id);
        }

        if (InvCanvas.enabled)
        {
            CreateInventorySlotsinWindow(CurrentInventory);
        }
    }
    private ref Dictionary<int, Item> SelectInventory(ItemsType itemType)
    {
        switch (itemType)
        {
            case ItemsType.Weapon:
                return ref WeaponInv;
            case ItemsType.Armour:
                return ref ArmourInv;
            case ItemsType.Consumable:
                return ref ConsumableInv;
            case ItemsType.Ingredient:
                return ref IngredientInv;
            case ItemsType.Quest:
                return ref QuestInv;
            case ItemsType.Miscellaneous:
                return ref MiscellaneousInv;
            default:
                return ref WeaponInv;
        }
    }

    private Dictionary<int, Item> SortAlphabetically(Dictionary<int, Item> inventory)
    {
        Dictionary<int, Item> Temp = new Dictionary<int, Item>();
        return inventory.OrderBy(i => i.Value.Name).ToDictionary(i => i.Key, i => i.Value);
    }

    private void ViewInventory()
    {
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
