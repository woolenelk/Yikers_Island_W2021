using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TowerType
{
    WALL,
    ATTACKING,
    MINING,
    ATOMIC,
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
}
