using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float HAxis;

    float ZAxis;



    UnityEngine.Vector2 direction ;

    Rigidbody2D rb;

     [SerializeField]
    float speed = 3;

    [SerializeField]
    float DashPower = 5;

    
    

    [SerializeField] bool isDashing = false;

    [SerializeField]float JumpPower = 3;

    [SerializeField]
    bool OnGround = true ;

    Animator animator;

    [SerializeField]TrailRenderer tr;
    
    private bool canDash = true;

    ChargeAttack chargeAttack;
   
   
    private float dashingTime = 0.2f;

    [SerializeField]private float dashingCooldown =1f;


    [SerializeField] private Cooldown cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        chargeAttack = GetComponent<ChargeAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    
      if(isDashing){
        return;
      }
        Movement();
        Dash();
        facing();
        Dashing();
        Jump();
        animations();
        
    }

void Dash(){
    if(Input.GetKeyDown(KeyCode.LeftShift)&& canDash){
        StartCoroutine(Dashing());
    }
}

    private IEnumerator Dashing(){
        canDash = false;
        isDashing = true;
        rb.velocity = new UnityEngine.Vector3 (HAxis,ZAxis)*DashPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.velocity = new UnityEngine.Vector3 (0,0);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash=true;
        
    }

    
    

    public void Movement()
    {
        //Player Input
        HAxis = Input.GetAxis("Horizontal");
        direction = new UnityEngine.Vector2 (HAxis,0); 
        transform.Translate ( direction* Time.deltaTime *speed);
        

        ZAxis = Input.GetAxis("Vertical");
        direction = new UnityEngine.Vector2 (0,ZAxis); 
        transform.Translate ( direction* Time.deltaTime *speed);
       
       
    }
     

    void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space)&& OnGround == true)
        {
                rb.velocity = new UnityEngine.Vector3 (0,0,0)* JumpPower;    
        }
    }

    private void OnTriggerExit(Collider col){
        if(col.tag == "Ground"){
           OnGround = false;    
        }
    }

    private void OnTriggerEnter(Collider col){
        if(col.tag == "Ground"){
           OnGround = true;    
        }
    }


    void facing(){
        // is player going left scale = -1
        if(HAxis < 0 ){
            transform.localScale = new UnityEngine.Vector3 (-1,1,1);
           
        } else if(HAxis > 0 ){
            transform.localScale = new UnityEngine.Vector3 (1,1,1);
            
        }
        // is player doing right scale = 1
    }

    void animations(){
        // if player if moving 
        animator.SetFloat("RightLeft", Mathf.Abs(HAxis));
        animator.SetFloat("UpDown",Mathf.Abs(ZAxis)); 
        animator.SetBool("Dash",isDashing);
        
        }
    
}
