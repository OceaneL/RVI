﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigationCible : MonoBehaviour
{

    public float horizontalRotation = 4;
    public float verticalRotation = 4;
    public float speedTranslation = 2;
    public Vector3 objectPosition;
    public Vector3 initCameraPosition;
    public float initMousePosition;
    public float initMousePositionX;
    public bool active = false;
    public Quaternion InitRotation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    objectPosition = hitInfo.point;
                    active = true;
                    initMousePosition = Input.mousePosition.y;
                    initMousePositionX = Input.mousePosition.x;
                    initCameraPosition = this.transform.position;
                    InitRotation = this.transform.rotation;

                }
            }
            if (active)
            {
                float total = initMousePosition;
                float depLoc = initMousePosition - Input.mousePosition.y;
                float depPour = depLoc / total;
                depPour = Mathf.Min(depPour, 0.99f);
                depPour = Mathf.Max(depPour, 0.00f);
                Vector3 transl = objectPosition - initCameraPosition;
                this.transform.position = initCameraPosition + (transl * depPour);
                /*var h = initMousePositionX - Input.mousePosition.x;
                Quaternion yaw = Quaternion.Euler(0f, h * Time.deltaTime, 0f);
                this.transform.rotation = yaw * InitRotation;*/
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                print(ray.direction);
                //Debug.DrawRay(this.transform.position, ray.direction, Color.green, 100);
                var h = this.transform.up.x - ray.direction.x;
                this.transform.Rotate(Vector3.up * h * Time.deltaTime * 5000, Space.Self);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            active = false;
        }

        
        /*if (Input.GetMouseButton(0))
        {
            var h = horizontalRotation * Input.GetAxis("Mouse X");
            this.transform.Rotate(Vector3.up * h * Time.deltaTime *100, Space.World);
            //this.transform.Rotate(Vector3.right * -v * Time.deltaTime *100, Space.Self);
        }*/
        
    }
}
