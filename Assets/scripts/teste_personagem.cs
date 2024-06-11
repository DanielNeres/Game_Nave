using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class teste_personagem : MonoBehaviour
{
    public float velocidade, pulo, velocidade_gancho;
    private bool estar_no_chao, gancho;
    private Vector3 posicao_apoio;
    private Rigidbody2D rigidi_personagem;

    
    void Start()
    {
        estar_no_chao = true;
        rigidi_personagem = GetComponent<Rigidbody2D>();
        gancho = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gancho){
            if (Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(velocidade * Time.deltaTime * transform.right);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(-velocidade * Time.deltaTime * transform.right);
            }
            if (Input.GetKeyDown(KeyCode.Space)){
                rigidi_personagem.AddForce(new Vector2(0, pulo), ForceMode2D.Impulse);
                estar_no_chao = false;
            }

            if (!estar_no_chao){
                if (Input.GetKeyDown("f")){
                    posicao_apoio = GameObject.FindGameObjectWithTag("apoio").transform.position;
                    Debug.Log("quadrado a x = " + posicao_apoio.x + " e y = " + posicao_apoio.y);
                    gancho = true;
                }
            }
        }else{
            transform.position = Vector3.MoveTowards(transform.position, posicao_apoio, velocidade_gancho * Time.deltaTime);
        }

    }

    private Vector3 objeto_mais_proximo()
    {
        Vector3 posicao_mais_poxima = Vector3.zero;
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("apoio");
        float menorDistancia = Mathf.Infinity;
        if (objetos != null){
            foreach (GameObject objeto in objetos){
                float distancia = Vector3.Distance(gameObject.transform.position, objeto.transform.position);
                if (distancia < menorDistancia){
                    menorDistancia = distancia;
                    posicao_mais_poxima = objeto.transform.position;
                }
            }
        } else if (objetos == null){
            return gameObject.transform.position;
        }
        return posicao_mais_poxima;
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("chao"))
        {
            estar_no_chao = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("apoio"))
        {
            gancho = false;
        }
    }

}


