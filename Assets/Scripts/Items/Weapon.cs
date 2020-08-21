﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public string WeaponType { get; protected set; }
    public int BaseMinDamage { get; protected set; }
    public int BaseMaxDamage { get; protected set; }

    public void Initialise(int id)
    {
        
        ID = id;
        Type = ItemsType.Weapon;
        Data = ItemDatabase.Instance.GetItem(id, Type);
        Name = Data[1];
        WeaponType = Data[2];
        ItemQuality = Data[3];
        Description = Data[4];
        BaseMinDamage = int.Parse(Data[5]);
        BaseMaxDamage = int.Parse(Data[6]);
        PrefabDir = Data[7];
    }
}
