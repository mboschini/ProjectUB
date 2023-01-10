using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Newtonsoft.Json;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform Player;
    public float mouseSensi = 2f;
    float cameraVerticalRotation = 0f;
    public Texture2D crosshair;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnGUI()
    {
        Camera mainCamera = Camera.main;
        int camwidth = mainCamera.pixelWidth;
        int camheight = mainCamera.pixelHeight;
        GUI.DrawTexture(new Rect(camwidth / 2 - (crosshair.width * 0.5f),
                                               camheight / 2 - (crosshair.height * 0.5f),
                                               crosshair.width, crosshair.height), crosshair);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = (Cursor.visible) ? CursorLockMode.None : CursorLockMode.Locked;
        }
        float inputX = Input.GetAxis("Mouse X") * mouseSensi;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensi;
         cameraVerticalRotation -= inputY;
         cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
         transform.localEulerAngles = Vector3.right * cameraVerticalRotation;        

        var pa = new PlayerActions() { ConnectionUUID = ClientWS._ConnectionID, Action = "MOUSE", MouseX = inputX, MouseY = inputY };

        if (inputX != 0 || inputY != 0)
        {
            ClientWS._ws.Send(JsonConvert.SerializeObject(pa));
        }
    }

}
