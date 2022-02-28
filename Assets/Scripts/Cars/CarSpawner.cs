using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    //Spawning bool controlled via editor
    [SerializeField] public bool EnableSpawning = true;
    [SerializeField] public Car[] CarsPrefabs;
    [SerializeField] private Vector2 NoProposalSpawnRate;
    [SerializeField] private Vector2 ApprovedProposalSpawnRate;
    [SerializeField] private Vector3 RoadDirection;

    private float timer = 0;

    private float spawnCooldown;
    //Spawning bool controlled via code
    private bool isSpawningCar;
    private int mask;
    // Start is called before the first frame update
    void Start()
    {
        //Only check for cars and player
        mask = LayerMask.GetMask("Car", "Player");
        SetSpawnCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Make sure nom cars are occupying the spawn space
        CheckSpawnValid();
        if (EnableSpawning && isSpawningCar && timer>=spawnCooldown)
        {
            SpawnCar();
            timer = 0;
            SetSpawnCooldown();
        }
    }

    private void SetSpawnCooldown()
    {
        if (WorldStateData.isCarProposalApproved)
        {
            spawnCooldown = Random.Range(ApprovedProposalSpawnRate.x, ApprovedProposalSpawnRate.y);
        }
        else
        {
            spawnCooldown = Random.Range(NoProposalSpawnRate.x, NoProposalSpawnRate.y);
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
