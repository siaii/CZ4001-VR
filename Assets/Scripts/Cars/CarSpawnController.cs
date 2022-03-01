using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    [SerializeField] private CarSpawner[] spawners;
    [SerializeField] private Transform[] StartSpawnPoints;
    [SerializeField] public Car[] CarsPrefabs;
    private bool isSpawningCar = false;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in spawners)
        {
            s.CarsPrefabs = CarsPrefabs;
        }
    }

    public void ToggleCarSpawning()
    {
        isSpawningCar = !isSpawningCar;
        foreach (var s in spawners)
        {
            s.EnableSpawning = isSpawningCar;
        }
    }

    public void SetCarSpawning()
    {
       //Pre-Spawn cars
       int interval = WorldStateData.isCarProposalApproved ? 1 : 3;

       for (int i = 0; i < StartSpawnPoints.Length; i += interval)
       {
           var prefab = CarsPrefabs[Random.Range(0, CarsPrefabs.Length)].gameObject;
           Instantiate(prefab, StartSpawnPoints[i].position, StartSpawnPoints[i].rotation);
       }
    }
}
