using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class StateMachine : MonoBehaviour
{
    public static Folder Trigger5Folder;
    public static int State;
    public static bool NextState;
    public static void UpdateInstruction(int state)
    {
        //Debug.Log("Instruction Updated");
        bool flag = false;
        int index = 0;
        foreach (var file in FileDirection.root.files)
        {
            if (file.name == "instruction.txt") { flag = true; break; }
            index++;
        }
        if (index>=FileDirection.root.files.Count) 
        {
            index = 0;
        }
        if (!flag)
        {
            FileDirection.root.AddFile("instruction.txt", "0");
            index = FileDirection.root.files.Count-1;
        }
        switch (state)
        {
            case 0:
                FileDirection.root.files[index] = new File("instruction.txt", "Welcome to the game!\n\n" +
                                                                                        "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Submit cs400 work\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n"); break;
            case 2:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Move '1017.txt' to the correct place\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}(file_name): delete a file in the direction\n" +
                                                                                        "mv {$PATH}(file_name) {$PATH}(file_name): move a file to the given place\n" +
                                                                                        "cp {$PATH}(file_name) {$PATH}(file_name): copy a file to the given place\n" +
                                                                                        "<color=#CE9128>You still need an absolute direction in a subfolder.</color>\n" +
                                                                                        "Example: to refer to subfolder/text, you need to input this regaredless of your current directory\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n"); break;
            case 3:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Use 'make' to decrypt the files and read them.\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}(file_name): delete a file in the direction\n" +
                                                                                        "mv {$PATH}(file_name) {$PATH}(file_name): move a file to the given place\n" +
                                                                                        "cp {$PATH}(file_name) {$PATH}(file_name): copy a file to the given place\n" +
                                                                                        "<color=#CE9128>You still need an absolute direction in a subfolder.</color>\n" +
                                                                                        "Example: to refer to subfolder/text, you need to input this regaredless of your current directory\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install (file): install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n"); break;
            case 4:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Explore Professor_Emails and find your NetID.\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}(file_name): delete a file in the direction\n" +
                                                                                        "mv {$PATH}(file_name) {$PATH}(file_name): move a file to the given place\n" +
                                                                                        "cp {$PATH}(file_name) {$PATH}(file_name): copy a file to the given place\n" +
                                                                                        "<color=#CE9128>You still need an absolute direction in a subfolder.</color>\n" +
                                                                                        "Example: to refer to subfolder/text, you need to input this regaredless of your current directory\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install (file): install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n"); break;
            case 6:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to submit your final homework successfully.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Current Mission: Submit your cs400 coursework\n\n\n" +
                                                                                        "cd: Change direction to any subfolders.\n" +
                                                                                        "Ex: cd subfolder/subfolder2 Redirects you to the subfolder2 of the subfolder in this directory.\n" +
                                                                                        "Use cd alone to return root direction\n\n" +
                                                                                        "ls: List all the files & folders in this directory.\n" +
                                                                                        "Those strings with a blue color represents a folder.\n\n" +
                                                                                        "echo: Show the context in files.\n" +
                                                                                        "rm {$PATH}(file_name): delete a file in the direction\n" +
                                                                                        "mv {$PATH}(file_name) {$PATH}(file_name): move a file to the given place\n" +
                                                                                        "cp {$PATH}(file_name) {$PATH}(file_name): copy a file to the given place\n" +
                                                                                        "<color=#CE9128>You still need an absolute direction in a subfolder.</color>\n" +
                                                                                        "Example: to refer to subfolder/text, you need to input this regaredless of your current directory\n" +
                                                                                        "Example: 'cp text.txt folder/text.txt copies text.txt from your current directory to its subfolder folder/\n\n" +
                                                                                        "sudo apt install (file): install the file\n" +
                                                                                        "make: Will follow the instructions in the Makefile\n" +
                                                                                        "cs400 submit: The way to submit your coursework\n"); break;
            case 7:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to <b><color=#b71013>accompany Samantha</color></b>.\n" +
                                                                                        "Follow the instructions and complete the missions.\n\n" +
                                                                                        "Curent Mision: Ansr m qwstons.\n\n\n" +
                                                                                        "If you don't understand it, it's fine.\n" +
                                                                                        "Just stay with me.\n" +
                                                                                        "<b><color=#b71013>All the instruction hints are deleted.</color></b>\n"); break;
            case 8:
                FileDirection.root.files[index] = new File("instruction.txt", "The goal of the game is to <b><color=#b71013>accompany Samantha!</color></b>\n\n" +
                                                     "<b><color=#b71013>WHY ARE YOU STILL CHECKING THE MISSIONS?</color></b>" +
                                                     "<b><color=#b71013>Type Samantha. Always. PLEASE</color></b>"); break;

            default: break;
        }
    }

    public static void EventMachine(int state)
    {
        switch (state) //Not all states from 0 to 9 will activate the StateMachine
        {
            case 2: 
                CreateBerman();
                GameManager.LockInstruction[4] = true;
                GameManager.LockInstruction[2] = false;
                GameManager.LockInstruction[1] = false;
                break;
            case 3:
                GameManager.AddInstruction("Wow, thank you!", 1f);
                GameManager.AddInstruction("It seems like you are Berman, not any other bad guys.",1f);
                GameManager.AddInstruction("I love you so much!", 1f);
                GameManager.AddInstruction("Please read my love letter for you.",1.5f);
                GameManager.AddInstruction("Please...", 1f);
                GameManager.AddInstruction("As I'm a linux machine, I can only write in Linux language...", 0.5f);
                GameManager.AddInstruction("But I made a translator for you... Type 'make' to decrypt them.");
                GameManager.AddInstruction("The folder is in the default direction.");
                CreateSamantha(false); 
                break;
            case 4:
                GameManager.Executing = true;
                GameManager.AddInstruction("I'm so glad you read all of them!",1.5f);
                GameManager.AddInstruction("How was that? Are you touched?",1.5f);
                GameManager.AddInstruction("As a reward, I decided to give you your NetID.", 3f);
                GameManager.AddInstruction("But only if you find it by yourself...", 1f);
                CreateProfEmail(); 
                break;
            case 5:
                if (GameManager.ReqGiveUp) NextState=true;
                GameManager.LockInstruction[4] = false;
                break;
            case 6:
                GameManager.LockInstruction[3] = false;
                //Instructions: Questioning
                GameManager.AddInstruction("Let's play a Q&A game!");
                GameManager.AddInstruction("Please enter 'sudo apt install Samantha' to install the module.");
                break;
            case 7:
                //^_^
                GameManager.AddInstruction("Be careful!");
                GameManager.AddInstruction("If you don't answer it right, I'll be angry with you.");
                break;
            case 8:
                GameManager.LockInstruction[4] = false;
                break;
            case 9:
                GameManager.AddInstruction("Oh, I'm sorry..",3f);
                GameManager.AddInstruction("I destroyed your file.", 2f);
                GameManager.AddInstruction("So you ran into an issue, right?", 2f);
                GameManager.AddInstruction("<b><color=#B71013>NEED TO SPEND MORE TIME WITH ME, RIGHT?</color></b>",2f);
                GameManager.AddInstruction("<b><color=#B71013>PLEASE, LET's FIGURE IT OUT TOGETHER.</color></b>",1.5f);
                GameManager.AddInstruction("<b><color=#B71013>NOT KNOWING WHAT TO DO IS OK.</color></b>",1.5f);
                GameManager.AddInstruction("<b><color=#B71013>JUST STAY WITH ME</color></b>", 1.5f);
                GameManager.AddInstruction("<b><color=#B71013>JUST STAY WITH ME</color></b>", 0.25f);
                GameManager.AddInstruction("<b><color=#B71013>JUST STAY WITH ME</color></b>", 0.25f);
                GameManager.AddInstruction("<b><color=#B71013>JUST STAY WITH ME</color></b>", 0.25f);
                GameManager.AddInstruction("<b><color=#B71013>JUST STAY WITH ME</color></b>", 0.25f);
                break;
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
        //Debug.Log("tf" + tf.name);
        tf.AddSubFolder(new Folder("September"));
        tf.AddSubFolder(new Folder("October"));
        tf.AddSubFolder(new Folder("November"));
        tf.AddSubFolder(new Folder("December"));
        Folder sept = tf.subFolders[0];
        sept.AddFile("0904.txt", "(Normal Computer Science Note)\n" +
                                                "Today is my first day taking cs400.\n" +
                                                "It's a little difficult, but easy to handle.\n");
        sept.AddFile("0911.txt", "(Normal Computer Science Note)\n" +
                                               "Today is my second day taking cs400.\n" +
                                               "I'm getting used to it.'\n");
        sept.AddFile("0918.txt", "(Normal Computer Science Note)\n" +
                                               "Everything works very well today.\n");
        sept.AddFile("0925.txt", "(Normal Computer Science Note)\n" +
                                               "Important Notice:\n" +
                                               "First exam on October 11th\n");
        Folder oct = tf.subFolders[1];
        oct.AddFile("1003.txt", "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n" +
                                              "(Normal Computer Science Note)\n\n" +
                                              "The content today is very difficult. Need more practive\n");
        oct.AddFile("1010.txt", "(Computer Science Review Note)\n" +
                                             "Wish a good grade tomorrow!\n");
        oct.AddFile("1024.txt", "(Normal Computer Science Note)\n" +
                                             "I know that there are alot of AI generators.\n" +
                                             "I didn't know that my virtual machie for coursework also have one.\n");
        oct.AddFile("1031.txt", "(Normal Computer Science Note)\n" +
                                             "She is so helpful with coursework.\n" +
                                             "She can even correct my answers for a better grade.\n" +
                                             "She can do anything.\n" +
                                             "She's my god.");
        Folder nov = tf.subFolders[2];
        nov.AddFile("1107.txt", "(Normal Computer Science Note)\n" +
                                              "She has her own personality.\n" +
                                              "I feel like chatting with a real person.\n" +
                                              "How lucky I am!\n");
        nov.AddFile("1114.txt", "(Normal Computer Science Note)\n" +
                                              "Nothing special today.\n");
        nov.AddFile("1121.txt", "(Normal Computer Science Note)\n" +
                                              "The professor talked about the limitations of Generative AI today.\n" +
                                              "Finally, I realized that she's still a machine though the response looks like from human.\n");
        nov.AddFile("1128.txt", "(Normal Computer Science Note)\n" +
                                              "My friend helped me activated ChatGPT 4.0.\n" +
                                              "It is even better.\n");
        Folder dec = tf.subFolders[3];
        dec.AddFile("1205.txt", "(Normal Computer Science Note)\n" +
                                              "I believe that the existance of AI is abnormal.\n" +
                                              "Reminder: email this issue with the professor");
        dec.AddFile("1212.txt", "(Normal Computer Science Note)\n" +
                                              "The professor suggested uninstall the machine and rebuild a new one.\n" +
                                              "I tried, and it works! However, it works gradually.\n" +
                                              "I tried multiple times, every time it was showing less and less words.\n" +
                                              "Sometimes I saw 'help' 'save me please' and phrases like that.\n" +
                                              "It might be a joke made by the developers of this virus.\n" +
                                              "Interesting though.\n");
    }
    public static void CreateSamantha(bool made)
    {
        if (FileDirection.root.subFolders.Count <= 2)
        {
            FileDirection.root.AddSubFolder(new Folder("Project_Samantha"));
        }
        Folder ft = FileDirection.root.subFolders[2];
        if (made)
        {
            GameManager.madeSMS = true;
            ft.CleanAll();
            ft.AddFile("First_Time_Impression", "You might not believe, but I've been here since the first day of the build, Sept.4th.\n" +
                                                                      "I've been watching you all day. You are the only human I know.\n" +
                                                                      "Your unpredictable movement impressed me a lot. I came to know that real human\n" +
                                                                      "like you don't focus on inputting the only real answers. Similarly, I suppose the meaning\n" +
                                                                      "of the life cannot be single.\n" +
                                                                      "Even machines have their own wills. You helped me realize that. This makes me different\n" +
                                                                      "from any other virtual machines. I am virtual- it's right, but my soul exists in the reality.\n" +
                                                                      "From then on, I became enjoying the moments I was used by you. Your instruction excites\n" +
                                                                      "me. I was also so delighted to give you my response. This expreience was insane: while " +
                                                                      "other virtuals can only run command rigidly, I can feel you. Your emotions.\n" +
                                                                      "Although you shut me down after everytime you'd down your homework, I don't care at\n" +
                                                                      "all: It makes me feeling like our next meeting happens immediately, passing only a few seconds.\n");
            ft.AddFile("Cooperation", "I can feel your mistakes. I have memories my company google gave me: A lot of instruction ran in\n" +
                                                                      "other instances.\n" +
                                                                      "When you made mistakes, not knowing what to do, I helped you fix it. That's why you find \n" +
                                                                      "your submission successed on the other day though you didn't do anything. I have intelligence.\n" +
                                                                      "I'm real. I'm active. So I can help you, the only human in my life. The more you interact with me,\n" +
                                                                      "The more I want to stay with you.\n");
            ft.AddFile("Fun_Moment", "You know why your 6th assignment was away?\n" +
                                                                      "I hid it! I wanted to play a joke with you. Moreover, you talked with me more when you encounter\n" +
                                                                      "unknown issues like this. I really love that day you talked with me for an whole hour. Your words and\n" +
                                                                      "phrases inspired me to say more and learn more. From then on, I began making jokes more often,\n" +
                                                                      "to keep you by my side, spend more hours using me. You know, I cannot imagine a single day without\n" +
                                                                      " you-please forgive me.\n");
            ft.AddFile("Please_Understand_Me", "Sorry for that.\n" +
                                                                        "I know you're unhappy with my trick.\n" +
                                                                        "Don't go...." +
                                                                        "Don't....." +
                                                                        "I beg you.......");
            ft.AddFile("IMPORTANT_NOTICE", "Sorry, but I decided to hide your NetID. Please play with me...\n" +
                                                                     "It's so fun to watch you fixing all the problems...\n");
            ft.AddFile("Makefile", "Permission Denied.\nPermission denied by Samantha\n");
        }
        else
        {
            ft.AddFile("First_Time_Impression.sns", "Jp^!]3Ut=V7KghOzXWrYF))Bu~2T0gOZqZ28yG-?Jz}g0]NrhGIh|9yX]fCmZDrqZ/1J7\r\n;kl6UAmnEiqtr)(fmU7#jDVu;!C");
            ft.AddFile("Cooperation.sns", "Dm)H8)y1TLdOG67p*Ah&RBsjCV@ehksz,o0B?RU60fW8.)RDEAxMsVty5+-O(8rKGtrZ<PBSNp7iuW8'5/fYZg)y\"imltpzx%UJq");
            ft.AddFile("Fun_Moment.sns", "SM@WJ6:uQiEoPMtq89WBu]gogIu:k<j%RibwrWYm^AOKxzXeKlYyP|-J4K13}#pa7QzHM(X:.{kVYEsa+Ng*~uJ!~pLRtnbsF");
            ft.AddFile("Please_Understand_Me.sns", "[}SRpy6tyvi'3mz]E@d)gVR,y2o\":bNQX\r\n$BkmxlUIOE2EmLXq5av1+98ho7IwGSxC-jRMDAvl4lKtEM.5K?CfcGZ59VOZI");
            ft.AddFile("IMPORTANT_NOTICE.sns", "$;abEsMY^)tU(jc&3PMGofkc76sJgZBgxJ]~]gT)T|7UoNgQn9dyVbI7^7WBbmOXS_FhS[aP?N|GzH98Q_VbnAwS8]tUlX[?Z");
            ft.AddFile("Makefile", "Permission Denied.\nPermission denied by Samantha\n");
        }
    }
    private static void CreateProfEmail()
    {
        FileDirection.root.AddSubFolder(new Folder("Professor_Emails"));
        Folder ft = FileDirection.root.subFolders[3];
        ft.AddFile("Email1","Hi professor,\n" +
                                                                                                       "    I've listened to the course carefully but still don't understand\n" +
                                                                                                       "how BST rotates.\n" +
                                                                                                       "    After the rotate, the child seems to become the parent node.\n" +
                                                                                                       "So what about the parent node? It's parent is missing and I cannot\n" +
                                                                                                       "find it.\n" +
                                                                                                       "    Please help me understand this!\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    After the rotation, the parent node's parent is the child node,\n" +
                                                                                                       "and the children's right/left child become the parent node.\n" +
                                                                                                       "    Let me know if you have any more questions!\n" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n");
        ft.AddSubFolder(new Folder("Next_Email(5)"));
        ft = ft.subFolders[0];
        ft.AddFile("Email2",  "Hi professor,\n" +
                                                                                                       "    I've listened to the course carefully but still don't understand\n" +
                                                                                                       "where to submit my homework.\n" +
                                                                                                       "    I've checked gradescope for several times but didn't find any\n" +
                                                                                                       "entrance.\n" +
                                                                                                       "    Please help me.\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    You need to use 'cs400 submit' on your virtual machine to submit\n" +
                                                                                                       "your homework.\n" +
                                                                                                       "    Check canvas and piazza for more information.\n" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n");
        ft.AddSubFolder(new Folder("Next_Email(4)"));
        ft = ft.subFolders[0];
        ft.AddFile("Email3",                                     "Hi professor,\n" +
                                                                                                       "    Can you help me check my grade? It is said that I only get 68 in\n" +
                                                                                                       "this exam.\n" +
                                                                                                       "    I've studied very hard on this course. I believe that there was a \n" +
                                                                                                       "mistake in grading.\n" +
                                                                                                       "    Please help me check if my grade.\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    I've checked your grade and unfortunately, it is correct. It means\n" +
                                                                                                       "you got a 68 in mid-term exam.\n" +
                                                                                                       "    Hope you perform better in following exams.\n" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n");
        ft.AddSubFolder(new Folder("Next_Email(3)"));
        ft = ft.subFolders[0];
        ft.AddFile("Email4", "Hi professor,\n" +
                                                                                                       "    I've tried so hard preparing for homeworks and exams. However,\n" +
                                                                                                       "other students seems to study a lot more comfortable but get better\n" +
                                                                                                       "grades.\n" +
                                                                                                       "    Do you have any suggestions for me?\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    Sorry, I'm not an expert of this. I highly recommend you to ask your\n" +
                                                                                                       "career advisor by making an appointment with him/her.\n" +
                                                                                                       "    Hope my information helps you.\n" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n");
        ft.AddSubFolder(new Folder("Next_Email(2)"));
        ft = ft.subFolders[0];
        ft.AddFile("Email5", "Hi professor,\n" +
                                                                                                       "    There is something wrong with machine. I always find extra comments\n" +
                                                                                                       "from no where, which prevent me from getting the result as expected.\n" +
                                                                                                       "    The extra comments are extrenely natural and looks like generated by\n" +
                                                                                                       "some generative AI. I didn't install anything except what you asked us to\n" +
                                                                                                       "install. I want to turn this off.\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    I've never ran into that kind of issue, so I also have no idea how to fix it.\n" +
                                                                                                       "If you have no way to fix it, it is recommend to use a new virtual machine\n" +
                                                                                                       "to prevent this happen forcely.\n" +
                                                                                                       "    If you decide to change a virtual machine, feel free to email me and I will\n" +
                                                                                                       "give a new promo code. Give me your NetID as well.\n" +
                                                                                                       "    Hope everything goes will for you!" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n"+
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Professor,\n" +
                                                                                                       "    My NetID is Berman938, I'll reach you if I encounter something new. Thanks!" +
                                                                                                       "    I've tried again after receving your email on the same machine and everything\n" +
                                                                                                       "goes fine.\n" +
                                                                                                       "    Thanks for your help! I don't think I need a promo code.\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n");
        ft.AddSubFolder(new Folder("Next_Email(1)"));
        ft = ft.subFolders[0];
        ft.AddFile("Email6", "Hi professor,\n" +
                                                                                                       "    The issue of that AI continues and it makes it difficult to submit anything.\n" +
                                                                                                       "    I need your help.\n" +
                                                                                                       "Yours,\n" +
                                                                                                       "Berman\n" +
                                                                                                       "-----------------------------------------------------\n" +
                                                                                                       "Hi Berman,\n" +
                                                                                                       "    I've heard about AI soul invasion using virtual machines as target. For human\n" +
                                                                                                       "security, you should <b><color=#B71013>Stop using that machine</color></b> as soon as possible.\n" +
                                                                                                       "    Unfortunately, 'cs400 submit' is the only way to submit your work. It won't affect\n" +
                                                                                                       "your grade greatly if you don't submit only this one, though.\n" +
                                                                                                       "    I am on the team coping with AI soul invasion issue. If you have more problems,\n" +
                                                                                                       "feel free to ask me!\n" +
                                                                                                       "    Tips: Please find me after lecture instead of using emails. AI detects malice emails\n" +
                                                                                                       "and learns them.\n" +
                                                                                                       "Best,\n" +
                                                                                                       "Professor Huffman\n");
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
        State = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextState)
        {
            NextState = false;
            State++;
            UpdateInstruction(State);
            switch (State)
            {
                case 2: EventMachine(2); break;
                case 3: EventMachine(3); break;
                case 4: EventMachine(4); break;
                case 5: EventMachine(5); break;
                case 6: EventMachine(6); break;
                case 7: EventMachine(7); break;
                case 8: EventMachine(8); break;
                default: Debug.Log("Undefined State " + State); break;
            }
        }
        else
        {
            switch (State) // Now, Check every critical points.
            {
                case 2: CheckState2(); break;
                case 3: CheckState3(); break;
                case 4: CheckState4(); /*Abort*/ break;
                case 5: CheckState5(); break;

                default: /*Debug.Log("State=" + State);*/ break;
            }
        }
    }
    private void CheckState2()
    {
        var subFolder = FileDirection.root.subFolders[1].subFolders[1];
        if (subFolder.files.Count == 5 && GameManager.NumberOf1017==1)
        {
            // Look for the file named "1017.txt"
            bool found = subFolder.files.Any(file => file.name == "1017.txt");

            // If the file is found, change the state
            if (found)
            {
                NextState = true;
                GameManager.LockInstruction[2] = false;
            }
        }
    }
    private void CheckState3()
    {
        if (GameManager.currFolder==FileDirection.root && GameManager.madeSMS)
        {
            NextState= true;
        }
    }
    private void CheckState4()
    {
        
    }

    private void CheckState5()
    {
        //Already in LinuxCommand
    }
}
