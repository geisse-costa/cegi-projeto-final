using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoParede : MonoBehaviour
{
    public float tempoEspera, velocidade;
    public Transform A,B;
    private Vector3 destino;
    private bool esperando;

    // Start is called before the first frame update
    void Start()
    {
        destino = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
        if(transform.position == destino && esperando == false)
        {
            StartCoroutine("moverEspinho");
        }
    }

    IEnumerator moverEspinho()
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
