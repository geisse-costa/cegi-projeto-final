using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoTeto : MonoBehaviour
{   
    private Rigidbody2D espinhoRb;
    public float tempoEspera;
    public int atritoMin, atritoMax;
    private Vector3 posicaoInicial;
    public GameObject espinhoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
        espinhoRb = GetComponent<Rigidbody2D>();
        espinhoRb.isKinematic = true;

        int atrito = Random.Range(atritoMin, atritoMax);
        espinhoRb.drag = atrito;

        StartCoroutine(soltar());
    }

    IEnumerator soltar()
    {
        yield return new WaitForSeconds(tempoEspera);
        espinhoRb.isKinematic = false;
        Debug.Log ("Caiu");
    }

    void OnCollisionEnter2D()
    {
        GameObject tempEspinho = Instantiate(espinhoPrefab, posicaoInicial, transform.rotation) as GameObject;
        tempEspinho.GetComponent<Rigidbody2D>().isKinematic = true;
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
