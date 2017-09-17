using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class CameraDualPoint : MonoBehaviour {

	// Use this for initialization

    

    Camera cam;
    public GameObject cible;
    public int speed = 20;
    public Vector3 position;
    public Quaternion rotation;


    void UpdateCamera() {
        if (cible != null)
        {
            transform.LookAt(cible.transform);
            transform.position = position;
        }
        else { 
            transform.SetPositionAndRotation(position, rotation);
        }
    }
	void Start () {
        UpdateCamera();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCamera();
	}
}
