// Virtual reality experiments for cognitive science
// Jonathan MIRAULT and Stephane DUFAU
// Laboratoire de psychologie cognitive
// CNRS & Aix-Marseille University, France
//
// Descriptin of the logic of a collision
// For each collision, print OK

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// Call the collision listener
	void OnCollisionEnter(Collision col)
	{

    // collision is listened with tags
		if (col.gameObject.tag == "Support"){

		    // this object hit the player
		      print("ok !");

		}
	}
}
