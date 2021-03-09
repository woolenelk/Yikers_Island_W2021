using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart, direction;
    public Camera cam;
    //public Text text;

    public float groundZ = 0f, zoomMin, zoomMax, cameraDistance, scrollSpeed;

    private bool IsPressed = false;
    Vector2 PreviousMousePosition;
    public Vector2 CurrentMousePosition;

    // Update is called once per frame
    void Update()
    {
        


        //************************************************************  CODE THAT PHOENIX HAD BEFORE    ***************************************************************
        //if (Input.GetMouseButtonDown(0))
        //{
        //    touchStart = GetWorldPosition(groundZ);
        //}

        //if (Input.touchCount == 2)
        //{
        //    Touch touchZero = Input.GetTouch(0);
        //    Touch touchOne = Input.GetTouch(1);

        //    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    float difference = currentMagnitude - prevMagnitude;
        //    // clamp z 40 to -70
        //    // clamp x 100 to -100
        //    cameraDistance += difference * scrollSpeed;
        //    cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
        //    if (difference < 0)
        //    {
        //        if (cameraDistance != zoomMax && cameraDistance != zoomMin)
        //        {
        //            Camera.main.transform.position += Vector3.forward * difference + Vector3.down * difference;
        //            //text.text = "curr < prev " + difference.ToString();
        //        }
        //    }
        //    if (difference > 0)
        //    {
        //        if (cameraDistance != zoomMin && cameraDistance != zoomMax)
        //        {
        //            Camera.main.transform.position -= Vector3.forward * difference + Vector3.down * difference;
        //            //text.text = "curr > prev " + difference.ToString();
        //        }
        //    }
        //}

        //else if (Input.GetMouseButton(0))
        //{
        //    direction = touchStart - GetWorldPosition(groundZ);
        //    Camera.main.transform.position += direction;

        //    float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
        //    //float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
        //    float clampZ = Mathf.Clamp(Camera.main.transform.position.z, -70, 40);

        //    Camera.main.transform.position = new Vector3(clampX, Camera.main.transform.position.y, clampZ);

        //}

        //if (Input.GetAxis("Mouse ScrollWheel") != 0)
        //{
        //    cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        //    cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
        //    if (Input.GetAxis("Mouse ScrollWheel") <= 0)
        //        if (cameraDistance != zoomMax && cameraDistance != zoomMin)
        //            Camera.main.transform.position += Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
        //    if (Input.GetAxis("Mouse ScrollWheel") >= 0)
        //        if (cameraDistance != zoomMin && cameraDistance != zoomMax)
        //            Camera.main.transform.position -= Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
        //}
        //************************************************************  CODE THAT PHOENIX HAD BEFORE    ***************************************************************
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(CurrentMousePosition);
        Plane ground = new Plane(Vector3.down, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

    public void OnClick(InputValue input)
    {
        Debug.Log("LeftClick");

        IsPressed = input.isPressed;
        if (IsPressed)
        {
            touchStart = GetWorldPosition(groundZ);
        }

    }

    public void OnScrollWheel(InputValue input)
    {

        Vector2 Scroll = input.Get<Vector2>();
        //Debug.Log(Scroll);
        if (Scroll.y == 0) return;

        cameraDistance += Scroll.y * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
        if (Scroll.y <= 0)
            if (cameraDistance != zoomMax && cameraDistance != zoomMin)
                Camera.main.transform.position += Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
        if (Scroll.y >= 0)
            if (cameraDistance != zoomMin && cameraDistance != zoomMax)
                Camera.main.transform.position -= Vector3.forward * cameraDistance + Vector3.down * cameraDistance;

    }

    public void OnPoint(InputValue input)
    {
        CurrentMousePosition = input.Get<Vector2>();

        //Debug.Log(MousePosition);

        //if (IsPressed)
        //{
        //    //Touch touchZero = Input.GetTouch(0);
        //    //Touch touchOne = Input.GetTouch(1);

        //    //Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        //    //Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        //    //float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        //    //float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

        //    //float difference = currentMagnitude - prevMagnitude;
        //    //// clamp z 40 to -70
        //    //// clamp x 100 to -100
        //    //cameraDistance += difference * scrollSpeed;
        //    //cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
        //    //if (difference < 0)
        //    //{
        //    //    if (cameraDistance != zoomMax && cameraDistance != zoomMin)
        //    //    {
        //    //        Camera.main.transform.position += Vector3.forward * difference + Vector3.down * difference;
        //    //        //text.text = "curr < prev " + difference.ToString();
        //    //    }
        //    //}
        //    //if (difference > 0)
        //    //{
        //    //    if (cameraDistance != zoomMin && cameraDistance != zoomMax)
        //    //    {
        //    //        Camera.main.transform.position -= Vector3.forward * difference + Vector3.down * difference;
        //    //        //text.text = "curr > prev " + difference.ToString();
        //    //    }
        //    //}
        //}
        //else if (IsPressed)
        if (IsPressed)
        {
            direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;

            float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
            //float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
            float clampZ = Mathf.Clamp(Camera.main.transform.position.z, -70, 40);

            Camera.main.transform.position = new Vector3(clampX, Camera.main.transform.position.y, clampZ);

        }

        PreviousMousePosition = CurrentMousePosition;
    }

}
