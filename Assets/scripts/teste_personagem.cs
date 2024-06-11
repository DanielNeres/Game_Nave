using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste_personagem : MonoBehaviour
{
    public float velocidade, pulo;
    private bool estar_no_chao;
    private Vector3 posicao_apoio;
    private Rigidbody2D rigidi_personagem;

    
    void Start()
    {
        estar_no_chao = true;
        rigidi_personagem = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(velocidade * Time.deltaTime * transform.right);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(velocidade * Time.deltaTime * transform.right);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            rigidi_personagem.AddForce(new Vector2(0, pulo), ForceMode2D.Impulse);
        }

        if (!estar_no_chao){
            if (Input.GetKeyDown("f")){
                posicao_apoio = GameObject.FindGameObjectWithTag("apoio").transform.position;
                Debug.Log("quadrado a x = " + posicao_apoio.x + " e y = " + posicao_apoio.y);
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, posicao_apoio, velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("chao"))
        {
            estar_no_chao = true;
            Debug.Log("estou no chao");
        }
    }
}
