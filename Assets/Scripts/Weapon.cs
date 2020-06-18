using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum WeaponTypes { Sword, Axe, Mace, Spear, Bow };

    [SerializeField]
    private WeaponTypes WeaponType;
    [SerializeField]
    private int BaseMinDamage;
    [SerializeField]
    private int BaseMaxdamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
