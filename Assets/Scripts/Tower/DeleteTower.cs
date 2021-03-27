using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DeleteTower : MonoBehaviour
{
    public GameObject button;

    public bool clicked = false;
    public bool clickedTower = false;

    private CameraController CameraController;

    public LayerMask RaycastMask;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);

        CameraController = FindObjectOfType<CameraController>();    
    }

    public GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        if (objectToDestroy == null)
            return;
        Destroy(objectToDestroy);
        button.SetActive(false);
    }

    public void OnTargetTower(InputValue input)
    {
        clicked = input.isPressed;
        if (!clicked)
            return;
            //clickedTower = true;

            var ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, RaycastMask))
            {
                /*objTransform = hit.transform;
                hit.transform.gameObject.CompareTag("Tower")
                var obj = objTransform.gameObject.name;*/
                if (hit.transform.gameObject.CompareTag("UI"))
                return;

                if (hit.transform.gameObject.CompareTag("Tower") || hit.transform.gameObject.CompareTag("Energy") || hit.transform.gameObject.CompareTag("Resource") || hit.transform.gameObject.CompareTag("Wall"))
                {
                    
                    button.SetActive(true);
                    objectToDestroy = hit.transform.gameObject;
                    
                }
                else
                {
                    objectToDestroy = null;
                    button.SetActive(false);
                }
            }
        else
        {
        button.SetActive(false);

        }


        Debug.Log("Clicked Tower!");
    }
}
