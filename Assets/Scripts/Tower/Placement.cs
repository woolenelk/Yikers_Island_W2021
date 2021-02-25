using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject AttackTower;
    public GameObject MiningTower;
    public GameObject AtomicTower;
    public GameObject Wall;
    public Vector3 offset = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The tower is: " + gameObject.name);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            transform.position = hit.point + offset;
        }
        if (name == "TowerTransparentUpright(Clone)")
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(AttackTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (name == "Mining Tower Transparent(Clone)")
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(MiningTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (name == "AtomicTower Transparent(Clone)")
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(AtomicTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (name == "Wall Transparent(Clone)")
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(Wall, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
