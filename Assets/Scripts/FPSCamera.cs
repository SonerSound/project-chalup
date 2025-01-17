﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public float MouseSensitivity = 100f;
    public Transform PlayerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
      Cursor.visible = false;

       Cursor.lockState = CursorLockMode.Locked;
        MouseSensitivity = Preferencesholder.instance.MouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {







        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        
        }

    }
}
