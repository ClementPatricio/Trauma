using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheminey_Light : MonoBehaviour
{
    Light li;
    // Start is called before the first frame update
    void Start()
    {
        li = GameObject.Find("Cheminey_Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        li.intensity = 1.0f + 0.5f * Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup)); 
    }
}
