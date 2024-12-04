using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;    // Flag to check if note can be pressed
    public bool isHit;           // Flag to track if the note has been hit
    public KeyCode keyToPress;   // The key assigned to this note
    public GameObject hitEffect, goodEffect, greatEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;  // Initialize as not hit
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed && !isHit)  // Check if the note can be pressed and hasn't been hit yet
            {
                isHit = true;  // Mark the note as hit
                gameObject.SetActive(false);  // Deactivate the note (can also use object pooling)
                GameManager.instance.NoteHit();  // Trigger the NoteHit event
                if(Mathf.Abs(transform.position.y) > 0.25){
                    Debug.Log("Ok");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect);
                } else if(Mathf.Abs(transform.position.y) > 0.1){
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect);
                } else if(Mathf.Abs(transform.position.y) > 0.05){
                    Debug.Log("Awesome!");
                    GameManager.instance.PerfectHit();
                    Instantiate(greatEffect);
                } else {
                    Debug.Log("Stellar!");
                    GameManager.instance.StellarHit();
                    Instantiate(perfectEffect);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator")){
            // Only allow the note to be pressed if it has entered the activator zone
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            // If the note exits the activator zone and it hasn't been hit yet, it's missed
            if (!isHit)
            {
                GameManager.instance.NoteMissed();  // Call the NoteMissed event
                Instantiate(missEffect);
                gameObject.SetActive(false);  // Deactivate the note
            }
            canBePressed = false;  // Reset the canBePressed flag
        }
    }
}
