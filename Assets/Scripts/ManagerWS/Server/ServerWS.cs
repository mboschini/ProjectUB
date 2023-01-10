using WebSocketSharp.Server;
using UnityEngine;

public class ServerWS : MonoBehaviour
{

    public static WebSocketServer _wssv;
    public Transform cameraServer;
    void Awake()
    {
        DigitalRuby.Threading.EZThread.ExecuteOnMainThread(() => funcionParaQueFuncioneEzThreads()); // para que funcione en los otros lugares, inentendible pero real        
    }

    void Start()
    {
        Instantiate(cameraServer);
        _wssv = new WebSocketServer("ws://localhost:3001");
        _wssv.AddWebSocketService<ServerBehaviourWS>("/Laputa");
        _wssv.Start();

    }




    //ACA VA A ESTAR EL MANEJO DE RUTAS CUANDO SE CREE UNA LOBBY NUEVA, HAY QUE TENER UNA RUTA NUEVA O VER SI ES NECESARIO UN







    void funcionParaQueFuncioneEzThreads() { }

}
