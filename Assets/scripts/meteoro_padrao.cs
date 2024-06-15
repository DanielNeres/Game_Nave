using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_meteoro_padrao : MonoBehaviour
{
    public float velocidade, vida, dano;
    private float velocidade_rotacao;
    private int sinal;
    private Camera cam;
    private Vector3 direcao;
    public GameObject Meteoro_padrao;

    void Start()
    {
        Inicializar();
    }

    public void Inicializar()
    {
        velocidade_rotacao = Random.Range(30f, 40f);
        direcao = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), transform.position.z).normalized;
        sinal = Random.Range(0, 2) == 0 ? -1 : 1;
        cam = Camera.main;
    }

    public void Estado_padrao()
    {
        

        float tamanho_vertical = cam.orthographicSize;
        float tamanho_horizontal = tamanho_vertical * cam.aspect;
        Vector3 nova_posicao = Meteoro_padrao.transform.position;

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

        if (Meteoro_padrao.transform.position != nova_posicao)
        {
            Meteoro_padrao.transform.position = nova_posicao;
        }

        Meteoro_padrao.transform.position += Time.deltaTime * velocidade * direcao;
        Meteoro_padrao.transform.Rotate(0, 0, sinal * velocidade_rotacao * Time.deltaTime);
    }
}
