using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float speed;
    public Text scoreTxt;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
        if(Input.GetMouseButtonDown(0))
        {
            Flip();
        }

        playerRb.velocity = new Vector3(speed, 0);
    }

    void Flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.tag == "Espinho")
      {
            GameOver();
      }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.tag == "Espinho")
      {
            GameOver();
      }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("score", score);

        if(score > PlayerPrefs.GetInt("record"))
        {
            PlayerPrefs.SetInt("record", score);
        }
        SceneManager.LoadScene("GameOver");
        //print("Morreu");
       
    }
}
