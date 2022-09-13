using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//shows the onscreen logs for your debuggin
public class LogSys : MonoBehaviour
{
    [SerializeField] TMP_Text container;
    static string totalLog = "";

    public static LogSys instance;

    private void Awake()
    {
        instance = this;
    }

    public static void Log(string type, string text)
    {
        totalLog += ($"[{type}] {text}\n");
        instance.UpdateLog();
    }

    void UpdateLog()
    {
        container.text = totalLog;
    }

    public static string TurnIntoLogStr(string type, string data)
    {
        return ($"[{type}] received: {data}");
    }
}
