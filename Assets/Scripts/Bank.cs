using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    
    [SerializeField] private Image goldImage;
    [SerializeField] private TMP_Text goldText;

    public int goldAmount;
    public List<Item> playerInventory= new List<Item>();


    private Bank instance;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;


        goldText.text = goldAmount.ToString();
    }


    public void UpdateGoldDisplay()
    {
        goldText.text = goldAmount.ToString();
    }

    public void DecreaseGoldAmount(int cost)
    {
        if (goldAmount <= 0)
        {
            return;
        }

        goldAmount -= cost;
    }

    public void IncreaseGoldAmount(int amount)
    {
        goldAmount += amount;
    }

    public void ShowPlayerInventory()
    {
    }
}