using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    public GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        if (objectToDestroy == null)
            return;
        Destroy(objectToDestroy);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
