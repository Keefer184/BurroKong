using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_DontDestroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<DK_DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DK_DontDestroy>()[i] != this)
            {
                if (Object.FindObjectsOfType<DK_DontDestroy>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }


}
