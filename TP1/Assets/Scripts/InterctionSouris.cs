using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InterctionSouris : MonoBehaviour {

	public Text gt;

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
                if (hitInfo.transform.gameObject.GetComponent(typeof(GUIText)) == null)
                {
                    //GUIText gt = hitInfo.transform.gameObject.AddComponent(typeof(GUIText)) as GUIText;
                    gt.text = hitInfo.transform.gameObject.name;
					//gt.rectTransform.position = hitInfo.point;
					gt.alignment = TextAnchor.MiddleCenter;
                }
            }

        }
	}
}
