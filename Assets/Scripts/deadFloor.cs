using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadFloor : MonoBehaviour
{

    public float scaleMinor;

    // Update is called once per frame
    void Update()
    {
        // if(encosto)
        // {
        //   if(Vertical)
        //   {
        //    transform.Translate(new Vector2(0f, speed * Time.deltaTime));
        //   } 
          
        //   else

        //   if(Vertical == false) 
        //   {
        //    transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        //   }
        // } 
        
        //else

        // if(encosto == false)
        // {
        //   if(Vertical)
        //   {
        //     transform.Translate(new Vector2(0f, -speed * Time.deltaTime));
        //   } 
          
        //   else

        //   if(Vertical == false) 
        //   {
        //     transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        //   }
        // } else
        // if(encosto == true)
        // {
        //   if(Vertical)
        //   {
        //     transform.Translate(new Vector2(0f, speed * Time.deltaTime));
        //   } 
          
        //   else

        //   if(Vertical == false) 
        //   {
        //     transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        //   }
        // } 

        if(blackFloor.biggerBigger)
        {
          transform.localScale -= new Vector3(scaleMinor, scaleMinor, 0f) * Time.deltaTime;
        } else
        if(blackFloor.biggerBigger == false)
        {
          transform.localScale += new Vector3(scaleMinor, scaleMinor, 0f) * Time.deltaTime;
        }

    }
}
