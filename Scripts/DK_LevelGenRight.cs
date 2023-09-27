using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DK_LevelGenRight : MonoBehaviour
{
    public GameObject [] rightPrefabs;
    public Transform placeHolder;
    public DK_ScoreScript game;
    private int randomIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        placeHolder = GetComponent<Transform>();
        game = FindObjectOfType<DK_ScoreScript>();
        randomIndex = UnityEngine.Random.Range(0, Math.Min(game.round - 1, rightPrefabs.Length));
    }

    void Start()
    {
        GenerateRight();
        
    }

 
    void GenerateRight()
    {
        GameObject rightInstance = Instantiate(rightPrefabs[randomIndex], placeHolder.position, placeHolder.rotation) as GameObject;
    }

    
}
