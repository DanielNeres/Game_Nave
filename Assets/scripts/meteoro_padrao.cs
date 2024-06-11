using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    public float Velocidade { get; set; }
    public int Vida { get; set; }
    public int Dano { get; set; }

    public virtual void Colidir(GameObject outroObjeto)
    {
        // Implementação padrão da colisão
    }
}