using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class InteractionController : MonoBehaviour
{
    protected bool isActive     = false;    // Is the object currently being interacted with?
    protected bool isCollide    = false;    // Is the object activated by collision instead of the interaction button?
    protected bool isDisabled   = false;    // Is the object disabled so we don't need to grab it on collision anymore?

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public void PressInteract() // Used for when the player presses a key to interact
    {
    }

    virtual public void CollideInteract() // Used for 
    {

    }

    public bool GetActive() { return isActive; }
    public void SetActive(bool active) { isActive = active; }

    public bool GetCollidable() { return isCollide; }

    public bool GetDisabled() { return isDisabled; }
    public void SetDisabled(bool disabled) { isDisabled = disabled; }
}
