using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_meteoro_G : MonoBehaviour
{
    private scr_meteoro_padrao meteoro;

    void Start()
    {
        meteoro = gameObject.AddComponent<scr_meteoro_padrao>();
        
        if (meteoro != null)
        {
            meteoro.Meteoro_padrao = gameObject;
            meteoro.velocidade = 1;
            meteoro.dano = 1;
            meteoro.vida = 4;
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
}
