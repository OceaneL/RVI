using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public int vitesseRotation = 10;

	// Use this for initialization
	void Start () {
		Debug.Log(this.name);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * vitesseRotation);
	}
}
