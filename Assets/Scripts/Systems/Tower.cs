using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TowerType
{
    WALL,
    ATTACKING,
    MINING,
    ATOMIC,
    HUB,
    TOWER_COUNT
}
public class Tower : MonoBehaviour
{
    [SerializeField]
    private TowerType type;
    [SerializeField]
    public int plutoniumCost;
    [SerializeField]
    public int oreCost;
    [SerializeField]
    public int energyCost;

    public int currentHP;
    public int maxHP;

    public HealthBar healthBar;

    internal TowerType Type { get => type; set => type = value; }

    public void Start()
    {
        PayCost();
    }

    public void PayCost()
    {
        ResourceSystem.Instance.AddEnergy(energyCost);
        ResourceSystem.Instance.AddOre(-oreCost);
        ResourceSystem.Instance.AddPlutonium(-plutoniumCost);
    }

    public void FixedUpdate()
    {
        updateHealth();
    }
    public void updateHealth()
    {
        healthBar.SetHealth(currentHP, maxHP);
    }

}
