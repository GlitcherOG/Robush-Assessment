using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    private string[] dialogue; //String array containing the dialogue
    private int options; //Int for where the options dialogue is located 
    private int index; //Index for where the dialouge is upto
    private bool dlgMode; //Bool for which dialogue mode it is
    public bool showDlg; //Bool for if the dialogue is being shown
    public Text dlg; //Refrence for where the text is going to go
    public GameObject panel; //Refrence for the panel gameobject
    public GameObject nextButton; //Refrence for the next button
    public GameObject acceptDeny; //Refrence for the accept and deny buttons
    public GameObject byeButton; //Refrence for the bye Button

    //Void to show dialogue using string array and int
    public void DialogueShow(string[] text, int option)
    {
        //Set the dialogue to equal text
        dialogue = text;
        //Set the options to equal option
        options = option;
        //If options equals zero
        if (options == 0)
        {
            //Set dialouge mode to true
            dlgMode = true;
        }
        //Set the panel state to active
        panel.SetActive(true);
        //Set the index to zero
        index = 0;
        //Start Dialogue direction
        DialougeDirection();
    }

    public void DialougeDirection(int dir = 0)
    {
        //Index plus dir
        index += dir;
        //Set the dialogue text to be the the dialogue in postion index in the diagloue array
        dlg.text = dialogue[index];
        //Set the next button state to false
        nextButton.SetActive(false);
        //Set the accept and deny buttons states to false
        acceptDeny.SetActive(false);
        //Set the bye button active state to false
        byeButton.SetActive(false);
        //If dialogue mode is false and the options equals index
        if (!dlgMode && options == index)
        {
            //Set the accept and deny buttons state to true
            acceptDeny.SetActive(true);
        }
        //Else if the index is equal to the end postion of the dialogue
        else if (index == dialogue.Length - 1)
        {
            //Set bye buttons state to active
            byeButton.SetActive(true);
        }
        else
        {
            //Set the next buttons state to active
            nextButton.SetActive(true);
        }
    }

    public void HideDialouge()
    {
        //Set the dialouge array to null
        dialogue = null;
        //Set options to zero
        options = 0;
        //Set the panel state to false
        panel.SetActive(false);
        //Set the dialouge mode to false
        dlgMode = false;
        //Set the index to zero
        index = 0;
    }

    public void LastDialouge()
    {
        //Set the index to the end of the dialouge
        index = dialogue.Length - 1;
        //Run void dialouge direction
        DialougeDirection();
    }
}
