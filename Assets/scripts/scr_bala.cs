using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bala : MonoBehaviour
{
    public float velocidade, dano;
    private float tamanho_vertical, tamanho_horizontal;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        tamanho_vertical = cam.orthographicSize;
        tamanho_horizontal = tamanho_vertical * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);

        if (transform.position.x > tamanho_horizontal){
            Destroy(gameObject);
        }
        else if (transform.position.x < -tamanho_horizontal){
            Destroy(gameObject);
        }

        if (transform.position.y > tamanho_vertical){
            Destroy(gameObject);
        }
        else if (transform.position.y < -tamanho_vertical){
            Destroy(gameObject);
        }
    }

    
}
