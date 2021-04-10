using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent<GameObject> DeathEvent;

    internal TowerType Type { get => type; set => type = value; }

    public void Start()
    {
        PayCost();
        updateHealth();
    }

    public void PayCost()
    {
        ResourceSystem.Instance.AddEnergy(energyCost);
        ResourceSystem.Instance.AddOre(-oreCost);
        ResourceSystem.Instance.AddPlutonium(-plutoniumCost);
    }

    
    public void updateHealth()
    {
        healthBar.SetHealth(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        updateHealth();
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        DeathEvent.Invoke(this.gameObject);
        DeathEvent.RemoveAllListeners();
    }

}
