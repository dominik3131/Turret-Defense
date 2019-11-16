using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float zoomOutMin = 11;
    public float zoomOutMax = 30;
    public Camera cam;

    private Vector3 touchStart;
    private float moveCooldown = 0.5f;
    private float zoomTimer = 0;


    // Update is called once per frame
    void Update()
    {
        zoomTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(0);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference*0.1f);
            zoomTimer = moveCooldown;

        } else if (Input.GetMouseButton(0) && zoomTimer < 0)
        {
            Vector3 direction = touchStart - GetWorldPosition(0);
            Camera.main.transform.position += direction;
        }

        //allow to zoom with Scrollwheel
        //zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - increment, zoomOutMin, zoomOutMax);
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

}
