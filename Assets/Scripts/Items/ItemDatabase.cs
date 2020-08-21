using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDatabase: MonoBehaviour 
{

    private static ItemDatabase ItemDB = null;

    // Item Databases
    private Dictionary<int, string[]> Weapons     = new Dictionary<int, string[]>();
    private Dictionary<int, string[]> Armours     = new Dictionary<int, string[]>();
    private Dictionary<int, string[]> Consumables = new Dictionary<int, string[]>();

    // Item data lookup variables
    private List<string> ItemList = new List<string>();
    private string[] ItemData;

    public static ItemDatabase Instance
    {
        get
        {
            if(ItemDB == null)
            {
                ItemDB = FindObjectOfType<ItemDatabase>();

                if(ItemDB == null)
                {
                    ItemDB = new GameObject().AddComponent<ItemDatabase>();
                }
            }

            return ItemDB;
        }
    }

    void Awake()
    {
        if (ItemDB != null)
        {
            Destroy(this);
            DontDestroyOnLoad(this);
        }

        ReadTextFile("Weapons");
        ReadTextFile("Armours");
        ReadTextFile("Consumables");

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    protected void ReadTextFile(string Type)
    {
        string FilePath = "Assets/Data/" + Type + ".csv";
        StreamReader inp_stm = new StreamReader(FilePath);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            if(!inp_ln.Contains("ID"))
                ItemList.Add(inp_ln);
        }

        inp_stm.Close();

        ParseList(Type);

        ItemList.Clear();
    }

    protected void ParseList(string Type)
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            ItemData = ItemList[i].Split(',');
            switch(Type)
            {
                case "Weapons":
                    Weapons.Add(int.Parse(ItemData[0]), ItemData);
                    break;
                case "Armours":
                    Armours.Add(int.Parse(ItemData[0]), ItemData);
                    break;
                case "Consumables":
                    Consumables.Add(int.Parse(ItemData[0]), ItemData);
                    break;
            }
        }
    }

    public string[] GetItem(int ID, ItemsType type)
    {
        switch (type)
        {
            case ItemsType.Weapon:
                return Weapons[ID];
            case ItemsType.Armour:
                return Armours[ID];
            case ItemsType.Consumable:
                return Consumables[ID];
            default: return null;
        }

        
    }
}
