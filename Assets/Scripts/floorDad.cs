using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorDad : MonoBehaviour
{
  
    public static float rightMines;
    
    public static float upMines;

    public float speed;

    void Start()
    {
        StartCoroutine("changeSides");
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(new Vector2((speed * rightMines) * Random.Range(0.8f, 1.25f) * Time.deltaTime, (speed * upMines) * Random.Range(0.8f, 1.25f) * Time.deltaTime));
    }

    IEnumerator changeSides()
    {
        yield return new WaitForSeconds(2f);
        int right = Random.Range(0,2);
        int up = Random.Range(0,2);
        if(right == 0)
        {
           rightMines = 1;
        } else
        if(right == 1)
        {
           rightMines = -1;
        } 
        if(up == 0)
        {
           upMines = 1;
        } else
        if(up == 1)
        {
           upMines = -1;
        } 
        StartCoroutine("changeSides");
    }
}
