using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Favour : MonoBehaviour
{

    private float fFavour;
    private RectTransform rtBar;
    public float fIncPos;
    public float fDecPos;
    // Start is called before the first frame update
    void Start()
    {
        rtBar = GetComponent<RectTransform>();
        //Debug.Log(rtBar.rect.width);
        fIncPos = (rtBar.rect.width) / 200;
        fDecPos = fIncPos * -1;
        rtBar.localPosition = new Vector3(rtBar.localPosition.x + 100 * fDecPos, rtBar.localPosition.y, rtBar.localPosition.z);
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
