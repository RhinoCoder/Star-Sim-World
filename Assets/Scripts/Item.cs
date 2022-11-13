using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemCost;
    public Image itemImage;
    public Bank bank;

    
    [SerializeField] private Image itemIcon; 
    [SerializeField] private TMP_Text itemDescription;
    

    private void Start()
    {
        ShowItemDescription();
    }

    
    public void ShowItemDescription()
    {
        itemImage = itemIcon;
        itemDescription.text = ($"Cost:{itemCost} | {itemName}" );
    }
    
    public void BuyItem()
    {
        
        if (bank.goldAmount >= itemCost)
        {
            
            bank.DecreaseGoldAmount(itemCost);
            bank.UpdateGoldDisplay();
            bank.playerInventory.Add(this);
            Debug.Log("You have purchased the item.");
        }
        
        
        
    }

    
}
