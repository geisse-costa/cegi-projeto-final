using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform objeto, A, B;
    private Vector3 destino;
    public float velocidade, tempoEspera;
    private bool esperando;
    

    // Start is called before the first frame update
    void Start()
    {
        destino = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        objeto.position = Vector3.MoveTowards(objeto.position, destino, velocidade * Time.deltaTime);
        if(objeto.position == destino && esperando == false)
        {
            StartCoroutine("moverPlataforma");
        }
    }

    IEnumerator moverPlataforma()
    {
        esperando = true;
        yield return new WaitForSeconds(tempoEspera);
        if(destino == A.position)
        {
            destino = B.position;
        }
        else if(destino == B.position)
        {
            destino = A.position;
        }
        esperando = false;
    }
}
