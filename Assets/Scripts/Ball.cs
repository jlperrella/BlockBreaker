using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3	paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
			// lock the ball position to paddle position
			this.transform.position = paddle.transform.position + paddleToBallVector;
	
			// launch on left mouse button
			if (Input.GetMouseButtonDown(0)){
				print ("mouse clicked, launch ball");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
	
	void onCollisionEnter2D (Collision2D collision) {
		//Simulates a degree of randomness to ball bounce
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.3f), Random.Range(0f,0.3f));
		rigidbody2D.velocity += tweak;
	}
}
