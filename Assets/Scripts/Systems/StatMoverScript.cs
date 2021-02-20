using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMoverScript : MonoBehaviour
{
    public int WaveReached;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    
}
