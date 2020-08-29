// Virtual reality experiments for cognitive science
// Jonathan MIRAULT and Stephane DUFAU
// Laboratoire de psychologie cognitive
// CNRS & Aix-Marseille University, France
// Original code from Tobii VR examples
//
// Each time the eye position is updated (90 Hz sampling rate), the position and
// orientation of the eye is recorded. When the program quits, data is saved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.Diagnostics;
using System.IO;
using Valve.VR;
using Tobii.G2OM;

// embed external variables from Tobii's HightlightAtGaze script
namespace Tobii.XR.Examples{

  public class SaveEyeTrackingData : MonoBehaviour
  {

    // dataLine holds data from the eye-tracker
    private string dataLine;

    // start TobiiXR
    void Awake()
    {
      var settings = new TobiiXR_Settings();
      TobiiXR.Start(settings);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // path to save the data to
    private string getPath(){
      return Application.dataPath + "/CSV/dataEye.csv";
    }

    // Update is called once per frame
    private void Update () {

      // Get eye tracking data in 3D-world space
      var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

      // Check if gaze ray is valid
      if(eyeTrackingData.GazeRay.IsValid){

        // The origin of the gaze ray is a 3D point
        var rayOrigin = eyeTrackingData.GazeRay.Origin;

        // The direction of the gaze ray is a normalized directional vector
        var rayDirection = eyeTrackingData.GazeRay.Direction;

        // The EyeBlinking boolean is true when the eye is closed
        var isLeftEyeBlinking = eyeTrackingData.IsLeftEyeBlinking;
        var isRightEyeBlinking = eyeTrackingData.IsRightEyeBlinking;

        // print the Focus status of the Cube GameObject (external variable at HighlightAtGaze)
        print(GameObject.Find("Cube").GetComponent<HighlightAtGaze>().Focus);

        // write information in dataLine
        dataLine = dataLine + Time.time.ToString("f6") + ";" +
        rayOrigin.x + ";" +
        rayOrigin.y + ";" +
        rayOrigin.z + ";" +
        rayDirection.x + ";" +
        rayDirection.y + ";" +
        rayDirection.z + ";" +
        isLeftEyeBlinking + ";" +
        isRightEyeBlinking + ";" +
        GameObject.Find("Cube").GetComponent<HighlightAtGaze>().Focus + ";" +
        "\n";

      }
    }

    // write data to a file when the executable quits
    void OnApplicationQuit()
    {
      string filePath = getPath();
      StreamWriter writer = new StreamWriter(filePath);
      writer.WriteLine("Time;OriginX;OriginY;OriginZ;DirectionX;DirectionY;DirectionZ;BlinkR;BlinkL;Focus;");
      writer.WriteLine(dataLine);
      writer.Flush();
      writer.Close();
    }
  }
}
