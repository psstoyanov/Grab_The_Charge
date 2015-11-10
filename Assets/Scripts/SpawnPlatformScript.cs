using UnityEngine;

public class SpawnPlatformScript : MonoBehaviour {

	public GameObject obj;
	Vector3 lastspawnPos;
	Vector3 currPos;
	float deltaDistance;
	float spawnDistance = 19;
	

	void Init()
	{
		currPos = lastspawnPos = transform.position;
		deltaDistance = 0;

		for (int i = 0; i<=6; i++) 
		{
			float startSpansDist = i* spawnDistance;
			Instantiate (obj, new Vector3(
				transform.position.x - startSpansDist,
				transform.position.y,
				transform.position.z), Quaternion.identity);
		}
	}
	// Use this for initialization
	void Start () 
	{
		Init();
	}


	
	void Update()
	{
		currPos = transform.position;
		deltaDistance = currPos.x - lastspawnPos.x;
	}
	void FixedUpdate()
	{
		if (deltaDistance > spawnDistance) 
		{
			Instantiate (obj, transform.position, Quaternion.identity);
			lastspawnPos = currPos;
			deltaDistance = 0;
		}
	}
}
