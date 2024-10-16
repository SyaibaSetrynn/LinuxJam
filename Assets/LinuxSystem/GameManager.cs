using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
struct lines
{
    public string Content;
    public float Cooldown;
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

    public static void AddInstruction(string cont,float Cool=0)
    {
        Debug.Log("AddInstruction");
        lines l=new lines();
        cont = Regex.Replace(cont, "¥n", "");
        l.Content = cont+"\n";
        l.Cooldown = Cool;
        instructions.Enqueue(l);
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
                    inputField.text += GameManager.DefaultInstruction;
                    displayManager.MaintainLength();
                }
                GameManager.Executing = false;
            }
            else
            {
                //Debug.Log("instructions.count Not 0");
                lines tmp = instructions.Dequeue();
                CurrCoolDown = tmp.Cooldown;
                inputField.text += tmp.Content;
            }
        }
        else
        {
            CurrCoolDown -= Time.deltaTime;
            if (CurrCoolDown < 0) { CurrCoolDown = 0; }
        }
    }
}
