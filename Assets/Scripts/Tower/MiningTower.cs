using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningTower : Tower
{
    [SerializeField]
    float startTime = 0f;
    [SerializeField]
    float endTime = 5f;
    private void Awake()
    {
        Type = TowerType.ATOMIC;
        energyCost = 1;
    }

    private void Start()
    {
        StartCoroutine(Building());
        maxHP = 20;
        currentHP = maxHP;
        healthBar.SetHealth(currentHP, maxHP);
        ResourceSystem.Instance.SetEnergy(1); // not increasing our energy yet.
    }
    private void Update()
    {
        healthBar.SetHealth(currentHP, maxHP);
        if(startTime >= endTime)
        {
            ResourceSystem.Instance.SetOre(ResourceSystem.Instance.GetOre() + 1); // some bug, adding 2 ore for some reason.
            startTime = 0f;
        }
        startTime += 1 * Time.deltaTime;
    }
    IEnumerator Building()
    {
        ResourceSystem.Instance.SetEnergy(ResourceSystem.Instance.GetEnergy() + energyCost);
        yield return new WaitForSeconds(5f);
    }
}
