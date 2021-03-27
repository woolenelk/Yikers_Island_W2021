using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    [SerializeField]
    SkinnedMeshRenderer rend;
    [SerializeField]
    MeshRenderer otherRend;


    Material mat;

    private Grid grid;
    RaycastHit hit;
    Vector3 movePoint;

    public GameObject AttackTower;
    public GameObject MiningTower;
    public GameObject AtomicTower;
    public GameObject Wall;
    public Vector3 offset = new Vector3(0, 1, 0);

    private CameraController CameraController;
    private int collisionCount = 0;

    public KeyboardSpawner Spawner;

    public Color holoRed;
    public Color holoGreen;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraController = FindObjectOfType<CameraController>();
        //rend = gameObject.GetComponent<SkinnedMeshRenderer>();

        name = gameObject.name;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   //old code from phoenix
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            transform.position = hit.point;
        }

        if(rend == null)
        {
            Debug.Log("rend is null");
        }

        float intensity = Mathf.Pow(2.0f, 2.61f);
        holoRed = new Color(1 * intensity, 0, 0);
        holoGreen = new Color(0, 1 * intensity, 0);

        if(rend != null)
        {
            mat = rend.material;
        }
        else if(otherRend != null)
        {
            mat = otherRend.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("The tower is: " + gameObject.name);
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);
        

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            TilePlacemnt(hit.point);
        }

        //Old code from phoenix
        //if (name == "TowerTransparentUpright(Clone)")
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        Instantiate(AttackTower, transform.position, transform.rotation);
        //        Destroy(gameObject);
        //    }
        //}

        //if (name == "Mining Tower Transparent(Clone)")
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        Instantiate(MiningTower, transform.position, transform.rotation);
        //        Destroy(gameObject);
        //    }
        //}

        //if (name == "AtomicTower Transparent(Clone)")
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        Instantiate(AtomicTower, transform.position, transform.rotation);
        //        Destroy(gameObject);
        //    }
        //}

        //if (name == "Wall Transparent(Clone)")
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        Instantiate(Wall, transform.position, transform.rotation);
        //        Destroy(gameObject);
        //    }
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        mat.SetColor("_HoloColor", holoRed);
        collisionCount++;
    }

    private void OnCollisionExit(Collision other)
    {
        mat.SetColor("_HoloColor", holoGreen);
        collisionCount--;
    }

    private void TilePlacemnt(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        gameObject.transform.position = finalPosition + offset;
    }

    public void OnPlaceTower()
    {
        if (collisionCount == 0)
        {
            if (Spawner != null)
            {
                Spawner.CurrentlySelectedTower = null;

            }

            if (name == "TowerTransparentUpright(Clone)")
            {
                Instantiate(AttackTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (name == "Mining Tower Transparent(Clone)")
            {
                Instantiate(MiningTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (name == "AtomicTower Transparent(Clone)")
            {
                Instantiate(AtomicTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (name == "Wall Transparent(Clone)")
            {
                Instantiate(Wall, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}
