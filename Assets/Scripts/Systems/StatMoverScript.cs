using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMoverScript : MonoBehaviour
{

    private StatMoverScript() { }

    private static StatMoverScript instance;
    public static StatMoverScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatMoverScript>();
            }
            return instance;
        }
        private set { }
    }


    public bool LookControlsInverted = false;

    public int WaveReached;

    

    // Start is called before the first frame update
    void Start()
    {
        StatMoverScript[] statMovers = FindObjectsOfType<StatMoverScript>();
        foreach (StatMoverScript mover in statMovers)
        {
            if (mover != Instance)
            {
                Destroy(mover.gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    
}
