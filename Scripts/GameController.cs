using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public Slider playerHealthSlider;
	public static int EnemyOnField;
	public GameObject enemyGreen;
	public GameObject enemyBlue;
	public GameObject enemyRed;
	public GameObject enemyBoss;
	public float timeBetweenSpawns;
	public int numberOfWaves;
	public int enemyPerWave;
	public static float Points;
	float elapsedTime;
	int actualEnemyCount;
	int actualWaveNumber;
	bool waveIsGoing;
	float timeBetweenWaves;
	float waveTimer;
	static bool mouseOverGUI;
	public static int priceOfGreenTower = 100;
	public static int priceOfBlueTower = 500;
	public static int priceOfRedTower = 1000;
	public static int priceOfBlocker = 200;
	public static int actualPlayerHealth;
	public static bool showRange;
	float originalTimescale;
	public Button OkButton;
	public GameObject gameConsole;
	public Text consoleText;
	public GameObject gameOverConsole;
	public Text gameOverText;
	public Button exitButton;
	
	public enum GameStateEnum
	{
		Welcome, showBase, playing
	}

	public enum SelectedTowerEnum
	{
		Green, Blue, Red, Blocker
	}

	public static SelectedTowerEnum selectedTower;
	public static GameStateEnum gameState;

	void exitClicked()
	{
		Application.LoadLevel(0);
	}

	void Start () 
	{
		gameOverConsole.SetActive (false);
		gameConsole.SetActive (true);
		gameState = GameStateEnum.Welcome;
		OkButton.onClick.AddListener (okClicked);
		exitButton.onClick.AddListener (exitClicked);
		originalTimescale = Time.timeScale;
		Time.timeScale = 0;
		Points = 300;
		selectedTower = SelectedTowerEnum.Green;
		waveIsGoing = true;
		elapsedTime = 0;
		actualEnemyCount = 0;
		actualWaveNumber = 0;
		timeBetweenWaves = 15;
		actualPlayerHealth = 10;
	}

	public void okClicked()
	{
		switch (gameState)
		{
		case GameStateEnum.Welcome:
			Camera.main.transform.position = new Vector3(-28.154f, 168.9f, -231.67f);
			gameState = GameStateEnum.showBase;
			consoleText.text = 
				"Your job is to stop them before they reach the communication center!\n" +
				"To do this, you need to build towers on our walls.\n" +
				"So are you ready for a mission?\n";
			break;
		case GameStateEnum.showBase:
			Time.timeScale = originalTimescale;
			Camera.main.transform.position = new Vector3(-22.616f, 161.78f, 84.169f);
			gameState = GameStateEnum.playing;
			gameConsole.SetActive(false);
			break;
		}
	}

	public static void setMouseOverGUI(bool isOver)
	{
		mouseOverGUI = isOver;
	}

	public static bool getMouseOverGui()
	{
		return mouseOverGUI;
	}

	void SpawnEnemies()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > timeBetweenSpawns && actualWaveNumber < numberOfWaves) 
		{
			switch (actualWaveNumber)
			{
			case 0:
			case 1:
			case 2:
				if (actualEnemyCount < enemyPerWave)
				{
					Instantiate (enemyGreen);
					EnemyOnField ++;
					elapsedTime = 0;
					actualEnemyCount ++;
				}
				else
				{
					if (actualWaveNumber == 2)
					{
						Instantiate (enemyBoss);
						EnemyOnField ++;
					}
					actualWaveNumber ++;
					actualEnemyCount = 0;
					elapsedTime = 0;
					waveIsGoing = false;
				}
				break;
			case 3:
			case 4:
			case 5:
				if (actualEnemyCount < enemyPerWave)
				{
					Instantiate (enemyBlue);
					EnemyOnField ++;
					elapsedTime = 0;
					actualEnemyCount ++;
				}
				else
				{
					actualWaveNumber ++;
					actualEnemyCount = 0;
					elapsedTime = 0;
					waveIsGoing = false;
				}
				break;
			case 6:
			case 7:
				if (actualEnemyCount < enemyPerWave)
				{
					Instantiate (enemyRed);
					EnemyOnField ++;
					elapsedTime = 0;
					actualEnemyCount ++;
				}
				else
				{
					actualWaveNumber ++;
					actualEnemyCount = 0;
					waveIsGoing = false;
				}
				break;
			}
			
		}
	}

	void LateUpdate () 
	{
		if (gameState == GameStateEnum.playing) {
						playerHealthSlider.value = actualPlayerHealth;
						if (actualPlayerHealth <= 0) {
				gameOverConsole.SetActive(true);
				Time.timeScale = 0;
								gameOverText.text = "Game Over!\n" +
									"The enemy destroyed the communication center.";
				gameOverConsole.SetActive(true);
						}

						if (waveIsGoing == true)
								SpawnEnemies ();
						else {
								if (EnemyOnField == 0) {
					if (actualWaveNumber == 5)
					{
						Time.timeScale = 0;
						gameOverText.text = "Congratulations!\n" +
							"You saved us from the aliens.\n" +
								"Nice job!";
						gameOverConsole.SetActive(true);
					}
										waveTimer += Time.deltaTime;

										if (waveTimer >= timeBetweenWaves)
												waveIsGoing = true;
								}
						}
				}
	}
}
