using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_meteoro_P : MonoBehaviour
{
    private scr_meteoro_padrao meteoro;

    void Start()
    {
        meteoro = gameObject.AddComponent<scr_meteoro_padrao>();
        
        if (meteoro != null)
        {
            meteoro.Meteoro_padrao = gameObject;
            meteoro.velocidade = 1.4f;
            meteoro.dano = 1;
            meteoro.vida = 2;
            meteoro.Inicializar();
        }
        else
        {
            Debug.LogError("scr_meteoro_padrao não encontrado no GameObject.");
        }
    }

    void Update()
    {
        meteoro.Estado_padrao();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bala"))
        {
            Debug.Log("Colisão com inimigo!");
            meteoro.vida -= other.GetComponent<scr_bala>().dano;
            Destroy(other.gameObject);
            if (meteoro.vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
