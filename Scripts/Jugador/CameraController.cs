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
    public float distancia = 4f;
    public float distanciaMaxima = 6f;
    public float distanciaMinima = 0.5f;
    public float mindistancia = 0.5f;
    //public float distancia=1f;
    public float distan;
    public float velocidadVertical = 4f;
    public float altura;
    public float probar;
    private Vector3 camDir;

    private Vector3 camDirPlus;
    Vector3 destino;
    RaycastHit hit;

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

       else if (myCamara.y > 3f)
        {
            myCamara.y = 3f;
        }


        //Se mueve la cámara al mantener pulsado el boton derecho
        if (Input.GetButton("MousePulsadoDer"))
            {
            // para que se mueva la cámara
            myCamara = giroCamara * myCamara;//* altoCamara 
            //Para que rote el jugador en el eje Y lo mismo que rota la cámara
            myPlayer.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            altura += Input.GetAxis("Mouse Y") * Time.deltaTime * -velocidadVertical;
        }
        //Para que se coloque en sitio correspondiente
        Vector3 nuevaPosicionCamara = myPlayer.transform.position + myCamara;

        ;




        destino = myPlayer.transform.position + myPlayer.transform.forward * -1 * distancia + Vector3.up * altura;
        if (Physics.Linecast(myPlayer.transform.position, destino, out hit))
        {
            distancia = Mathf.Clamp(hit.distance, distanciaMinima, distanciaMaxima);
            //this.transform.position = hit.point+hit.normal*0.14f;
        }
        else
        {
            distancia = 4f;
        }

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * 10);
        //Para que siga al jugador
        transform.LookAt(myPlayer.transform.position + new Vector3(0f,probar,0f));

        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name != "Cube")
            {
                hit.collider.gameObject.SetActive(false);
            }
            
        }*/

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

