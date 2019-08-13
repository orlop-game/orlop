using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Direction = CommonUtil.Direction;

public class CameraManager : MonoBehaviour
{
    public Transform PlayerTransform;    // A variable that stores a reference to our Player
    private Vector3 _offset;      // A variable that allows us to offset the position (x, y, z)
    private Camera _camera;
    private BaseActor _playerActor;


    private static Dictionary<Direction, Direction> _rotationMap = new Dictionary<Direction, Direction>
    {
        { Direction.F, Direction.L },
        { Direction.FR, Direction.FL },
        { Direction.R, Direction.F },
        { Direction.BR, Direction.FR },
        { Direction.B, Direction.R },
        { Direction.BL, Direction.BR },
        { Direction.L, Direction.B },
        { Direction.FL, Direction.BL },
    };

    void Awake()
    {
        _offset = new Vector3(0.0f, 1.0f, -5.0f);
        _camera = GameObject.Find("Main Camera").GetComponent("Camera") as Camera;
        GameObject playerObject = GameObject.Find("PlayerObject");
        PlayerTransform = playerObject.transform;
        _playerActor = playerObject.GetComponent("BaseActor") as BaseActor;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_player = actor.GetCharacterController().transform;
    }

    public Camera getCamera() { return this._camera; }

    // Update is called once per frame
    void Update()
    {
        // Set our position to the players position and offset it
        _camera.transform.position = PlayerTransform.position + _offset;
        //Debug.Log(PlayerTransform.position);
    }

    public void RotateClockwise()
    {
        // rotate camera clockwise 90 deg, change relative position to point at character from other side.
        // later, make this a smooth animation (spring arm setup)
        _playerActor.SetDirection(_rotationMap[_playerActor.GetDirection()]);
        print(PlayerTransform.position + _offset);
        float x = _offset.x;
        _offset.x = _offset.z;
        _offset.z = -x;
        _camera.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        // rotate sprite so you see it head on
        PlayerTransform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        _camera.transform.position = PlayerTransform.position + _offset;
    }
}
