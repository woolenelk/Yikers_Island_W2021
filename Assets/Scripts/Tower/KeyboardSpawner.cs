using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSpawner : MonoBehaviour
{
    public GameObject TowerTransparent;
    public GameObject MiningTransparent;
    public GameObject AtomicTransparent;
    public GameObject WallTransparent;

    public GameObject CurrentlySelectedTower = null;

    public void OnSelectTower1()
    {
        if (CurrentlySelectedTower == null )
        {
            CurrentlySelectedTower = Instantiate(TowerTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
        else
        {
            Destroy(CurrentlySelectedTower);
            CurrentlySelectedTower = Instantiate(TowerTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }

    }

    public void OnSelectTower2()
    {
        if (CurrentlySelectedTower == null)
        {
            CurrentlySelectedTower = Instantiate(MiningTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
        else
        {
            Destroy(CurrentlySelectedTower);
            CurrentlySelectedTower = Instantiate(MiningTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
    }

    public void OnSelectTower3()
    {
        if (CurrentlySelectedTower == null)
        {
            CurrentlySelectedTower = Instantiate(AtomicTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
        else
        {
            Destroy(CurrentlySelectedTower);
            CurrentlySelectedTower = Instantiate(AtomicTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
    }

    public void OnSelectTower4()
    {
        if (CurrentlySelectedTower == null)
        {
            CurrentlySelectedTower = Instantiate(WallTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
        else
        {
            Destroy(CurrentlySelectedTower);
            CurrentlySelectedTower = Instantiate(WallTransparent);
            CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
        }
    }
}
