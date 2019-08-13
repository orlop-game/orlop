using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject _obj;
    private CameraManager _cameraManager;

    public static GameManager GetGameManager() { return GameObject.Find("GameManagerObject").GetComponent("GameManager") as GameManager; }

    public CameraManager GetCameraManager() { return this._cameraManager; }

    void Awake()
    {
        _obj = GameObject.Find("GameManagerObject");
        _cameraManager = _obj.GetComponent("CameraManager") as CameraManager;
    }

    void Start()
    {
         //BaseActor character = new BaseActor(Camera.main);
    }
}
