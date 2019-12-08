using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] text; //For all the text dialogue 
    public int option; //for which one has an option of avaliable

    //Turn on the diaolgue GUI
    public void TurnOnGUI(DialogueHandler dlg)
    {
        //Show the dialogue with the text and options values
        dlg.DialogueShow(text, option);
    }
}
