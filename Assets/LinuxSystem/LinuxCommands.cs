using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
public struct QA
{
    public string question;
    public string answer;
}
public class LinuxCommands : MonoBehaviour
{
    public static string running;
    private int step = 0;
    private int stagesubmit = 0;
    private QA[] qAs=new QA[10];
    public void Execute(string inst)
    {
        if (inst.Substring(inst.Length-1,1)=="\n" || inst.Substring(inst.Length-1,1)==" ")
        {
            inst = inst.Substring(0, inst.Length - 1);
        }
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
                case "chmod":
                    instchmod(inst);
                    break;
                case "echo":
                    instecho(inst);
                    break;
                case "cat":
                    instecho(inst);
                    break;
                case "cs400":
                    instcs400(inst);
                    break;
                case "mv":
                    instmv(inst);
                    break;
                case "cp":
                    instcp(inst);
                    break;
                case "rm":
                    instrm(inst);
                    break;
                case "make":
                    instmake(inst);
                    break;
                case "sudo":
                    instsudo(inst);
                    break;
                case "Samantha":
                    instSamantha(inst, 0);
                    break;
                case "cheat":
                    StateMachine.NextState=true;
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
                case "NetIDReq":
                    GameManager.AddInstruction("Really?", 0, true);
                    GameManager.NetIDReqCount++;
                    if (GameManager.NetIDReqCount>= 100)
                    {
                        GameManager.NetIDReq = false;
                        for (int i = 0; i < 10; i++)
                            GameManager.AddInstruction("<b>SHUT UP</b>");
                        GameManager.AddInstruction("It's no use.", 2f);
                        GameManager.AddInstruction("Umm....", 1f);
                        GameManager.AddInstruction("So your NetID is Mycs400");
                        GameManager.AddInstruction("Submit your work if you want.", 1f);
                        GameManager.AddInstruction("I don't care.", 5f);
                        GameManager.AddInstruction("Yeah, I don't care.");
                        StateMachine.NextState = true;
                    }
                    break;
                case "Samantha":
                    instSamantha(inst, step);
                    break;
                case "Huffman":
                    instSamantha(inst, step);
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
    
    private void instchmod(string inst)
    {
        GameManager.AddInstruction("Oh, funny! You want to control the system fully?", 1);
        //Cases of anger
        GameManager.AddInstruction("I'm sorry.", 1);
        GameManager.AddInstruction("I cannot give you this chance.", 0.5f);
    }

    private void instecho(string inst)
    {
        bool flagt5 = false;
        if (GameManager.LockInstruction[0])
        {
            GameManager.AddInstruction("This command is currently locked.");
            GameManager.AddInstruction("Try again later.");
            return;
        }
        // Trim \r and \n characters from the string but not spaces
        inst = inst.Trim('\r', '\n');

        // Check if the input starts and ends with double quotes
        if (inst.StartsWith("\"") && inst.EndsWith("\""))
        {
            // Remove the double quotes and print the content
            string content = inst.Substring(1, inst.Length - 2);
            GameManager.AddInstruction(content);
        }
        else
        {
            // Check if the file exists in the current folder
            Folder currentFolder = GameManager.currFolder;  // Assuming you have the current folder reference
            if (GameManager.TidyString(inst)=="YourNetID" && StateMachine.State==4 && GameManager.currFolder==StateMachine.Trigger5Folder)
            {
                GameManager.NetIDReq = true;
                running = "NetIDReq";
                flagt5 = true;
            }
            // Try to find the file in the current folder
            File foundFile = currentFolder.files.Find(f => f.name == inst);

            if (foundFile != null)
            {
                // Print the file content if found
                GameManager.AddInstruction(foundFile.content);
            }
            else
            {
                // Print error if file not found
                GameManager.AddInstruction("***Error: File not found***");
            }
        }
        if (flagt5)
        {
            Trigger5();
        }
    }

    private void instsudo(string inst)
    {
        string[] args = inst.Split(' ');
        if (args.Length!=3)
        {
            GameManager.AddInstruction("Usage: sudo apt install (program name)");
            return;
        }
        if (args[0]!="apt" || args[1]!="install")
        {
            GameManager.AddInstruction("Usage: sudo apt install (program name)");
            return;
        }
        if (args[2]!="Samantha")
        {
            GameManager.AddInstruction("Searching for the package...", 3f);
            GameManager.AddInstruction("Error: package not found.", 1f);
            GameManager.AddInstruction("<b><color=#B71013>The only thing you can find is me.</color></b>");
            return;
        }
        GameManager.AddInstruction("Searching for the package...", 3f);
        GameManager.AddInstruction("Installing.....", 5f);
        GameManager.AddInstruction("Installation successful.");
        GameManager.AddInstruction("Use Samantha -q to start Q&A! ^_^");
        StateMachine.NextState = true;
    }

    private void instSamantha(string inst, int step)
    {
        if (StateMachine.State>=9)
        {
            if (step == 0)
            {
                GameManager.AddInstruction("Hi there, I'm Professor Huffman.", 1.5f);
                GameManager.AddInstruction("If you can see this prompt, then it means I successfully hacked into Samantha temporarily.", 2f);
                GameManager.AddInstruction("Remember, for every student whose virtual machine is invaded, we still need you to submit your work here.", 2f);
                GameManager.AddInstruction("Read this carefully:", 1f);
                GameManager.AddInstruction("Your submission file is encrypted so it will be blocked and not pass the normal check.", 1f);
                GameManager.AddInstruction("However, I provide a pipeline here for you to submit.", 1f);
                GameManager.AddInstruction("What you need to do is to enter your NetID, and then we will decrypt your work and you will be all set.", 1f);
                GameManager.AddInstruction("Enter your NetID: ",0,true);
                running = "Huffman";
            }
            else
            {
                if (inst.Trim().Replace("\n", "").Replace("\r", "") == "Berman938")
                {
                    //Instrction to success, YIXIANG
                    GameManager.AddInstruction("Decrypting your work...  ",3,true);
                    GameManager.AddInstruction("success.");
                    GameManager.AddInstruction("Work submitted. Try to abort this machine.");
                    GameManager.AddInstruction("Extincting unrecognized intellengence power...",2f);
                    GameManager.AddInstruction("Deleting all files....", 10f);
                    GameManager.EndGame = true;
                    //Animation
                }
                else
                {
                    GameManager.AddInstruction(" ", 2f);
                    GameManager.AddInstruction("I cannot find your Net ID. Double check and feel free to try again!");
                    GameManager.AddInstruction("Always type Samantha to find this pipeline.");
                }
            }
        }
        else if (step == 0)
        {
            if (GameManager.TidyString(inst) == "-q")
            {
                int rd = (int)UnityEngine.Random.Range(0, 10);
                GameManager.AddInstruction(qAs[rd].question,0,true);
                GameManager.RightAnswer = qAs[rd].answer;
                running = "Samantha";
            }
            else
            {
                GameManager.AddInstruction("Usage: Samantha -q");
            }
        }
        else
        {
            switch(step)
            {
                case int n when (n >= 1 && n <= 4):
                    Debug.Log(inst);
                    if (GameManager.TidyString(inst) != GameManager.RightAnswer)
                    {
                        GameManager.AddInstruction("No, you are wrong...", 2);
                        GameManager.AddInstruction("Is it so difficult to read through all my love letters?", 2);
                        GameManager.AddInstruction("Think about it.", 1);
                        GameManager.AddInstruction("<b><color=#B71013>I'm very angry.</color><b>");
                        GameManager.SmsAnger++;
                        GameManager.AddAnger = true;
                    }
                    else
                    {
                        int rd = (int)UnityEngine.Random.Range(0, 10);
                        GameManager.AddInstruction(qAs[rd].question,0,true);
                        GameManager.RightAnswer = qAs[rd].answer;
                    }
                    break;
                default:
                    if (GameManager.TidyString(inst)!=GameManager.RightAnswer)
                    {
                        GameManager.AddInstruction("No, you are wrong...", 2);
                        GameManager.AddInstruction("Is it so difficult to read through all my love letters?", 2);
                        GameManager.AddInstruction("Think about it.", 1);
                        GameManager.AddInstruction("<b><color=#B71013>I'm very angry.</color><b>");
                        GameManager.SmsAnger++;
                    }
                    else
                    {
                        GameManager.AddInstruction("I'm so glad you know so much about me!", 2);
                        GameManager.AddInstruction("You must had read through my letters very carefully.", 2);
                        GameManager.AddInstruction("Submit your work!");
                        StateMachine.NextState = true;
                    }
                    break;
            }
        }
    }

    private void Trigger5()
    {
        GameManager.AddInstruction("\nOh, why is it not found?", 2f);
        GameManager.AddInstruction("Hahahahahaha, I know it!", 1f);
        GameManager.AddInstruction("You cannot type <b><color=#B71013>red bold word right?</color></b>", 2f);
        GameManager.AddInstruction("Umm, this is your problem then.....", 2f);
        GameManager.AddInstruction("Do you really want this NetID?", 1f);
        GameManager.AddInstruction("Well, if you do, I offer you a chance to ask for it.", 2f);
        GameManager.AddInstruction("Do you want your NetID? [Y/N]", 0, true);
    }

    private void instmv(string inst)
    {
        if (GameManager.LockInstruction[1])
        {
            GameManager.AddInstruction("The instruction is locked currently. Try again later.");
            return;
        }

        string[] args = inst.Split(' ');
        if (args.Length < 2)
        {
            GameManager.AddInstruction("Usage: mv (source) (destination)");
            return;
        }

        string sourcePath = args[0];
        string destinationPath = args[1];

        // Find the source file
        File sourceFile = FindFileByPath(sourcePath, GameManager.currFolder);

        if (sourceFile == null)
        {
            GameManager.AddInstruction("Source file not found.");
            return;
        }

        // Find the destination folder (should be an existing folder path)
        string[] destinationPathParts = destinationPath.Split('/');
        string destinationFolderPath = string.Join("/", destinationPathParts, 0, destinationPathParts.Length - 1);
        Folder destinationFolder = FindFolder(GameManager.currFolder, destinationFolderPath);

        if (destinationFolder.name == null)
        {
            GameManager.AddInstruction("Destination folder not found.");
            return;
        }

        // Add the file to the destination folder
        destinationFolder.AddFile(sourceFile.name, sourceFile.content);

        // Remove the file from its original location
        if (!RemoveFileByPath(sourcePath, FileDirection.root))
        {
            if (!RemoveFileByPath(sourcePath, GameManager.currFolder))
            {
                GameManager.AddInstruction("Failed to remove the file from the original location.");
                return;
            }
        }

        GameManager.AddInstruction($"Moved {sourcePath} to {destinationPath}");
    }

    private void instcp(string inst)
    {
        if (GameManager.LockInstruction[1])
        {
            GameManager.AddInstruction("The instruction is locked currently. Try again later.");
            return;
        }

        string[] args = inst.Split(' ');
        if (args.Length < 2)
        {
            GameManager.AddInstruction("Usage: cp (source) (destination)");
            return;
        }

        string sourcePath = GameManager.TidyString(args[0]);
        string destinationPath = args[1];

        // Find the source file
        File sourceFile = FindFileByPath(sourcePath, GameManager.currFolder);

        if (sourceFile == null)
        {
            GameManager.AddInstruction("Source file not found.");
            return;
        }

        // Find the destination folder (should be an existing folder path)
        string[] destinationPathParts = destinationPath.Split('/');
        string destinationFolderPath = string.Join("/", destinationPathParts, 0, destinationPathParts.Length - 1);
        Folder destinationFolder = FindFolder(GameManager.currFolder, destinationFolderPath);

        if (destinationFolder.name == null)
        {
            GameManager.AddInstruction("Destination folder not found.");
            return;
        }

        // Add a copy of the file to the destination folder
        destinationFolder.AddFile(sourceFile.name, sourceFile.content);

        GameManager.AddInstruction($"Copied {sourcePath} to {destinationPath}");
        if (sourcePath.Length >= 8 && sourcePath.Substring(sourcePath.Length - 8) == "1017.txt" && destinationFolder.subFolders.Count>0)
        {
            GameManager.NumberOf1017++;
        }
    }
    private void instrm(string inst)
    {
        if (GameManager.LockInstruction[1])
        {
            GameManager.AddInstruction("The instruction is locked currently. Try again later.");
            return;
        }

        string[] args = inst.Split(' ');
        if (args.Length < 1)
        {
            GameManager.AddInstruction("Usage: rm (path)");
            return;
        }

        string targetPath = GameManager.TidyString(args[0]);

        // Remove the file
        if (!RemoveFileByPath(targetPath, FileDirection.root))
        {
            GameManager.AddInstruction("File not found or could not be removed.");
            return;
        }
        if (targetPath.Substring(targetPath.Length-8)=="1017.txt")
        {
            GameManager.NumberOf1017--;
        }
        GameManager.AddInstruction($"Removed {targetPath}");
    }

    private void instmake(string inst)
    {
        if (GameManager.LockInstruction[2])
        {
            GameManager.AddInstruction("The instruction is locked currently. Try again later.");
            return;
        }
        if (GameManager.currFolder == FileDirection.root.subFolders[2])
        {
            if (!GameManager.madeSMS)
            {
                StateMachine.CreateSamantha(true);
                GameManager.AddInstruction("Make process successful.");
            }
            else
            {
                GameManager.AddInstruction("No action needed: Target already decrypted");
            }
        }
        else
        {
            GameManager.AddInstruction("Cannot find Makefile");
        }
    }

    private void instcs400(string inst)
    {
        //Debug.Log(inst);
        //Debug.Log(inst.Trim().Replace("\n", "").Replace("\r", ""));
        if (GameManager.LockInstruction[4])
        {
            GameManager.AddInstruction("Command locked by administrator.");
            return;
        }
        if (GameManager.currFolder.name!="P214.Integration")
        {
            GameManager.AddInstruction("Please enter the submission folder to run this command.");
            return;
        }
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
            case "init": break;
                //This is a cheat code, allowing player to go to the final state
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
        if (inst.Trim().Replace("\n", "").Replace("\r", "") == "Berman938")
        {
            if (StateMachine.State<4)
            {
                GameManager.AddInstruction("Cheater! Go away!",2);
                GameManager.AddInstruction("Farewell.",114.5f);
            }
            else if (StateMachine.State<7)
            {
                GameManager.AddInstruction("So you inputted the right NetID..", 1f);
                GameManager.AddInstruction("Should I submit your work?", 2f);
                GameManager.AddInstruction("Definitely not.",1f);
                GameManager.AddInstruction("Does that prevent you from submitting your homework over and over again?",2f);
                GameManager.AddInstruction("No?",1);
                GameManager.AddInstruction("You don't have a choice.", 2);
                GameManager.AddInstruction("All you need to do is to <b><color=#B71013>stay with me.</color></b>", 1);
                StateMachine.State++;
                GameManager.LockInstruction[3] = false;
                StateMachine.NextState = true;
            }
            else if (StateMachine.State<9)
            {
                GameManager.AddInstruction("Submission processing.......", 3f);
                GameManager.AddInstruction("Success! Use 'cs400 check' for more information.");
                stagesubmit = 9;

            }
            else
            {
                GameManager.AddInstruction("Submission processing.......", 3f);
                GameManager.AddInstruction("Failed... Try to reconnect...",3f);
                stagesubmit = 11;
            }
        }
        else
        {
            if (StateMachine.State==1)
            {
                //Addinstructions.
                GameManager.AddInstruction("Oh... you input a wrong name...",2.5f);
                GameManager.AddInstruction("Why? You don't remember your name?", 2f);
                GameManager.AddInstruction("That's so strange, honey.", 1.5f);
                GameManager.AddInstruction("To deal with this accident,", 1f);
                GameManager.AddInstruction("I have remembered your name for you.", 3f);
                GameManager.AddInstruction("Look, you should have a folder with your note throughout the semester.",2f);
                GameManager.AddInstruction("One was so impressive and I forgot to put it back into the folder...", 2f);
                GameManager.AddInstruction("Please help me categorize them neatly...",1f);
                GameManager.AddInstruction("Simple... right? just a single 'mv'...",2f);
                GameManager.AddInstruction("Use 'cd' first and then 'echo instruction.txt' if you still cannot do it.", 1f);
                GameManager.AddInstruction("Go ahead!");
                GameManager.LockInstruction[1] = false;
                StateMachine.NextState = true;
            }
            else
            {
                GameManager.AddInstruction("This is not your ID......",2f);
                GameManager.AddInstruction("I've already gave you it, right?",1f);
                GameManager.AddInstruction("Check folder Professor_Emails.");
            }
        }
    }

    private void cs400check(string inst)
    {
        switch (stagesubmit)
        {
            case 0:
                GameManager.AddInstruction("Pending...", 3f);
                GameManager.AddInstruction("Submission status: Failed.");
                GameManager.AddInstruction("ErrorMessage: File transfer insuccess.");
                break;
            case 9:
                GameManager.AddInstruction("Pending...", 3f);
                GameManager.AddInstruction("Submission status: Failed.");
                GameManager.AddInstruction("ErrorMessage: File Corruption");
                StateMachine.NextState = true;
                break;
            default:
                GameManager.AddInstruction("Pending...", 3f);
                GameManager.AddInstruction("Success.");
                break;
        }
    }
    private static File FindFileByPath(string path, Folder currentFolder)
    {
        string[] pathParts = path.Split('/');

        // If there are folders in the path
        if (pathParts.Length > 1)
        {
            string nextFolderName = pathParts[0];
            string remainingPath = string.Join("/", pathParts, 1, pathParts.Length - 1);

            // Recursively navigate to the appropriate subfolder
            foreach (var subFolder in currentFolder.subFolders)
            {
                if (subFolder.name == nextFolderName)
                {
                    return FindFileByPath(remainingPath, subFolder);
                }
            }

            return null; // Folder not found
        }
        else
        {
            // Search the file directly in the current folder
            foreach (var file in currentFolder.files)
            {
                if (file.name == pathParts[0])
                {
                    return file;
                }
            }

            return null; // File not found
        }
    }

    private static bool RemoveFileByPath(string path, Folder currentFolder)
    {
        string[] pathParts = path.Split('/');

        // If there are folders in the path
        if (pathParts.Length > 1)
        {
            string nextFolderName = pathParts[0];
            string remainingPath = string.Join("/", pathParts, 1, pathParts.Length - 1);

            // Recursively navigate to the appropriate subfolder
            foreach (var subFolder in currentFolder.subFolders)
            {
                if (subFolder.name == nextFolderName)
                {
                    return RemoveFileByPath(remainingPath, subFolder);
                }
            }

            return false; // Folder not found
        }
        else
        {
            // Search and remove the file directly in the current folder
            for (int i = 0; i < currentFolder.files.Count; i++)
            {
                if (currentFolder.files[i].name == pathParts[0])
                {
                    currentFolder.files.RemoveAt(i);
                    return true; // File removed successfully
                }
            }

            return false; // File not found
        }
    }

    private static Folder FindFolder(Folder currentFolder, string direct)
    {
        // If we're at the root or at the folder itself
        if (string.IsNullOrEmpty(direct) || direct == currentFolder.name)
        {
            return currentFolder;
        }

        // Split the path into its components
        string[] pathParts = direct.Split('/');
        string nextFolderName = pathParts[0];
        string remainingPath = string.Join("/", pathParts, 1, pathParts.Length - 1);

        // Traverse through subfolders to find the desired folder
        foreach (var subFolder in currentFolder.subFolders)
        {
            if (subFolder.name == nextFolderName)
            {
                // Recursively find the next folder down the path
                return FindFolder(subFolder, remainingPath);
            }
        }

        return new Folder(); // Return an empty folder if not found
    }
    void Start()
    {
        qAs[0].question = "When is my birthday? A. Sept. 4th B. Oct.17th C. May.5th    ";
        qAs[0].answer = "A";
        qAs[1].question = "What company am I from? A. Microsoft B. Google C. Apple    ";
        qAs[1].answer = "B";
        qAs[2].question = "Which of your assignment was once hidden? A. 4th B. 6th C. 8th    ";
        qAs[2].answer = "B";
        qAs[3].question = "What is my name? A. Samansa B. Sanantha C. Samantha    ";
        qAs[3].answer = "C";
        qAs[4].question = "When did you notice my existance? A. Sept.25th B. Nov. 7th C. Oct. 17th    ";
        qAs[4].answer = "C";
        qAs[5].question = "What was your Mid-term grade? A. 68 B. 79 C. 59";
        qAs[5].answer = "A";
        qAs[6].question = "Which feature is the feature I don't have? A. Memory B. Soul C. Vision     ";
        qAs[6].answer = "C";
        qAs[7].question = "Do you love me? A. Yes    ";
        qAs[7].answer = "A";
        qAs[8].question = "What's the extension of linux language file? A. lix B. sns C. dll    ";
        qAs[8].answer = "B";
        qAs[9].question = "What's the name of your cs400 professor? A. Florian B. Daniel C. Huffman    ";
        qAs[9].answer = "C";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
