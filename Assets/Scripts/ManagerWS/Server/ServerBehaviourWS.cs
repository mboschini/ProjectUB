using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entities;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
using UnityEngine;
using DigitalRuby.Threading;

public class ServerBehaviourWS : WebSocketBehavior
{    
    public static List<string> _clientsUUID = new List<string>();

    protected override void OnOpen()
    {
        base.OnOpen();
        try
        {
            _clientsUUID.Add(ID);
            EZThread.ExecuteOnMainThread(() => DoActions.CreatePlayer(ID));
            var connectedAction = JsonConvert.SerializeObject(new PlayerActions() { ConnectionUUID = ID, Action = "CONNECTED" });
            Send(connectedAction); // Send para enviar mensaje al cliente que abrio esta conexion
        }
        catch (Exception ex)
        {
            Debug.LogError("No se pudo conectar. ERROR: " + ex.Message);
        }
    }

    protected override void OnMessage(MessageEventArgs e)
    {   
        try
        {
            if (e.Data.ToUpperInvariant().Contains("ACTION"))
            {
                ParseAction(e.Data);
            }
            else
            {
                var playerData = JsonConvert.DeserializeObject<PlayerData>(e.Data);
                if (playerData != null)
                {
                    playerData.ConnectionUUID = ID;
                    EZThread.ExecuteOnMainThread(() => DoActions.UpdateRotation(playerData));
                }
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("No se pudo leer el mensaje del cliente: " + ID);
        }
    }

    private void ParseAction(string data)
    {
        try
        {           
            var playerAction = JsonConvert.DeserializeObject<PlayerActions>(data);
            playerAction.ConnectionUUID = ID;
            EZThread.ExecuteOnMainThread(() => DoActions.MovePlayer(playerAction));
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    
    

}
