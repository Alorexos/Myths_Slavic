using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour
{
    public string Type;
    private PlayerStats p_sPlayerStats;
    private Weapon p_sWeapon;
    // Start is called before the first frame update
    void Start()
    {
        p_sPlayerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;



    }

}
