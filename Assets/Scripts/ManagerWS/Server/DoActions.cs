using UnityEngine;
using Entities;
using Newtonsoft.Json;
using WebSocketSharp.Server;
using System;

public class DoActions : MonoBehaviour
{
    public Transform Player;
    public static Transform staticPlayer;

    void Start()
    {
        staticPlayer = Player;
    }

    private void Update()
    {
        ServerBehaviourWS._clientsUUID.ForEach(x => UpdatePlayer(x));
    }

    private void UpdatePlayer(string clientUUID)
    {
        try
        {
            var go = GameObject.Find(clientUUID);
            if (go != null)
            {
                PlayerData p = new PlayerData();
                p.ConnectionUUID = clientUUID;
                p.X = go.transform.position.x;
                p.Y = go.transform.position.y;
                p.Z = go.transform.position.z;
                p.RotationX = go.transform.rotation.eulerAngles.x;
                p.RotationY = go.transform.rotation.eulerAngles.y;
                p.RotationZ = go.transform.rotation.eulerAngles.z;
                var json = JsonConvert.SerializeObject(p);
                SendMessageToAllClients(json);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }


    public static WebSocketSessionManager GetClientsWS()
    {
        return ServerWS._wssv.WebSocketServices["/Laputa"].Sessions;
    }

    public static void SendMessageToAllClients(string json)
    {
        try
        {
            GetClientsWS().Broadcast(json);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public static void CreatePlayer(string connectionUUID)
    {
        try
        {
            var t = Instantiate(staticPlayer, new Vector3(UnityEngine.Random.Range(0, 4), 0, UnityEngine.Random.Range(0, 4)), Quaternion.identity);
            t.gameObject.name = connectionUUID;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public static void MovePlayer(PlayerActions playerAction)
    {
        Vector3 side = new Vector3();
        GameObject pj = GameObject.Find(playerAction.ConnectionUUID);
        switch (playerAction.Action.ToUpperInvariant())
        {
            case "FORWARD":
                //side = pj.transform.forward;
                side = Vector3.forward;
                break;
            case "BACK":
                side = Vector3.back;
                //side = -pj.transform.forward;
                break;
            case "LEFT":
                side = Vector3.left;
                //side = -pj.transform.right;
                break;
            case "RIGHT":
                side = Vector3.right;
                //side = pj.transform.right;
                break;
            case "MOUSE":
                
                
                
                pj.transform.Rotate(Vector3.up * playerAction.MouseX);
                

                break;
            default:
                side = new Vector3();
                break;
        }
        if (side != new Vector3())
        {
            Vector3 movementDirection = pj.transform.right;
            var rb = pj.GetComponent<Rigidbody>();
            pj.transform.Translate(side * 5f * Time.deltaTime);
        }
    }

    public static void UpdateRotation(PlayerData pd)
    {
        try
        {
            // GameObject go = GameObject.Find(pd.ConnectionUUID);
            // //go.transform.rotation = Quaternion.Euler(pd.RotationX * 180 / Mathf.PI, pd.RotationY * 180 / Mathf.PI, pd.RotationZ * 180 / Mathf.PI);
            // go.transform.rotation = Quaternion.Euler(pd.RotationX, pd.RotationY, pd.RotationZ);
            // //go.transform.rotation = Quaternion.Normalize(ss);
            // PlayerData p = new PlayerData();
            // p.ConnectionUUID = pd.ConnectionUUID;
            // p.X = 0;
            // p.Y = 0;
            // p.Z = 0;
            // if (go.transform.rotation.x == 0)
            // {
            //     //Debug.Log("es igual a 0");
            // }
            // p.RotationX = go.transform.rotation.x;
            // p.RotationY = go.transform.rotation.y;
            // p.RotationZ = go.transform.rotation.z;
            // var json = JsonConvert.SerializeObject(p);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }



}
