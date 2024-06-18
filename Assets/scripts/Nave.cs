using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float velocidade, velocidade_rotacao, taxa_de_tiro, tempo_de_espera, vida;
    private float tamanho_vertical, tamanho_horizontal;
    public Animator animacao;
    private Camera cam;
    public GameObject bala, canva, escudo;
    public AudioSource audio_projetil, audio_hit, audio_melhoria;
    public bool escudo_ativo;

    void Start(){
        cam = Camera.main;
        animacao = GetComponent<Animator>();
        tempo_de_espera = 0;
        escudo_ativo = false;
        tamanho_vertical = cam.orthographicSize;
        tamanho_horizontal = tamanho_vertical * cam.aspect;
    }

    void Update(){
        Vector3 nova_posicao = transform.position;

        if (transform.position.x > tamanho_horizontal){
            nova_posicao.x = -tamanho_horizontal;
        }
        else if (transform.position.x < -tamanho_horizontal){
            nova_posicao.x = tamanho_horizontal;
        }

        if (transform.position.y > tamanho_vertical){
            nova_posicao.y = -tamanho_vertical;
        }
        else if (transform.position.y < -tamanho_vertical){
            nova_posicao.y = tamanho_vertical;
        }

        if (transform.position != nova_posicao){
            transform.position = nova_posicao;
        }

        if (Input.GetKey("a")){
            transform.Rotate(0, 0, velocidade_rotacao * Time.deltaTime);
        }
        if (Input.GetKey("d")){
            transform.Rotate(0, 0, -velocidade_rotacao * Time.deltaTime);
        }
        if (Input.GetKey("w")){
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
            animacao.SetBool("andando", true);
        } else{
            animacao.SetBool("andando", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > tempo_de_espera){
            tempo_de_espera = Time.time + taxa_de_tiro;
            Instantiate(bala, transform.position, transform.rotation);
            audio_projetil.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.CompareTag("meteoro")){
            audio_hit.Play();
            if (escudo_ativo){
                escudo_ativo = false;
                escudo.GetComponent<SpriteRenderer>().enabled = false;
            } else{
                vida -= other.GetComponent<scr_meteoro_padrao>().dano;
            }
            if (vida <= 0){
                canva.SetActive(true);
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("escudo")){
            audio_melhoria.Play();
            escudo_ativo = true;
            escudo.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(other.gameObject);
        }
    }
}
