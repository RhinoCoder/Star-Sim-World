using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{


    [SerializeField] private Dialogue dialogue;
    [SerializeField] private string[] storyLines;
    [SerializeField] private float rangeToPlayer = 1f;
    [SerializeField] private PlayerMovement playerMovement;


    private Sprite playerSprite;
    
    public string npcName;
    public string npcGender;
    public int npcAge;
    public Sprite npcImage;
    
    //Neutral means 50
    // lovely- likely means +50
    // hatred- anger means -50
    public float attitudeTowardPlayer=50f;

    
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerSprite = playerMovement.playerSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GreetPlayer();
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        dialogue.CloseMessage();
    }

    private void GreetPlayer()
    {
        int x = UnityEngine.Random.Range(0, storyLines.Length);
        dialogue.ShowMessage(npcImage,storyLines[x]);
        Debug.Log("Hello player, I am " + npcName);
        
    }

    private void Update()
    {
        PlayerInteraction();
        
    }

    private void PlayerInteraction()
    {
        float currentDistance = Vector3.Distance(playerMovement.transform.position, transform.position);
        if (currentDistance <= rangeToPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogue.ShowMessage(playerSprite,"Hello, " + npcName + "I am , Player how is it going?");
                Debug.Log("IS this think working?");
                
            }
            
        }
        
        
    }
}
