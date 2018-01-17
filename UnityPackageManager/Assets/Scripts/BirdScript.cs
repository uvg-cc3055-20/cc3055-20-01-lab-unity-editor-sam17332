using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
	public float jumpForce = 35f;
	public float forwardSpeed = 2f;
	public Rigidbody2D rb;
	public GameObject cam;
	public bool dead = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (dead == false) {
			if (Input.GetButtonDown ("Jump")) {
				rb.velocity = Vector2.zero;
				rb.AddForce (Vector2.up * jumpForce);
			}
			rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
			cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
		}
		if (rb.transform.position.x>25)
		{
			dead = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if(collision.gameObject.CompareTag("coin"))
			{
				Destroy(collision.gameObject);
			}
		else
			{
				dead = true;
			}
	}
}
