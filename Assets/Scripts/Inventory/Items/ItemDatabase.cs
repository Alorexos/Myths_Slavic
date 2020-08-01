using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDatabase: MonoBehaviour 
{

    private static ItemDatabase ItemDB = null;

    // Item Databases
    private List<Item> Items = new List<Item>();

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
                    Items.Add(Weapon.CreateInstance(ItemData));
                    break;
                case "Armours":
                    Items.Add(Armour.CreateInstance(ItemData));
                    break;
                case "Consumables":
                    Items.Add(Consumable.CreateInstance(ItemData));
                    break;
            }
        }
    }

    public Item GetItem(int ID, ItemsType type)
    {
        return Items.Find(item => item.ID == ID && item.Type == type);
    }
}
