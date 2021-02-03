using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TargetStyle
{
    Single_RetargetOutRange, 
    Single_RetargetOnFrame
}

public class TowerTargeting : MonoBehaviour
{
    [SerializeField]
    TargetStyle targetStyle = TargetStyle.Single_RetargetOutRange;
    [SerializeField]
    int AttacksPerSecond;
    [SerializeField]
    float timer;
    [SerializeField]
    int Damage;
    [SerializeField]
    float Range;
    [SerializeField]
    GameObject currentEnemyTarget;
    [SerializeField] 
    SphereCollider sphereCollider;
    [SerializeField] 
    List<GameObject> EnemysInRange;
    
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Entered");
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy");
            if (!EnemysInRange.Contains(other.gameObject))
            {
                Debug.Log("Enemy Added");
                EnemysInRange.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (EnemysInRange.Contains(other.gameObject))
            EnemysInRange.Remove(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = Range;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetStyle == TargetStyle.Single_RetargetOutRange)
        {
            if (currentEnemyTarget == null || !EnemysInRange.Contains(currentEnemyTarget))
            { ChooseNewTarget(); }
        }
        else if (targetStyle == TargetStyle.Single_RetargetOnFrame)
        {
            ChooseNewTarget();
        }

        //Draw lines to Each enemy in Range
        foreach (GameObject Enemy in EnemysInRange)
        {
            Debug.DrawLine(transform.position, Enemy.transform.position, Color.blue, Time.deltaTime);
        }
        if (currentEnemyTarget != null)
        {
            Debug.DrawLine(transform.position, currentEnemyTarget.transform.position, Color.red, Time.deltaTime + 0.01f);
        }
    }

    void ChooseNewTarget()
    {

        if (EnemysInRange.Count == 0)
        {
            currentEnemyTarget = null;
            return;
        }
        // Check for Closest Enemy
        float closestDistance = 10000000;
        if (EnemysInRange[0] != null)
            closestDistance = Vector3.Distance(transform.position, EnemysInRange[0].transform.position);
        GameObject Target = EnemysInRange[0];
        foreach (GameObject Enemy in EnemysInRange)
        {
            if (Vector3.Distance(transform.position, Enemy.transform.position) <= closestDistance )
            {
                closestDistance = Vector3.Distance(transform.position, Enemy.transform.position);
                Target = Enemy;
            }
        }
        currentEnemyTarget = Target;
    }

    private void Update()
    {
        if (currentEnemyTarget == null)
            return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && currentEnemyTarget != null)
        {
            currentEnemyTarget.GetComponent<EnemyAI>().TakeDamage(Damage);
            timer = 1.0f / AttacksPerSecond;
            
        }
    }
}
