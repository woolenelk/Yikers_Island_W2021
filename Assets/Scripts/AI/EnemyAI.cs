using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum PREF_TARGET { WALL, TOWER, RESOURCE, HUB};

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    
    [SerializeField]
    int HP;
    [SerializeField]
    float range;
    [SerializeField]
    float damage;
    [SerializeField]
    int PlutoniumValue;
    [SerializeField]
    PREF_TARGET targetting;
    [SerializeField]
    SphereCollider sphereCollider;
    [SerializeField]
    GameObject currentTarget;
    [SerializeField]
    bool Alive = true; 

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
                    Debug.Log("Found Wall");
                }
                break;
            case PREF_TARGET.TOWER:
                if (other.CompareTag("Tower"))
                {
                    currentTarget = other.gameObject;
                    Debug.Log("Found Tower");
                }
                break;
            case PREF_TARGET.RESOURCE:
                if (other.CompareTag("Resource"))
                {
                    currentTarget = other.gameObject;
                    Debug.Log("Found Resource");
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
        agent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
        agent.SetDestination(currentTarget.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <=0 && Alive)
        {
            Debug.Log("Now Dead");
            agent.updatePosition = false;
            Alive = false;
            Destroy(agent);
            transform.Translate(new Vector3(0, -100, 0));
            GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceSystem>().AddPlutonium(PlutoniumValue);
            StartCoroutine(Death());
        }
        
        if(currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("HUB");
            agent.SetDestination(currentTarget.transform.position);
        }
        Debug.DrawLine(transform.position, currentTarget.transform.position, Color.cyan, Time.deltaTime);
        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
        if (agent == null)
            return;
        if (distance > 2.5)
        {
            //agent.updatePosition = true;
            agent.isStopped = false;
            //agent.SetDestination(target.position);
        }
        else
        {
            //agent.updatePosition = false;
            agent.isStopped = true;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public bool IsAlive()
    {
        return Alive;
    }
}
