using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicTower : Tower
{
    
    private void Awake()
    {
        Type = TowerType.ATOMIC;
        //plutoniumCost = 20;
    }

    private void Start()
    {
        PayCost();
        //StartCoroutine(Building());
        //ResourceSystem.Instance.AddEnergy(2);
        //maxHP = 20;
        //currentHP = maxHP;
        //healthBar.SetHealth(currentHP, maxHP);
        ResourceSystem.Instance.AtomicTowerSpawned();
    }

    private void Update()
    {
        updateHealth();
    }

    //IEnumerator Building() // we can add animation for building here
    //{
    //    ResourceSystem.Instance.SetPlutonium(ResourceSystem.Instance.GetPlutonium() - plutoniumCost);
    //    yield return new WaitForSeconds(5f);
    //}

}
