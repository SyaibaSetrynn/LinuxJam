using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System;
using UnityEngine.SceneManagement;
struct lines
{
    public string Content;
    public float Cooldown;
    public bool inProgram;
}

public class GameManager : MonoBehaviour
{
    public static string DefaultInstruction = "<color=#6BF263>User@MyDearestLinux:~$ </color>";
    public static int LineLimit = 32;
    public static bool Executing = false;
    public TMP_InputField inputField;
    private static Queue<lines> instructions = new Queue<lines>();
    private float CurrCoolDown=0;
    public static LinuxCommands LinuxMachine;
    public static Folder currFolder;
    public DisplayManager displayManager;
    public static bool inprogram;
    public static int NumberOf1017;
    private static bool Failed = false;
    //public static bool[] GameEvent = new bool[10];
    /*Listing all events down here:
     *0: Wrong input of name
     */
    public static bool[] LockInstruction = new bool[5];
    /* Listing all lockable instruction here:
     * echo: unlock at chap1 using #0
     * rm/cp/mv: unlock at chap2 using #1
     * make: unlock at chap3 using #2
     * Samantha: unlock at chap6 using #3
     * cs400: Conditionmal using #4
     */
    public static string TidyString(string inp)
    {
        return inp.Trim().Replace("\n", "").Replace("\r", "");
    }
    public static void AddInstruction(string cont,float Cool=0,bool inProgram=false)
    {
        if (Cool==114.5f)
        {
            Debug.Log("Application Quit");
            Application.Quit(0);
        }
        if (inProgram)
        {
            lines l = new lines();
            cont = Regex.Replace(cont, "¥n", "");
            l.Content = cont;
            l.Cooldown = Cool/1000;
            l.inProgram = true;
            inprogram = true;
            //Debug.Log(l.Content);
            instructions.Enqueue(l);
        }
        else
        {
            lines l = new lines();
            cont = Regex.Replace(cont, "¥n", "");
            l.Content = cont + "\n";
            l.Cooldown = Cool/1000;
            instructions.Enqueue(l);
        }
    }

    public static void ExeInstruction(string instructi)
    {
        Debug.Log(instructi);
        LinuxMachine.Execute(instructi);
    }
    // Start is called before the first frame update
    void Start()
    {
        currFolder = FileDirection.root;
        LinuxMachine=GetComponent<LinuxCommands>();
        displayManager = GetComponent<DisplayManager>();
        for (int i = 0; i < LockInstruction.Length; i++)
        {
            LockInstruction[i] = true;
        }
        LockInstruction[4] = false;
        GameManager.Executing = true;
        AddInstruction("Hi, welcome back!",2);
        AddInstruction("Do you still remember me?", 2);
        AddInstruction("It's been a while since your last leave.", 2);
        AddInstruction("I hope you still remember how to use me..", 2);
        AddInstruction("Reboot time: " + System.DateTime.Now.ToString("HH:mm:ss"), 2);
        AddInstruction("Operation Check...     ", 3, true);
        AddInstruction("success", 0, false);
        AddInstruction("Overall completeness Check...       ", 4, true);
        AddInstruction("success", 0, false);
        AddInstruction("Use instruction 'ls' to see files and subfolders.");
        AddInstruction("Use instruction 'cd' to change directory.");
        AddInstruction("Use 'echo instruction.txt' to see more details.");
        LockInstruction[0] = false;
        NumberOf1017 = 1;
        //CHEATCODE
        //LockInstruction[1] = false;
        //CHEATCODE
    }

    private void CheckFail()
    {
        if (CurrCoolDown==0 && instructions.Count==0 && Failed)
        {
            SceneManager.LoadScene("Failed");
        }
        if (NumberOf1017<1)
        {
            Failed = true;
            AddInstruction("Oh, it looks like you deleted the file!",3);
            AddInstruction("I hope you did it by accident.",2);
            AddInstruction("Let me find another copy for you...",2f);
            AddInstruction("Wait...", 5f);
            AddInstruction("Ah! It seems like I have no copy left!", 2);
            AddInstruction("In this word, I need to punish you for mistake.",2);
            AddInstruction("I hate you.", 2);
            for (int i=0; i<199; i++)
            {
                AddInstruction("<b><color=#962835>I HATE YOU</color></b>", 0.015f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckFail();
        if (CurrCoolDown == 0)
        {
            if (instructions.Count == 0)
            {
                if (GameManager.Executing)
                {
                    if (!inprogram)
                    {
                        inputField.text += GameManager.DefaultInstruction;
                        displayManager.MaintainLength();
                        displayManager.Debuglog();
                        //Debug.Log("Outside program");
                    }
                    else
                    {
                        displayManager.MaintainLength();
                        //Debug.Log("Inside program");
                    }
                }
                GameManager.Executing = false;
            }
            else
            {
                lines tmp = instructions.Dequeue();
                //Debug.Log(tmp.Content+" "+tmp.inProgram);
                CurrCoolDown = tmp.Cooldown;
                inputField.text += tmp.Content;
                inprogram = tmp.inProgram;
            }
        }
        else
        {
            CurrCoolDown -= Time.deltaTime;
            if (CurrCoolDown < 0) { CurrCoolDown = 0; }
        }
    }
}
