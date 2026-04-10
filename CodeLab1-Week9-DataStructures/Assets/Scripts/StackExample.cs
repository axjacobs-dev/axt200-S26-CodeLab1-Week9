using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StackExample : MonoBehaviour
{
    //effects is an instance of the stack thing
    private Stack<string> effects = new Stack<string>();

    public Text display;
    public Text poemDisplay;
    private bool hasPlayed = false;
    private AudioSource audioSource;

    private float timer = 0;
    private float timePerTurn = 5;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 1f;
        Debug.Log("Audio source: " + audioSource);
        Debug.Log("Audio clip: " + audioSource.clip);

    }

    private void Update()
    {
        // If you press space, reload the scene.  This makes it easy to restart!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // // If a move takes more than 5 seconds, continue.
        //if (timer > timePerTurn) return;
        
        // Increase the timer.
        timer += Time.deltaTime;

        // If you press an alphabetical key, pushes that move into the stack.
        if (Input.GetKeyDown(KeyCode.A)) effects.Push("--");
        if (Input.GetKeyDown(KeyCode.B)) effects.Push("/");
        if (Input.GetKeyDown(KeyCode.C)) effects.Push("...");
        if (Input.GetKeyDown(KeyCode.D)) effects.Push("waste-");
        if (Input.GetKeyDown(KeyCode.E)) effects.Push("ok");
        if (Input.GetKeyDown(KeyCode.F)) effects.Push("}{");
        if (Input.GetKeyDown(KeyCode.G)) effects.Push("vvv");
        if (Input.GetKeyDown(KeyCode.H)) effects.Push("==");
        if (Input.GetKeyDown(KeyCode.I)) effects.Push("fin");
        if (Input.GetKeyDown(KeyCode.J)) effects.Push("we were");
        if (Input.GetKeyDown(KeyCode.K)) effects.Push("-kin-");
        if (Input.GetKeyDown(KeyCode.L)) effects.Push("light");
        if (Input.GetKeyDown(KeyCode.M)) effects.Push("mmmhmmm");
        if (Input.GetKeyDown(KeyCode.N)) effects.Push("edge");
        if (Input.GetKeyDown(KeyCode.O)) effects.Push("there");
        if (Input.GetKeyDown(KeyCode.P)) effects.Push("x");
        if (Input.GetKeyDown(KeyCode.Q)) effects.Push("*");
        if (Input.GetKeyDown(KeyCode.R)) effects.Push("---");
        if (Input.GetKeyDown(KeyCode.S)) effects.Push("shhh");
        if (Input.GetKeyDown(KeyCode.T)) effects.Push("twilight");
        if (Input.GetKeyDown(KeyCode.U)) effects.Push("a void");
        if (Input.GetKeyDown(KeyCode.V)) effects.Push("return");
        if (Input.GetKeyDown(KeyCode.W)) effects.Push("love,");
        if (Input.GetKeyDown(KeyCode.X)) effects.Push("here");
        if (Input.GetKeyDown(KeyCode.Y)) effects.Push("crave");
        if (Input.GetKeyDown(KeyCode.Z)) effects.Push("<<>>");

        // If the time is up, say that time is up and show the effects.
        if (timer >= timePerTurn)
        {
            display.text = "You have written the world's last poem.";
            ShowCardStack();

            if (!hasPlayed)
            {
                Debug.Log("playing clip");
                PlaySound();
                hasPlayed = true;
            }
            return;
        }
        else
        {
            // Display the timer
            display.text = (timePerTurn - timer).ToString("F1");
        }

        if (Input.GetMouseButtonDown(0))
        {
            ThrowException();
        }
    }

    private void ShowCardStack()
    {
        
        // While there are effects in the stack, pop them out and show them.
        while (effects.Count > 0)
        {
            poemDisplay.text += "\n" + effects.Pop();
        }
    }

    private void PlaySound()
    {
        audioSource.Play(); 
    }
    
    void ThrowException()
    {
        throw new NotImplementedException();
    }
}
