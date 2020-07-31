﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDatabase: MonoBehaviour 
{

    private static ItemDatabase ItemDB = null;

    // Item Databases
    private List<Weapon> Weapons = new List<Weapon>();
    private List<Armour> Armours = new List<Armour>();
    private List<Consumable> Consumables = new List<Consumable>();

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
                    Weapons.Add(new Weapon(ItemData));
                    break;
                case "Armours":
                    Armours.Add(new Armour(ItemData));
                    break;
                case "Consumables":
                    Consumables.Add(new Consumable(ItemData));
                    break;
            }
        }
    }

    public Weapon GetWeaponItem(int ID)
    {
        return Weapons.Find(item => item.ID == ID);
    }

    public Armour GetArmourItem(int ID)
    {
        return Armours.Find(item => item.ID == ID);
    }

    public Consumable GetConsumableItem(int ID)
    {
        return Consumables.Find(item => item.ID == ID);
    }
}