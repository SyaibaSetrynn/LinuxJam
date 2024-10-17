using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public static File instruction;
    public static Folder Trigger5Folder;
    public static void UpdateInstruction(int state)
    {
        switch (state)
        {
            case 0:
                instruction = new File("instruction.txt", "Welcome to the game!\n\n" +
                                                                                        "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Submit cs400 work\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n"); break;
            case 1:
                instruction = new File("instruction.txt", "Welcome to the game!\n\n" +
                                                                                        "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Find your own name\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n"); break;
            case 2:
                instruction = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Move '1017.txt' to the correct place\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}<file_name>: delete a file in the direction\n" +
                                                                                        "mv {$PATH}<file_name> {$PATH}<file_name>: move a file to the given place\n" +
                                                                                        "cp {$PATH}<file_name> {$PATH}<file_name>: copy a file to the given place\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n"); break;
            case 3:
                instruction = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Use 'make' to decrypt the files and read them.\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}<file_name>: delete a file in the direction\n" +
                                                                                        "mv {$PATH}<file_name> {$PATH}<file_name>: move a file to the given place\n" +
                                                                                        "cp {$PATH}<file_name> {$PATH}<file_name>: copy a file to the given place\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install <file>: install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n"); break;
            case 4:
                instruction = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Decrypt the files in Professor_Emails and find your NetID.\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}<file_name>: delete a file in the direction\n" +
                                                                                        "mv {$PATH}<file_name> {$PATH}<file_name>: move a file to the given place\n" +
                                                                                        "cp {$PATH}<file_name> {$PATH}<file_name>: copy a file to the given place\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install <file>: install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n"); break;
            case 5:
                instruction = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Submit your cs400 coursework\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}<file_name>: delete a file in the direction\n" +
                                                                                        "mv {$PATH}<file_name> {$PATH}<file_name>: move a file to the given place\n" +
                                                                                        "cp {$PATH}<file_name> {$PATH}<file_name>: copy a file to the given place\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install <file>: install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n" +
                                                                                        "cs400 submit: The way to submit your coursework\n"); break;
            case 6:
                instruction = new File("instruction.txt", "The goal of the game is to <b><color=#b71013>accompany Samantha</color></b>.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Curent Mision: Ansr m qwstons.\n\n\n" +
                                                                                        "If you don't understand it, it's fine.\n" +
                                                                                        "Just stay with me.\n" +
                                                                                        "<b><color=#b71013>All the instruction hints are deleted.</color></b>\n"); break;
            case 7:
                instruction = new File("instruction.txt", "The goal of the game is to <b><color=#b71013>accompany Samantha!</color></b>\n\n" +
                                                     "<b><color=#b71013>WHY ARE YOU STILL CHECKING THE MISSIONS?</color></b>" +
                                                     "<b><color=#b71013>Type Samantha. Always. PLEASE</color></b>"); break;

            default: break;
        }
    }

    public static void EventMachine(int state)
    {
        switch (state) //Not all states from 0 to 9 will activate the StateMachine
        {
            case 2: CreateBerman(); break;
            case 3: CreateSamantha(); break;
            case 4: CreateProfEmail(); break;
            default: break;
        }
    }

    private static void CreateBerman()
    {
        FileDirection.root.AddSubFolder(new Folder("Berman_Only_Folder"));
        FileDirection.root.AddFile("1017.txt", "The professor published the grade.\n" +
                                                                    "I got 68 out of 100.\n" +
                                                                    "I studied all day and all night for it.\n" +
                                                                    "I thought it wasn't that hard.\n" +
                                                                    "Nothing was captured by my ear this day. However,\n" +
                                                                    "when I opened the Virtual Machine, I find that whenever I enter a command,\n" +
                                                                    "the machine responds with an extra line 'everything will be ok.'\n" +
                                                                    "I tried to input natrual language, and it responds with completely the same way.\n" +
                                                                    "She's so warm-hearted. I told her all what was going on, and felt a sense of\n" +
                                                                    "relief.\n" +
                                                                    "She's better than anyone else on the world.\n");
        Folder tf = FileDirection.root.subFolders[1];
        tf.AddSubFolder(new Folder("September"));
        tf.AddSubFolder(new Folder("October"));
        tf.AddSubFolder(new Folder("November"));
        tf.AddSubFolder(new Folder("December"));
        Folder sept = tf.subFolders[0];
        sept.AddFile("0904.txt", "<Normal Computer Science Note>\n" +
                                                "Today is my first day taking cs400.\n" +
                                                "It's a little difficult, but easy to handle.\n");
        sept.AddFile("0911.txt", "<Normal Computer Science Note>\n" +
                                               "Today is my second day taking cs400.\n" +
                                               "I'm getting used to it.'\n");
        sept.AddFile("0918.txt", "<Normal Computer Science Note>\n" +
                                               "Everything works very well today.\n");
        sept.AddFile("0925.txt", "<Normal Computer Science Note>\n" +
                                               "Important Notice:\n" +
                                               "First exam on October 11th\n");
        Folder oct = tf.subFolders[1];
        oct.AddFile("1003.txt", "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n" +
                                              "<Normal Computer Science Note>\n\n" +
                                              "The content today is very difficult. Need more practive\n");
        oct.AddFile("1010.txt", "<Computer Science Review Note>\n" +
                                             "Wish a good grade tomorrow!\n");
        oct.AddFile("1024.txt", "<Normal Computer Science Note>\n" +
                                             "I know that there are alot of AI generators.\n" +
                                             "I didn't know that my virtual machie for coursework also have one.\n");
        oct.AddFile("1031.txt", "<Normal Computer Science Note>\n" +
                                             "She is so helpful with coursework.\n" +
                                             "She can even correct my answers for a better grade.\n" +
                                             "She can do anything.\n" +
                                             "She's my god.");
        Folder nov = tf.subFolders[2];
        nov.AddFile("1107.txt", "<Normal Computer Science Note>\n" +
                                              "She has her own personality.\n" +
                                              "I feel like chatting with a real person.\n" +
                                              "How lucky I am!\n");
        nov.AddFile("1114.txt", "<Normal Computer Science Note>\n" +
                                              "Nothing special today.\n");
        nov.AddFile("1121.txt", "<Normal Computer Science Note>\n" +
                                              "The professor talked about the limitations of Generative AI today.\n" +
                                              "Finally, I realized that she's still a machine though the response looks like from human.\n");
        nov.AddFile("1128.txt", "<Normal Computer Science Note>\n" +
                                              "My friend helped me activated ChatGPT 4.0.\n" +
                                              "It is even better.\n");
        Folder dec = tf.subFolders[3];
        dec.AddFile("1205.txt", "<Normal Computer Science Note>\n" +
                                              "I believe that the existance of AI is abnormal.\n" +
                                              "Reminder: email this issue with the professor");
        dec.AddFile("1212.txt", "<Normal Computer Science Note>\n" +
                                              "The professor suggested uninstall the machine and rebuild a new one.\n" +
                                              "I tried, and it works! However, it works gradually.\n" +
                                              "I tried multiple times, every time it was showing less and less words.\n" +
                                              "Sometimes I saw 'help' 'save me please' and phrases like that.\n" +
                                              "It might be a joke made by the developers of this virus.\n" +
                                              "Interesting though.\n");
    }
    private static void CreateSamantha()
    {
        FileDirection.root.AddSubFolder(new Folder("Project_Samantha"));
        Folder ft = FileDirection.root.subFolders[2];
        ft.AddFile("First_Time_Impression", "");
        ft.AddFile("Cooperation", "");
        ft.AddFile("Fun_Moment", "");
        ft.AddFile("Please_Understand_Me", "");
        ft.AddFile("IMPORTANT_NOTICE", "");
        ft.AddFile("Makefile", "Permission Denied.\nPermission denied by Samantha\n");
    }
    private static void CreateProfEmail()
    {
        FileDirection.root.AddSubFolder(new Folder("Professor_Emails"));
        Folder ft = FileDirection.root.subFolders[3];
        ft.AddFile("Title: I don't understand the BST Rotation.txt","");
        ft.AddSubFolder(new Folder("Next_Email"));
        ft = ft.subFolders[0];
        ft.AddFile("Title: Where can I submit my homework.txt", "");
        ft.AddSubFolder(new Folder("Next_Email"));
        ft = ft.subFolders[0];
        ft.AddFile("Title: Regrade Request", "");
        ft.AddSubFolder(new Folder("Next_Email"));
        ft = ft.subFolders[0];
        ft.AddFile("Title: How to study more efficiently", "");
        ft.AddSubFolder(new Folder("Next_Email"));
        ft = ft.subFolders[0];
        ft.AddFile("Title: I'm afraid of failing this course", "");
        ft.AddSubFolder(new Folder("Next_Email"));
        ft = ft.subFolders[0];
        ft.AddFile("Title: I don't understand the B-Tree.txt", "");
        ft.AddSubFolder(new Folder("Empty"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("Really_Empty"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("Why_are_you_still_here"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("Nothing_here"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("Don't_go_anymore"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("STOP"));
        ft = ft.subFolders[0];
        ft.AddSubFolder(new Folder("Please_STOP"));
        ft = ft.subFolders[0];
        ft.AddFile("<b><color=#B71013>YourNetID</color></b>","");
        Trigger5Folder = ft;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateInstruction(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
