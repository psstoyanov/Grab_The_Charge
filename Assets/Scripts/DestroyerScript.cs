using UnityEngine;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player)") {
			Debug.Break ();

			return;
		}
		if (other.tag == "Boundary") {
			return;
		}
			
			Destroy (other.gameObject);

	}
}
