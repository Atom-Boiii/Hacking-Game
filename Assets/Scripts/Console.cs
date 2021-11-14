using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public GameObject commandLineText;
    public Transform commandLineHolder;

    public TMP_InputField commandField;

    public List<Email> emailList = new List<Email>();

    private List<GameObject> commands = new List<GameObject>();

    private void Start()
    {
        RunHome();
    }

    private void RunHome()
    {
        GameObject line = Instantiate(commandLineText, commandLineHolder);

        line.GetComponent<TMP_Text>().text = "Welcome back: "+ "User" +";<br>- You have " + emailList.Count + " emails;";

        commands.Add(line);
    }
    
    public void RunCommand(string line)
    {
        if (line.ToLower().StartsWith("email"))
        {
            string[] commandSplit = line.Split(' ');

            if(commandSplit[1] == "read")
            {
                int emailID = int.Parse(commandSplit[2]) - 1;

                if (emailList.Count >= emailID)
                {
                    for (int i = 0; i < commands.Count; i++)
                    {
                        Destroy(commands[i]);
                    }
                    commands.Clear();

                    GameObject lineObj = Instantiate(commandLineText, commandLineHolder);

                    lineObj.GetComponent<TMP_Text>().text = "From: " + emailList[emailID].from + "<br>To: " + emailList[emailID].to + "<br><br>" + emailList[emailID].message;

                    commands.Add(lineObj);
                }
                else
                {
                    GameObject lineObj = Instantiate(commandLineText, commandLineHolder);

                    lineObj.GetComponent<TMP_Text>().color = Color.red;

                    lineObj.GetComponent<TMP_Text>().text = "Message not found;";

                    commands.Add(lineObj);
                }
            }

            if(commandSplit[1] == "list")
            {
                GameObject lineObj = Instantiate(commandLineText, commandLineHolder);

                lineObj.GetComponent<TMP_Text>().text = "You have " + emailList.Count + " unread emails;";

                for (int i = 0; i < emailList.Count; i++)
                {
                    lineObj.GetComponent<TMP_Text>().text += "<br>1. From: " + emailList[i].from + ";";
                }

                commands.Add(lineObj);
            }

            if (commandSplit[1] == "delete")
            {
                int emailID = int.Parse(commandSplit[2]) - 1;

                if (emailList.Count >= emailID)
                {
                    GameObject lineObj = Instantiate(commandLineText, commandLineHolder);

                    lineObj.GetComponent<TMP_Text>().color = Color.red;

                    lineObj.GetComponent<TMP_Text>().text = "Message from " + emailList[emailID].from + " deleted;";

                    commands.Add(lineObj);

                    emailList.Remove(emailList[emailID]);
                }
                else
                {
                    GameObject lineObj = Instantiate(commandLineText, commandLineHolder);

                    lineObj.GetComponent<TMP_Text>().color = Color.red;

                    lineObj.GetComponent<TMP_Text>().text = "Message not found;";

                    commands.Add(lineObj);
                }
            }
        }

        if (line.ToLower().StartsWith("home"))
        {
            for (int i = 0; i < commands.Count; i++)
            {
                Destroy(commands[i]);
            }
            commands.Clear();

            RunHome();
        }

        commandField.text = "";
    }
}
