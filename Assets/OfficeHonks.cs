using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OfficeHonks : MonoBehaviour
{
    [SerializeField] private Vector2 timeInterval;

    public bool isEnabled = false;
    
    private AudioSource audioSource;

    private float timer = 0.5f;
    private float honkCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        honkCooldown = Random.Range(timeInterval.x, timeInterval.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled) return;
        
        if (timer >= honkCooldown)
        {
            audioSource.Play();
            timer = 0;
            honkCooldown = Random.Range(timeInterval.x, timeInterval.y);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    
}
