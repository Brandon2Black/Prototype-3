using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver = false;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
    
       if(collision.gameObject.CompareTag("Obstacle"))
        {
           gameOver = true;
            Debug.Log("you're now getting railed by an obstacle, GAME OVER!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
          
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
        {
          isOnGround = true;
        }
    }
}
