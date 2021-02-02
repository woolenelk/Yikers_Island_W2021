using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicTower : Tower
{
    
    private void Awake()
    {
        Type = TowerType.ATOMIC;
        plutoniumCost = 20;
    }

    private void Start()
    {
        StartCoroutine(Building());
        ResourceSystem.Instance.EnergyMax += 1;
    }

    IEnumerator Building() // we can add animation for building here
    {
        ResourceSystem.Instance.SetPlutonium(ResourceSystem.Instance.GetPlutonium() - plutoniumCost);
        yield return new WaitForSeconds(5f);
    }

}