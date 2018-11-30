using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dialogo: MonoBehaviour
{

    private DialogoNPC conversaciones;

    void Start()
    {
        conversaciones = GameObject.Find("Gato").GetComponent<DialogoNPC>();
        //Aqui meter las conversaciones



    }

    

}



/*  [TextArea(1, 20)]
    public string[] oraciones;
    public Queue<string> oracionConversaciones;
    private Dialogo dialogo;
    GameObject gato;
    private DebugText debugg;

    // Use this for initialization
    void Start()
    {

        oracionConversaciones = new Queue<string>();
        debugg = GameObject.Find("DebugText").GetComponent<DebugText>();
        IntroducirConversaciones();
    }

    // Update is called once per frame
    void Update()
    {
       
        EncontrarNPCConversable();
        // EmpezarConversacion();
     //   ContinuarConversacion();

    }

    public void IntroducirConversaciones()
    {
        foreach (string oracion in oraciones)
        {
            oracionConversaciones.Enqueue(oracion);
            // debugg(oracion);
        }



    }

    public void EncontrarNPCConversable()
    {
        gato = GameObject.Find("Gato");

        gato.transform.GetComponent<Renderer>().material.color = Color.blue;

        dialogo = new Dialogo(gato.transform.name, oracionConversaciones);
       
        //  debugg(dialogo.colaConversaciones);

        float distancia = Vector3.Distance(gato.transform.position, this.transform.position);
        if (distancia <= maxdistance)
        {
            //mensaje debug
            debugg.DebuggingText("Pulsa E para interactuar con el objecto");
            // if (Input.GetKeyDown(KeyCode.E))
            //{
            EmpezarConversacion();
            //}

        }
    }

    public void EmpezarConversacion()
    {
        debugg("Hola, soy " + dialogo.nombreNPC);

        //oracionConversaciones.Clear();
        //  debugg(oracionConversaciones);
        debugg(dialogo.colaConversaciones.Count + "1");
        string sentence = dialogo.colaConversaciones.Dequeue();
        debugg(dialogo.colaConversaciones.Count + "2");
        // debugg(sentence);
       // oracionConversaciones.Clear();

        //   debugg( dialogo.oracionConver);

        if (oracionConversaciones.Count == 0)
        {
            FinalizaConversacion();
        }
        else
        {
            ContinuarConversacion();
        }
        
            foreach (string frase in dialogo.oracionConver)
            {
                oracionConversaciones.Enqueue(frase);
            }

        }


    }

    public void ContinuarConversacion()
{

    string frase = oracionConversaciones.Dequeue();
    //  debugg(frase);

}

public void FinalizaConversacion()
{
    debugg("Final conversación");
    return;
}*/
