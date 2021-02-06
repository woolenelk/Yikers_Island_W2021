using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart, direction;
    public Camera cam;
    //public Text text;

    public float groundZ = 0f, zoomMin, zoomMax, cameraDistance, scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }

        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            cameraDistance += difference * scrollSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
            if (difference < 0)
            {
                if (cameraDistance != zoomMax && cameraDistance != zoomMin)
                {
                    Camera.main.transform.position += Vector3.forward * difference + Vector3.down * difference;
                    //text.text = "curr < prev " + difference.ToString();
                }
            }
            if (difference > 0)
            {
                if (cameraDistance != zoomMin && cameraDistance != zoomMax)
                {
                    Camera.main.transform.position -= Vector3.forward * difference + Vector3.down * difference;
                    //text.text = "curr > prev " + difference.ToString();
                }
            }
        }

        else if(Input.GetMouseButton(0))
        {
            direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
            if(Input.GetAxis("Mouse ScrollWheel") <= 0)
                if(cameraDistance != zoomMax && cameraDistance != zoomMin)
                Camera.main.transform.position += Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
            if (Input.GetAxis("Mouse ScrollWheel") >= 0)
                if(cameraDistance != zoomMin && cameraDistance != zoomMax)
                Camera.main.transform.position -= Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.down, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}
