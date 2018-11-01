using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{

    public GameObject myPlayer;
    // public GameObject myReferencia;
    private Vector3 myCamara;
 //   private Vector3 myPlayer;
    [Range(0.01f, 1.0f)]
    public float smothFactor = 0.5f;
  //  public bool miramyPlayerTransform = false;
  //  public bool rotamyPlayerTransform = true;
    public float velocidadRotacion = 5.0f;
    public float velocidadRotacion1 = 40.0f;
 //   private Vector3 angularVector = new Vector3(0, 0, 0);

    // public Vector3 myCamara;

    //Vector2 touchDeltaPosition;

    //public Camera camara;
    //public Transform myPlayer;
    //public float velocidadDrag = 1f;
    //private Vector3 origen;
    //public float velocidadZoom;
    //public bool zooming;

    void Start()
    {
        myCamara = transform.position - myPlayer.transform.position;
    //    angularVector = new Vector3(0, velocidadRotacion1 * Time.deltaTime, 0);
      //  myPlayer = myPlayerTransform.transform.position;

        
    }

    void LateUpdate()
    {


       // if (rotamyPlayerTransform){
        
            //  float angle = Vector3.Angle(myCamara, myPlayer);
            Debug.Log(myCamara);
            Quaternion giroCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velocidadRotacion, Vector3.up);
            //Quaternion girillo = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velocidadRotacion, Vector3.up);
            Quaternion altoCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * velocidadRotacion, Vector3.right);
            //   Quaternion red = Quaternion.Euler(Input.GetAxis("Mouse X")*velocidadRotacion, 0, 0);

            if (Input.GetButton("MousePulsadoDer"))
            {
                myCamara = giroCamara * altoCamara * myCamara;

            }



    //    }
        Vector3 nuevaPosicionCamara = myPlayer.transform.position + myCamara;

        transform.position = Vector3.Slerp(transform.position, nuevaPosicionCamara, smothFactor);
        //myPlayerTransform.transform.rotation = myPlayerTransform.transform.rotation + myPlayer;
        // transform.posiz = Vector3.Slerp(transform.position, nuevaPosicionmyPlayerTransform, smothFactor);


      /*  if (miramyPlayerTransform || rotamyPlayerTransform)
        {*/
            transform.LookAt(myPlayer.transform.position);
      //  }

       /* if (Input.GetButton("MousePulsadoDer"))
        {
            myPlayerTransform.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * velocidadRotacion1);
        }*/
    }







}

