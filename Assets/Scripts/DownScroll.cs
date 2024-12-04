using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{

    public float beatTmepo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTmepo = beatTmepo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
                /*if(Input.anyKeyDown)
                {
                    hasStarted = true;
                }*/
        } else
        {
            transform.position -= new Vector3(0f, beatTmepo * Time.deltaTime, 0f);
        }
    }
}
