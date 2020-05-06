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
        gods.Add("Pierun",GameObject.Find("FavourPierun").GetComponent<Favour>());
        gods.Add("Veles",GameObject.Find("FavourVeles").GetComponent<Favour>());
        gods.Add("Stribog",GameObject.Find("FavourStribog").GetComponent<Favour>());
        gods.Add("Svarog",GameObject.Find("FavourSvarog").GetComponent<Favour>());
        gods.Add("Dazbog",GameObject.Find("FavourDazbog").GetComponent<Favour>());
        gods.Add("Jutrobog",GameObject.Find("FavourJutrobog").GetComponent<Favour>());
        gods.Add("Belobog",GameObject.Find("FavourBelobog").GetComponent<Favour>());
        gods.Add("Chernobog",GameObject.Find("FavourChernobog").GetComponent<Favour>());
        gods.Add("Svetovid",GameObject.Find("FavourSvetovid").GetComponent<Favour>());
        FavourUI = GameObject.Find("FavourText").GetComponent<Text>();
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
            gods["Veles"].IncreaseFavour(1.0f);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            gods["Veles"].DecreaseFavour(1.0f);
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
