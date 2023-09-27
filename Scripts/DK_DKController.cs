using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_DKController : MonoBehaviour
{
    public Transform barrelSpawn;
    public Rigidbody barrel;
    public Animator anim;
    public Transform enemyTrans;
    public Transform lookAt;
    public Rigidbody dkBody;
    public Transform dkSpawn;
    public DK_ScoreScript game;

    // Start is called before the first frame update
    void Start()
    {
        //slam animation upon start of level
        anim.Play("MK_stabJumpFward");
        enemyTrans = GetComponent<Transform>();

    }

    private void Awake()
    {
        game = FindObjectOfType<DK_ScoreScript>();
        //Begins throwing barrels
        InvokeRepeating("Throw", 4f, game.throwSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Throw()
    {
        anim.Play("MK_quickSwipe");
        enemyTrans.rotation=Quaternion.LookRotation(enemyTrans.position - lookAt.position);
        Rigidbody barrelInstance;
        barrelInstance = Instantiate(barrel, barrelSpawn.position, barrelSpawn.rotation) as Rigidbody;
        Vector3 moveBarrel = barrelSpawn.up + barrelSpawn.right;
        barrelInstance.AddForce(moveBarrel * 1200);
    }


}
