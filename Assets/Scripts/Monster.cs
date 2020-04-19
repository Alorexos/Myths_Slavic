using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Health;

    private float fFinalDamage;
    private float fPhysicalResistance;
    private float fLightningResistance;
    private float fFireResistance;
    private float fWindResistance;
    private float fNecroticResistance;
    private float fLightResistance;
    private float fShadowResistance;

    // Start is called before the first frame update
    void Start()
    {
        fPhysicalResistance = 20.0f;
        fLightningResistance = 0.0f;
        fFireResistance = 50.0f;
        fWindResistance = 0.0f;
        fNecroticResistance = 0.0f;
        fLightResistance = 0.0f;
        fShadowResistance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void fntDamage(float fDamage,string sDmgType)
    {
        switch (sDmgType)
        {
            case "PHYSICAL":
                fFinalDamage = fDamage * ((100 - fPhysicalResistance) / 100);
                Health -= fFinalDamage;
                Debug.Log("Physical: " + fFinalDamage + " (Resisted: " + (fDamage - fFinalDamage) + ")");
                break;
            case "FIRE":
                fFinalDamage = fDamage * ((100 - fFireResistance) / 100);
                Health -= fFinalDamage;
                Debug.Log("Fire: " + fFinalDamage + " (Resisted: " + (fDamage - fFinalDamage) + ")");
                break;

        }
    }
}
