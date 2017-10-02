using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationFPS : MonoBehaviour {

    public float horizontalRotation = 4;
    public float verticalRotation = 4;
    public float speedTranslation = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var h = horizontalRotation * Input.GetAxis("Mouse X");
        var v = verticalRotation * Input.GetAxis("Mouse Y");
       // this.transform.Rotate(Vector3.up * h * Time.deltaTime *100, Space.World);
        //this.transform.Rotate(Vector3.right * -v * Time.deltaTime *100, Space.Self);
        // Yaw happens "over" the current rotation, in global coordinates.
        Quaternion yaw = Quaternion.Euler(0f, h * speedTranslation *  Time.deltaTime *50, 0f);
        transform.rotation =  yaw * transform.rotation;

        // Pitch happens "under" the current rotation, in local coordinates.
        Quaternion pitch = Quaternion.Euler(-v * speedTranslation * Time.deltaTime *50, 0f, 0f);
        transform.rotation = transform.rotation * pitch;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        this.transform.Translate(movement * speedTranslation * Time.deltaTime *50);
	}
}
