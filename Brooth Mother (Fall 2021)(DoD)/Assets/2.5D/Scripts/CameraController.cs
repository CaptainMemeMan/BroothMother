using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Vector2 middleRigHeight = new Vector2(5f, 13.58f);
    [SerializeField] private float rotationSensitivity = 300f;
    [SerializeField] private float zoomSensitivity = 5f;

    private SpriteDirection[] spriteDirection;
    private float currentHeight;
    private Vector3 _angle = new Vector3();
    private DirectionalAngle _facing = DirectionalAngle.Down;
    public DirectionalAngle Facing { get { return _facing; } }


    // Start is called before the first frame update
    void Start()
    {
        spriteDirection = FindObjectsOfType<SpriteDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        _angle = Camera.main.transform.localEulerAngles;

        CameraDirection();
        CameraZoom();
    }

    //Sets the Facing variable depending on the Camera Angle.
    void CameraDirection()
    {
        float rX = _angle.y;
        float x = Mathf.Abs(rX);

        if (x < 22.5f && x < 337.5f) _facing = DirectionalAngle.Up;
        else if (x < 67.5f & x >= 22.5f) _facing = DirectionalAngle.UpRight;
        else if (x < 112.5f && x < 157.5f) _facing = DirectionalAngle.Right;
        else if (x < 157.5f && x < 202.5f) _facing = DirectionalAngle.DownRight;
        else if (x < 202.5f && x < 247.5f) _facing = DirectionalAngle.Down;
        else if (x < 247.5f && x < 292.5) _facing = DirectionalAngle.DownLeft;
        else if (x < 292.5 && x < 337.5)_facing = DirectionalAngle.Left;
        else if (x < 337.5 && x < 360)_facing = DirectionalAngle.UpLeft;
    }

    void CameraZoom()
    {
        currentHeight += Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;
        currentHeight = Mathf.Clamp(currentHeight, middleRigHeight.x, middleRigHeight.y);
    }

    /*If the Player is moving the mouse and is pressing the Move Camera input, the camera will rotate
    in the direction of the mouse. */
    public float GetAxisCustom(string axisName)
    {
        if (axisName == "Mouse X") if(Input.GetButton("Move Camera")) return Input.GetAxis("Mouse X");
        else
            return 0;

        return UnityEngine.Input.GetAxis(axisName);
    }
}
