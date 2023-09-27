using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_JumpandScore : MonoBehaviour
{
    public SphereCollider jumpDetector;
    public DK_ScoreScript scoring;
    public DK_Barrel barrelJumped;

    void Awake()
    {
        jumpDetector = GetComponent<SphereCollider>();
        scoring = FindObjectOfType<DK_ScoreScript>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //This code is to make it so a barrel is only scored once when being jumped
        if (other.gameObject.tag == "Projectile")
        {
            barrelJumped = other.gameObject.GetComponent<DK_Barrel>();
            if (barrelJumped.hasBeenJumped == false)
            {
                scoring.ScoreJump();
                barrelJumped.hasBeenJumped = true;
            }
            
            
        }

    }
}
