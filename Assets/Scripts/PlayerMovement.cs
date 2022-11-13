using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Dialogue dialogue;
    
    
    private Vector2 movementAxes;
    private Transform lastPos;
    private PlayerMovement instance;

    
    public Sprite playerSprite;


 
    private void Start()
    {
        if (instance != null && instance != this){Destroy(this);}
        else{instance = this;}
        lastPos = transform;
    }

    private void Update()
    {
        movementAxes.x = Input.GetAxisRaw("Horizontal");
        movementAxes.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        //Movement
        playerRb.MovePosition(playerRb.position + movementAxes*moveSpeed*Time.fixedDeltaTime);
        playerAnim.SetFloat("horizontal",movementAxes.x);
        playerAnim.SetFloat("vertical",movementAxes.y);
        playerAnim.SetFloat("speed",movementAxes.sqrMagnitude);
        
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goToShop"))
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (other.gameObject.CompareTag("goToHall"))
        {
            lastPos = transform;
            DontDestroyOnLoad(this.gameObject);
            OnSceneChangeCharacterHandler();
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.CompareTag("goToEntrance"))
        {
            transform.position = lastPos.position;
            OnSceneChangeCharacterHandler();
            SceneManager.LoadScene(0);
        }

       
        
    }



    private void OnSceneChangeCharacterHandler()
    {
        
        
    }
    
}