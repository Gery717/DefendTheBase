using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyMovementScript : MonoBehaviour 
{
	public Slider slider;
	public Transform target;
	public float Health;
	GameObject explosion;
	GameObject slowingLight;
	float actualHealth;
	NavMeshAgent agent;
	float speedDownTimer;
	public bool isSlowed;

	void Start () 
	{
		isSlowed = false;
		actualHealth = Health;
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination (target.position);
		explosion = GameObject.FindGameObjectWithTag("explosion");
		slowingLight = GameObject.FindGameObjectWithTag("slowing");
		speedDownTimer = 30.0f;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Finish") 
		{
			GameObject g = (GameObject)Instantiate (explosion.gameObject, new Vector3 (transform.position.x, transform.position.y + 20, transform.position.z), Quaternion.identity);	
			ParticleSystem p = g.GetComponent<ParticleSystem> ();
			p.Play();
			GameObject g2 = (GameObject)Instantiate (explosion.gameObject,new Vector3(target.position.x, target.position.y +20, target.position.z), Quaternion.identity);	
			ParticleSystem p2 = g2.GetComponent<ParticleSystem> ();
			p2.startSize = 20;
			p2.Play();
			Destroy(gameObject);
			GameController.EnemyOnField--;
			GameController.actualPlayerHealth--;
		}
	}

	public void Attack(float points)
	{
		actualHealth -= points;
	}

	public void Slow()
	{
		GameObject g = (GameObject)Instantiate (slowingLight.gameObject, new Vector3 (transform.position.x, transform.position.y + 20, transform.position.z), Quaternion.LookRotation(new Vector3(0,1,0)));	
		ParticleSystem p = g.GetComponent<ParticleSystem> ();
		p.Play();
		isSlowed = true;
		agent.speed /= 2;
		agent.acceleration /= 2;
	}

	void Update () 
	{
		if (isSlowed) 
		{
			speedDownTimer -= Time.deltaTime;
			if (speedDownTimer <=0)
			{
				isSlowed = false;
				agent.speed *= 2;
				agent.acceleration *= 2;
			}
		}
		slider.value = (100 / Health)*actualHealth;
		if (actualHealth <= 0) 
		{
			GameObject g = (GameObject)Instantiate (explosion.gameObject, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);	
			ParticleSystem p = g.GetComponent<ParticleSystem> ();
			p.Play();
			GameController.EnemyOnField--;
			GameController.Points += Health;
			Destroy(gameObject);
		}
	}
}
