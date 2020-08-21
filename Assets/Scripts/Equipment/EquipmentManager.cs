using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;
public enum EquipmentSlot
{
    RightHand,
    LeftHand,
    Head,
    Shoulders,
    Chest,
    Hands,
    Legs, 
    Feet
}
public class EquipmentManager : MonoBehaviour
{

    [SerializeField]
    private GameObject RightHand;
    [SerializeField]
    private GameObject LeftHand;
    private GameObject RightHandItem;
    private GameObject LeftHandItem;

    //private List<string> stringList;
    //private string[] parsedList;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Equip(Item item, EquipmentSlot slot)
    {
        switch (slot)
        {
            case EquipmentSlot.RightHand:
                if (RightHandItem != null)
                    Unequip(EquipmentSlot.RightHand);
                RightHandItem = Instantiate(Resources.Load(item.PrefabDir), RightHand.transform) as GameObject;
                break;
            case EquipmentSlot.LeftHand:
                if (LeftHandItem != null)
                    Unequip(EquipmentSlot.LeftHand);
                LeftHandItem = Instantiate(Resources.Load(item.PrefabDir), LeftHand.transform) as GameObject;
                break;
        }
    }

    void Unequip(EquipmentSlot slot)
    {
        switch (slot)
        {
            case EquipmentSlot.RightHand:
                Destroy(RightHandItem);
                break;
            case EquipmentSlot.LeftHand:
                Destroy(LeftHandItem);
                break;
        }
    }

}
