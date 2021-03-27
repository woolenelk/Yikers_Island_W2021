using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Towers
{
    public int health;
    public Vector3 postion;
    public Towers()
    {
        health = 0;
        postion = new Vector3();
    }
}

[System.Serializable]
public class TowerList
{
    public List<Towers> ListsOfTowers;
    public TowerList()
    {
        ListsOfTowers = new List<Towers>();
    }
}

[System.Serializable]
public class SaveData
{

    public int plutonium;
    public int ore;
    public int Wave;
    public TowerList AttackTowers;
    public TowerList EnergyTowers;
    public TowerList MiningTowers;
    public TowerList WallTower;

    public SaveData()
    {
        plutonium = 0;
        ore = 0;
        Wave = 1;
        AttackTowers = new TowerList();
        EnergyTowers = new TowerList();
        MiningTowers = new TowerList();
        WallTower = new TowerList();
    }
}

public class SaveLoadManager : MonoBehaviour
{
    [SerializeField]
    ResourceSystem resourceSystem;
    [SerializeField]
    WaveManager waveManager;
    [SerializeField]
    GameObject TowerPrefab;
    [SerializeField]
    GameObject MiningPrefab;
    [SerializeField]
    GameObject AtomicPrefab;
    [SerializeField]
    GameObject WallPrefab;

    SaveData data;
    string s_Data;

    private void Start()
    {
        data = new SaveData();
        s_Data = "";
    }

    public void Save()
    {
        StartCoroutine(SaveNow());
    }

    public void Load()
    {
        StartCoroutine(LoadNow());
    }


    IEnumerator SaveNow()
    {
        yield return new WaitForSeconds(0.1f);

        resourceSystem = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceSystem>();
        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();

        data.plutonium = resourceSystem.EarnedPlutonium;
        data.ore = resourceSystem.EarnedOre;

        data.Wave = waveManager.GetWave();

        GameObject[] listTower = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject obj in listTower)
        {
            Towers temp = new Towers();
            temp.postion = obj.transform.position;
            temp.health = obj.GetComponent<Tower>().currentHP;
            data.AttackTowers.ListsOfTowers.Add(temp);
        }

        listTower = GameObject.FindGameObjectsWithTag("Energy");
        foreach (GameObject obj in listTower)
        {
            Towers temp = new Towers();
            temp.postion = obj.transform.position;
            temp.health = obj.GetComponent<Tower>().currentHP;
            data.EnergyTowers.ListsOfTowers.Add(temp);
           
        }

        listTower = GameObject.FindGameObjectsWithTag("Resource");
        foreach (GameObject obj in listTower)
        {
            Towers temp = new Towers();
            temp.postion = obj.transform.position;
            temp.health = obj.GetComponent<Tower>().currentHP;
            data.MiningTowers.ListsOfTowers.Add(temp);
            
        }

        listTower = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject obj in listTower)
        {
            Towers temp = new Towers();
            temp.postion = obj.transform.position;
            temp.health = obj.GetComponent<Tower>().currentHP;
            data.WallTower.ListsOfTowers.Add(temp);
            
        }

        s_Data = JsonUtility.ToJson(data);
        Debug.Log(s_Data);
        PlayerPrefs.SetString("SaveSlot", s_Data);
    }

    IEnumerator LoadNow()
    {
        yield return new WaitForSeconds(0.1f);
        s_Data = PlayerPrefs.GetString("SaveSlot","null");
        Debug.Log("check if null = " + s_Data);
        if (s_Data != "null")
        {

            GameObject[] listTower = GameObject.FindGameObjectsWithTag("Tower");
            foreach (GameObject obj in listTower)
            {
                Destroy(obj);
            }

            listTower = GameObject.FindGameObjectsWithTag("Energy");
            foreach (GameObject obj in listTower)
            {
                Destroy(obj);
            }

            listTower = GameObject.FindGameObjectsWithTag("Resource");
            foreach (GameObject obj in listTower)
            {
                Destroy(obj);
            }

            listTower = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject obj in listTower)
            {
                Destroy(obj);
            }

            data = JsonUtility.FromJson<SaveData>(s_Data);
            waveManager.SetWave(data.Wave);

            resourceSystem.AddPlutonium(data.plutonium);
            resourceSystem.AddOre(data.ore);

            foreach (Towers tower in data.AttackTowers.ListsOfTowers)
            {
                GameObject temp = Instantiate(TowerPrefab, tower.postion, Quaternion.identity);
                temp.GetComponent<Tower>().currentHP = tower.health;
            }

            foreach (Towers tower in data.EnergyTowers.ListsOfTowers)
            {
                GameObject temp = Instantiate(AtomicPrefab, tower.postion, Quaternion.identity);
                temp.GetComponent<Tower>().currentHP = tower.health;
            }

            foreach (Towers tower in data.MiningTowers.ListsOfTowers)
            {
                GameObject temp = Instantiate(MiningPrefab, tower.postion, Quaternion.identity);
                temp.GetComponent<Tower>().currentHP = tower.health;
            }

            foreach (Towers tower in data.WallTower.ListsOfTowers)
            {
                GameObject temp = Instantiate(WallPrefab, tower.postion, Quaternion.identity);
                temp.GetComponent<Tower>().currentHP = tower.health;
            }
        }
    }
}
