using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_meteoro_G : MonoBehaviour
{
    public GameObject Meteoro_G = GameObject.GetComponent<Nave>();

    void Start()
    {
        gameObject = Meteoro_G;
    }

    void Update()
    {

    }
}

