using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoTeto : MonoBehaviour
{   
    private Player playerScript;

    private Rigidbody2D espinhoRb;
    public float tempoEspera;
    public int atritoMin, atritoMax;
    private Vector3 posicaoInicial;
    public GameObject espinhoPrefab, explosaoPrefab;
    public int pontos;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType(typeof(Player)) as Player;

        posicaoInicial = transform.position;
        espinhoRb = GetComponent<Rigidbody2D>();
        espinhoRb.isKinematic = true;

        int atrito = Random.Range(atritoMin, atritoMax);
        espinhoRb.drag = atrito;

        StartCoroutine(soltar());
    }

    IEnumerator soltar()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,tempoEspera));
        espinhoRb.isKinematic = false;
    
    }

    void OnCollisionEnter2D()
    {
        GameObject tempEspinho = Instantiate(espinhoPrefab, posicaoInicial, transform.rotation) as GameObject;
        tempEspinho.GetComponent<Rigidbody2D>().isKinematic = true;
        
        GameObject explosao = Instantiate(explosaoPrefab, transform.position, transform.rotation) as GameObject;
        Destroy(explosao, 0.3f);

        playerScript.score += pontos;
        
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
