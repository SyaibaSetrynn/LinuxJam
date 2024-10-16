using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LinuxCommands : MonoBehaviour
{
    public void Execute(string inst)
    {
        string command;
        string parameter;
        int spaceIndex = inst.IndexOf(" "); // Find the index of the first space
        if (spaceIndex != -1) // If there is a space in the string
        {
            string beforeSpace = inst.Substring(0, spaceIndex); // Get the substring before the first space
            Debug.Log(beforeSpace); // Output: "User@MyDearestLinux:~$"
            command = beforeSpace;
            inst=inst.Substring(spaceIndex + 1);
        }
        else
        {
            command = inst;
            inst = "";
        }
        command = command.Split(' ')[0].Trim();
        switch (command)
        {
            case "cd":
                instcd(inst);
                break;
            case "ls":
                instls(inst); break;
            default: 
                GameManager.AddInstruction("Command not found");
                break;
        }
    }

    private void instcd(string inst)
    {
        inst = Regex.Replace(inst, "\n", "").Trim();

        if (string.IsNullOrEmpty(inst) || inst == "~")
        {
            // Navigate to root directory if "~" or empty is passed
            GameManager.currFolder = FileDirection.root;
            GameManager.DefaultInstruction = "<color=#6BF263>User@MyDearestLinux:~$ </color>";
        }
        else
        {
            // Otherwise, change to the specified directory
            FileDirection.ChangeDirectory(inst);
        }
    }

    private void instls(string inst)
    {
        if (Regex.Replace(inst, " ", "").Trim().Length!=0)
        {
            Debug.Log(inst);
            GameManager.AddInstruction("Additional Parameter ignored.");
        }
        FileDirection.list(GameManager.currFolder);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
