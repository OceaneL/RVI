using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour {

	public Plane groundPlane;
	public GameObject ball;
	public GameObject planeloc;

	// Use this for initialization
	void Start() {
		groundPlane = new Plane (planeloc.transform.forward, planeloc.transform.position);	
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (groundPlane.Raycast (ray, out rayDistance)) {
				Instantiate(ball, ray.GetPoint (rayDistance), Quaternion.identity);
			}

		}
	}

}
