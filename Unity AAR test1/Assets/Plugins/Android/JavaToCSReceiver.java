package com.company.product;
import android.os.Bundle;
import android.widget.FrameLayout;
import br.com.manp.libaartest.JavaToCSInterface;

import com.unity3d.player.UnityPlayerActivity;

//this class overrides the interface and make it possible for you to send stuff between the AAR (your plugin) and the .java (the OverrideUnityActivity)
public class JavaToCSReceiver extends JavaToCSInterface
{
    @Override
    public void UnitySendMessage(String object, String method, String data) {
        OverrideUnityActivity.UnitySendMessage(object, method, data);
    }
}
