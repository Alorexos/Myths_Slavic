using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item
{
    public string ArmourType { get; protected set; }
    public int Defence { get; protected set; }
    public int BaseMaxDamage { get; protected set; }

    public void Initialise(string[] data)
    {
        ID = int.Parse(data[0]);
        Type = ItemsType.Armour;
        Name = data[1];
        ArmourType = data[2];
        ItemQuality = data[3];
        Description = data[4];
        Defence = int.Parse(data[5]);
        PrefabDir = data[6];
    }

    public static Armour CreateInstance(string[] data)
    {
        Armour instance = ScriptableObject.CreateInstance<Armour>();
        instance.Initialise(data);
        return instance;
    }
}
