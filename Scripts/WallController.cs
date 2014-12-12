using UnityEngine;
using System.Collections;
using System.Linq;

public class WallController : MonoBehaviour {

	public GameObject particleSystem;
	public GameObject particleSystemBad;
	bool hasTower;
	int price;

	void Start () 
	{
		hasTower = false;
		price = GameController.priceOfGreenTower;
		particleSystemBad = GameObject.FindGameObjectWithTag("badParticle");
	}

	void OnMouseDown() 
	{

		if (!hasTower && !GameController.getMouseOverGui())
		{
			Vector3 pos = this.gameObject.transform.position;
			hasTower = true;

			switch(GameController.selectedTower)
			{
			case GameController.SelectedTowerEnum.Green:
				if (GameController.Points >= price)
				{
					GameObject newGreen = (GameObject)Instantiate ((Resources.Load("TowerGreen")));
					newGreen.transform.position = new Vector3 (pos.x, pos.y + 10, pos.z);
					newGreen.SetActive (true);
					GameController.Points -= price;
				}
				break;
			case GameController.SelectedTowerEnum.Blue:
				if (GameController.Points >= price)
				{
					GameObject newBlue = (GameObject)Instantiate ((Resources.Load("TowerBlue")));
					newBlue.transform.position = new Vector3 (pos.x, pos.y + 10, pos.z);
					newBlue.SetActive (true);
					GameController.Points -= price;
				}
				break;
			case GameController.SelectedTowerEnum.Red:
				if (GameController.Points >= price)
				{
					GameObject newRed = (GameObject)Instantiate ((Resources.Load("TowerRed")));
					newRed.transform.position = new Vector3 (pos.x, pos.y + 10, pos.z);
					newRed.SetActive (true);
					GameController.Points -= price;
				}
				break;
			case GameController.SelectedTowerEnum.Blocker:
				if (GameController.Points >= price)
				{
					GameObject newBlocker = (GameObject)Instantiate ((Resources.Load("Blocker")));
					newBlocker.transform.position = new Vector3 (pos.x, pos.y + 15, pos.z);
					newBlocker.SetActive (true);
					GameController.Points -= price;
				}
				break;
			}
		}
	}

	void OnMouseEnter()
	{
		if (price > GameController.Points || hasTower) 
		{
			particleSystemBad.SetActive (true);
			Vector3 pos = this.gameObject.transform.position;
			particleSystemBad.transform.position = new Vector3 (pos.x, pos.y + 10, pos.z);
		} 
		else 
		{
			particleSystem.SetActive (true);
			Vector3 pos = this.gameObject.transform.position;
			particleSystem.transform.position = new Vector3 (pos.x, pos.y + 10, pos.z);
		}
	}

	void OnMouseExit()
	{
		particleSystemBad.SetActive (false);
		particleSystem.SetActive (false);
	}

	void LateUpdate () 
	{
		switch(GameController.selectedTower)
		{
		case GameController.SelectedTowerEnum.Green:
			price = GameController.priceOfGreenTower;
			break;
		case GameController.SelectedTowerEnum.Blue:
			price = GameController.priceOfBlueTower;
			break;
		case GameController.SelectedTowerEnum.Red:
			price = GameController.priceOfRedTower;
			break;
		case GameController.SelectedTowerEnum.Blocker:
			price = GameController.priceOfBlocker;
			break;
		}
	}
}
