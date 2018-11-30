using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraCont : MonoBehaviour {

    public GameObject myPlayer;
    //  public GameObject cuerpo;
    private MovimientoJugador moverse;

    public Transform  centro;

    public float distancia=4f;
    public float distanciaMaxima = 6f;
    public float distanciaMinima = 0.5f;
    public float altura;
    public float alturaMaxima=1.2f;
    public float alturaMinima=-0.7f;
    [Range(0.01f, 1.0f)]
    public float smothFactor = 0.5f;
    public float velocidadOrbi=50;
    public float velocidadVertical=2;
    RaycastHit hit;
    Vector3 destino;

    // Use this for initialization
    void Start () {
        moverse = GameObject.Find("Cube").GetComponent<MovimientoJugador>();
	}
	
	// Update is called once per frame
	void Update () {
        centro.position = myPlayer.transform.position + new Vector3(0, 2f, 0);
        if (Input.GetButton("MousePulsadoDer"))
        {
            centro.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * velocidadOrbi, 0);
            altura += Input.GetAxis("Mouse Y") * Time.deltaTime * -velocidadVertical;
            
        }

        altura = Mathf.Clamp(altura, alturaMinima, alturaMaxima);
       
    }

   void FixedUpdate()
    { //Debug.DrawLine(this.transform.position, myPlayer.transform.position, Color.magenta);
        myPlayer.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        destino=centro.position + centro.forward * -1 * distancia + Vector3.up * altura;
        if(Physics.Linecast(centro.position,destino,out hit))
        {
            if(hit.collider.tag!="Zombie" && hit.collider.tag !="Objectos") { 
            distancia = Mathf.Clamp(hit.distance, distanciaMinima, distanciaMaxima);
            velocidadOrbi = 70;}

           
            //this.transform.position = hit.point+hit.normal*0.14f;
        }
        else
        {
          //  Debug.Log(hit.distance);
            distancia = 3f;
            velocidadOrbi = 70;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, destino, Time.deltaTime * 10);
        this.transform.LookAt(centro.position);
    }
}
