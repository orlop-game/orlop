using UnityEngine;
using Direction = CommonUtil.Direction;

public class MovementController : MonoBehaviour {

	private BaseActor _actor; // basic attributes of an actor
    private float _currentSpeed;
    private CharacterController _characterController;
    private Camera _mainCamera;

    private float GetCurrentSpeed() { return this._currentSpeed; }

    void Awake()
    {
        GameObject _obj = GameObject.Find("PlayerObject");
        _actor = _obj.GetComponent("BaseActor") as BaseActor;
        _currentSpeed = _actor.GetMoveSpeed();
        _characterController = _obj.GetComponent("CharacterController") as CharacterController;
    }

    void Start()
    {
        _mainCamera = GameManager.GetGameManager().GetCameraManager().getCamera();
    }

    public void StartSprint()
    {
        _currentSpeed = _actor.GetSprintSpeed();
    }

    public void StopSprint()
    {
        _currentSpeed = _actor.GetMoveSpeed();
    }

    public void StartDash()
    {
        // nothing yet
    }

    private Vector3 F() { return _mainCamera.transform.forward; }
    private Vector3 B() { return -_mainCamera.transform.forward; }
    private Vector3 L() { return -_mainCamera.transform.right; }
    private Vector3 R() { return _mainCamera.transform.right; }
    private Vector3 Gravity() { return new Vector3(0.0f, -1.0f, 0.0f); }

    public void Move(Direction direction)
    {
        //TODO(ash)
        // Direction  = input
        // based on input, and camera position/rotation, figure out direction vector to move character
        // apply
        Vector3 MovementDirection = new Vector3(0,0,0);
        switch (direction)
        {
            case Direction.F:
                MovementDirection += F();
                break;
            case Direction.B:
                MovementDirection += B();
                break;
            case Direction.L:
                MovementDirection += L();
                break;
            case Direction.R:
                MovementDirection += R();
                break;
            case Direction.FL:
                MovementDirection += F() + L();
                break;
            case Direction.FR:
                MovementDirection += F() + R();
                break;
            case Direction.BL:
                MovementDirection += B() + L();
                break;
            case Direction.BR:
                MovementDirection += B() + R();
                break;
        }
        MovementDirection.Normalize();
        MovementDirection *= GetCurrentSpeed();
        // apply gravity after regular movement
        MovementDirection += Gravity();
        _actor.SetDirection(direction);
        _characterController.Move(MovementDirection * Time.deltaTime);
    }


}
