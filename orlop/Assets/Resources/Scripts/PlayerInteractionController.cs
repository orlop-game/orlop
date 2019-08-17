using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private GameObject _hitObj;
    private InteractionController _hitComp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If we are currently interacting with an item and it has become disabled, remove it from our minds
        if (_hitComp != null)
        {
            if (_hitComp.GetDisabled()) { _hitComp = null; }
        }
    }

    // Fires when the player collides with any other collider
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_hitComp == null)
        {
            _hitObj = hit.gameObject; // Get the GameObject from what we just collided with
            _hitComp = _hitObj.GetComponent(typeof(InteractionController)) as InteractionController; // Get the Interaction component if it exists

            if (_hitComp != null) // null check so we don't cause an error if the component doesn't exist on the object
            {
                if (!_hitComp.GetActive()) // The object is active and now interactable
                {
                    print("Object is active...");
                    _hitComp.SetActive(true);
                    if (_hitComp.GetCollidable()) { _hitComp.CollideInteract(); } // If this is a collidable interaction, do the interaction
                }
            }
        }
    }

    public void Interact() // This function should only ever get called when the player presses an interaction key
    {
        print("test1");
        if (_hitComp != null) // null check so we don't cause an error if the component doesn't exist on the object
        {
            print("test2");
            if (_hitComp.GetActive())
            {
                print("test3");
                _hitComp.PressInteract();
            }
        }
    }

    public void ClearInteraction()
    {
        _hitObj = null;
        _hitComp = null;
    }
}
