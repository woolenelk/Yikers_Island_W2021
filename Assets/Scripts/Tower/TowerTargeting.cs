using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    [SerializeField]
    float Range;
    [SerializeField]
    SphereCollider sphereCollider;
    [SerializeField]
    List<GameObject> EnemysInRange;
    [SerializeField]
    GameObject currentEnemyTarget;

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
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = Range;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentEnemyTarget == null || !EnemysInRange.Contains(currentEnemyTarget))
            ChooseNewTarget();
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
        float closestDistance = Vector3.Distance(transform.position, EnemysInRange[0].transform.position);
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
}
