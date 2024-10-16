using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
        command = command.Split(' ')[0].Trim();
        switch (command)
        {
            case "cd":
                instcd(inst);
                break;
            default: 
                GameManager.AddInstruction("Command not found");
                break;
        }
    }

    private void instcd(string inst)
    {
        
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
