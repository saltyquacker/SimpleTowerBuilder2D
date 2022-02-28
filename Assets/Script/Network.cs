using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sfs2X;
using Sfs2X.Core;
using Sfs2X.Entities.Data;

public class Network : MonoBehaviour
{
    public string ServerIP = "127.0.0.1";
    public int ServerPort = 9933;

    SmartFox sfs;

    // connect to smartfox server
    void Start()
    {
        sfs = new SmartFox();
        sfs.ThreadSafeMode = true;

        sfs.AddEventListener(SFSEvent.CONNECTION, OnConnection);
        sfs.Connect(ServerIP, ServerPort);
    }

    void OnConnection(BaseEvent e)
    {
        if ((bool)e.Params["success"])
        {
            Debug.Log("SmartFox Connected");
           
        }
        else
        {
            Debug.Log("Connection Failed");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        sfs.ProcessEvents();

    }

    void OnApplicationQuit()
    {
        if (sfs.IsConnected)
            sfs.Disconnect();
    }
}
