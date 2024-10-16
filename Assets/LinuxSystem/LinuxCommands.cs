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
        // Remove any newline characters or extra spaces
        inst = Regex.Replace(inst, "¥n", "").Trim();

        // If the input is empty or contains only spaces, go to the root folder
        if (string.IsNullOrEmpty(inst))
        {
            GameManager.currFolder = FileDirection.root;  // Adjust to root folder
            GameManager.DefaultInstruction = "<color=#6BF263>User@MyDearestLinux:~$ </color>";
            return;
        }

        // Split the input by '/' to navigate through folders
        string[] folders = inst.Split('/');

        // Start from the current folder
        Folder currentFolder = GameManager.currFolder;

        foreach (string folder in folders)
        {
            // Try to find the folder within the current folder
            Folder nextFolder = currentFolder.subFolders.Find(f => f.name == folder);

            if (nextFolder.name == null)
            {
                // If the folder is not found, output an error message and stop
                GameManager.AddInstruction("***Directory not found***");
                return;
            }

            // Move to the next folder in the path
            currentFolder = nextFolder;
        }

        // Update the current folder to the one we navigated to
        GameManager.currFolder = currentFolder;

        // Update the DefaultInstruction to reflect the new folder path
        GameManager.DefaultInstruction = $"<color=#6BF263>User@MyDearestLinux:~/{inst}$ </color>";
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
