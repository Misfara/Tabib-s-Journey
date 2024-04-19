using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
{

    Animator animator;
    public KeyCode Attacking;
    public float ChargeAttackTimer = 0;
    public Sprite attackImage;
    Rigidbody2D rb;

    public bool ischarging = false;
PlayerController playercontroller;



    TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        tr= GetComponent<TrailRenderer>();
        playercontroller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(Attacking)){
            ChargeAttackTimer += Time.deltaTime;
          
            
        }

        charge();
       

        if(Input.GetKeyUp (Attacking) ){
            animator.SetTrigger("Attacking");
            ChargeAttackTimer = 0;
        }
    }

    public void charge(){
        if( ChargeAttackTimer > 0.4 && ChargeAttackTimer <= 1.5){
            animator.SetTrigger("Charge");
            animator.SetTrigger("ChargeAttack");
            ischarging=true;
            
        }   

        }
    
}
