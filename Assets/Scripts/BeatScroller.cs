using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatScrollSpeed; // Speed at which beats scroll
    public bool hasStarted; // To track if scrolling has started

    // Start is called before the first frame update
    void Start()
    {
        // Initialize scroll speed if necessary
        beatScrollSpeed = beatScrollSpeed / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            // Scroll beats down
            transform.position -= new Vector3(0f, beatScrollSpeed * Time.deltaTime, 0f);
        }
    }

    // Method to start scrolling
    public void StartScrolling()
    {
        hasStarted = true;
    }

    // Method to stop scrolling
    public void StopScrolling()
    {
        hasStarted = false;
    }
}
