using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Music : MonoBehaviour
{
    //запрет на уничтожение GO - splashScreenMusic
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
   
}
