using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedTextBox : MonoBehaviour
{
    [SerializeField] private Text text;

    [SerializeField] private GameObject likeTextGameObject;

    [SerializeField] private GameObject retweetTextGameObject;

    // Start is called before the first frame update
    
    private readonly string[,] tweetContent =
    {
        {
            "New leader, new hope!",
            "I bet everything will remain the same.",
            "BREAKING NEWS: A new leader of the world has just been elected!",
            "The new leader is nothing but cowards. I will be the one who can make changes. #MakeWorldGreatAgain",
            "I just had a phone call with the new leader of the world. I will support him in fighting climate changes and global warming.",
            "The Pope: I pray that the world can be at peace in the new world leadership",
            "BREAKING NEWS: Fire at Amazon Rainforest in control as support come from across the globe.",
            "The new leader of the world will bring the changes long needed by the world.",
            "I hope the new leader of the world can solve the housing problem.",
            "It's getting boring here, I need to have some fun.",
        },
        {
            "Cheaper housing, finally!",
            "The leader of the world is stupid, he doesn't care about climate change.",
            "BREAKING NEWS: A new proposal on land clearance is approved by the leader of the world.",
            "The leader's popularity rises as populist proposal is approved.",
            "I am disappointed by the leader's move to cut down trees. Such move will hinder our effort in fighting climate change.",
            "Only I care about the earth. Only I care for our children's future. #MakeWorldGreatAgain",
            "BREAKING NEWS: Wild fire at Australia is uncontrollable.",
            "This is not the change the world expect.",
            "I hope the new leader of the world can solve the housing problem.",
            "I guess now we can have some fun.",
        },
        {
            "When can I afford my own house.",
            "The leader of the world is stupid, he doesn't care about the people.",
            "BREAKING NEWS: A proposal on land clearance is rejected by the leader of the world.",
            "The new leader is nothing but cowards. I will be the one who can make changes. #MakeWorldGreatAgain",
            "The latest move by the leader is a small step on a long fight against climate change.",
            "Only I care about you. A house is a basic necessity and a human right. Only I can provide housing for everyone. #MakeWorldGreatAgain",
            "BREAKING NEWS: Price of house rose by 75% as land clearance proposal is turned down.",
            "A fresh air that the world needs.",
            "This is outrageous, working hard all my life but cannot have my own house?",
            "The leader is out of touch to the world. With home ownership at all time low, this is not the time for environment shenanigans.",
        },
    };
    void Start()
    {
        likeTextGameObject.GetComponent<Text>().text = Random.Range(150, 890).ToString();
        retweetTextGameObject.GetComponent<Text>().text = Random.Range(150, 890).ToString();
        int idx = 0;
        if (WorldStateData.isForestProposalApproved)
        {
            idx = 1;
        }
        else
        {
            idx = 2;
        }
        text.text = tweetContent[idx,Random.Range(0, tweetContent.GetLength(1))];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
