using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_SwordScore : MonoBehaviour
{
    public SphereCollider swordDetector;
    public DK_ScoreScript scoring;
    public DK_Barrel barrelHit;
    public DK_PlayerController swinging;
    public ParticleSystem sparks;


    // Start is called before the first frame update
    void Awake()
    {
        swordDetector = GetComponent<SphereCollider>();
        scoring = FindObjectOfType<DK_ScoreScript>();
        swinging = FindObjectOfType<DK_PlayerController>();

    }

    private void FixedUpdate()
    {
        ParticleSystem[] playerParticles = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < playerParticles.Length; i++)
        {
            if (playerParticles[i].name == "Sparks")
            {
                sparks = playerParticles[i];
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile" && swinging.isSwinging==true)
        {
            barrelHit = other.gameObject.GetComponent<DK_Barrel>();
            Destroy(other.gameObject, 0f);
            sparks.Play();
            if (barrelHit.hasBeenJumped == false)
            {
                scoring.ScoreSword();
            }
            
            

        }
    }
}
