using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {

	public static float batteryLevel = 0f;

	 float Speed = 0f; 
	 float maxSpeed = 40;
	 float minSpeed = 1f; 
	 float hoverForce = 65f;
	 float hoverHeight = 1f;

	 bool jumped = false;
	 float jumpForce = 90.0f;

	 float maxAcceleration = 8f; // Controls the acceleration
	
	private Rigidbody speedsterRigidbody;

	// Use this for initialization
	void Awake () 
	{
		speedsterRigidbody= GetComponent <Rigidbody>();
	
	}

	void OnCollisionEnter(Collider other)
	{
		if (other.tag == "Battery")
		{
			batteryLevel += 25f;
			
		}
		if (other.tag == "Enemy")
		{
			Debug.Log("enemy");
			batteryLevel -= 50f;
		}
		Destroy (other.gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Speed += maxAcceleration* Time.deltaTime;
		Speed = Mathf.Clamp(Speed,minSpeed,maxSpeed);


		//Touch myTouch = Input.GetTouch(0);


		if(Input.touchCount > 0 )
		{
			Touch myTouch = Input.GetTouch(0);
			if(myTouch.phase == TouchPhase.Began)
			{
				jumped=true;
			}
			
		}




	}



	void FixedUpdate()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, hoverHeight))
		{
		   float proportionalHeight = (hoverHeight - hit.distance)/ hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			speedsterRigidbody.AddForce(appliedHoverForce);
		}

		if(jumped)
		{
			speedsterRigidbody.AddForce(Vector3.up * jumpForce * maxAcceleration, ForceMode.Force);
			jumped = false;
		}



		speedsterRigidbody.AddForce( Speed,0f, 0f);

	}
}
