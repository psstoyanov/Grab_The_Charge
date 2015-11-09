using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	//when to spawn
	public float spawnMin = 1f;
	public float spawnMax = 3f;

	public float offsetY;



	Vector3 lastspawnPos;
	Vector3 currPos;
	float deltaDistance;
	float spawnDistance;
	float spawnDistanceMin = 30f;
	float spawnDistanceMax = 70f;

	// Use this for initialization
	void Start () {
		Init ();
		//Spawn();
	}
	void Init()
	{
		updateSpawnDist();
		currPos = lastspawnPos = transform.position;
	}
	void updateSpawnDist()
	{
		spawnDistance = Random.Range (spawnDistanceMin, spawnDistanceMax);
	}
	
	void Spawn()
	{
		Instantiate (obj[Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);

		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}

	void Update()
	{
		if (deltaDistance > spawnDistance) 
		{
			Instantiate (obj[Random.Range (0, obj.GetLength (0))],
			             new Vector3(transform.position.x,
			            transform.position.y + offsetY,transform.position.z), Quaternion.identity);
			lastspawnPos = currPos;
			deltaDistance = 0;
			updateSpawnDist();
		}
	}
	void LateUpdate()
	{
		currPos = transform.position;
		deltaDistance = currPos.x - lastspawnPos.x;
	}
}
