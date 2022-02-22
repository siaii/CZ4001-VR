using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedAutoScroll : MonoBehaviour
{
    [SerializeField] private GameObject feedPrefab;
    [SerializeField] private GameObject content;
    private ScrollRect scrollRect;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        //Can be used for auto initializing the text
        for (int i = 0; i < 20; ++i)
        {
            GameObject go = Instantiate(feedPrefab, content.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollRect.velocity = Vector2.up * 100;
    }
}
