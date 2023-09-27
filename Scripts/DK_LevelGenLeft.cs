using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DK_LevelGenLeft : MonoBehaviour
{
    public GameObject[] leftPrefabs;
    public Transform placeHolder;
    public DK_ScoreScript game;
    private int randomIndex;

    private void Awake()
    {
        placeHolder = GetComponent<Transform>();
        game = FindObjectOfType<DK_ScoreScript>();
        randomIndex = UnityEngine.Random.Range(0, Math.Min(game.round - 1, leftPrefabs.Length ));
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateLeft();
    }

    void GenerateLeft()
    {
        GameObject lefttInstance = Instantiate(leftPrefabs[randomIndex], placeHolder.position, placeHolder.rotation) as GameObject;


    }
}
