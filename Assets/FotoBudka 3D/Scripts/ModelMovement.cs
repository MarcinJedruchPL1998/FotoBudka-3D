using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelMovement : MonoBehaviour
{
    [SerializeField] private GameObject modelPos;
    GameObject model;
    public bool isMoving;
    [SerializeField] private float movementSpeed;

    [SerializeField] private Slider slider;
    float sliderZoom;
    [SerializeField] float sliderPower;
    public bool zooming;
    private void Start()
    {
        sliderZoom = 5f;
    }

    private void Update()
    {
        if(modelPos.transform.childCount > 0)
        {
            model = modelPos.transform.GetChild(0).gameObject;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
        }

        else if(Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            zooming = false;
        }
        

        if(isMoving && !zooming)
        {
            float Xrot = Input.GetAxis("Mouse X") * movementSpeed * Time.deltaTime;
            float Yrot = Input.GetAxis("Mouse Y") * movementSpeed * Time.deltaTime;

            model.transform.Rotate(Vector3.down, Xrot);
            model.transform.Rotate(Vector3.right, Yrot);
        }

        Camera.main.orthographicSize = sliderZoom;
    }

    public void SliderZoom(float zoom)
    {
        zooming = true;
        zoom = 5f - slider.value * sliderPower; 
        sliderZoom = zoom;
    }
}
