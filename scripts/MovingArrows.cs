// Virtual reality experiments for cognitive science
// Jonathan MIRAULT and Stephane DUFAU
// Laboratoire de psychologie cognitive
// CNRS & Aix-Marseille University, France
//
// On each update of the game loop, listen to the input of the keyboard specific keys.
// If directional keys (z,s,d,q forming a pad in AZERTY layout) is pressed,
// speed is modified in the z- or x-dimension.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingArrows : MonoBehaviour
{
	// declare speed
	public float speed = 0.1f;

	// update is called on each iteration of the game loop
	void Update () {

		// declare the position object
		Vector3 pos = transform.position;

		// detect if z,s,d,q is pressed
		if (Input.GetKey ("z")) {
			// z-postion is increased if z key is pressed (going forward)
			pos.z += speed * Time.deltaTime;
		}
		if (Input.GetKey ("s")) {
			// z-postion is decreased if s key is pressed (going backward)
			pos.z -= speed * Time.deltaTime;
		}
		if (Input.GetKey ("d")) {
			// x-postion is increased if d key is pressed (going right)
			pos.x += speed * Time.deltaTime;
		}
		if (Input.GetKey ("q")) {
			// x-postion is decreased if q key is pressed (going left)
			pos.x -= speed * Time.deltaTime;
		}

		// apply the computed transformation
		transform.position = pos;
		
	}
}
