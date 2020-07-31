using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using System.IO;

public class Item
{
    public int ID { get; protected set; }
    public string Type { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string ItemQuality { get; protected set; }
    public string PrefabDir { get; protected set; }

}
