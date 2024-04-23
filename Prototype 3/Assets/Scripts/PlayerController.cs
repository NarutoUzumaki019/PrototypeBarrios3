using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private Animator playerAnim;
    private AudioSource playerAudio;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    public bool isOnGround = true;
    private float speed = 30;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
              
        {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            {
                playerAnim.SetTrigger("Jump_trig");
            }
        }
    }
    public bool gameOver = false;
    public ParticleSystem explosionParticle;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground"))
            
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
            
        {
            explosionParticle.Play();
            dirtParticle.Stop();
        
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }   
    }
}
