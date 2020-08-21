using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using System.IO;

public class Item: ScriptableObject
{
    public int ID { get; protected set; }
    public ItemsType Type { get; protected set; }
    public int Stack { get; set; } = 1;
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string ItemQuality { get; protected set; }
    public string PrefabDir { get; protected set; }

    protected string[] Data;

}
