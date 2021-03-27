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

    private CameraController CameraController;

    public KeyboardSpawner Spawner;
    public LayerMask SpawnLayer;


    // Start is called before the first frame update
    void Start()
    {
        CameraController = FindObjectOfType<CameraController>();

        name = gameObject.name;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   //old code from phoenix
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The tower is: " + gameObject.name);
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, SpawnLayer))
        {
            transform.position = hit.point + offset;
        }

        
    }

    public void OnPlaceTower()
    {
        if (Spawner != null)
        {
            Spawner.CurrentlySelectedTower = null;

        }

        if (name == "TowerTransparentUpright(Clone)" 
            && ResourceSystem.Instance.GetEnergy() < ResourceSystem.Instance.EnergyMax 
            && ResourceSystem.Instance.GetOre() >= 20)
        {
                Instantiate(AttackTower, transform.position, transform.rotation);
                Destroy(gameObject);
        }

        if (name == "Mining Tower Transparent(Clone)" && ResourceSystem.Instance.GetEnergy() < ResourceSystem.Instance.EnergyMax)
        {
                Instantiate(MiningTower, transform.position, transform.rotation);
                Destroy(gameObject);
        }

        if (name == "AtomicTower Transparent(Clone)" && ResourceSystem.Instance.GetPlutonium() >= 20)
        {
                Instantiate(AtomicTower, transform.position, transform.rotation);
                Destroy(gameObject);
        }

        if (name == "Wall Transparent(Clone)" && ResourceSystem.Instance.GetOre() >= 5)
        {
                Instantiate(Wall, transform.position, transform.rotation);
                Destroy(gameObject);
        }
    }

}
