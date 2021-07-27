using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    private float vitesseDeplacement = 3f;
    private float vitesseSaut = 5f;

    private Animator anim_knight;
    private Rigidbody2D rb_knight;
    private Collider2D collider_knight;
   
    void Start()
    {
        anim_knight = GetComponent<Animator>();
        rb_knight = GetComponent<Rigidbody2D>();
        collider_knight = GetComponent<Collider2D>();

    }

    
    void Update()
    {
        Deplacement();
        Saute();
    }

    void Deplacement()
    {
        float mouvementHorizontal = Input.GetAxis("Horizontal");
        rb_knight.velocity = new Vector2(mouvementHorizontal * vitesseDeplacement, rb_knight.velocity.y);
        
    }

    void Saute()
    {
        int quelLayer = LayerMask.GetMask("Sol");
        if (!collider_knight.IsTouchingLayers(quelLayer))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb_knight.velocity = new Vector2(0, vitesseSaut);
        }

    }














}
