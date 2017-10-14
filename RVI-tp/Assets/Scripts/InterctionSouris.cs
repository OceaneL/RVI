using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterctionSouris : MonoBehaviour {

	public Text gt;
	private bool displayed = false;
	private GameObject selectedObject = null;
    private float lastH;
    private float lastV;
    private bool objectIsSelected = false;
    private bool objectIsSelected2 = false;
    private GameObject selectedObject2 = null;

	// Use this for initialization
	void Start () {
		
	}



				
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

                if (selectedObject != hitInfo.transform.gameObject || displayed == false)
                {
                    displayed = true;
                    selectedObject = hitInfo.transform.gameObject;
                }
                else
                {
                    displayed = false;
                    //selectedObject = null;
                }

                objectIsSelected = true;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            objectIsSelected = false;
        }
       // Debug.Log(objectIsSelected);
        if (Input.GetMouseButton(0) && objectIsSelected)
        {
            Plane groundPlane = new Plane(Vector3.up, selectedObject.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (groundPlane.Raycast(ray, out rayDistance)) {
                selectedObject.transform.position = ray.GetPoint(rayDistance);
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

                selectedObject2 = hitInfo.transform.gameObject;
                objectIsSelected2 = true;

            }

        }

        if (Input.GetMouseButtonUp(1))
        {
            objectIsSelected = true;
        }


        if (Input.GetMouseButton(1) && objectIsSelected2)
        {
            Plane groundPlane = new Plane(Camera.main.transform.forward, selectedObject2.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (groundPlane.Raycast(ray, out rayDistance))
            {
                selectedObject2.transform.position = ray.GetPoint(rayDistance);
            }

        }
	}

	void OnGUI(){
		if (displayed) {
			Vector3 pos = selectedObject.transform.position;
			Vector3 pos2d = Camera.main.WorldToScreenPoint (pos);
			Rect posRect = new Rect (pos2d.x, Screen.height - pos2d.y, 100, 100);
			GUI.Label(posRect, selectedObject.name + "\n"+ pos); 
		}
	}

    
}
