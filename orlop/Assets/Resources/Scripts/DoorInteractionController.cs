using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionController : InteractionController
{
    private bool isLocked; // Is the door currently locked
    
    // Start is called before the first frame update
    void Start()
    {
        isCollide = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    override public void CollideInteract()
    {
        print("Collide Interact...");
        if(isActive && !isDisabled)
        {
            if (isLocked)
            {
                // Do nothing atm
            }
            else
            {
                this.transform.position = new Vector3(10, this.transform.position.y, this.transform.position.z);
                isDisabled = true;
            }
        }
    }

    public bool GetLock() { return isLocked; }
    public void SetLock(bool locked) { isLocked = locked; }
}
