using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class LinuxCommands : MonoBehaviour
{
    public static string running;
    private int step = 0;
    public void Execute(string inst)
    {
        if (!GameManager.inprogram)
        {
            string command;
            int spaceIndex = inst.IndexOf(" "); // Find the index of the first space
            if (spaceIndex != -1) // If there is a space in the string
            {
                string beforeSpace = inst.Substring(0, spaceIndex); // Get the substring before the first space
                //Debug.Log(beforeSpace); // Output: "User@MyDearestLinux:~$"
                command = beforeSpace;
                inst = inst.Substring(spaceIndex + 1);
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
                    instls(inst);
                    break;
                case "nano":
                    instnano(inst);
                    break;
                case "cs400":
                    instcs400(inst);
                    break;
                default:
                    GameManager.AddInstruction("Command not found");
                    break;
            }
            step = 0;
        }
        else
        {
            step++;
            switch (running)
            {
                case "cs400 submit":
                    //Yet to be design.
                    cs400submit(inst,step);
                    break;
                default: 
                    Debug.Log("You cannot reach here because running is invalid.");
                    GameManager.inprogram = false;
                    break;
            }
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

    private void instnano(string inst)
    {
        GameManager.AddInstruction("Oh, funny! You want to cheat on your coursework?", 1);
        GameManager.AddInstruction("Never-ever!",0.5f);
    }

    private void instcs400(string inst)
    {
        //Debug.Log(inst);
        //Debug.Log(inst.Trim().Replace("\n", "").Replace("\r", ""));
        switch (inst.Trim().Replace("\n", "").Replace("\r", ""))
        {
            case "submit":
                running = "cs400 submit";
                GameManager.AddInstruction("Enter your NetID: ",0,true);
                GameManager.inprogram = false;
                break;
            case "check":
                //Some checks. Need further design
                GameManager.inprogram = false;
                break;
            default:
                GameManager.AddInstruction("Invalid parameter for command 'cs400'.");
                GameManager.AddInstruction("Try again.");
                GameManager.inprogram = false;
                break;
        }

    }
    // Start is called before the first frame update

    private void cs400submit(string inst,int step)
    {
        Debug.Log(inst);
        if (inst.Trim().Replace("\n", "").Replace("\r", "") == "Mycs400")
        {
            if (!GameManager.GameEvent[0])
            {
                GameManager.AddInstruction("Cheater! Go away!",2);
                GameManager.AddInstruction("Farewell.",114.5f);
            }
            else
            {
                //Need Redesign
                GameManager.AddInstruction("Finally!");
            }
        }
        else
        {
            if (!GameManager.GameEvent[0])
            {
                //Addinstructions.
                GameManager.AddInstruction("Oh... you input a wrong name...",1f);
                GameManager.GameEvent[0] = true;
            }
            else
            {
                GameManager.AddInstruction("This is not your name......",2f);
                GameManager.AddInstruction("I know it.");
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
