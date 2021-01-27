using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    private static ResourceSystem _instance;

    public static ResourceSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ResourceSystem>();
            }
            return _instance;
        }
    }

    // Resources
    private int Gold;
    private int Ore;
    private int Energy;

    int GetGold()
    {
        return Gold;
    }
    void SetGold(int gold)
    {
        Gold = gold;
    }
    int GetOre()
    {
        return Ore;
    }
    void SetOre(int ore)
    {
        Ore = ore;
    }
    int GetEnergy()
    {
        return Energy;
    }
    void SetEnergy(int energy)
    {
        Energy = energy;
    }

}
