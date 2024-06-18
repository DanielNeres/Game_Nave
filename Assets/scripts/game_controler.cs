using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controler : MonoBehaviour
{
    private Camera cam;
    private float tamanho_vertical, tamanho_horizontal;    
    void Start()
    {
        cam = Camera.main;
        tamanho_vertical = cam.orthographicSize;
        tamanho_horizontal = tamanho_vertical * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
