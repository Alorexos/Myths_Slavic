using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    enum WeaponTypes {Sword,Axe,Mace,Spear,Bow};

    [SerializeField]
    private WeaponTypes WeaponType;
    [SerializeField]
    private int BaseMinDamage;
    [SerializeField]
    private int BaseMaxdamage;

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
        //gameObject.GetComponent<BoxCollider>().isTrigger = false;
        p_sMonster = other.GetComponentInParent<Monster>();
        p_sMonster.fntDamage(Random.Range(BaseMinDamage,BaseMaxdamage));
        if (ExDmgType != "")
        {
            p_sMonster.fntDamage(2, "FIRE");
        }
    }
}
