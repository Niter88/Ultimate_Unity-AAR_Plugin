# Ultimate_Unity-AAR_Plugin
Total integration between Unity and an AAR plugin. You can send, set and get variables and access methods between the two.\
Both the AAR lib and the Unity app are fully commented so you can understand the logic behind it and reproduce it.

# Understanding the code
JavaToCSInterface will be used to send data from the AAR to the Unity activity override. You must send the instance provided and hold it on the AAR side. Once you have loaded the AAR, you'll be able to extend it from inside the JavaToCSReceiver in Unity.

You'll use the OverrideUnityActivity to override the UnityPlayerActivity and be able to send strings to C# from your Java code. It requires you to use a custom android manifest in order to actually override the activity. Providing you with the onCreate method call (and any other from the android lifecycle). You MUST enter the onCreate method in order to keep an instance of it so you can send messages to Unity.

Sending things from Unity to the AAR is a lot easier, you can just call, send, set or get directly. You can peek at the docs bellow for a better understanding

# Docs
docs on using the AndroidJava objects and methods:\
https://docs.unity3d.com/Manual/android-plugins-java-code-from-c-sharp.html \
use a custom manifest in Unity:\
https://docs.unity3d.com/Manual/overriding-android-manifest.html

# Installing the apk
If you wish just to install the apk you can find it at releases\
https://github.com/Niter88/Ultimate_Unity-AAR_Plugin/releases

# Instructions on editing
Clone the repo\
Unity AAR test1/ is the Unity project\
LibAARTest/ is the Lib project\
open the Unity project, import TMP essentials, setup for android deploy, build it and run into your android device. It already has the lib imported inside it.\
if you wanna edit the lib, you can clone it edit and create a module from the lib (you have to select the lib, not the app to do it)

# Remember
You'll have to import the TMP essentials in Unity (for editing)\
You'll have to set a keystore in Unity
