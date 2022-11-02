using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    // "Initialize your first game character"-homework
    // Here I've defined my Character Name as a public string variable and my Game Level as a private int variable
    public string characterName = "Fox";
    private int characterLevel = 1;

    // Here I've created a string property, called "Info", where I'm calling my variables from.
    string Info => $"My character name is {characterName}\n                    Current Level is {characterLevel}";


    /// <summary>
    /// Here I'm declaring a method from the example in the book - The spacing is used to line up all the variables in the console 
    /// public void GenerateInfo()
    /// {
    /// Debug.Log($"Character: {characterName}\n                     Level: {characterLevel}");
    /// }
    /// </summary>
 

    /// <summary>
    /// Here I'm adding method parameters to my method
    /// public void GenerateInfo2(string name, int level)
    /// {
    /// Debug.LogFormat("Character: {0}\n                     Level: {1}", name, level);
    /// }
    /// </summary>



    // Specifying and using return values from the example in the book
    public int GenerateInfo3(string name, int level)
    {
        // Debug.LogFormat("Character: {0}\n                     Level: {1}", name, level);

        return level += 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Variables inside the method Start()
        int characterLevel = 99;
        int NextSkillLevel = GenerateInfo3("Fox", characterLevel);
        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateInfo3("Fox", characterLevel));

        // Here I'm calling my first method GenerateInfo
        // GenerateInfo();

        // Here I'm calling my second method GenerateInfo2
        // GenerateInfo2("Fox", characterLevel);

        // Here I'm calling my third method GenerateInfo3
        GenerateInfo3("Fox", characterLevel);


        // Here I'm calling my string "Info" from the Start() method using Debug.Log(), which will print the variables into the console when the game starts
        Debug.Log(Info);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
