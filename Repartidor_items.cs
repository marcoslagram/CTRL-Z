/*
 * #########################################################
 * Repartidor_items Beta 2
 * Marcos Lago Ramilo
 * .EXE Diciembre 2018
 * #########################################################
 * Situa los objetos de forma aleatoria por el escenario sin posiciones repetidas
 * Objetos_a_posicionar NO puede tener mayor longitud que Posiciones_validas
 * #########################################################
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repartidor_items : MonoBehaviour {

    public Transform[] Posiciones_validas;
    public GameObject[] Objetos_a_posicionar;
    public bool Reparto_aleatorio = true;

    private int[] arrayIndices;
	// Use this for initialization
	void Start () {
        if (!Reparto_aleatorio)
        {
            for (int i = 0; i < Objetos_a_posicionar.Length; i++)
            {
                Instantiate(Objetos_a_posicionar[i], Posiciones_validas[i].position, Quaternion.identity);
            }
        }
        else
        {
            int[] arrayIndices = new int[Posiciones_validas.Length];
            for (int i = 0; i < Posiciones_validas.Length; i++)
            {
                arrayIndices[i] = i;
            }
            //Knuth shuffle algorythm
            for (int t = 0; t < arrayIndices.Length; t++)
            {
                int tmp = arrayIndices[t];
                int r = Random.Range(t, arrayIndices.Length);
                arrayIndices[t] = arrayIndices[r];
                arrayIndices[r] = tmp;
            }
            for (int i = 0; i < Objetos_a_posicionar.Length; i++)
            {
                Instantiate(Objetos_a_posicionar[i], Posiciones_validas[arrayIndices[i]].position, Quaternion.identity);
            }
        }
	}


	
	// Update is called once per frame
	//void Update () {
		
	//}
}
