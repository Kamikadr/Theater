using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Reflection;


public class SendData : WebSocketBehavior
{
    static string schedule = "net schedule (999";

    public static int connectionsCounter = 0;

    int attempts = 0;

    public static void SetData(string newSchedule)
    {
        schedule = newSchedule;
    }

    protected override void OnError(ErrorEventArgs args)
    {
        Send(args.Exception.Message);
    }

    protected override void OnOpen()
    {
        connectionsCounter += 1;
        //Send(schedule);
    }

    protected override void OnClose(CloseEventArgs args)
    {
        connectionsCounter -= 1;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        if((e.Data == "fail") && (attempts < 100))
        {
            attempts += 1;
            Send(schedule);
        }
    }

}

public class Server : MonoBehaviour
{

    WebSocketServer m_webSocketServer;
    

    //TODO: Provide security
    private void Start()
    {
        //IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        m_webSocketServer = new WebSocketServer(5055);
        m_webSocketServer.AddWebSocketService<SendData>("/ScenesDataTransfer");


        SetDataForNewClients();
        //Schedule.onScheduleChange += BroadCastSchedule;

        m_webSocketServer.Start();
    }

    public void SetDataForNewClients()
    {
        SendData.SetData(Schedule.GetScheduleObjectAsString());
    }

    public void BroadCastSchedule()
    {
        print("broadcast!");
        SetDataForNewClients();
        try
        {
            m_webSocketServer.WebSocketServices["/ScenesDataTransfer"].Sessions.Broadcast(Schedule.GetScheduleObjectAsString());
        }
        catch
        {
            print("not broadcasted");
        }
        
    }


    public void GetTestCounter()
    {
        print(SendData.connectionsCounter.ToString());
    }

    private void OnDisable()
    {
        if(m_webSocketServer != null)
            m_webSocketServer.Stop();
    }
}
