using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knight : MonoBehaviour
{

    public float vitesseDeplacement = 2f;
    private float vitesseSaut = 5f;

    private Animator anim_knight;
    private Rigidbody2D rb_knight;
    private Collider2D collider_knight;

    private float scaleHero;
    private int direction = 1;
    private float mouvement = 0f;



    void Start()
    {
        anim_knight = GetComponent<Animator>();
        rb_knight = GetComponent<Rigidbody2D>();
        collider_knight = GetComponent<Collider2D>();

        scaleHero = transform.localScale.x;

    }

    
    void Update()
    {
        Deplacement();
        Saute();
        FlipKnight();
    }

    void Deplacement()
    {
        float mouvementHorizontal = Input.GetAxisRaw("Horizontal");
        rb_knight.velocity = new Vector2(mouvementHorizontal * vitesseDeplacement, rb_knight.velocity.y);

        anim_knight.SetFloat("Walk", Mathf.Abs(mouvementHorizontal));

        if (Input.GetKey("left shift"))
        {
            vitesseDeplacement = 5f;
            anim_knight.SetBool("Run", true);

        }else
        {
            vitesseDeplacement = 2f;
            anim_knight.SetBool("Run", false);
        }
        
        
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
            Debug.Log("je saute");
            rb_knight.velocity = new Vector2(0, vitesseSaut);
            anim_knight.SetTrigger("Jump");
        }

    }

    void FlipKnight(){
        mouvement = Input.GetAxis("Horizontal");
        transform.localScale = new Vector2(scaleHero * direction, scaleHero);
        if(mouvement > 0)
        {
            direction = 1;
        }else if(mouvement < 0){
            direction = -1;
        }
    }

    














}
