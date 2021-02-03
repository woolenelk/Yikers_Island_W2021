using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private int Plutonium;
    [SerializeField]
    private int Ore;
    [SerializeField]
    private int Energy;
    public int EnergyMax;
    // UI elements
    public Text plutoniumText;
    public Text oreText;
    public Text energyText;

    public int GetPlutonium()
    {
        return Plutonium;
    }
    public void SetPlutonium(int plutonium)
    {
        Plutonium = plutonium;
    }
    public int GetOre()
    {
        return Ore;
    }
    public void SetOre(int ore)
    {
        Ore = ore;
    }
    public int GetEnergy()
    {
        return Energy;
    }
    public void SetEnergy(int energy)
    {
        Energy = energy;
    }

    private void Start() // our starting resources
    {
        Plutonium = 50;
        Ore = 50;
        Energy = 0;
        //EnergyMax = 5;
    }

    private void Update()
    {
        plutoniumText.text = "Plutonium: " + Plutonium.ToString();
        oreText.text = "Ore: " + Ore.ToString();
        energyText.text = "Energy: " + Energy.ToString() + "/" + EnergyMax.ToString();
    }
}
