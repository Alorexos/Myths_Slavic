using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum QualityTypes {Common,Uncommon,Rare,Epic,Set,Legendary};
    enum ItemTypes {Weapon,Armour,Food};

    [SerializeField]
    private ItemTypes ItemType;
    [SerializeField]
    private string ItemName;
    [SerializeField]
    private string ItemDescription;
    [SerializeField]
    private QualityTypes ItemQuality;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
