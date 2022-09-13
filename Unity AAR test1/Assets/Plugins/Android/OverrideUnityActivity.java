package com.company.product;
import android.os.Bundle;
import android.widget.FrameLayout;
import android.util.Log; //you can remove the logs if you want to

import com.unity3d.player.UnityPlayerActivity;


//This activity will override the UnityPlayerActivity and manage things instead
//docs https://docs.unity3d.com/Manual/android-custom-activity.html
//you can make it abstract and use another activity extending this
public class OverrideUnityActivity extends UnityPlayerActivity
{
    //It's crucial to have an instance of this
    //this activity must Override the UnityPlayerActivity on the manifest so it enters the onCreate onDestroy
    //use a custom manifest https://docs.unity3d.com/Manual/overriding-android-manifest.html
    //and change the:
        //android:name="com.unity3d.player.UnityPlayerActivity"
    //for, in this case:
        //android:name="com.company.product.OverrideUnityActivity"
    
    public static OverrideUnityActivity instance = null;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        instance = this;
        Log.d("OverrideActivity", "onCreate called!");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        instance = null;
    }

    //this sends the message from Java to C#
    //you can send just strings, if you're confused, you can send a JSON in order to send complex stuff
    public static void UnitySendMessage(String object, String method, String data) {
        //Log.d("OverrideActivity", "SendMessage called!");
        if(instance != null){
            instance.mUnityPlayer.UnitySendMessage(object, method, data);   
        } else {
	        Log.d("OverrideActivity", "instance is empty!");
        }

    }
}
