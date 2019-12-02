using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public string[] dialogue;
    public int options;
    public int index;
    public bool dlgMode;
    public bool showDlg;
    public Text dlg;
    public GameObject panel;
    public GameObject nextButton;
    public GameObject acceptDeny;
    public GameObject byeButton;

    public void DialogueShow(string[] text, int option)
    {
        dialogue = text;
        options = option;
        if (options == 0)
        {
            dlgMode = true;
        }
        panel.SetActive(true);
        index = 0;
        DialougeDirection();
    }

    public void DialougeDirection(int dir = 0)
    {
        index += dir;
        dlg.text = dialogue[index];
        nextButton.SetActive(false);
        acceptDeny.SetActive(false);
        byeButton.SetActive(false);
        if (!dlgMode && options == index)
        {
            acceptDeny.SetActive(true);
        }
        else if (index == dialogue.Length - 1)
        {
            byeButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }

    public void HideDialouge()
    {
        dialogue = null;
        options = 0;
        panel.SetActive(false);
        dlgMode = false;
        index = 0;
    }

    public void LastDialouge()
    {
        index = dialogue.Length-1;
        DialougeDirection();
    }
}
