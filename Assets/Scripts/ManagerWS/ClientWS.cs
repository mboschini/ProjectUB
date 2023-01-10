using UnityEngine;
using WebSocketSharp;

using Newtonsoft.Json;
using DigitalRuby.Threading;
using Entities;

public class ClientWS : MonoBehaviour
{

    public Transform LocalPlayer;
    public Transform InternetPlayer;
    public static WebSocket _ws;
    public static string Text;
    public Material blanco;
    public static string _ConnectionID;

    void Start()
    {
        EZThread.ExecuteOnMainThread(() => s());
        ConectarWS("");
    }

    private void s() { }


    //el mensaje tiene que ser
    //Entitie a la que se va a parsear + JSON 
    public void ConectarWS(string text)
    {
        _ws = new WebSocket("ws://localhost:3001/Laputa");

        _ws.OnOpen += (sender, e) =>
        {
        };

        _ws.OnMessage += (sender, e) =>
        {
            if (e.Data != null && e.Data.Contains("CONNECTED"))
            {
                var s = JsonConvert.DeserializeObject<PlayerData>(e.Data);
                _ConnectionID = s.ConnectionUUID;
            }
            else
            {
                var p = JsonConvert.DeserializeObject<PlayerData>(e.Data);
                EZThread.ExecuteOnMainThread(() => updatePlayer(p));
            }
        };


        _ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close" + e.Reason + " --- " + e.Code);
        };

        _ws.Connect();
    }
    
    public void updatePlayer(PlayerData p)
    {
        GameObject go = GameObject.Find(p.ConnectionUUID);
        if (go == null && _ConnectionID == p.ConnectionUUID)
        {
            var t = Instantiate(LocalPlayer, new Vector3(0, 0, 0), Quaternion.identity); //creo local player
            t.gameObject.name = _ConnectionID;
            go = t.gameObject;
        }
        else if (go == null && _ConnectionID != p.ConnectionUUID)
        {
            var s = Instantiate(InternetPlayer, new Vector3(0, 0, 0), Quaternion.identity);
            go = s.gameObject;
            go.name = p.ConnectionUUID;
        }

        go.transform.position = new Vector3(p.X, p.Y, p.Z);
        go.transform.rotation = Quaternion.Euler(p.RotationX * 180 / Mathf.PI, p.RotationY * 180 / Mathf.PI, p.RotationZ * 180 / Mathf.PI);
        

    }




}
