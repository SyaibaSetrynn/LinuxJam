using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public struct File
{
    public string name;
    public string content;
    public File(string name, string content)
    {
        this.name = name;
        this.content = content;       // Initialize the list of files
    }
}
public struct Folder
{
    public string name;                    // Name of the folder
    public List<Folder> subFolders;        // A list of subfolders within this folder
    public List<File> files;             // A list of files within this folder
    // Constructor to initialize folder with its name
    public Folder(string name)
    {
        this.name = name;
        this.subFolders = new List<Folder>();   // Initialize the list of subfolders
        this.files = new List<File>();        // Initialize the list of files
    }
    // Method to add a subfolder to this folder
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

        if (currentFolder.name == null)
        {
            GameManager.AddInstruction("***Directory not found***");
            return;
        }

        // Create output string (only show current folder contents, not recursive)
        string output = "";

        foreach (var folder in currentFolder.subFolders)
        {
            output += "["+folder.name + "]  ";  // Show subfolders (with a trailing slash)
        }

        foreach (var file in currentFolder.files)
        {
            output += file.name + "  ";  // Show files
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
            current = FindParentFolder(current, root);  // Helper to find parent folder
        }

        return string.Join("/", folderNames);
    }

    // Helper to find the parent folder of the current folder, starting from root
    private static Folder FindParentFolder(Folder folder, Folder current)
    {
        foreach (var subFolder in current.subFolders)
        {
            if (subFolder.name == folder.name)
                return current;

            var foundFolder = FindParentFolder(folder, subFolder);
            if (foundFolder.name != null)
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
    void Start()
    {
        root.AddFile("Instruction.txt", "This is the instruction");
        //Construct Folders
        root.AddSubFolder(new Folder("LastProject"));
        root.subFolders[0].AddSubFolder(new Folder("Handout"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
