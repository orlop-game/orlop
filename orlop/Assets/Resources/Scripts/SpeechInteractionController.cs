using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechInteractionController : InteractionController
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    override public void PressInteract()
    {
        print("Pressed Interact...");
        if (isActive && !isDisabled)
        {
            this.transform.position = new Vector3(10, this.transform.position.y, this.transform.position.z);
            isDisabled = true;
        }
    }
}