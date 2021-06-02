using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=450;
    public float jumpforce=450;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
       SwitchAnim();
        
    }

    void Movement(){
        float horizontalmove= Input.GetAxis("Horizontal");
        float facedir=Input.GetAxisRaw("Horizontal");
        //角色移动
        if(horizontalmove!=0){
            rb.velocity=new Vector2(horizontalmove*speed*Time.deltaTime,rb.velocity.y);

            anim.SetFloat("running",Mathf.Abs(horizontalmove));
        }

        if(facedir!=0){
            transform.localScale=new Vector3(facedir,1,1);
        }
        //角色跳跃
        if(Input.GetButtonDown("Jump")){
            rb.velocity=new Vector2(rb.velocity.x,jumpforce*Time.deltaTime);
            anim.SetBool("jumping",true);
        }
       // if(Input.GetButton("Submit")){
       //    Physics2D.gravity=new Vector2(0,9.8f );
        //  
      //  }



    }

    void SwitchAnim(){
        if(anim.GetBool("jump")){
            if(rb.velocity.y<0){
                anim.SetBool("jumping",false);
            }
        }
    }
}
