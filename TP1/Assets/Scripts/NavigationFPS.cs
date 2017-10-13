using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationFPS : MonoBehaviour {

    public float horizontalRotation = 4;
    public float verticalRotation = 4;
    public float speedTranslation = 2;
    public Vector3 initMousePosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(1))
            {
                initMousePosition = Input.mousePosition;
            }
            Vector3 translate = Input.mousePosition - initMousePosition;
            this.transform.Translate(translate.x * 0.01f, 0, translate.y * 0.01f);
        }
        else
        {
            if (Input.GetMouseButton(0)) { 
                var h = horizontalRotation * Input.GetAxis("Mouse X");
                var v = verticalRotation * Input.GetAxis("Mouse Y");
                // this.transform.Rotate(Vector3.up * h * Time.deltaTime *100, Space.World);
                //this.transform.Rotate(Vector3.right * -v * Time.deltaTime *100, Space.Self);
                // Yaw happens "over" the current rotation, in global coordinates.
                Quaternion yaw = Quaternion.Euler(0f, h * speedTranslation * Time.deltaTime * 50, 0f);
                transform.rotation = yaw * transform.rotation;

                // Pitch happens "under" the current rotation, in local coordinates.
                Quaternion pitch = Quaternion.Euler(-v * speedTranslation * Time.deltaTime * 50, 0f, 0f);
                transform.rotation = transform.rotation * pitch;
            }
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            this.transform.Translate(movement * speedTranslation * Time.deltaTime * 50);
        }
	}
}
