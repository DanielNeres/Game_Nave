using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bala : MonoBehaviour
{
    public float velocidade, dano;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);

        float tamanho_vertical = cam.orthographicSize;
        float tamanho_horizontal = tamanho_vertical * cam.aspect;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("meteoro"))
        {
            Debug.Log("Colisão com inimigo!");
            other.GetComponent<scr_meteoro_M>().vida -= dano;
            Destroy(gameObject);
        }
    }
}
