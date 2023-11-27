using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text score, record;
    // Start is called before the first frame update
    void Start()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        record.text = PlayerPrefs.GetInt("record").ToString();
    }

    public void irPara(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
