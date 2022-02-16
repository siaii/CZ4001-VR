using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterScript : MonoBehaviour
{

    public GameObject litter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLitter(bool isLitter)
    {
        if(litter.activeInHierarchy == true)
        {
            litter.SetActive(false);
        }
        else
        {
            litter.SetActive(true);
        }
    }
}
