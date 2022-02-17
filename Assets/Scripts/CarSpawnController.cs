using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnController : MonoBehaviour
{
    [SerializeField] private CarSpawner[] spawners;
    private bool isSpawningCar = false;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize based on accepted policy
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCarSpawning()
    {
        isSpawningCar = !isSpawningCar;
        foreach (var s in spawners)
        {
            s.EnableSpawning = isSpawningCar;
        }
    }
}
