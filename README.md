# Virtual reality headsets for Cognitive science

**Virtual reality experiments for cognitive science**

Jonathan MIRAULT and Stephane DUFAU

Laboratoire de psychologie cognitive
 CNRS &amp; Aix-Marseille University, France

_ **Guide written in AUGUST 2020** _

[Forewords 2](#_Toc49533948)

[1. Software installation 3](#_Toc49533949)

[1.1. Unity 3](#_Toc49533950)

[1.2. SteamVR 3](#_Toc49533951)

[2. One tool for several experimental configurations 4](#_Toc49533952)

[2.1. Display the Windows Desktop in the headset 4](#_Toc49533953)

[2.2. World creation in Unity 4](#_Toc49533954)

[2.3. Record eye positions (eye tracking feature) 6](#_Toc49533955)

[2.4. Head and mouse tracking 6](#_Toc49533956)

[2.5. Controller tracking 6](#_Toc49533957)

[3. EXTERNAL SOURCES 8](#_Toc49533958)

[3.1. Setting the HTC Vive eye-tracking 9](#_Toc49533959)

# Forewords

This guide was realized in the Cognitive Psychology Lab (CNRS &amp; Aix-Marseille University) using the following Virtual Reality setup:

- one **DELL Precision desktop** (Intel Core i7 8700K processor, 6 cores at 3.7 Ghz; 16 GB of RAM) with a NVIDIA GTX 1060 graphic card. The monitor was standard.
- one **HTC Vive Pro** (cost: ~1000/1500 $). Beware of the location of the stores as product may vary from one place to the other.

The scientific programs created in this guide were successfully tested on both the HTC and the FOVE headsets. Chosen software is free-of-use.

You can refer to the related scientific article published at XXX.

# 1. Software installation

## 1.1. Unity

Unity ([https://unity.com](https://unity.com/)) is a cross-platform game engine that supports external C# scripts. Download the version that suits your professional situation.

## 1.2. SteamVR

SteamVR ([https://store.steampowered.com/app/250820/SteamVR/](https://store.steampowered.com/app/250820/SteamVR/)) is handy middleware that supports many headsets including HTC and FOVE: one experiment programmed in Unity can be played on many headsets without extensive manipulation.

First, download Steam ([https://store.steampowered.com/about/](https://store.steampowered.com/about/)), install it, plug your headset and follow the procedure to install SteamVR.

Alternatively, SteamVR installation can be achieved within Unity (download the &quot;SteamVR&quot; plug-in). To do this, go to the &quot;Asset store&quot; in Unity, type &quot;SteamVR Plugin&quot;, then download and import it. Import and/or accept all the windows that will pop up onscreen.

SteamVR supports most of the virtual reality headsets but in rare case, you will need additional drivers like, for example, with the Fove or Razer Hydra headsets.

Prior the first utilization, define the kind of setup between &quot;room-scale&quot; and &quot;standing only&quot; in the SteamVR software, clicking on &quot;Room setup&quot; (Figure 1).

![](RackMultipart20200828-4-cgn1l1_html_db83da954bdc79b0.png) ![](RackMultipart20200828-4-cgn1l1_html_abff17e63066a4e3.png)

Figure 1. Room setup selection window (left) and SteamVR options&#39; list (right).

# 2. One tool for several experimental configurations

## 2.1. Display the Windows Desktop in the headset

Displaying the Windows desktop (computer-like headset use) is great for running web browsers and other software already installed on the computer: an immersive experience for the participant and a control of external visual distractor for the experimenter. Any experiment tool such as OpenSesame, E-Prime, Matlab or DMDX can easily be converted into a 2D-projection in a virtual environment. In the 3d virtual world, the screen is displayed at a fixed location, mimicking the reality, meaning that when you moved the head, the display does not follow your head. This sort of reality replication is the key to avoid virtual sickness (nausea).

To display the Windows desktop of the computer, run SteamVR and press the menu button of a controller, then click on the &quot;Desktops&quot; icon on the bottom left hand corner (Figure 2, top panel). You can modify the size of the screen from 75 to 150% (Figure 2, bottom panel).

![](RackMultipart20200828-4-cgn1l1_html_975866f0e6001211.png)

![](RackMultipart20200828-4-cgn1l1_html_87b21ae8b77bce68.png)

Figures 2. Access to the Windows desktop from the menu of SteamVR (top) and choosing the size of the display (bottom).

You can alternatively install a Steam plugin such as Virtual desktop ([https://www.vrdesktop.net](https://www.vrdesktop.net/); 12 $) that has many more features (multi-monitor, custom environment, etc).

## 2.2. World creation in Unity

The world created in tis section is generic and will serve in all the proposed experiments.

**World creation**. When Unity is launched, an empty scene is created. It is composed of an infinite world divided into 2 zones: a dark one for the ground and a blueish one for the sky. The two zones are separated by a curved horizontal line. In the scene, there is by default one light and one camera. In all the VR experiments proposed here, we change the _external_ setting of the camera to setting corresponding to the _participant point of view_ (his/her gaze). The camera setting in this context corresponds to a Point Of View shot (subjective camera). We will call the participant the &quot;Player&quot;. For most of the experiments, we also need a plane (a physical surface) on which the Player and some virtual objects can stand on. These objects (a square, a ball, etc) are the &quot;gameObjects&quot;. So that&#39;s all for our initial 3D world in Unity: a Player in a scene with gameObjects the Player can interact with.

**Object creation**. Surfaces and 3D objects are easy to set: into the &quot;Hierarchy&quot; panel (the location of this panel could change according to your software configuration), right-click in the empty zone. Under the &quot;3D Object&quot; menu, select the objects to put in the world. In the &quot;Inspector&quot; panel, you can precisely set the location and the size of the objects. Keep in mind that 1 unit stands for 1 meter in this software.

**Component**** creation **. It is important to dissociate the virtual environment from virtual reality. Within virtual reality, you can create a virtual environment for a 2D use or one for a 3D use. We focused in this guide on 3D worlds. We therefore want to set the compatibility of the created environment to virtual reality: for this, go to** Unity \&gt; Edit \&gt; Project Settings \&gt; Player \&gt; XR Settings**. Make sure that (i) the &quot;Virtual Reality Supported&quot; option box is checked and (ii) &quot;OpenVR&quot; is the Virtual Reality SDK selected (see Figure 3).

![](RackMultipart20200828-4-cgn1l1_html_c153f7a8e203a171.png)

Figure 3. Setting &quot;OpenVR&quot; as the main SDK in Project Settings.

Next, import the SteamVR plugin (installed in 1.2) into your project. This plugin has many components. One of them, the Player prefab, is to be put into the scene. For this, after the import step, type &quot;Player&quot; in the search bar of the Project panel. Drag and drop the Player prefab in the scene onto your plane. For a human-size display, set the Y position value to zero in the &quot;Inspector&quot; panel.

## 2.3. Record eye positions (eye tracking feature)

Getting the eye-tracking data follows 2 steps: (i) some modifications on the Unity side and (2) the creation of a C# script. Using the world created in 2.2, add some new piece of software. This process is described in section XXX of this document. At step 6 of the additional setup, the VIVE SDK is used (which needs SRanipal&#39;s SDK), but it could be replaced by the Tobii item which does not need any additional SDK.

After this additional setup, we will modify the script to continuously record the gaze position (90 Hz sampling rate) and record an event (trigger) when the gaze hits a target object. The script, called &quot;SaveEyeTrackingData.cs&quot;, is available in the actual repository. It originates from a script proposed in the examples of the Tobii SDK. The script HighlightAtGaze from Tobii is copied to the actual repository.

To record eye movments, create a new C# script and attach it to the TobiiXR Initializer. Copy the code from &quot;SaveEyeTrackingData.cs&quot; to your script. What the script does is the following: each time the eye position is updated (90 Hz sampling rate), the position and orientation of the eye is recorded. When the program quits, data is saved

## 2.4. Head and mouse tracking

Following a method identical to 2.3 (record eye position), change the settings of the &quot;Eye Tracking Providers&quot;, from the Tobii option (if &quot;TobiiXR Initializer&quot; was installed) or the &quot;VIVE&quot; option to the new setting &quot;Nose Direction&quot; (see Figure 4 below). Identically, select &quot;Mouse&quot; to track the computer&#39;s mouse.

![](RackMultipart20200828-4-cgn1l1_html_da42c3e6cb081a28.png) ![](RackMultipart20200828-4-cgn1l1_html_c3df0e78317e4d0.png)

Figure 4. Selection of the &quot;Nose Direction&quot; (left panel) or the &quot;Mouse&quot;mode (right panel) in the &quot;Eye Tracking Providers&quot; settings.

## 2.5. Controller tracking

Tracking and recording controllers requires more work. First, make some modification in Unity. In the Hierarchy panel, develop both the Player item and the SteamVRObjects item (child of Player). You will see two gameObjects named &quot;LeftHand&quot; and &quot;RightHand&quot; (see Figure 5). They correspond to the two controllers.

![](RackMultipart20200828-4-cgn1l1_html_50403a6fe7404ee6.png)

Figure 5. Hierarchy panel and child items of Player.

For each GameObject, follow this two-step procedure: (i) create the new tag and (ii) associate the tag to the controller (hand). In details, for each controller (i.e. &quot;Lefthand&quot; and &quot;RightHand&quot; item), go to the Inspector panel and add a new tag. Here, we create two tags named &quot;LeftHand&quot; and &quot;RightHand&quot; that are respectively associated to each controller.

Next, create a new C# script that is added to the Player item. Open the script editor and copy-paste the content of the &quot;TrackingControllers.cs&quot; script.

What the script does is the following: each time the controller information is updated (30 Hz sampling rate), the position (3 axes), rotation (3 axes) and button states (3 buttons) are recorded. When the program quits, data is saved. There are two types of buttons: a trigger (named &quot;Squeeze&quot;, actioned by the index finger) that is dynamic and is mapped from 0 to 1, and two other buttons (named &quot;Teleport&quot; and &quot;GrabGrip&quot;, actioned by the thumb) that are binary coded (0: not pressed, 1: pressed).

# 3. EXTERNAL SOURCES

## 3.1. Setting the HTC Vive eye-tracking

Eye Tracking setup for HTC VIVE (from [https://vr.tobii.com/sdk/develop/unity/getting-started/vive-pro-eye/](https://vr.tobii.com/sdk/develop/unity/getting-started/vive-pro-eye/).)

**HTC VIVE Pro Eye Development Guide**

![](RackMultipart20200828-4-cgn1l1_html_27f3ea47a17ddd18.png)

This page will give you a step-by-step walkthrough on how to set up your HTC VIVE Pro Eye and how to create a simple scene in Unity using the Tobii XR SDK.

In the finished scene, you will be able to highlight game objects by looking at them.

With VIVE Pro Eye, developers are now able to create more immersive experiences using precision eye tracking and foveated rendering. The headset features 120Hz tracking and 0.5°–1.1° accuracy for amazing eye tracking performance and is the preferred VR headset for NVIDIA Variable Rate Shading (VRS).

HTC VIVE Sense SDK gives access to the eye tracking capabilities of VIVE Pro Eye through Unity and Unreal plugins as well as from native C. The Tobii XR SDK supports the VIVE Sense SDK. All use cases and source code samples are compatible with the SRanipal APIs as well as Tobii APIs. Find out more about VIVE Sense SDK [here](https://developer.vive.com/resources/pc-vr/).

**Step 1: Set up your headset****   **

Follow the [VIVE Pro Eye Setup](https://enterprise.vive.com/eu/setup/vive-pro/) guide.

**Step 2: Calibrate for your eyes****   **

The VIVE Pro Eye Setup guide will automatically start the calibration at the end of the setup flow.

If you need to re-calibrate or if you switch users, you can always open the calibration tool from the SteamVR dashboard.

![](RackMultipart20200828-4-cgn1l1_html_e9165f05b47566d8.png)

**Step 3: Download and Import the VIVE SRanipal SDK****   **

[Download the VIVE SRanipal SDK](https://developer.vive.com/resources/knowledgebase/vive-sranipal-sdk/) and import the .unitypackage into your Unity project.

**Make sure the VIVE Sranipal SDK works before going to the next step.**

The tray icon eyes turn green when eye tracking is active, this should happen when your Unity application is running.

![](RackMultipart20200828-4-cgn1l1_html_7efc46ca9a7e0746.png) ![](RackMultipart20200828-4-cgn1l1_html_70d6cb7fdf5b874a.png)

**Step 4: Import the Tobii XR SDK****   **

[Download the Tobii XR SDK for Unity](https://vr.tobii.com/sdk/downloads/) and import it into your Unity project.

**Remember to enable VR support in your Unity project. We support Unity 2018.2.5f1 or later.**

If you have an older version of the Tobii XR SDK, remember to remove it before importing the new version to avoid conflicts.

**Step 5: Add the****   ****TobiiXR Initializer****   ****prefab to your scene****   **

The prefab can be found in the Prefabs folder.

![](RackMultipart20200828-4-cgn1l1_html_4d61d96393f74e45.png)

The TobiiXR\_Initializer script attached to the prefab calls TobiiXR.Start() to initialize the the Tobii XR SDK.

**Step 6: Configure the Tobii XR SDK****   **

To configure the Tobii XR SDK, edit the fields of the TobiiXR Initializer prefab in your scene.

Make sure the  **VIVE**  provider is at the top of the  **Eye Tracking Providers**  list.

Enable the  **Support VIVE Pro Eye**  option.

![](RackMultipart20200828-4-cgn1l1_html_4ce4679aca467f46.png)

Read more about the providers and other settings in the [Tobii XR Settings](https://vr.tobii.com/sdk/develop/unity/documentation/tobii-settings/) page.

**Step 7: Create a cube and place it somewhere in the scene****   **

![](RackMultipart20200828-4-cgn1l1_html_2a16a87fb682d824.png)

**Step 8: Add the****   ****HighlightAtGaze****   ****script to the cube****   **

![](RackMultipart20200828-4-cgn1l1_html_c3eb552dd1e8dc.png)

The `HighlightAtGaze` component implements the `IGazeFocusable` interface, which will be called whenever the object receives or loses focus.

**Step 9: Run the scene****   **

By pressing play, you can now highlight the cube by looking at it.

If you want, you can add more objects that react to gaze to the scene in order to test and play around.

If you want to build your solution, make sure to build it for 64 bit.

**Next steps****   **

Congratulations! You&#39;re now up and running with the Tobii XR SDK for Unity and can start developing with eye tracking in VR.

Check out our [Showcases](https://vr.tobii.com/sdk/showcases/) section for demos and prototypes.

Check out the [Documentation](https://vr.tobii.com/sdk/develop/unity/documentation/) page, or try out our [Unity Examples](https://vr.tobii.com/sdk/develop/unity/unity-examples/).

Read our [Design](https://vr.tobii.com/sdk/interaction-design/) section if you want to know more about how to design eye tracking interactions in VR.

9
