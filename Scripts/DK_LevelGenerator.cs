using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform startingPoint;
    public Transform endingPoint;
    private Transform gridArea;
    private List<Vector3> gridPositions = new List<Vector3>();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InitializeGrid()
    {

    }
}
