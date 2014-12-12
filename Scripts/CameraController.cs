using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public float speed;
	float ZoomAmount= 0; //With Positive and negative values
	float MaxToClamp = 10;
	float ROTSpeed = 100;
	void Start () {
	
	}

	void LateUpdate () 
	{
			ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
			ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
			var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
			gameObject.transform.Translate(0,0,translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
		transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*Time.deltaTime*speed;
	}
}
