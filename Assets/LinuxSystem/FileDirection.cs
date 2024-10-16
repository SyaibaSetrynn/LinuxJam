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
