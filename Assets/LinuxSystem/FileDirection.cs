using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class File
{
    public string name;
    public string content;
    public File(string name, string content)
    {
        this.name = name;
        this.content = content;       // Initialize the list of files
    }
}
public class Folder
{
    public string name;
    public List<Folder> subFolders;
    public List<File> files;

    public Folder()
    {
        this.name = "";
        this.subFolders = new List<Folder>();
        this.files = new List<File>();
    }

    public Folder(string name)
    {
        this.name = name;
        this.subFolders = new List<Folder>();
        this.files = new List<File>();
    }

    public void AddSubFolder(Folder subFolder)
    {
        subFolders.Add(subFolder);
    }

    public void AddFile(string name, string content)
    {
        files.Add(new File(name, content));
    }
}

public class FileDirection : MonoBehaviour
{
    public static Folder root=new Folder("");
    // Start is called before the first frame update
    public static void list(Folder currentFolder)
    {
        Debug.Log(GameManager.currFolder.files.Count);
        if (currentFolder == null)
        {
            GameManager.AddInstruction("***Directory not found***");
            return;
        }

        if (currentFolder.name == null)
        {
            GameManager.AddInstruction("***Directory not found***");
            return;
        }

        // Create output string (only show current folder contents, not recursive)
        string output = "";

        foreach (var folder in currentFolder.subFolders)
        {
            output += "<b><color=#569CD6>" + folder.name + "</color></b> ";  // Show subfolders (with a trailing slash)
        }

        foreach (var file in currentFolder.files)
        {
            output += file.name + "    ";  // Show files
        }

        // Output result to GameManager
        GameManager.AddInstruction($"{output.Trim()}");
    }
    public static void ChangeDirectory(string path)
    {
        // Navigate to root if path is empty or '/'
        if (string.IsNullOrEmpty(path) || path == "/")
        {
            GameManager.currFolder = root;
            GameManager.DefaultInstruction = "<color=#6BF263>User@MyDearestLinux:~$ </color>";
            return;
        }

        string[] pathParts = path.Split('/');
        Folder targetFolder = GameManager.currFolder;

        // Traverse through folder structure
        foreach (string part in pathParts)
        {
            if (string.IsNullOrEmpty(part)) continue;  // Skip empty parts

            Folder nextFolder = targetFolder.subFolders.Find(f => f.name == part);
            if (nextFolder==null)
            {
                GameManager.AddInstruction("***Directory not found***");
                return;
            }

            if (nextFolder.name == null)  // Folder not found
            {
                GameManager.AddInstruction("***Directory not found***");
                return;
            }

            targetFolder = nextFolder;
        }

        // Update current folder and construct the full path for prompt display
        GameManager.currFolder = targetFolder;
        string fullPath = GetFullPath(GameManager.currFolder);
        GameManager.DefaultInstruction = $"<color=#6BF263>User@MyDearestLinux:~/{fullPath}$ </color>";
    }

    // Helper function to construct the full path of the current folder
    private static string GetFullPath(Folder folder)
    {
        List<string> folderNames = new List<string>();

        // Traverse upwards from the current folder to root to get the full path
        Folder current = folder;
        while (current.name != root.name)
        {
            folderNames.Insert(0, current.name);
            Debug.Log(current.name);
            current = FindParentFolder(current, root);  // Helper to find parent folder
        }

        return string.Join("/", folderNames);
    }

    // Helper to find the parent folder of the current folder, starting from root
    private static Folder FindParentFolder(Folder folder, Folder current)
    {
        Debug.Log("Enter Function: folder=" + folder.name + ", current=" + current.name);
        foreach (var subFolder in current.subFolders)
        {
            if (subFolder.name == folder.name)
            {
                Debug.Log(folder.name + " " + subFolder.name);
                return current;
            }
        }
        foreach (var subFolder in current.subFolders)
        {
            Debug.Log(subFolder.name);
            var foundFolder = FindParentFolder(folder, subFolder);
            if (foundFolder != null)
                if (foundFolder.name!="")
                    return foundFolder;
        }
        return new Folder();  // Return an empty folder if not found
    }

    // Helper function to recursively find the folder based on the directory string
    private static Folder FindFolder(Folder currentFolder, string direct)
    {
        if (direct == "" || direct == currentFolder.name)
        {
            return currentFolder;
        }

        string[] pathParts = direct.Split('/');
        string nextFolderName = pathParts[0];
        string remainingPath = string.Join("/", pathParts, 1, pathParts.Length - 1);

        foreach (var subFolder in currentFolder.subFolders)
        {
            if (subFolder.name == nextFolderName)
            {
                return FindFolder(subFolder, remainingPath);
            }
        }

        return new Folder(); // Return an empty folder if not found
    }
    void Awake()
    {
        root.AddFile("instruction.txt", "This is the instruction");
        Debug.Log(root.files[0].name);
        //Construct Folders
        root.AddSubFolder(new Folder("P214.Integration"));
        root.subFolders[0].AddFile("submission.java",
                                                    "*****Premission Error*****\n" +
                                                    "You don't have permission to open this file.\n" +
                                                    "Error detail: Time period exceeded\n" +
                                                    "***************************\n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
