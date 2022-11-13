using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public Bank bank;
    
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        DOTween.Init();
    }

    
   
   
    public void OpenShop()
    {
        playerMovement.isGameRunning = false;
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
    }
    
    public void CloseShop()
    {
        playerMovement.isGameRunning = true;
        transform.DOScale(new Vector3(0f, 0f, 0f), 0.5f);
    }
}
