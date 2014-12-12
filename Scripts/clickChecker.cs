using UnityEngine;
using System.Collections;

public class clickChecker : MonoBehaviour {

	Rect button;

	void Start () 
	{
		float width = Screen.width;
		float height = Screen.height;
		button = new Rect (width - 150, height - 300, 150, 300);
	}

	void Update () 
	{
		if (button.Contains (Input.mousePosition))
			GameController.setMouseOverGUI (true);
		else
			GameController.setMouseOverGUI (false);
	}
}
