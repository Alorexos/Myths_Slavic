using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public string ConsumableType { get; protected set; }
    public string Effect { get; protected set; }
    public int Value { get; protected set; }

    public Consumable(string[] Data)
    {
        ID = int.Parse(Data[0]);
        Name = Data[1];
        ConsumableType = Data[2];
        ItemQuality = Data[3];
        Description = Data[4];
        Effect = Data[5];
        Value = int.Parse(Data[6]);
        PrefabDir = Data[7];
    }
}
