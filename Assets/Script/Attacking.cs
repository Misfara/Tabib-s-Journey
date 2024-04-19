using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    
    Animator animator;
    BoxCollider2D boxCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    
         void Update()
    {
        Attack();
    }
    
        

        
    public void Attack(){
        if (Input.GetMouseButtonDown(0)){
            
        }

        

    }

    
}

