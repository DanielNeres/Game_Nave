using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidade, velocidade_rotacao;
    public Animator animacao;
    private Camera cam;

    void Start(){
        cam = Camera.main;
        animacao = GetComponent<Animator>();
    }

    void Update(){
        float tamanho_vertical = cam.orthographicSize;
        float tamanho_horizontal = tamanho_vertical * cam.aspect;
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
        if(Input.GetKeyDown(KeyCode.Space)){

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("meteoro"))
        {
            Debug.Log("Colisão com inimigo!");
        }
    }
}
