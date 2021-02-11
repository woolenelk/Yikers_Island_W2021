using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTower : Tower
{
    private void Awake()
    {
        Type = TowerType.HUB;
        energyCost = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(currentHP, maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHP, maxHP);
    }
}
