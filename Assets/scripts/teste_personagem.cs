using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste_personagem : MonoBehaviour
{
    public float velocidade, pulo;
    private bool estar_no_chao;
    private Vector3 posicao_apoio;
    void Start()
    {
        estar_no_chao = true;
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
            transform.Translate(pulo * Time.deltaTime * transform.up);
        }

        if (!estar_no_chao){
            if (Input.GetKeyDown("f")){
                posicao_apoio = GameObject.FindGameObjectWithTag("apoio").transform.position;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, posicao_apoio, velocidade * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estar_no_chao = false;
        }
    }
}
