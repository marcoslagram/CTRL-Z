using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dialogo: MonoBehaviour
{

    private DialogoNPC conversaciones;

    void Start()
    {
        conversaciones = GameObject.Find("Gato").GetComponent<DialogoNPC>();
        //En cada if se metería las oraciones de tuturial como por ejemplo conversaciones.oracionControl[0] = "  ";
        // y las conversaciones con el Gato como por ejemplo  conversaciones.oracionConverJugadorF1[0] = "  ";
       

        //0=castellano 1=galego 2=inglés

        if (Menu.idiomaElegido == 0)
        {
            //Aqui se meterían las frases en español
        }

        else if (Menu.idiomaElegido == 1)
        {
            //Aqui se meterían las frases en gallego
        }

        else if (Menu.idiomaElegido == 2)
        {
            //Aqui se meterían las frases en inglés
        }


    }



}


