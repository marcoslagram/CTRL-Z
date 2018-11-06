using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{

    public GameObject myPlayer;
 
    private Vector3 myCamara;

    [Range(0.01f, 1.0f)]
    public float smothFactor = 0.5f;

    public float velocidadRotacion = 5.0f;

    public float velocidadRotacion1 = 40.0f;
 

    void Start()
    {
        myCamara = transform.position - myPlayer.transform.position;
    }

    void LateUpdate()
    {


       //Giro camara en eje X
        Quaternion giroCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velocidadRotacion, Vector3.up);
       //Subir y bajar cámara
        Quaternion altoCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * velocidadRotacion, Vector3.right);
       
        //Se mueve la cámara al mantener pulsado el boton derecho
        if (Input.GetButton("MousePulsadoDer"))
            {
            // para que se mueva la cámara
            myCamara = giroCamara * altoCamara * myCamara;
            //Para que rote el jugador en el eje Y lo mismo que rota la cámara
            myPlayer.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
        }
        //Para que se coloque en sitio correspondiente
        Vector3 nuevaPosicionCamara = myPlayer.transform.position + myCamara;

        transform.position = Vector3.Slerp(transform.position, nuevaPosicionCamara, smothFactor);
      
        //Para que siga al jugador
        transform.LookAt(myPlayer.transform.position);
     
    }

}

