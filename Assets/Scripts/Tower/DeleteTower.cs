using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DeleteTower : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;
    public Transform objTransform;

    public bool clicked = false;
    public bool clickedTower = false;

    private CameraController CameraController;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);

        CameraController = FindObjectOfType<CameraController>();    
    }

    /* Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objTransform = hit.transform;
            var obj = objTransform.gameObject.name;
            if (obj == "Tower(Clone)")
            {
                if (clicked == true)
                {
                    button.SetActive(true);
                    button.GetComponent<DeleteButton>().objectToDestroy = objTransform.gameObject;
                }
            }
            else
            {
                if (clicked == true)
                {
                    button.GetComponent<DeleteButton>().objectToDestroy = null;
                    button.SetActive(false);
                }
            }
        }
    }*/

    public void OnClick(InputValue input)
    {
        clicked = input.isPressed;
        if (!clicked)
            return;
            //clickedTower = true;

            var ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
            /*objTransform = hit.transform;
        hit.transform.gameObject.CompareTag("Tower")
            var obj = objTransform.gameObject.name;*/
            if (hit.transform.gameObject.CompareTag("UI"))
                return;
                if (hit.transform.gameObject.CompareTag("Tower") || hit.transform.gameObject.CompareTag("Energy") || hit.transform.gameObject.CompareTag("Resource") || hit.transform.gameObject.CompareTag("Wall"))
                {
                    
                    button.SetActive(true);
                    button.GetComponent<DeleteButton>().objectToDestroy = hit.transform.gameObject;
                    
                }
                else
                {
                    button.GetComponent<DeleteButton>().objectToDestroy = null;
                    button.SetActive(false);
                }
            }
        
        Debug.Log("Clicked Tower!");
    }
}
