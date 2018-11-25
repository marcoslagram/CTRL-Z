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

    public float zoom;

    public float mindistancia = 0.5f;
    public float distancia=1f;
    public float distan;
    private Vector3 camDir;

    private Vector3 camDirPlus;

    //public float velocidadRotacion1 = 40.0f;


    void Start()
    {
        myCamara = transform.position - myPlayer.transform.position;

       /* camDir = this.transform.localPosition.normalized;

        zoom = this.transform.localPosition.magnitude;*/
    }

    void LateUpdate()
    {
        /*  if (Input.GetAxis("Mouse ScrollWheel")>0) // forward
   {
              this.transform.GetComponent<Camera>().fieldOfView--;
              Debug.Log("11111111111");
          }

          if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
          {
              this.transform.GetComponent<Camera>().fieldOfView++;
              Debug.Log("11111111111");
          }
        //AumentarZoom();

        Vector3 camPos = this.transform.TransformPoint(camDir * distancia);
        RaycastHit hit;

        if(Physics.Linecast(this.transform.position,camPos,out hit))
        {
            zoom = Mathf.Clamp((hit.distance * 0.9f), mindistancia, distancia);
        }

        else
        {
            zoom = distancia;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, camDir * zoom, Time.deltaTime * smothFactor);
        */

       //Giro camara en eje X
        Quaternion giroCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velocidadRotacion, Vector3.up);
       
       //Subir y bajar cámara
        Quaternion altoCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * velocidadRotacion, Vector3.right);

        if (myCamara.y < 0.5)
        {
            myCamara.y = 0.5f;
        }

       else if (myCamara.y > 5f)
        {
            myCamara.y = 5f;
        }


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

    public void AumentarZoom()
    {
        float zoomCambiante=5f;
        if (Input.GetButton("Mouse ScrollWheel"))
        {
            Debug.Log("11111111111");
            this.transform.GetComponent<Camera>().fieldOfView++;
        }
       else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            this.transform.GetComponent<Camera>().fieldOfView--;
            zoom -= zoomCambiante * Time.deltaTime;
        }
    }

}

