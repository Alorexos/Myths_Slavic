using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public string WeaponType { get; protected set; }
    public int BaseMinDamage { get; protected set; }
    public int BaseMaxDamage { get; protected set; }

    private void Initialise(string[] data)
    {
        ID = int.Parse(data[0]);
        Type = ItemsType.Weapon;
        Name = data[1];
        WeaponType = data[2];
        ItemQuality = data[3];
        Description = data[4];
        BaseMinDamage = int.Parse(data[5]);
        BaseMaxDamage = int.Parse(data[6]);
        PrefabDir = data[7];
    }
    public static Weapon CreateInstance(string[] data)
    {
        Weapon instance = ScriptableObject.CreateInstance<Weapon>();
        instance.Initialise(data);
        return instance;
    }
}
