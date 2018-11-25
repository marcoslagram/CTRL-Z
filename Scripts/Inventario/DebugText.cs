using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Text debugging;
    public Text salud;
    public Text energia;
    public Text usos;
    public Text dialogos;
    public Text tutorial;


    //Para llamarlo poner debugg.DebbuggingText(lo que quieras sacar);

    public void DebuggingText(string text)
    {
         
        
           // Debug.Log("aaaa");
            debugging.text = text;
            
            //debugging.gameObject.SetActive(!debugging.gameObject.activeInHierarchy);
        
        
           // Debug.Log(text);
        
        
    }

    /*public void DebuggingSalud(string text)
    {
        salud.text = text;
     //   Debug.Log(text);
    }

    public void DebuggingEnergia(string text)
    {
        energia.text = text;
     //   Debug.Log(text);
    }

    public void DebuggingUsos(string text)
    {
        usos.text = text;
        //Debug.Log(text);
    }*/


    public void DebuggingDialogos(string text)
    {
        dialogos.text = text;
        //Debug.Log(text);
    }

    public void DebuggingTutorial(string text)
    {
        tutorial.text = text;
        //Debug.Log(text);
    }


}
