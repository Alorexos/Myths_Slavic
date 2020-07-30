using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameObject ItemSlotPrefab;
    public GameObject Content;
    public ToggleGroup ItemSlotToggleGroup;

    private int PosX = 0;
    private int PosY = 0;
    private GameObject ItemSlot;

    private int TempID;

    // Inventory Lists
    private Dictionary<int, Weapon>        WeaponInv  = new Dictionary<int, Weapon>();
    private Dictionary<int, Armour>        ArmourInv  = new Dictionary<int, Armour>();
    private Dictionary<int, Consumable>    ConsumInv  = new Dictionary<int, Consumable>();
    private Dictionary<int, Ingredient>    IngredInv  = new Dictionary<int, Ingredient>();
    private Dictionary<int, QuestItem>     QuestInv   = new Dictionary<int, QuestItem>();
    private Dictionary<int, Miscellaneous> MiscInv    = new Dictionary<int, Miscellaneous>();

    // Start is called before the first frame update
    void Start()
    {

        // TESTING CODE - This will be reading from save file if anything
        for (int i = 0; i < 50 ; i++)
        {
            TempID = Random.Range(1, 10);

            if (WeaponInv.ContainsKey(TempID))
            {
                WeaponInv[TempID].Count++;
            }
            else
            {
                WeaponInv.Add(TempID, ItemDatabase.Instance.GetWeaponItem(TempID));
            }
        }
        for (int i = 0; i < 100; i++)
        {
            TempID = Random.Range(1, 12);

            if (ArmourInv.ContainsKey(TempID))
            {
                ArmourInv[TempID].Count++;
            }
            else
            {
                ArmourInv.Add(TempID, ItemDatabase.Instance.GetArmourItem(TempID));
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

    public void CreateInventorySlotsinWindow(string ItemType)
    {
        for (int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        switch(ItemType)
        {
            case "Weapon":
                CreateSlotForWeapon();
                break;
            case "Armour":
                CreateSlotForArmour();
                break;
            case "Consumables":
                CreateSlotForConsum();
                break;
            case "Ingredients":
                CreateSlotForIngred();
                break;
            case "Quest":
                CreateSlotForQuest();
                break;
            case "Miscellaneous":
                CreateSlotForMisc();
                break;
        }
    }
    private void CreateSlot(int i)
    {
        ItemSlot = Instantiate(ItemSlotPrefab);
        ItemSlot.name = i.ToString();
        ItemSlot.GetComponent<Toggle>().group = ItemSlotToggleGroup;
        ItemSlot.transform.SetParent(Content.transform, false);
        ItemSlot.GetComponent<RectTransform>().localPosition = new Vector3(PosX, PosY, 0.0f);
        PosY -= (int)ItemSlot.GetComponent<RectTransform>().rect.height;
    }
    private void CreateSlotForWeapon()
    {
        for (int i = 1; i < WeaponInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = WeaponInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = WeaponInv[i].Count.ToString();
        }
    }

    private void CreateSlotForArmour()
    {
        for (int i = 1; i < ArmourInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = ArmourInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = ArmourInv[i].Count.ToString();
        }
    }

    private void CreateSlotForConsum()
    {
        for (int i = 1; i < ConsumInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = ConsumInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = ConsumInv[i].Count.ToString();
        }
    }

    private void CreateSlotForIngred()
    {
        for (int i = 1; i < IngredInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = IngredInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = IngredInv[i].Count.ToString();
        }
    }

    private void CreateSlotForQuest()
    {
        for (int i = 1; i < QuestInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = QuestInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = QuestInv[i].Count.ToString();
        }
    }

    private void CreateSlotForMisc()
    {
        for (int i = 1; i < MiscInv.Count; i++)
        {
            CreateSlot(i);
            ItemSlot.transform.GetChild(0).GetComponent<Text>().text = MiscInv[i].Name;
            ItemSlot.transform.GetChild(1).GetComponent<Text>().text = MiscInv[i].Count.ToString();
        }
    }

    public void AddItem(Weapon Item)
    {
        if (WeaponInv.ContainsKey(Item.ID))
        {
            WeaponInv[Item.ID].Count++;
        }
        else
        {
            WeaponInv.Add(Item.ID, Item);
        }
    }

    public void RemoveItem(Weapon Item)
    {
        if (WeaponInv.ContainsKey(Item.ID))
        {
            if (WeaponInv[Item.ID].Count > 1)
            {
                WeaponInv[Item.ID].Count--;
            }
            else
            {
                WeaponInv.Remove(Item.ID);
            }
        }
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
