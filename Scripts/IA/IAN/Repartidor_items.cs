using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartidor_items : MonoBehaviour {

    public Transform[] Posiciones_validas;
    public GameObject[] Objetos_a_posicionar;
    public bool Reparto_aleatorio = true;

    private int numero_objetos;
    // Use this for initialization
    void Start() {

        if (GestionDias.dia > 1) { 
            if (!Reparto_aleatorio)
            {
                for (int i = 0; i < Objetos_a_posicionar.Length; i++)
                {
                    Instantiate(Objetos_a_posicionar[i], Posiciones_validas[i].position, Quaternion.identity);
                }
            } else
            {
                for (int i = 0; i < Objetos_a_posicionar.Length; i++)
                {
                    float random = Random.value * Posiciones_validas.Length;
                    int valor = Mathf.FloorToInt(random);
                    Instantiate(Objetos_a_posicionar[i], Posiciones_validas[valor].position, Quaternion.identity);
                }
            }

        }
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
