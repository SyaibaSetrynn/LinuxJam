using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Globalization;
using System.Text.RegularExpressions;

public class DisplayManager : MonoBehaviour
{
    public TMP_InputField inputfield;
    private string LengthDefault,CurrentText="";
    // Start is called before the first frame update
    void Start()
    {
        inputfield.text = "";
        LengthDefault = inputfield.text;
        inputfield.caretPosition = inputfield.text.Length;
    }

    public void EnterCommand()
    {
        //Debug.Log("Enter");

        // Handle the case where there is no input
        if (CurrentText == "") inputfield.text += "\n";

        GameManager.ExeInstruction(CurrentText);
        GameManager.Executing = true;
        // Disable interaction while processing
        inputfield.interactable = false;

        // Update the internal state
        LengthDefault = inputfield.text;
        CurrentText = "";

        // Make sure the input field stays interactable after processing
        inputfield.interactable = true;

        // Ensure the input field is focused and caret is moved to the end
        //StartCoroutine(SetCaretToEnd());
        SetCaretToEnd();
    }

    public void FixWords()
    {
        if (LengthDefault.Length>inputfield.text.Length)
        {
            inputfield.text = LengthDefault;
        }
        else if (!inputfield.text.StartsWith(LengthDefault))
        {
            inputfield.text = LengthDefault + CurrentText;
        }
        else
        {
            CurrentText=inputfield.text.Substring(LengthDefault.Length);
        }
        if (inputfield.textComponent.textInfo.lineCount > GameManager.LineLimit)
        {
            SwallowLine();
        }
    }

    public void CheckParet()
    {
        if (inputfield.caretPosition < Regex.Replace(LengthDefault, "<.*?>", "").Length)
        {
            inputfield.caretPosition = Regex.Replace(LengthDefault, "<.*?>", "").Length;
        }
        //Debug.Log(LengthDefault.Substring(LengthDefault.Length-10)+Regex.Replace(LengthDefault, "<.*?>", "").Length + "<=" + inputfield.caretPosition);
    }
    private void SwallowLine()
    {
        TMP_TextInfo textInfo = inputfield.textComponent.textInfo; // Get the TextInfo
        // While the visual line count exceeds the limit
        while (textInfo.lineCount > GameManager.LineLimit)
        {
            Debug.Log(textInfo.lineCount + ">" + GameManager.LineLimit);
            Debug.Log("Try to swallow");

            // Get the index of the first character of the first line
            int firstCharIndex = textInfo.lineInfo[0].firstCharacterIndex;

            // Get the index of the last character of the first line
            int lastCharIndex = textInfo.lineInfo[0].lastCharacterIndex;

            // Remove all characters of the first visual line from the text
            string fullText = inputfield.text;

            // Remove the entire first line by taking all text after the last character of the first line
            string newText = fullText.Substring(lastCharIndex + 1);  // +1 to move past the last character of the line

            // Update the input field's text without the first visual line
            inputfield.text = newText;

            // Force TextMeshPro to update the text info and recalculate line info
            inputfield.ForceLabelUpdate();

            // Re-fetch the updated TextInfo after modifying the text
            textInfo = inputfield.textComponent.textInfo;

            // Move the caret to the end to keep the focus
            inputfield.caretPosition = inputfield.text.Length;

            LengthDefault = newText;
        }
        // Keep the input field active
        inputfield.ActivateInputField();
        //StartCoroutine(SetCaretToEnd());
        SetCaretToEnd();
    }
    private void SetCaretToEnd()
    {
        //yield return new WaitForEndOfFrame();
        // Now set the caret position at the end of the text
        inputfield.ActivateInputField();
        inputfield.caretPosition = inputfield.text.Length;
        //Debug.Log(LengthDefault.Length + "<=" + inputfield.caretPosition);
    }

    public void MaintainLength()
    {
        LengthDefault = inputfield.text;
    }

    public void Debuglog()
    {
        //Debug.Log(LengthDefault.Substring(LengthDefault.Length - 10) + Regex.Replace(LengthDefault, "<.*?>", "").Length + "<=" + inputfield.caretPosition);
    }
    // Update is called once per frame
    void Update()
    {
        bool flag = true;
        if (Input.anyKeyDown)
        {
            //Debug.Log(LengthDefault.Length+">"+inputfield.text.Length);
            CheckParet();
            flag = false;
        }
        if (inputfield.interactable == GameManager.Executing)
        {
            inputfield.interactable = !GameManager.Executing;
            if (inputfield.interactable)
            {
                LengthDefault = inputfield.text;
                //StartCoroutine(SetCaretToEnd());
                SetCaretToEnd() ;
            }
        }
        CheckParet();
        FixWords();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            EnterCommand();
        }
    }
}
