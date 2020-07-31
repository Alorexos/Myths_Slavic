using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

public class WeaponEquip : MonoBehaviour
{

    [SerializeField]
    private GameObject RightHandItem;
    private GameObject Weapon;

    //private List<string> stringList;
    //private string[] parsedList;

    // Start is called before the first frame update
    void Start()
    {
        //stringList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (Weapon != null)
        //    {
        //        Unequip();
        //    }
        //    else
        //    {
        //        Equip(1);
        //    }
        //}


    }
    public void Equip(int id)
    {
        if (Weapon != null)
            Unequip();
        Debug.Log("Equiping: " + ItemDatabase.Instance.GetWeaponItem(id).PrefabDir);
        Weapon = Instantiate(Resources.Load(ItemDatabase.Instance.GetWeaponItem(id).PrefabDir), RightHandItem.transform) as GameObject;
       //Weapon.GetComponent<Weapon>().SetupWeapon(int.Parse(parsedList[0]), parsedList[1], int.Parse(parsedList[2]), int.Parse(parsedList[3]));
    }


    //void Equip(Weapon WeaponObject)
    //{
    //    if (Weapon != null)
    //        Unequip();

    //    //Weapon = Instantiate(Resources.Load(WeaponObject.GetPrefabDir()),RightHandItem.transform) as GameObject;
    //}

    void Unequip()
    {
        Destroy(Weapon);
    }
    
    //void readTextFile(int ID)
    //{
    //    StreamReader inp_stm = new StreamReader("Assets/Data/Weapons.csv");

    //    while (!inp_stm.EndOfStream)
    //    {
    //        string inp_ln = inp_stm.ReadLine();
    //        stringList.Add(inp_ln);
    //    }

    //    inp_stm.Close();

    //    parseList(ID);
    //}

    //void parseList(int ID)
    //{
    //    for (int i = 0; i < stringList.Count; i++)
    //    {
    //        parsedList = stringList[i].Split(',');

    //        if (int.Parse(parsedList[0]) == ID)
    //            break;
    //    }

    //}
}
