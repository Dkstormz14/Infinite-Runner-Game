using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputManager : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    float threshHori = 0.25f;

    [Range(0, 1)]
    [SerializeField]
    float threshVert = 0.25f;

    float targetPixelsHori;
    float targetPixelsVert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
