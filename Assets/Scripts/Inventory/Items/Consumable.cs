using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public string ConsumableType { get; protected set; }
    public string Effect { get; protected set; }
    public int Value { get; protected set; }

    public void Initialise(string[] data)
    {
        ID = int.Parse(data[0]);
        Type = ItemsType.Consumable;
        Name = data[1];
        ConsumableType = data[2];
        ItemQuality = data[3];
        Description = data[4];
        Effect = data[5];
        Value = int.Parse(data[6]);
        PrefabDir = data[7];
    }
}
