using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroolTexto : MonoBehaviour
{
    // velocidade de scroll na 'distancia'
    public float scrollSpeed = 20;
    
    //-------------
    void Update()
    {
    // pega a posicao atual GameObject pai
    Vector3 pos = transform.position;
    
    // posiciona o vetor apontando para a distancia
    Vector3 localVectorUp = transform.TransformDirection(0,1,0);
    
    // move o objeto de texto na distancia para o efeito de scrolling 3D
    pos += localVectorUp * scrollSpeed * Time.deltaTime;
    transform.position = pos;
    }
}
