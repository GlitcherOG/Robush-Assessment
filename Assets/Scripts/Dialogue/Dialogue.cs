using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] text;
    public int option;

    public void TurnOnGUI(DialogueHandler dlg)
    {
        dlg.DialogueShow(text, option);
    }
}
