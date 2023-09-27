using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_Barrel : MonoBehaviour
{
    public Rigidbody rbody;
    public Transform barrel;
    public CapsuleCollider barrelCollider;
    public Transform barrelSpawn;
    public bool hasBeenJumped;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        barrel = GetComponent<Transform>();
        barrelCollider = GetComponent<CapsuleCollider>();
        hasBeenJumped = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Destroys barrels on impact of player and when they've left the map
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0f);
        }
    }


}
