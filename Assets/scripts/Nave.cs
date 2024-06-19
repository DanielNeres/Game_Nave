using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;


public class Nave : MonoBehaviour
{
    public float velocidade, velocidade_rotacao, taxa_de_tiro, tempo_de_espera, vida, tempo_melhoria_projetil, tempo_imunidade;
    private float tamanho_vertical, tamanho_horizontal, tempo_melhoria_projetil_ativa, tempo_imunidade_ativo;
    public Animator animacao;
    private Camera cam;
    public GameObject bala, canva, escudo;
    public AudioSource audio_projetil, audio_hit, audio_melhoria;
    public bool escudo_ativo;

    void Start(){
        cam = Camera.main;
        animacao = GetComponent<Animator>();
        tempo_de_espera = 0;
        tempo_imunidade_ativo = 0;
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

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color cor = spriteRenderer.color;
        if (tempo_imunidade_ativo > Time.time) {
            
            float pingPong = Mathf.PingPong(Time.time * 2, 1);
            cor.a = pingPong;
            
            spriteRenderer.color = cor;
        } else{
            cor.a = 1;
            spriteRenderer.color = cor;
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
            audio_projetil.Play();
            tempo_de_espera = Time.time + taxa_de_tiro;
            if(Time.time > tempo_melhoria_projetil_ativa){
                bala.transform.localScale = new Vector3(1, 1, 0);
                bala.GetComponent<scr_bala>().dano = 1;
                Instantiate(bala, transform.position, transform.rotation);
            } else {
                Instantiate(bala, transform.position, transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.CompareTag("meteoro")){
            if (tempo_imunidade_ativo < Time.time){
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
                tempo_imunidade_ativo = tempo_imunidade + Time.time;
            }

        } else if (other.gameObject.CompareTag("escudo")){
            audio_melhoria.Play();
            escudo_ativo = true;
            escudo.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(other.gameObject);

        } else if (other.gameObject.CompareTag("melhoria_projetil")){
            audio_melhoria.Play();
            tempo_melhoria_projetil_ativa = Time.time + tempo_melhoria_projetil; 
            bala.transform.localScale = new Vector3(2, 2, 0);
            bala.GetComponent<scr_bala>().dano = 2;
            Destroy(other.gameObject);
        }
    }
}
