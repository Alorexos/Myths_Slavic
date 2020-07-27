using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour
{

    [SerializeField]
    private GameObject RightHandItem;
    [SerializeField]
    private GameObject WeaponPrefab;
    private GameObject Weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Weapon = Instantiate(WeaponPrefab, RightHandItem.transform) as GameObject;
            //Weapon.transform.localPosition = new Vector3(0, 0, 0);
            //Weapon.transform.localRotation = Quaternion.identity;
            Weapon.GetComponent<Weapon>().Initialise(1);
        }
    }
}
