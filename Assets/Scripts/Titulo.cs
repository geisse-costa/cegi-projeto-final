using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Titulo : MonoBehaviour
{
    public Text record;

    // Start is called before the first frame update
    void Start()
    {
        record.text = "RECORD: " + PlayerPrefs.GetInt("record").ToString();
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
