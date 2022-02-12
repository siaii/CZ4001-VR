using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Car[] carsPrefabs;
    [SerializeField] private float TimeBetweenSpawn;
    [SerializeField] private Vector3 RoadDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCar()
    {
        var prefab = carsPrefabs[Random.Range(0, carsPrefabs.Length)].gameObject;
        var instance = Instantiate(prefab, transform.position, Quaternion.LookRotation(RoadDirection));
    }
}
