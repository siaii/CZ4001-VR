using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    //Spawning bool controlled via editor
    [SerializeField] private bool EnableSpawning = true;
    [SerializeField] private Car[] CarsPrefabs;
    [SerializeField] private float TimeBetweenSpawn = 1f;
    [SerializeField] private Vector3 RoadDirection;

    private float timer = 0;
    //Spawning bool controlled via code
    private bool isSpawningCar;
    private int mask;
    // Start is called before the first frame update
    void Start()
    {
        //Only check for cars and player
        mask = LayerMask.GetMask("Car", "Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Make sure nom cars are occupying the spawn space
        CheckSpawnValid();
        if (EnableSpawning && isSpawningCar && timer>=TimeBetweenSpawn)
        {
            SpawnCar();
            timer = 0;
        }
    }

    //Implement object pooling if have enough time and/or performance issues
    public void SpawnCar()
    {
        var prefab = CarsPrefabs[Random.Range(0, CarsPrefabs.Length)].gameObject;
        var instance = Instantiate(prefab, transform.position, Quaternion.LookRotation(RoadDirection));
    }

    private void CheckSpawnValid()
    {
        var collision = Physics.OverlapBox(transform.position , Vector3.one*2, Quaternion.identity, mask);
        isSpawningCar = collision.Length <= 0;
    }
}
