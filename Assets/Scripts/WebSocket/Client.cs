using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using WebSocketSharp.Server;


public class Client : MonoBehaviour
{
    string schedule = "";

    #region -Debug output-

    public Text debugOutputText;
    //public InputField inputField;

    string toAdd = "";

    [SerializeField]
    ConnectionIndicator connectionIndicator;

    #endregion -Debug output-

    [SerializeField]
    InputField ipInput;

    string serverIpAddres = "";
    private void Start()
    {
        if (ipInput.text != "")
        {
            serverIpAddres = ipInput.text;
        }
    }

    private void Update()
    {
        if (toAdd != "")
        {
            debugOutputText.text += toAdd;
            toAdd = "";
        }


        if(schedule != "")
        {
            bool canParse = true;

            try
            {
                Schedule.SaveStringToScheduleObject(schedule);
            }
            catch (Exception exception)
            {
                toAdd += "\n ^^ Can not parse message as a Schedule ^^" + "\n" + exception.Message + "\n" + exception.StackTrace;
                canParse = false;
                
            }
            finally
            {
                schedule = "";
            }

            if (canParse)
            {
                connectionIndicator.Success();
                success = true;
                m_webSocketClient.Send("success");
            }
            else
            {
                connectionIndicator.Fail();
                success = false;
                m_webSocketClient.Send("fail");
            }

            
        }

        if (!onConnectingFlag && 
            (m_webSocketClient == null ||
            m_webSocketClient.ReadyState != WebSocketState.Open
            )
        )
        {
            connectionIndicator.NotConnected();
            try
            {
                Connect();
            }
            catch (Exception exception)
            {
                print(exception.Message);
            }
        }
    }

    bool success = false;

    bool onConnectingFlag = false;
    WebSocket m_webSocketClient = null;
    public void Connect()
    {
        onConnectingFlag = true;
        /*if (m_webSocketClient != null)
        {
            m_webSocketClient.Close();
            toAdd += "\n" + m_webSocketClient.ReadyState + "On close";
        }*/

        m_webSocketClient = new WebSocket("ws://" + serverIpAddres + ":5055/ScenesDataTransfer");
        toAdd += "\ntrying connect ipAddress: " + serverIpAddres;

        m_webSocketClient.OnMessage += (sender, e) =>
        {
            success = false;
            toAdd += "\nServer responding with message of length" + e.Data.Length.ToString();
            schedule = e.Data;
        };

        m_webSocketClient.OnError += (sender, e) =>
        {
            toAdd += "\n" + sender.ToString() + ": "+ e.Exception;
            return;
        };

        m_webSocketClient.OnClose += (sender, e) =>
        {
            connectionIndicator.NotConnected();
        };

        m_webSocketClient.OnOpen += (sender, e) =>
        {
            connectionIndicator.Connected();
        };



        m_webSocketClient.Connect();
        
        print(m_webSocketClient.ReadyState);
        toAdd += "\nConnection status: <" + m_webSocketClient.ReadyState.ToString() + ">";

        if (m_webSocketClient.ReadyState == WebSocketState.Closed)
            connectionIndicator.NotConnected();

        onConnectingFlag = false;
    }
}
