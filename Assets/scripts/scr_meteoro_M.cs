using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_meteoro_M : MonoBehaviour
{
    public float velocidade, vida, dano;
    private float velocidade_rotacao;
    private int sinal;
    private Camera cam;

    private Vector3 direcao;

    void Start()
    {
        velocidade_rotacao = Random.Range(30f, 40f);
        velocidade = 2.3f;
        direcao = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), transform.position.z).normalized;
        sinal = Random.Range(0, 2) == 0 ? -1 : 1;
        cam = Camera.main;
    }

    void Update()
    {
        if (vida <= 0){
            Destroy(gameObject);
        }

        float tamanho_vertical = cam.orthographicSize;
        float tamanho_horizontal = tamanho_vertical * cam.aspect;
        Vector3 nova_posicao = transform.position;

        if (transform.position.x > tamanho_horizontal)
        {
            nova_posicao.x = -tamanho_horizontal;
        }
        else if (transform.position.x < -tamanho_horizontal)
        {
            nova_posicao.x = tamanho_horizontal;
        }

        if (transform.position.y > tamanho_vertical)
        {
            nova_posicao.y = -tamanho_vertical;
        }
        else if (transform.position.y < -tamanho_vertical)
        {
            nova_posicao.y = tamanho_vertical;
        }

        if (transform.position != nova_posicao)
        {
            transform.position = nova_posicao;
        }

        transform.position += Time.deltaTime * velocidade * direcao;
        transform.Rotate(0, 0, sinal * velocidade_rotacao * Time.deltaTime);
    }
}

