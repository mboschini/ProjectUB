using System;
using System.Collections;
using System.Collections.Generic;
using Entities;
using Newtonsoft.Json;
using UnityEngine;
public class Movement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ClientWS._ws.Send("{'ConnectionUUID': '" + ClientWS._ConnectionID + "' ,'ACTION': 'FORWARD'}");
        }
        if (Input.GetKey(KeyCode.S))
        {
            ClientWS._ws.Send("{'ConnectionUUID': '" + ClientWS._ConnectionID + "' ,'ACTION': 'BACK'}");
            //transform.Translate(Vector3.back * movementSpeed* Time.deltaTime );
        }
        if (Input.GetKey(KeyCode.A))
        {
            ClientWS._ws.Send("{'ConnectionUUID': '" + ClientWS._ConnectionID + "' ,'ACTION': 'LEFT'}");
            //transform.Translate(Vector3.left* movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ClientWS._ws.Send("{'ConnectionUUID': '" + ClientWS._ConnectionID + "' ,'ACTION': 'RIGHT'}");
            //transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }        
    }


}