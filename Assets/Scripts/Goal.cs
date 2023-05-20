using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    
    
    public UnityEvent goal;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Send goal Event
        if (other.gameObject.CompareTag("Ball"))
        {
            goal.Invoke();
        }
    }
}
