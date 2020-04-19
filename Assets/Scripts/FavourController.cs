using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavourController : MonoBehaviour
{
    private bool Visible;
    private Canvas Canvas;
    private RectTransform FavourRod;
    private Dictionary<string,Favour> gods;
    private Vector3 temp;
    public Text FavourUI;
    
    // Start is called before the first frame update
    void Start()
    {
        gods = new Dictionary<string,Favour>();
        gods.Add("Rod",GameObject.Find("FavourRod").GetComponent<Favour>());
        //gods.Add("Pierun",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Veles",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Stribug",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Svarog",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Dazbog",GameObject.Find("FavourRod").GetComponent<GodFavour>());
        //gods.Add("Jutrobog",GameObject.Find("FavourRod").GetComponent<GodFavour>());
        //gods.Add("Belobog",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Chernobog",GameObject.Find("FavourRod").GetComponent<GodFavour>());
       // gods.Add("Svetovid",GameObject.Find("FavourRod").GetComponent<GodFavour>());
        FavourUI = GameObject.Find("Text").GetComponent<Text>();
        Canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (Visible)
            {
                Hide();
                Visible = false;
            }
            else
            {
                Display();
                Visible = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            gods["Rod"].IncreaseFavour(1.0f);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            gods["Rod"].DecreaseFavour(1.0f);
        }
    }
    void Hide()
    {
        Canvas.enabled = false;
    }

    void Display()
    {
        FavourUI.text = null;
        foreach (KeyValuePair<string,Favour> attachStat in gods)
        {
            FavourUI.text = FavourUI.text
                          + attachStat.Key + ": "
                          + attachStat.Value.GetFavour().ToString()
                          + "\n";
        }
        Canvas.enabled = true;
    }
}
