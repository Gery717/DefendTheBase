using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDController : MonoBehaviour {

	public Text AmountOfPointsText;
	public Toggle greenTowerButton;
	public Toggle blueTowerButton;
	public Toggle redTowerButton;
	public Toggle BlockerButton;
	public Toggle rangeToggle;

	void Start () 
	{
		greenTowerButton.enabled = true;
		blueTowerButton.enabled = true;
		redTowerButton.enabled = true;
		BlockerButton.enabled = true;
		greenTowerButton.isOn = true;
		blueTowerButton.isOn = false;
		redTowerButton.isOn = false;
		BlockerButton.isOn = false;
		AmountOfPointsText.text = "0";
		greenTowerButton.onValueChanged.AddListener (greenChanged);
		blueTowerButton.onValueChanged.AddListener (blueChanged);
		redTowerButton.onValueChanged.AddListener (redChanged);
		BlockerButton.onValueChanged.AddListener (BlockerChanged);
		rangeToggle.onValueChanged.AddListener(showRangeChanged);
		GameController.showRange = rangeToggle.isOn;
	}

	void showRangeChanged(bool on)
	{
		GameController.showRange = on;
	}

	void greenChanged(bool on)
	{
		if (on)
			GameController.selectedTower = GameController.SelectedTowerEnum.Green;
	}

	void blueChanged(bool on)
	{
		if (on)
			GameController.selectedTower = GameController.SelectedTowerEnum.Blue;
	}

	void redChanged(bool on)
	{
		if (on)
			GameController.selectedTower = GameController.SelectedTowerEnum.Red;
	}

	void BlockerChanged(bool on)
	{
		if (on)
			GameController.selectedTower = GameController.SelectedTowerEnum.Blocker;
	}

	void Update () 
	{
		AmountOfPointsText.text = GameController.Points.ToString ();
		if (GameController.selectedTower == GameController.SelectedTowerEnum.Green) 
		{
			greenTowerButton.isOn = true;
			blueTowerButton.isOn = false;
			redTowerButton.isOn = false;
			BlockerButton.isOn = false;
		}
		if (GameController.selectedTower == GameController.SelectedTowerEnum.Blue) 
		{
			blueTowerButton.isOn = true;
			greenTowerButton.isOn = false;
			redTowerButton.isOn = false;
			BlockerButton.isOn = false;
		}
		if (GameController.selectedTower == GameController.SelectedTowerEnum.Red) 
		{
			redTowerButton.isOn = true;
			blueTowerButton.isOn = false;
			greenTowerButton.isOn = false;
			BlockerButton.isOn = false;
		}
		if (GameController.selectedTower == GameController.SelectedTowerEnum.Blocker) 
		{
			BlockerButton.isOn = true;
			blueTowerButton.isOn = false;
			greenTowerButton.isOn = false;
			redTowerButton.isOn = false;
		}

		if (GameController.Points < GameController.priceOfGreenTower) 
		{
			greenTowerButton.enabled = false;
			BlockerButton.enabled = false;
			blueTowerButton.enabled = false;
			redTowerButton.enabled = false;
		} 
		else if (GameController.Points < GameController.priceOfBlocker && GameController.Points >= GameController.priceOfGreenTower) 
		{
			greenTowerButton.enabled = true;
			BlockerButton.enabled = false;
			blueTowerButton.enabled = false;
			redTowerButton.enabled = false;
		} 
		else if (GameController.Points >= GameController.priceOfBlocker && GameController.Points < GameController.priceOfBlueTower) 
		{
			greenTowerButton.enabled = true;
			BlockerButton.enabled = true;
			blueTowerButton.enabled = false;
			redTowerButton.enabled = false;
		} 
		else if (GameController.Points >= GameController.priceOfBlueTower && GameController.Points < GameController.priceOfRedTower) 
		{
			greenTowerButton.enabled = true;
			BlockerButton.enabled = true;
			blueTowerButton.enabled = true;
			redTowerButton.enabled = false;
		} 
		else if (GameController.Points >= GameController.priceOfRedTower) 
		{
			greenTowerButton.enabled = true;
			BlockerButton.enabled = true;
			blueTowerButton.enabled = true;
			redTowerButton.enabled = true;
		}

	}

}
