using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
     public Shop shop;


     private void OnTriggerExit2D(Collider2D other)
     {
          shop.CloseShop();
     }
}
