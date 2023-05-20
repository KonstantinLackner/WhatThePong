using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    //Vars needed for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();

        //Voice commands for movement
        keyActs.Add("auffe", Up);
        keyActs.Add("owe", Up);
        keyActs.Add("up", Up);
        keyActs.Add("down", Down);
        keyActs.Add("ride", Right);
        keyActs.Add("write", Right);
        keyActs.Add("right", Right);
        keyActs.Add("rechts", Right);
        keyActs.Add("ume", Right);
        keyActs.Add("left", Left);
        keyActs.Add("links", Left);
        keyActs.Add("speed", ChangeSpeed);
        keyActs.Add("stop", Stop);
        keyActs.Add("stopp", Stop);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void Update() 
    {
        
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args) 
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }

    void Up() 
    {
        Vector2 movement = new Vector2(0.0f, 1.0f);
        rb.AddForce(movement * speed);
    }

    void Down() 
    {
        Vector2 movement = new Vector2(0.0f, -1.0f);
        rb.AddForce(movement * speed);
    }

    void Right() 
    {
        Vector2 movement = new Vector2(1.0f, 0.0f);
        rb.AddForce(movement * speed);
    }

    void Left() 
    {
        Vector2 movement = new Vector2(-1.0f, -1.0f);
        rb.AddForce(movement * speed);
    }

    void ChangeSpeed() 
    {
        speed+=20;
    }

    void Stop() 
    {
        rb.velocity = Vector2.zero;
    }
}
