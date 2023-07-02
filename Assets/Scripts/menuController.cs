using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuController : MonoBehaviour
{

    public TextMeshProUGUI bestScoreTXT;
    public TextMeshProUGUI scoreTXT;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreTXT.text = ("Record: " + PlayerPrefs.GetInt("HighScore").ToString());
        scoreTXT.text = ("Score: ") + player.playerXP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        print("botao");
        if(Input.GetKeyDown(KeyCode.Mouse0))
        { 
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        } 
    }


}
