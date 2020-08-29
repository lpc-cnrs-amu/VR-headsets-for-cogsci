using System.Collections;
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
	
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Support"){
		// this rigidbody hit the player
		print("ok !");
		}
	}
}
