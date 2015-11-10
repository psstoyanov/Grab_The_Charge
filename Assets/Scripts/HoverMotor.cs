using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour 
{

	public float batteryLevel = 0f,
	Speed = 0f, maxSpeed = 40, minSpeed = 1f, hoverForce = 15.0f, 
	jumpForce = 5.0f;
	 float hoverHeight = 3f;
	 
	 // Boolean to control when the player can jump. 
	public bool isGrouded = false;
	public LayerMask playerMask;

	 float maxAcceleration = 8f; // Controls the acceleration
	
	private Rigidbody myBody;
	private Transform myTrans, tagGround;

	// Use this for initialization
	void Awake () 
	{
		myBody= GetComponent <Rigidbody>();
		myTrans = this.transform;
		tagGround = GameObject.Find(this.name +"/tag_ground").transform;
	
	}
	


	void FixedUpdate()
	{
		Speed += maxAcceleration* Time.deltaTime;
		Speed = Mathf.Clamp(Speed,minSpeed,maxSpeed);
		
		isGrouded = Physics.Linecast(myTrans.position, tagGround.position, playerMask); 
		
		Hover();
		
		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		
		Vector3 moveVel = myBody.velocity;
		moveVel.x = Speed;
		myBody.velocity = moveVel;

	}
	
	// Function to jump
	public void Jump()
	{
		if(isGrouded)
		myBody.velocity += Vector3.up * jumpForce;
	}
	
	//The hover function
	void Hover()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, hoverHeight))
		{
		   float proportionalHeight = (hoverHeight - hit.distance)/ hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			myBody.AddForce(appliedHoverForce);
		}
	}
}
