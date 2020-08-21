using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot: MonoBehaviour, IPointerClickHandler
{
    private GameObject Player;
    private Item SlotItem; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Player.GetComponent<EquipmentManager>().Equip(SlotItem, EquipmentSlot.LeftHand);
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Middle click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Player.GetComponent<EquipmentManager>().Equip(SlotItem, EquipmentSlot.RightHand);
            
        }
    }

    public void AddSlot(Item item)
    {
        SlotItem = item;
        transform.GetChild(0).GetComponent<Text>().text = item.Name;
        transform.GetChild(1).GetComponent<Text>().text = item.Stack.ToString();
        SetQuality(item.ItemQuality);

        switch (item.Type)
        {
            case ItemsType.Weapon:
                SlotInfoExtra((Weapon)item);
                break;
            case ItemsType.Armour:
                SlotInfoExtra((Armour)item);
                break;
            case ItemsType.Consumable:
                SlotInfoExtra((Consumable)item);
                break;
        }
    }

    private void SlotInfoExtra(Weapon item)
    {
        transform.GetChild(2).GetComponent<Text>().text = item.BaseMinDamage.ToString();
        transform.GetChild(3).GetComponent<Text>().text = item.BaseMaxDamage.ToString();
    }

    private void SlotInfoExtra(Armour item)
    {
        transform.GetChild(2).GetComponent<Text>().text = item.Defence.ToString();
        transform.GetChild(3).GetComponent<Text>().text = "";
    }
    
    private void SlotInfoExtra(Consumable item)
    {
        transform.GetChild(2).GetComponent<Text>().text = "";
        transform.GetChild(3).GetComponent<Text>().text = "";
    }

    //private void SetupSlotInfo()
    //{
    //    transform.GetChild(0).GetComponent<Text>().text = WeaponItem.Name;
    //    transform.GetChild(1).GetComponent<Text>().text = count.ToString();
    //}


    //private void SetupSlotInfo()
    //{
    //    transform.GetChild(0).GetComponent<Text>().text = WeaponItem.Name;
    //    transform.GetChild(1).GetComponent<Text>().text = count.ToString();
    //}

    private void SetQuality(string quality)
    {
        Image SlotBackground = GetComponent<Image>();

        switch(quality)
        {
            case "Common":
                SlotBackground.color = Color.white;
                break;
            case "Rare":
                SlotBackground.color = new Color32(40,142,225,255);
                break;
            case "Epic":
                SlotBackground.color = new Color32(130,40,225,255);
                break;
            case "Legendary":
                SlotBackground.color = new Color32(225,71,0,255);
                break;

        }
    }
}
