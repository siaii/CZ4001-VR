using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isHappyHash; // stores string into simpler data type
    int isAngryHash; // stores string into simpler data type
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isHappyHash = Animator.StringToHash("isHappy");
        isAngryHash = Animator.StringToHash("isAngry");
    }

    // Update is called once per frame
    void Update()
    {
        bool isHappy = animator.GetBool("isHappy");
        bool isAngry = animator.GetBool("isAngry");

        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");

        // WIN ELECTION ANIMATIION

        // press w to start cheering animation
        if (!isHappy && forwardPressed)
        {
            // then set the isHappy boolean to be true
            animator.SetBool(isHappyHash, true);
        }
        // if w not pressed, go back to idle state
        if (isHappy && !forwardPressed)
        {
            // then set the isHappy boolean to be false
            animator.SetBool(isHappyHash, false);
        }


        // LOSE ELECTION ANIMATION

        // press s to start dissapointed animation
        if (!isAngry && backwardPressed)
        {
            // then set the isAngry boolean to be true
            animator.SetBool(isAngryHash, true);
        }

        //if s not pressed, go back to idle state
        if (isAngry && !backwardPressed)
        {
            // then set the isRunning boolean to be true
            animator.SetBool(isAngryHash, false);
        }
    }
}
