using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jacaré : MonoBehaviour
{
   
    public float jacareSpeed; 
    private SpriteRenderer jacareSprite;

    void Start() 
    {
       jacareSprite = transform.GetComponent<SpriteRenderer>();
       int direcaoJacare;
       direcaoJacare = Random.Range(0,2);
       if(direcaoJacare == 1)
       {
         jacareSpeed = -1;
       } else
       if(direcaoJacare == 0)
       {
         jacareSprite.flipX = true;
       } 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(jacareSpeed * Time.deltaTime, 0f));
        if(transform.position.x >= 11)
        {
          jacareSpeed = -1;
          jacareSprite.flipX = false;
        }
        if(transform.position.x <= -11)
        {
          jacareSpeed = 1;
          jacareSprite.flipX = true;
        }
    }
}
