// Virtual reality experiments for cognitive science
// Jonathan MIRAULT and Stephane DUFAU
// Laboratoire de psychologie cognitive
// CNRS & Aix-Marseille University, France
// Original code from Tobii VR examples
//
// Each time a controller is updated, its positional information is recorded.
// When the program quits, data is saved.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Valve.VR;

public class TrackingControllers : MonoBehaviour
{
  // define GameObjects (hands and buttons)
  public GameObject LeftHand;
  public GameObject RightHand;
  private string dataLine;

  public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
  public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;

  public bool isPressedL;
  public bool isPressedR;

  // Start is called before the first frame update
  void Start(){
  }

  // get the path to save the data to
  private string getPath(){
    return Application.dataPath + "/CSV/dataControllers.csv";
  }

  // Update is called once per frame
  void Update(){

    // initialize local GameObjects (linked to tags)
    LeftHand = GameObject.FindWithTag("LeftHand");
    RightHand = GameObject.FindWithTag("RightHand");

    // read the rotation and position of the GameObjects
    // dataLine hold the data information (position, rotation, action)
    // of each controller
    dataLine = dataLine + Time.time.ToString("f6") + ";"
    + LeftHand.transform.position.x.ToString() + ";"
    + LeftHand.transform.position.y.ToString() + ";"
    + LeftHand.transform.position.z.ToString() + ";"
    + LeftHand.transform.rotation.x.ToString() + ";"
    + LeftHand.transform.rotation.y.ToString() + ";"
    + LeftHand.transform.rotation.z.ToString() + ";"
    + RightHand.transform.position.x.ToString() + ";"
    + RightHand.transform.position.y.ToString() + ";"
    + RightHand.transform.position.z.ToString() + ";"
    + RightHand.transform.rotation.x.ToString() + ";"
    + RightHand.transform.rotation.y.ToString() + ";"
    + RightHand.transform.rotation.z.ToString() + ";"
    + SteamVR_Actions._default.Squeeze.GetAxis(LeftInputSource).ToString() + ";"
    + SteamVR_Actions._default.Teleport.GetState(LeftInputSource) + ";"
    + SteamVR_Actions._default.GrabGrip.GetState(LeftInputSource) + ";"
    + SteamVR_Actions._default.Squeeze.GetAxis(RightInputSource).ToString() + ";"
    + SteamVR_Actions._default.Teleport.GetState(RightInputSource) + ";"
    + SteamVR_Actions._default.GrabGrip.GetState(RightInputSource) + ";"
    + "\n";

    // get the status of the controllers' buttons
    isPressedL = SteamVR_Actions._default.Teleport.GetState(LeftInputSource);
    isPressedR = SteamVR_Actions._default.Teleport.GetState(RightInputSource);

    // render a sphere at the controller's position if a button is pressed
    // left controller
    if (isPressedL==true){
      GameObject cubeObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      cubeObj.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
      cubeObj.transform.position= LeftHand.transform.position;
      cubeObj.GetComponent<Renderer>().material.color = new Color(255,0,0);
      cubeObj.GetComponent<Collider>().enabled = false;
    }

    // left controller
    if (isPressedR==true){
      GameObject cubeObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      cubeObj.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
      cubeObj.transform.position= RightHand.transform.position;
      cubeObj.GetComponent<Renderer>().material.color = new Color(0,255,0);
      cubeObj.GetComponent<Collider>().enabled = false;
    }
  }

  // save the data when the executable quits
  void OnApplicationQuit()
  {
    string filePath = getPath();
    StreamWriter writer = new StreamWriter(filePath);
    writer.WriteLine("Time;" +
    "CoLeftPosX;CoLeftPosY;CoLeftPosZ;" +
    "CoLeftRotX;CoLeftRotY;CoLeftRotZ;" +
    "CoRightPosX;CoRightPosY;CoRightPosZ;" +
    "CoRightRotX;CoRigthRotY;CoRightRotZ;" +
    "CoLeftBut1;CoLeftBut2;CoLeftBut3;" +
    "CoRightBut1;CoRightBut2;CoRightBut3");
    writer.WriteLine(dataLine);
    writer.Flush();
    writer.Close();
  }
}
