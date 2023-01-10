using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHitDetection : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit hit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, Vector3.forward * 1000f, Color.black);
        // if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1000f))
        // {

        //     var posicion = hit.point;
        //     var distancia = hit.distance;
        //     var nombre = hit.collider.gameObject.name;
        //     if (hit.transform.tag == "Enemigo")
        //     {
        //         //Debug.DrawRay(transform.position, Vector3.forward + posicion, Color.green);
        //         //hit.transform.gameObject.GetComponent<MiScript>().miFuncion()
        //     }
        //     else{
        //         //Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.black);
        //     }
        // }







    }
}
