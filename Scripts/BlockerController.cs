using UnityEngine;
using System.Collections;

public class BlockerController : MonoBehaviour {
	
	void Start () 
	{
		
	}

	void LateUpdate () 
	{
		transform.Rotate (new Vector3 (45, 45, 45) * Time.deltaTime);
	}
}
