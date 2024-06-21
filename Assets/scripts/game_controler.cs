using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_controler : MonoBehaviour
{
    private Camera cam;
    private float tamanho_vertical, tamanho_horizontal, timer, tempo_de_espera;
    public GameObject[] melhorias;
    void Start()
    {
        cam = Camera.main;
        tamanho_vertical = cam.orthographicSize;
        tamanho_horizontal = tamanho_vertical * cam.aspect;
        tamanho_vertical *= 0.85f;
        tamanho_horizontal *= 0.85f;
        tempo_de_espera = Random.Range(5, 10);
        timer = tempo_de_espera + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer){
            Vector3 posicao = new Vector3(Random.Range(-tamanho_horizontal, tamanho_horizontal), Random.Range(-tamanho_vertical, tamanho_vertical), 0);
            int index = Random.Range(0, 2);
            Instantiate(melhorias[index], posicao, Quaternion.identity);
            timer += Random.Range(5f, 10f);
        }
        
    }

    public void botao_reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
