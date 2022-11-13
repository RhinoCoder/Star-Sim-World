using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Seller : MonoBehaviour
{
     public Shop shop;
     [SerializeField] private GameObject[] items;
     private void Start()
     {
          items = GameObject.FindGameObjectsWithTag("Item");
     }

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.gameObject.CompareTag("Player"))
          {
               foreach (var item in items)
               {
                    item.GetComponent<Item>().bank = other.GetComponent<Bank>();
               }
               shop.bank = other.GetComponent<Bank>();

          }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
          shop.CloseShop();
     }
}
