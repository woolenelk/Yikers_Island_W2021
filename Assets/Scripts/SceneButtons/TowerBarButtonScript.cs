using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBarButtonScript : MonoBehaviour
{
    [SerializeField]
    TowerType tower = TowerType.ATOMIC;
    
    public void OnTowerBarButtonPressed()
    {
        switch (tower)
        {
            case TowerType.ATOMIC:
                Debug.Log("Atomic Tower Selected");
                break;
            case TowerType.WALL:
                Debug.Log("Wall Selected");
                break;
            case TowerType.MINING:
                Debug.Log("Mining Tower Selected");
                break;
            case TowerType.ATTACKING:
                Debug.Log("Attacking Tower Selected");
                break;
            default:
                break;
        }
    }
}
