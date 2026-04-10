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
        Debug.Log("Clip: " + audioSource.clip);
        Debug.Log("Number of AudioSources found: " + gameObject.GetComponents<AudioSource>().Length);

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
        if (Input.GetKeyDown(KeyCode.A)) effects.Push("autumn");
        if (Input.GetKeyDown(KeyCode.B)) effects.Push("breath");
        if (Input.GetKeyDown(KeyCode.C)) effects.Push("cold");
        if (Input.GetKeyDown(KeyCode.D)) effects.Push("dusk");
        if (Input.GetKeyDown(KeyCode.E)) effects.Push("echo");
        if (Input.GetKeyDown(KeyCode.F)) effects.Push("fading");
        if (Input.GetKeyDown(KeyCode.G)) effects.Push("gentle");
        if (Input.GetKeyDown(KeyCode.H)) effects.Push("hollow");
        if (Input.GetKeyDown(KeyCode.I)) effects.Push("infinite");
        if (Input.GetKeyDown(KeyCode.J)) effects.Push("journey");
        if (Input.GetKeyDown(KeyCode.K)) effects.Push("kind");
        if (Input.GetKeyDown(KeyCode.L)) effects.Push("light");
        if (Input.GetKeyDown(KeyCode.M)) effects.Push("moonlit");
        if (Input.GetKeyDown(KeyCode.N)) effects.Push("night");
        if (Input.GetKeyDown(KeyCode.O)) effects.Push("ocean");
        if (Input.GetKeyDown(KeyCode.P)) effects.Push("pale");
        if (Input.GetKeyDown(KeyCode.Q)) effects.Push("quiet");
        if (Input.GetKeyDown(KeyCode.R)) effects.Push("rain");
        if (Input.GetKeyDown(KeyCode.S)) effects.Push("silence");
        if (Input.GetKeyDown(KeyCode.T)) effects.Push("twilight");
        if (Input.GetKeyDown(KeyCode.U)) effects.Push("undone");
        if (Input.GetKeyDown(KeyCode.V)) effects.Push("void");
        if (Input.GetKeyDown(KeyCode.W)) effects.Push("wandering");
        if (Input.GetKeyDown(KeyCode.X)) effects.Push("exile");
        if (Input.GetKeyDown(KeyCode.Y)) effects.Push("yearning");
        if (Input.GetKeyDown(KeyCode.Z)) effects.Push("zenith");

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
