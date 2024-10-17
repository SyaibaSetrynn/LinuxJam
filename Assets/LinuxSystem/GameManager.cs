using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System;
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
    public static bool[] GameEvent = new bool[10];
    /*Listing all events down here:
     *0: Wrong input of name
     */
    public static bool[] LockInstruction = new bool[4];
    /* Listing all lockable instruction here:
     * echo: unlock at chap1 using #0
     * rm/cp/me: unlock at chap2 using #1
     * make: unlock at chap3 using #2
     * Samantha: unlock at chap6 using #3
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
            l.Cooldown = Cool;
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
            l.Cooldown = Cool;
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
    }

    // Update is called once per frame
    void Update()
    {
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
                        Debug.Log("Outside program");
                    }
                    else
                    {
                        displayManager.MaintainLength();
                        Debug.Log("Inside program");
                    }
                }
                GameManager.Executing = false;
            }
            else
            {
                lines tmp = instructions.Dequeue();
                Debug.Log(tmp.Content+" "+tmp.inProgram);
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
