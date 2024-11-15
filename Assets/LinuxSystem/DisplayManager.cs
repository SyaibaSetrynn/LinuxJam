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
        TMP_InputField inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        inputField.textComponent.enableWordWrapping = false;  // Disables word wrapping
        inputField.textComponent.overflowMode = TextOverflowModes.Overflow;
    }

    public void EnterCommand()
    {
        //Debug.Log("Enter");

        // Handle the case where there is no input
        if (CurrentText == "") inputfield.text += "\n";

        GameManager.ExeInstruction(Regex.Replace(CurrentText,"\n",""));
        GameManager.Executing = true;
        GameManager.WrapLine = true;
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
            //Debug.Log("1Activated");
            inputfield.text = LengthDefault;
        }
        else if (!inputfield.text.StartsWith(LengthDefault))
        {
            //Debug.Log("2Activated");
            inputfield.text = LengthDefault + CurrentText;
        }
        else
        {
            //Debug.Log("3Activated");
            CurrentText =inputfield.text.Substring(LengthDefault.Length);
        }
        if (inputfield.textComponent.textInfo.lineCount > GameManager.LineLimit)
        {
            Debug.Log("4Activated");
            SwallowLine();
        }
        if (!inputfield.interactable)
        {
            FixWordHelper();
            GameManager.WrapLine = false;
        }
    }
    private string StripRichTextTags(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty);
    }
    private void FixWordHelper()
    {
        TMP_TextInfo textInfo = inputfield.textComponent.textInfo;

        // Create a copy of the input field text without rich text tags
        string strippedText = StripRichTextTags(inputfield.text);
        int strippedIndexOffset = 0; // Tracks offset between original and stripped text
        bool splitOccurred = false; // Tracks if a split has occurred for any line

        for (int i = 0; i < textInfo.lineCount; i++)
        {
            TMP_LineInfo lineInfo = textInfo.lineInfo[i];

            // Check if the length of the line in the stripped text exceeds the limit
            if (lineInfo.characterCount > 110 && !splitOccurred)
            {
                // Calculate the position to insert the newline in the stripped text
                int limitCharIndex = lineInfo.firstCharacterIndex + 108 - 1;

                // Find the corresponding index in the original text
                for (int j = 0, k = 0; j < inputfield.text.Length && k < strippedText.Length; j++)
                {
                    if (inputfield.text[j] == strippedText[k])
                    {
                        k++;
                        if (k == limitCharIndex + 1)
                        {
                            // Insert a newline in the original text at the matching index
                            inputfield.text = inputfield.text.Insert(j + 1, "\r\n");
                            splitOccurred = true; // Mark that a split occurred
                            inputfield.textComponent.ForceMeshUpdate();
                            textInfo = inputfield.textComponent.textInfo;
                            for (int l = 0; l < textInfo.lineCount; l++)
                            {
                                TMP_LineInfo lineInfo2 = textInfo.lineInfo[l];
                                if (lineInfo2.characterCount > 108)
                                    Debug.Log("This line still bigger than 108: " + lineInfo2.ToString());
                            }
                            if (inputfield.text.Contains(LengthDefault))
                            {
                                CurrentText = inputfield.text.Substring(LengthDefault.Length);
                                Debug.Log("CurrentText=" + CurrentText);
                            }
                            else
                            {
                                LengthDefault = inputfield.text.Substring(0, LengthDefault.Length + 2);
                                Debug.Log("Not Containing CurrText and FOrce update");
                            }
                            break;
                        }
                    }
                }

                // Update the text component
                inputfield.caretPosition += 2;
                inputfield.textComponent.ForceMeshUpdate();
                textInfo = inputfield.textComponent.textInfo; // Refresh textInfo after change
            }
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
            //Debug.Log(textInfo.lineCount + ">" + GameManager.LineLimit);
            //Debug.Log("Try to swallow");

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
        //Debug.Log(CurrentText);
        bool flag = true;
        if (Input.anyKeyDown)
        {
            //Debug.Log(LengthDefault.Length+">"+inputfield.text.Length);
            CheckParet();
            flag = false;
            //inputfield.Select();
            //inputfield.ActivateInputField();
            //Debug.Log(inputfield.caretPosition);
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
