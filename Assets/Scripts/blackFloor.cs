using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackFloor : MonoBehaviour
{

    public static bool biggerBigger;

    public float scaleMinor;

    public float blackMaxSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       scaleVoid();
    }

    void scaleVoid()
    {
        if(biggerBigger == false)
        {
          transform.localScale -= new Vector3(scaleMinor, scaleMinor, 0f) * Time.deltaTime;
        } else
        if(biggerBigger)
        {
          transform.localScale += new Vector3(scaleMinor, scaleMinor, 0f) * Time.deltaTime;
        }
        if(transform.localScale.x <= 0.7f)
        {
          biggerBigger = true;
        } else
        if(transform.localScale.x >= 5.17f)
        {
          biggerBigger = false;
        } 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("noFloorL"))
        {
           floorDad.rightMines = 1;
        } 
        if(other.CompareTag("noFloorR"))
        {
           floorDad.rightMines = -1;
        } 
        if(other.CompareTag("noFloorU"))
        {
           floorDad.upMines = -1;
        } 
        if(other.CompareTag("noFloorD"))
        {
           floorDad.upMines = 1;
        } 
    }
    
}
