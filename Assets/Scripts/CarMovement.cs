using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
	public float maxVelocity = 50;
	public float hoverForce = 1000;
	public float gravityForce = 1000f;
	public float hoverHeight = 1.5f;
	public float jumpForce = 10f;
	public GameObject[] hoverPoints;

	public float forwardAcceleration = 8000f;
	public float reverseAcceleration = 4000f;
	public float turnStrength = 1000f;

	private Rigidbody _body;
	private float _deadZone = 0.1f; // used to eleminate non existant key presses
	private float _thrust = 0f;
	private float _turnValue = 0f;
	private bool _isJumping = false;
	private int _layerMask;

	void Start()
	{
		_body = GetComponent<Rigidbody>();

		_layerMask = 1 << LayerMask.NameToLayer("Vehicle"); // https://answers.unity.com/questions/8715/how-do-i-use-layermasks.html
		_layerMask = ~_layerMask;
	}

	void Update()
	{
		// get thrust input
		_thrust = 0.0f;
		float acceleration = Input.GetAxis("Vertical");
		if (acceleration > _deadZone)
			_thrust = acceleration * forwardAcceleration;
		else if (acceleration < -_deadZone)
			_thrust = acceleration * reverseAcceleration;

		// get turning input
		_turnValue = 0.0f;
		float turnAxis = Input.GetAxis("Horizontal");
		if (Mathf.Abs(turnAxis) > _deadZone)
			_turnValue = turnAxis;
	}

	void FixedUpdate()
	{
		//  Hover force for each hoverPoint
		RaycastHit hit;
		
		for (int i = 0; i < hoverPoints.Length; i++)
		{
			var hoverPoint = hoverPoints[i];
			Ray ray = new Ray(hoverPoint.transform.position, -transform.up);

			if (Physics.Raycast(ray, out hit, hoverHeight, _layerMask))
			{
				float proprtaionalHeight = (hoverHeight - hit.distance) / hoverHeight;
				Vector3 appliedHoverForce = Vector3.up * proprtaionalHeight * hoverForce;
				_body.AddForceAtPosition(appliedHoverForce, hoverPoint.transform.position);
			}
			else
			{
				if (!_isJumping) // allows car to jump without being pushed down
				{
					// returns the vehicle to horizontal when not grounded
					if (transform.position.y > hoverPoint.transform.position.y)
					{
						_body.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hoverPoint.transform.position);
					}
					else
					{
						_body.AddForceAtPosition(hoverPoint.transform.up * -gravityForce, hoverPoint.transform.position);
					}
				}
			}
		}


		// Handle Forward and Reverse
		if (Mathf.Abs(_thrust) > 0)
		{
			_body.AddForce(transform.forward * _thrust);
		}
		
		// handle Turning
		if (_turnValue > 0 || _turnValue < 0)
		{
			_body.AddRelativeTorque(Vector3.up * _turnValue * turnStrength);
		}
		// limit car velocity to max velocity
		if (_body.velocity.sqrMagnitude > (_body.velocity.normalized * maxVelocity).sqrMagnitude)
		{
			_body.velocity = _body.velocity.normalized * maxVelocity;
		}
		// allow car to jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_body.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
			StartCoroutine(Jumping());
		}
	}

	IEnumerator Jumping()
	{
		// does not activate forces to balance car out while jumping
		_isJumping = true;
		yield return new WaitForSeconds(2.5f);
		_isJumping = false;
	}

}
