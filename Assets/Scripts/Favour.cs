using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Favour : MonoBehaviour
{
    public float MaxPosition;
    public float MinPosition;
    public float ZeroPosition;


    private float fFavour;
    private RectTransform rtBar;
    public float fIncPos;
    public float fDecPos;
    // Start is called before the first frame update
    void Start()
    {
        fIncPos = (Mathf.Abs(MaxPosition) + Mathf.Abs(ZeroPosition)) / 100;
        fDecPos = fIncPos * -1;
        rtBar = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetFavour()
    {
        return fFavour;
    }

    public void IncreaseFavour(float Val)
    {

        fFavour += Val;
        rtBar.localPosition = new Vector3(rtBar.localPosition.x + Val * fIncPos, rtBar.localPosition.y, rtBar.localPosition.z);
    }
    public void DecreaseFavour(float Val)
    {

        fFavour -= Val;
        rtBar.localPosition = new Vector3(rtBar.localPosition.x + Val * fDecPos, rtBar.localPosition.y, rtBar.localPosition.z);
    }
}
