using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TowerType
{
    WALL,
    ATTACKING,
    RESOURCE,
    TOWER_COUNT
}
public class Tower : MonoBehaviour
{
    [SerializeField]
    private TowerType m_type;
    [SerializeField]
    private int m_goldCost;
    [SerializeField]
    private int m_oreCost;
    [SerializeField]
    private int m_energyCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
