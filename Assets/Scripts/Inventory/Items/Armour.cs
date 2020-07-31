using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : Item
{
    public string ArmourType { get; protected set; }
    public int Defence { get; protected set; }
    public int BaseMaxDamage { get; protected set; }

    public Armour(string[] Data)
    {
        ID = int.Parse(Data[0]);
        Name = Data[1];
        ArmourType = Data[2];
        ItemQuality = Data[3];
        Description = Data[4];
        Defence = int.Parse(Data[5]);
        PrefabDir = Data[6];
    }
}
