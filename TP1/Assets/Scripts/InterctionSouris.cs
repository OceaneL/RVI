using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterctionSouris : MonoBehaviour {

	public Text gt;
	private bool displayed = false;
	private GameObject selectedObject = null;

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
                Debug.Log(hitInfo.transform.gameObject.name);
				if (selectedObject != hitInfo.transform.gameObject) {
					displayed = true;
					selectedObject = hitInfo.transform.gameObject;
				} else {
					displayed = false;
					selectedObject = null;
				}
				
                /*if (hitInfo.transform.gameObject.GetComponent(typeof(GUIText)) == null)
                {
                    //GUIText gt = hitInfo.transform.gameObject.AddComponent(typeof(GUIText)) as GUIText;
                    gt.text = hitInfo.transform.gameObject.name;
					//gt.rectTransform.position = hitInfo.point;
					gt.alignment = TextAnchor.MiddleCenter;
                }*/

				/*
				var horizontalSpeed = 2.0;

				function OnMouseDrag()
				{
					var h = horizontalSpeed * Input.GetAxis ("Mouse X");
					transform.Translate(h, 0, 0);
				}
				*/
            }

        }
	}

	void OnGUI(){
		if (displayed) {
			Vector3 pos = selectedObject.transform.position;
			Vector3 pos2d = Camera.main.WorldToScreenPoint (pos);
			Rect posRect = new Rect (pos2d.x, pos2d.y, 100, 100);
			GUI.Label(posRect, selectedObject.name + "\n"+ pos); 
		}
	}
}
