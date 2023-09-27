using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_PlayerController : MonoBehaviour
{
    public CapsuleCollider capsuleCollider;
    public Rigidbody rbody;
    public Transform player;
    public float speed=15f;
    public Transform spawner;
    private bool isJumping = false;
    public bool isSwinging = false;
    public DK_ScoreScript game; 
    public DK_SceneChanger deathScene;
    public Animation playerAnimations;
    public AudioSource jumpNoise;
    public AudioSource swingNoise;
    public AudioSource deathNoise;
    public ParticleSystem dirt;
 


    

    // Start is called before the first frame update
    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rbody = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
        playerAnimations = GetComponent<Animation>();
        game = FindObjectOfType<DK_ScoreScript>();
    }


    private void FixedUpdate()
    {
        ParticleSystem[] playerParticles = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < playerParticles.Length; i++)
        {
            if (playerParticles[i].name == "dirt")
            {
                dirt = playerParticles[i];
            }

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (game.lives > 0)
        {
            //Movement
            float moveHoriz = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHoriz, 0f, 0f);
            if (movement != Vector3.zero)
            {
                player.rotation = Quaternion.LookRotation(movement);
                rbody.AddForce(movement * speed);
            }
            if (isJumping == false && isSwinging == false)
            {
                if (rbody.velocity.x != 0)
                {
                    playerAnimations.Play("Run");
                    dirt.Play();
                }
                else
                {
                    playerAnimations.Play("idle");
                    dirt.Stop();
                }

            }

            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isJumping == false && isSwinging == false)
                {
                    isJumping = true;
                    playerAnimations.Play("Jump", PlayMode.StopAll);
                    jumpNoise.Play();
                    rbody.AddForce(player.up * 2000);
                }
            }

            //Attack
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (isSwinging == false && isJumping == false && rbody.velocity.magnitude < 2)
                {
                    isSwinging = true;
                    playerAnimations.Play("Attack", PlayMode.StopAll);
                    swingNoise.Play();
                }
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                isSwinging = false;
                swingNoise.Stop();
            }

        }
        else
        {
            deathScene.GameOver();
        }

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        //reset to jump only after hitting ground again
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
        //kill player conditions
        if (collision.gameObject.tag == "Boundary"|| collision.gameObject.tag=="Projectile")
        {
            Death();
        }
        //Wins game by reaching princess
        if (collision.gameObject.tag == "Collectable")
        {
            if (game.round < 10)
            {
                game.NextRound();
                deathScene.GoToMainScene();
            }
            else
            {
                game.SetHighScore();
                deathScene.GameWin();
            }
            
        }

    }


    private void Death()
    {
        //loses life and respawns character
        game.LoseLife();
        deathNoise.Play();
        Destroy(gameObject, 0.1f);
        Rigidbody playerInstance;
        playerInstance = Instantiate(rbody, spawner.position, rbody.rotation)as Rigidbody;

    }


}
