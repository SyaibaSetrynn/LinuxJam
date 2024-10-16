using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
struct lines
{
    public string Content;
    public float Cooldown;
}

public class GameManager : MonoBehaviour
{
    public static string DefaultInstruction = "<color=#6BF263>User@MyDearestLinux:~$_</color>";
    public static int LineLimit = 32;
    public static bool Executing = false;
    public InputField inputField;
    private static Queue<lines> instructions = new Queue<lines>();
    private float CurrCoolDown=0;

    public static void AddInstruction(string cont,float Cool=0)
    {
        lines l=new lines();
        l.Content = cont;
        l.Cooldown = Cool;
        instructions.Enqueue(l);
    }

    public static string ExeInstruction(string instruct)
    {
        Debug.Log("Exe");
        return "Command not found\n";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrCoolDown == 0)
        {
            if (instructions.Count == 0)
            {
                GameManager.Executing = false;
            }
            else
            {
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
