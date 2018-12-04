using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situador : MonoBehaviour
{

    /*
     * ESTE SCRIPT SE ENCARGA DE POSICIONAR LOS ZOMBIS EN LAS MISMAS COORDENADAS QUE LOS PUNTOS MAS FRECUENTES
     */

    public GameObject[] Balizas = null; //Todos los objetos Punto
    private Transform[] PointsPosition;//Posiciones de los puntos
    private float[] vectorProbabilidades = null; //Aquí quiero tener el valor de la variable valorProbabilidad de cada Punto
    public GameObject ObjetoZombi; //El objeto del zombi a situar

    public int Numero_Zombis_por_defecto = 5;
    public int Numero_Zombis_minimo = 3;
    public int Numero_Zombis_maximo = 8;
    private int Zombis_que_se_van_a_situar = 0;

    public float Tiempo_dia = 300f;
    public float Ultimo_tiempo_sobrante = -1;

    public bool ActivarIA = true;

    // Use this for initialization
    void Start()
    {
        //Inicializo los arrays
        vectorProbabilidades = new float[Balizas.Length];
        PointsPosition = new Transform[Balizas.Length];

        //Saco las posiciones de los puntos
        for (int i = 0; i < Balizas.Length; i++)
        {
            PointsPosition[i] = Balizas[i].transform;
        }

        if ((Ultimo_tiempo_sobrante < 0.0f) || !ActivarIA)//Si es el primer dia no habrá datos del último tiempo sobrante, por tanto situaremos el número de zombis por defecto
        {
            Zombis_que_se_van_a_situar = Numero_Zombis_por_defecto;
        }
        else //Para el resto de días calculamos cuántos zombis poner
        {
            float mitad_tiempo = Tiempo_dia / 2;
            if (Ultimo_tiempo_sobrante > mitad_tiempo)
            {
                Zombis_que_se_van_a_situar = Numero_Zombis_maximo;
            }
            else
            {
                int variacion_posibles_zombis = Numero_Zombis_maximo - Numero_Zombis_minimo;
                float aux = mitad_tiempo / variacion_posibles_zombis;
                float aux2 = aux;
                print("aux: " + aux);
                Zombis_que_se_van_a_situar = Numero_Zombis_minimo;
                while (aux2 < Ultimo_tiempo_sobrante){
                    aux2 = aux2 + aux;
                    Zombis_que_se_van_a_situar++;
                }
            }
        }

        int punto = 0;
        //print("puntosEscogidosLength = " + puntos_Escogidos.Length);
        for (int i = 0; i < (Zombis_que_se_van_a_situar-1); i++)
        {
            punto = elegirPunto();
            Instantiate(ObjetoZombi, PointsPosition[punto].position, Quaternion.identity);
        }



    }






    // Update is called once per frame
    //   void Update () {

    //}

    int elegirPunto() //Me devuelve de los puntos más probables
    {
        for (int i = 0; i < Balizas.Length; i++)
        {
            vectorProbabilidades[i] = Balizas[i].GetComponent<Punto>().valorProbabilidad;
        }

        float total = 0;
        foreach (float elem in vectorProbabilidades)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < vectorProbabilidades.Length; i++)
        {
            if (randomPoint < vectorProbabilidades[i])
            {
                return i;
            }
            else
            {
                randomPoint -= vectorProbabilidades[i];
            }
        }

        return vectorProbabilidades.Length - 1;
    }
}
