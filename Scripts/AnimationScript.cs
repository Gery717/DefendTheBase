using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour 
{
	public Button newGameButton;
	public Button helpButton;
	public Button exitButton;
	public GameObject helpPanel;
	public Button closeHelpButton;

	void newGameClick ()
	{
		Application.LoadLevel ("Map1");
	}

	void helpClick ()
	{
		helpPanel.SetActive (true);
	}

	void exitClick()
	{
		Application.Quit ();
	}

	void exitHelp()
	{
		helpPanel.SetActive (false);
	}

	void Start () 
	{
		helpPanel.SetActive (false);
		newGameButton.onClick.AddListener (newGameClick); 
		helpButton.onClick.AddListener (helpClick);
		exitButton.onClick.AddListener (exitClick);
		closeHelpButton.onClick.AddListener (exitHelp);
	}
	
	void LateUpdate ()
	{
		transform.Rotate (new Vector3 (1, 0, 0) * Time.deltaTime);
	}
}
