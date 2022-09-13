using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integration : MonoBehaviour
{
    /*
    private void Awake()
    {
        SetJavaInstance(); //after you get rid of LogSys, use this one instead of Start()
    }
    */

    void Start()
    {
        SetJavaInstance();

        SendLogToJava();
        TestAllUnityMethods();
        AskAndroidForAMessage();
    }

    //this is VERY important, you have to call it
    //it actually belongs to the Awake() method, it's being called at the Start() to give the LogSys space to inicialize
    public void SetJavaInstance()
    {
        try
        {
            //creates a new reference to the class
            AndroidJavaClass jc = new AndroidJavaClass("br.com.manp.libaartest.LibTest");
            //it creates a new JavaToCSReceiver, which will receive all the messages the AAR plugin is sending to Unity
            AndroidJavaObject receiver = new AndroidJavaObject("com.company.product.JavaToCSReceiver"); //WARNING! assure it's the right package
            //sends the receiver to the AAR so it keeps an instance of it
            jc.CallStatic("setInstance", receiver);
            LogSys.Log("UNITY", "Java instance set");
        }
        catch (Exception e)
        {
            LogSys.Log("UNITY", "error " + e.ToString());
        }
    }

    //gets a string just like LogSys
    

    //One of the examples, sends a string to the AAR
    public void SendLogToJava()
    {
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass("br.com.manp.libaartest.LibTest");

            //sends a string to a static method with void return
            jc.CallStatic("sendAStringToJava", LogSys.TurnIntoLogStr("START", "App has been started"));
            LogSys.Log("UNITY","Log enviado pro java");
        }
        catch (Exception e)
        {
            LogSys.Log("UNITY", "error " + e.ToString());
        }
    }

    //tests Unity sending, setting and getting things from AAR
    public void TestAllUnityMethods()
    {
        try
        {
            //docs on using the AndroidJava objects and methods
            //https://docs.unity3d.com/Manual/android-plugins-java-code-from-c-sharp.html

            //variables
            string tempStr;
            int tempNum;
            //reference to the class (not the object, object is down bellow)
            AndroidJavaClass jc = new AndroidJavaClass("br.com.manp.libaartest.LibTest");

            //gets an int value from a static variable
            tempNum = jc.GetStatic<int>("counter");
            LogSys.Log("UNITY", "GetStatic<int> " + tempNum);

            //gets an string value from a static variable
            tempStr = jc.GetStatic<string>("testString");
            LogSys.Log("UNITY", "GetStatic<string> " + tempStr);

            //calls a static method that returns a string (you could also send stuff if you want to)
            tempStr = jc.CallStatic<string>("getStringMessage");
            LogSys.Log("UNITY", tempStr);

            //sets and gets an int value from a static variable
            jc.SetStatic<int>("testNum", 5);
            tempNum = jc.GetStatic<int>("testNum");
            LogSys.Log("UNITY", "int value altered to " + tempNum);

            //now using objects
            //gets the Activity's instance from the AAR so you can access it
            AndroidJavaObject instanceActivity = jc.GetStatic<AndroidJavaObject>("instance");
            LogSys.Log("UNITY", "got the object instance");

            //calls a method (not static) that returns a string (you could also send stuff if you want to)
            tempStr = instanceActivity.Call<string>("getTextObj");
            LogSys.Log("UNITY", "called " + tempStr);

            //gets an string value from a non static variable
            tempStr = instanceActivity.Get<string>("textObj");
            LogSys.Log("UNITY", "get "+tempStr);

            LogSys.Log("UNITY", " Unity part completed");
        }
        catch (Exception e)
        {
            LogSys.Log("UNITY", "error " + e.ToString());
        }
    }

    //it's the method that shows the message for demonstration purposes
    //you'll want to make your own methods and reference them instead of this one
    public void ReceiveMessageFromAndroid(string data)
    {
        LogSys.Log("ANDROID", data);
    }

    //sends a message to the AAR and triggers the UnitySendMessage
    public void AskAndroidForAMessage()
    {
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass("br.com.manp.libaartest.LibTest");

            jc.CallStatic("sendMessagesToUnity");
            LogSys.Log("UNITY", "sending texts from android has finished");
        }
        catch (Exception e)
        {
            LogSys.Log("UNITY", "error " + e.ToString());
        }
    }
    
}
