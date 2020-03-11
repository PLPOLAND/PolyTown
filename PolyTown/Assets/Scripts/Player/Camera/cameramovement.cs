using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotSpeed = 40f;
    public float zoomSens = 10f;
    public float screenBorder = 10f;
    public Vector2 limit = new Vector2(10, 10);
    private Transform cameraTransform;
    private Vector2 MouseIn
    {
        get { return Input.mousePosition; }
    }
    private float Scroll
    {
        get { return Input.GetAxis("Mouse ScrollWheel"); }
    }
    private void Start()
    {
        cameraTransform = this.transform;
    }
    void Update()
    {
        move();
        mouseMove();
        clampPos();
        zoom();
    }

    void move()
    {
        var pos = transform.position;
        Vector2 keyboardInput = new Vector2(0, 0);
        if (Input.GetKey("w"))
            keyboardInput.y = 1;
        if (Input.GetKey("s"))
            keyboardInput.y = -1;
        if (Input.GetKey("a"))
            keyboardInput.x = -1;
        if (Input.GetKey("d"))
            keyboardInput.x = 1;

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.down, rotSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime, Space.World);
        }

        Vector3 ruch = new Vector3(keyboardInput.x, 0, keyboardInput.y);
        ruch *= moveSpeed; // pomnóż przez prędkość
        ruch *= Time.deltaTime; // pomnóż przez różnice czasu dla płynnego ruchu
        ruch = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * ruch; //obróc wektor aby odpowiadał obrotowi kamery
        ruch = cameraTransform.InverseTransformDirection(ruch);
        cameraTransform.Translate(ruch, Space.Self); //ustaw nową pozycję kamery
    }
    void mouseMove()
    {
        Vector3 desiredMove = new Vector3();

        Rect left = new Rect(0, 0, screenBorder, Screen.height);
        Rect right = new Rect(Screen.width - screenBorder, 0, screenBorder, Screen.height);
        Rect up = new Rect(0, Screen.height - screenBorder, Screen.width, screenBorder);
        Rect down = new Rect(0, 0, Screen.width, screenBorder);

        desiredMove.x = left.Contains(MouseIn) ? -1 : right.Contains(MouseIn) ? 1 : 0;
        desiredMove.z = up.Contains(MouseIn) ? 1 : down.Contains(MouseIn) ? -1 : 0;

        desiredMove *= moveSpeed;
        desiredMove *= Time.deltaTime;
        desiredMove = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * desiredMove;
        desiredMove = cameraTransform.InverseTransformDirection(desiredMove);

        cameraTransform.Translate(desiredMove, Space.Self);
    }
    void clampPos()
    {
        cameraTransform.position = new Vector3(Mathf.Clamp(cameraTransform.position.x, -limit.x, limit.x),
               cameraTransform.position.y,
               Mathf.Clamp(cameraTransform.position.z, (-limit.y - cameraTransform.position.y), (limit.y + cameraTransform.position.y)));
    }
    void zoom(){
        float zoomPos = Scroll * Time.deltaTime * zoomSens * 50;
        float targetHeight = Mathf.Clamp(cameraTransform.position.y + zoomPos, 5, 200);
        cameraTransform.position = new Vector3(cameraTransform.position.x,targetHeight,cameraTransform.position.z);
    }
}
