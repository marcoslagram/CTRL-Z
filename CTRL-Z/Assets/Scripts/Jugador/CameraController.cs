using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Vector2 touchDeltaPosition;

    //public Camera camara;
    public float velocidadDrag = 1f;
    private Vector3 origen;
    //public float velocidadZoom;
    //public bool zooming;

    void Start()
    {
        /*RaycastHit hit;
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            //Creo que va a ser necesario para cuando la cámara pueda encontrarse con objetos en la escena, pero no consigo que funcione
        }*/
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))    //1 para el boton derecho
        {
            Debug.Log("Boton derecho pulsado");
            origen = Input.mousePosition;
            return;
        }
        if (!Input.GetMouseButton(1)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - origen);   //aqui me salta un error al probarlo de referencia nula
        Vector3 move = new Vector3(pos.x * velocidadDrag, 0, pos.y * velocidadDrag);

        transform.Translate(move, Space.World);
        transform.Rotate(move, Space.Self);
    }



    /*  if (zooming)
      {
          Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
          float distanciaZoom = velocidadZoom * Input.GetAxis("Vertical") * Time.deltaTime;
          camara.transform.Translate(rayo.direction * distanciaZoom, Space.World);
      }*/



}


