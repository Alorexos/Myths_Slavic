using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponType;
    public int BaseMinDamage;
    public int BaseMaxdamage;

    private Monster p_sMonster;
    private PlayerStats p_sPlayerStats;
    private string ExDmgType;

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

        p_sMonster = other.GetComponent<Monster>();
        p_sMonster.fntDamage(Random.Range(BaseMinDamage,BaseMaxdamage));
        if (ExDmgType != "")
        {
            p_sMonster.fntDamage(2, "FIRE");
        }
    }
}
