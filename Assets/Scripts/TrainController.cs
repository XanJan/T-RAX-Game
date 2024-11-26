using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Windows;
using TMPro;



public class TrainController : MonoBehaviour
{
    private bool onGround = false;
    private float jumpForce = 7f;
    public List<GameObject> vagnar;
    public List<GameObject> charactersStand;
    public List<GameObject> characters;
    public GameManager gameManager;


    private BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (onGround && UnityEngine.Input.GetButtonDown("Jump"))
        {
            jump();
            
        }


        if (UnityEngine.Input.GetButton("Vertical"))
        {
            duck();
        }
        else
        {
            stand();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
            
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstical")){
            gameManager.GameOver();
        }

    }

    private void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        for(int i = 0; i < vagnar.Count; i++) {

            StartCoroutine(WaitTimeCoroutine(i));
            
        }
        onGround = false;

    }
    private void duck()
    {
        collider.size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.18f);
        collider.offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, 0.01f);

        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetActive(true);
            charactersStand[i].SetActive(false);
        }
        
    }

    private void stand()
    {
        collider.size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.28f);
        collider.offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, 0.06f);

        for (int i = 0; i < characters.Count; i++)
        {
            charactersStand[i].SetActive(true);
            characters[i].SetActive(false);
        }

    }

    IEnumerator WaitTimeCoroutine(int i)
    {
        yield return new WaitForSeconds(0.3f + (0.3f * i));
        vagnar[i].GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    }   
