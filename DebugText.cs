using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Text debugging;
    

    //Para llamarlo poner debugg.DebbuggingText(lo que quieras sacar);

    public void DebuggingText(string text)
    {

        debugging.text = text;
    }
}
