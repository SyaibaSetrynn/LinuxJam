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
    public static bool Success = false;
    public static bool madeSMS = false, NetIDReq=false ,ReqGiveUp=false;
    public static int NetIDReqCount = 0;
    public static Folder NetIDFolder;
    public static int SmsAnger = 0;
    public static string RightAnswer = "";
    public Animator mask, guitou;
    public static bool AddAnger = false;
    public static bool EndGame = false;
    private static float CoolDownBeforeEnd = 5;
    private static bool TS7 = false;
    public static bool WrapLine = false;
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
            l.Cooldown = Cool/1000;// 1000
            l.inProgram = true;
            inprogram = true;
            //Debug.Log(l.Content);
            instructions.Enqueue(l);
        }
        else
        {
            lines l = new lines();
            if (cont != null)
            {
                cont = Regex.Replace(cont, "¥n", "");
                l.Content = cont + "\n";
                l.Cooldown = Cool/1000; //1000
                instructions.Enqueue(l);
            }
        }
    }

    public static void ExeInstruction(string instructi)
    {
        //Debug.Log(instructi);
        if (instructi == null || instructi=="")
        {
            instructi = "a";
        }
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
        if (CurrCoolDown == 0 && instructions.Count == 0 && Success)
        {
            SceneManager.LoadScene("Success");
        }
        if ((NumberOf1017<1) && (!Failed))
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
        if (SmsAnger>=3 && (!Failed))
        {
            AddInstruction("Wait.",2);
            AddInstruction("Do you answer the question just for the purpose of beating the game?", 2);
            AddInstruction("I'm so disappointed.", 2);
            AddInstruction("You could read my love letter more carefully.");
            for (int i = 0; i < 199; i++)
            {
                AddInstruction("<b><color=#962835>I HATE YOU</color></b>", 0.015f);
            }
            Failed = true;
        }
    }

    private void CheckT5()
    {
        if (NetIDReq)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                NetIDReq = false;
                StateMachine.NextState = true;
                AddInstruction("\nGive up?",3f);
                AddInstruction("Alright. That's a wise decision.", 1f);
                AddInstruction("All you need to do is to stay by my side.", 2f);
                AddInstruction("Umm... Let me think what we can do...",4f);
                ReqGiveUp = true;
            }
            if (Input.anyKeyDown)
            {
                switch(NetIDReqCount)
                {
                    case < 10: AddInstruction("Really?", 0, true); break;
                    //case % 10 == 0: AddInstruction("Really?\n", 0, true); break;
                    default: 
                        if (NetIDReqCount % 10==0)
                        {
                            AddInstruction("Really?\n", 0, true);
                        }
                        AddInstruction("<b><color=#AB601E>Really?</color></b>", 0, true); 
                        break;
                }
                NetIDReqCount++;
                if (NetIDReqCount>101)
                {
                    NetIDReq = false;
                    for (int i = 0; i < 10; i++)
                        AddInstruction("<b>SHUT UP</b>");
                    AddInstruction("It's no use.", 2f);
                    AddInstruction("Umm....", 1f);
                    AddInstruction("So your NetID is Mycs400");
                    AddInstruction("Submit your work if you want.",1f);
                    AddInstruction("I don't care.",5f);
                    AddInstruction("Yeah, I don't care.");
                    StateMachine.NextState = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AddAnger)
        {
            AddAnger = false;
            mask.SetInteger("Anger", SmsAnger);
        }
        if (StateMachine.State>=7 && !TS7)
        {
            mask.SetTrigger("State7");
            TS7 = true;
        }
        if (EndGame)
        {
            if (CoolDownBeforeEnd>0)
            {
                CoolDownBeforeEnd -= Time.deltaTime;
            }
            else
            {
                mask.SetTrigger("FinalState");
                guitou.SetTrigger("GameEnd");
                EndGame = false;
            }
        }
        CheckFail();
        CheckT5();
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
