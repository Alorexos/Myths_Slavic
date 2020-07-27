using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Weapon : MonoBehaviour
{
    enum WeaponTypes {Sword,Axe,Mace,Spear,Bow};

    [SerializeField]
    private WeaponTypes WeaponType;
    [SerializeField]
    private int BaseMinDamage;
    [SerializeField]
    private int BaseMaxDamage;

    private Monster p_sMonster;
    private PlayerStats p_sPlayerStats;
    private string ExDmgType;


    private List<string> stringList;
    private string[] parsedList;

    // Start is called before the first frame update
    void Start()
    {
        p_sPlayerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Monster") return;
        //gameObject.GetComponent<BoxCollider>().isTrigger = false;
        p_sMonster = other.GetComponentInParent<Monster>();
        p_sMonster.fntDamage(Random.Range(BaseMinDamage,BaseMaxDamage));
        if (ExDmgType != "")
        {
            p_sMonster.fntDamage(2, "FIRE");
        }
    }

    public void Initialise(int ID)
    {
        stringList = new List<string>();
        readTextFile(ID);
        GetComponent<MeshFilter>().mesh = (Mesh)Resources.Load(parsedList[4], typeof(Mesh));
        BaseMinDamage = int.Parse(parsedList[2]);
        BaseMaxDamage = int.Parse(parsedList[3]);
    }

    void readTextFile(int ID)
    {
        StreamReader inp_stm = new StreamReader("Assets/Data/Axe.csv");

        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            stringList.Add(inp_ln);
        }

        inp_stm.Close();

        parseList(ID);
    }

    void parseList(int ID)
    {
        for(int i = 0; i < stringList.Count; i++)
        {
            parsedList = stringList[i].Split(',');

            if(int.Parse(parsedList[0]) == ID)
                break;
        }

    }
}
