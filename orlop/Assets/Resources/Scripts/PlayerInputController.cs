using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Direction = CommonUtil.Direction;

public class PlayerInputController : MonoBehaviour
{

    Dictionary<string, string[]> _inputs = new Dictionary<string, string[]>
{
    { "F", new []{"w"} },
    { "B", new []{"s"} },
    { "L", new []{"a"} },
    { "R", new []{"d"} },
    { "FL", new []{"a","w"} },
    { "FR", new []{"w","d"} },
    { "BL", new []{"a","s"} },
    { "BR", new []{"s","d"} },
    { "SPRINT", new []{"left shift"} },
    { "DASH", new []{"space"} },
    { "CAMERA", new []{"left ctrl"} },
    { "ATTACK", new []{"u"} },
    { "GEM1", new []{"i"} },
    { "GEM2", new []{"o"} },
    { "GEMSWAP", new []{"p"} },
    { "MENU", new []{"m"} },
    { "EXIT", new []{"escape"} },
};

    // WASD -> movement, anim
    // sprint -> movement, anim
    // dash -> movement, anim
    // camera swap -> camera 
    // basic attack -> combat, anim
    // gem 1 -> combat, anim
    // gem 2 -> ..
    // gem swap -> menu, combat, anim
    // pause / settings -> menu

//player input

    private MovementController _movementController;
    //private BaseActor _actor;
    private GameObject _obj;
    private GameManager _gameManager;
    private CameraManager _cameraManager;

    void Awake()
    {
        _obj = GameObject.Find("PlayerObject");
        _movementController = _obj.GetComponent("MovementController") as MovementController;
        _gameManager = GameManager.GetGameManager(); // GameManager singleton
    }

    // Start is called before the first frame update
    void Start()
    {
        _cameraManager = _gameManager.GetCameraManager();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private bool AreKeysPressed(string[] keys)
    {
        foreach (string key in keys)
        {
            if (!(Input.GetKey(key)))
            {
                return false;
            }
        }
        return true;
    }

    public void HandleInputs()
    {
        if (AreKeysPressed(_inputs["FR"]))
        {
            _movementController.Move(Direction.FR);
        }
        else if (AreKeysPressed(_inputs["FL"]))
        {
            _movementController.Move(Direction.FL);
        }
        else if (AreKeysPressed(_inputs["BL"]))
        {
            _movementController.Move(Direction.BL);
        }
        else if (AreKeysPressed(_inputs["BR"]))
        {
            _movementController.Move(Direction.BR);
        }
        else if (AreKeysPressed(_inputs["F"]))
        {
            _movementController.Move(Direction.F);
        }
        else if (AreKeysPressed(_inputs["B"]))
        {
            _movementController.Move(Direction.B);
        }
        else if (AreKeysPressed(_inputs["L"]))
        {
            _movementController.Move(Direction.L);
        }
        else if (AreKeysPressed(_inputs["R"]))
        {
            _movementController.Move(Direction.R);
        }

        if (Input.GetKeyDown(_inputs["SPRINT"][0]))
        {
            _movementController.StartSprint();
        }
        else if (Input.GetKeyUp(_inputs["SPRINT"][0]))
        {
            _movementController.StopSprint();
        }

        if (Input.GetKeyDown(_inputs["DASH"][0]))
        {
            _movementController.StartDash();
        }

        if (Input.GetKeyDown(_inputs["CAMERA"][0]))
        {
           _cameraManager.RotateClockwise();
        }

        /** TODO:
    { "ATTACK", new []{"u"} },
    { "GEM1", new []{"i"} },
    { "GEM2", new []{"o"} },
    { "GEMSWAP", new []{"p"} },
    { "MENU", new []{"m"} },
    { "EXIT", new []{"escape"} },
         * 
         **/
    }
}
