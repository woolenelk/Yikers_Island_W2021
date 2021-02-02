using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum PREF_TARGET { WALL, TOWER, RESOURCE, HUB};

public class EnemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    
    [SerializeField]
    int HP;
    [SerializeField]
    float range;
    [SerializeField]
    float damage;
    [SerializeField]
    PREF_TARGET targetting;
    [SerializeField]
    SphereCollider sphereCollider;
    [SerializeField]
    GameObject currentTarget;

    private void OnTriggerEnter(Collider other)
    {
        if(!currentTarget.CompareTag("HUB"))
        {
            return;
        }
        switch(targetting)
        {
            case PREF_TARGET.WALL:
                Debug.Log("Start Targetting");
                if(other.CompareTag("Wall"))
                {
                    currentTarget = other.gameObject;
                    Debug.Log("Found Target");

                }
                break;
            case PREF_TARGET.TOWER:
                if (other.CompareTag("Tower"))
                {
                    currentTarget = other.gameObject;
                }
                break;
            case PREF_TARGET.RESOURCE:
                if (other.CompareTag("Resource"))
                {
                    currentTarget = other.gameObject;
                }
                break;
            case PREF_TARGET.HUB:
                break;
        }
        agent.SetDestination(currentTarget.transform.position);
        Debug.Log("Set Destination");

    }

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = GameObject.FindGameObjectWithTag("HUB");
        target = GameObject.FindGameObjectWithTag("HUB").transform;
        agent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(currentTarget == null)
        {
            //target = GameObject.FindGameObjectWithTag("HUB").transform;
            //agent.SetDestination(target.position);
        }
        if (distance > 1.5)
        {
            agent.updatePosition = true;
            //agent.SetDestination(target.position);
        }
        else
        {
            agent.updatePosition = false;
        }
    }
}
