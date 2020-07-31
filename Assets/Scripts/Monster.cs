using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float fHealth;
    public float Armour;
    public float fLightningResistance;
    public float fFireResistance;
    public float fWindResistance;
    public float fNecroticResistance;
    public float fLightResistance;
    public float fShadowResistance;

    private float fFinalDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(fHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void fntDamage(float fDamage)
    {
        fFinalDamage = fDamage * ((100 - Armour) / 100);
        fHealth -= fFinalDamage;
        Debug.Log("Physical: " + fFinalDamage + " (Resisted: " + (fDamage - fFinalDamage) + ")");
    }

    public void fntDamage(float fDamage,string sDmgType)
    {
        switch (sDmgType)
        {
            
            case "FIRE":
                fFinalDamage = fDamage * ((100 - fFireResistance) / 100);
                fHealth -= fFinalDamage;
                Debug.Log("Fire: " + fFinalDamage + " (Resisted: " + (fDamage - fFinalDamage) + ")");
                break;

        }
    }
}
