using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Direction = CommonUtil.Direction;

// like a character manager, can rename
public class BaseActor : MonoBehaviour
{
    // can move into attributes class later
    private float _moveSpeed = 2.0f;
    private float _sprintSpeed = 4.0f;
    public float GetMoveSpeed() { return _moveSpeed; }
    public float GetSprintSpeed() { return _sprintSpeed; }
    private Direction _direction = Direction.B;
    public Direction GetDirection() { return _direction; }
    public void SetDirection(Direction d) { this._direction = d; }



    // for physics --- DONT USE RIGIDBODY - use a Collider/BoxCollider for now, then later switch to mesh. Makes everything easy, we don't need physics 
    //private Rigidbody _rb;
    //public Rigidbody getRigidBody() { return _rb; }
    /*
    private Collider _collider;
    public Collider GetCollider() { return _collider; }

    private CharacterController _characterController;
    public CharacterController GetCharacterController() { return this._characterController; }

    private CameraManager _cameraManager;
    private MovementController _movementManager;

    public MovementController GetMovementManager() { return this._movementManager; }
    public CameraManager GetCameraManager() { return this._cameraManager; }

    private Camera _camera;
    */

    void Awake()
    {
        // make sprite actors cast a shadow
        gameObject.GetComponent<SpriteRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }

    // Start is called before the first frame update
    void Start()
    {

       // _characterController = GetComponent<CharacterController>();
        
        //_cameraManager = new CameraManager(_camera, this);
        //_movementManager = new MovementController(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
