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
    public bool isGameRunning = true;


    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        if (objs.Length > 1){Destroy(this.gameObject);}

        dialogue = FindObjectOfType<Dialogue>();

        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Update()
    {
        if (!isGameRunning){return;}
        CalculateAxes();
    }

    private void FixedUpdate()
    {
        if (isGameRunning){PlayerMovementHandler();}
        
    }

    private void CalculateAxes()
    {
        movementAxes.x = Input.GetAxisRaw("Horizontal");
        movementAxes.y = Input.GetAxisRaw("Vertical");
    }
    private void PlayerMovementHandler()
    {
        //Movement
        playerRb.MovePosition(playerRb.position + movementAxes * moveSpeed * Time.fixedDeltaTime);
        playerAnim.SetFloat("horizontal", movementAxes.x);
        playerAnim.SetFloat("vertical", movementAxes.y);
        playerAnim.SetFloat("speed", movementAxes.sqrMagnitude);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goToShop"))
        {
             
            SceneManager.LoadScene(2);
        }

        if (other.gameObject.CompareTag("goToHall"))
        {
             
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.CompareTag("goToEntrance"))
        {
             
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.CompareTag("Seller"))
        {
            other.GetComponent<Seller>().shop.OpenShop();
        }
        
    }
    
}