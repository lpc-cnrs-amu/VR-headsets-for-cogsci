using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingArrows : MonoBehaviour
{
    public float speed = 0.1f;
 
     void Update () {
         Vector3 pos = transform.position;
 
         if (Input.GetKey ("z")) {
             pos.z += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.z -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("q")) {
             pos.x -= speed * Time.deltaTime;
         }
           
         transform.position = pos;
     }
}
