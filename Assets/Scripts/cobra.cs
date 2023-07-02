using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cobra : MonoBehaviour
{

    public float cobraSpeed;

    private Rigidbody2D cobraRB;

    private SpriteRenderer cobraSR;

    // Start is called before the first frame update
    void Start()
    {
        cobraSR = transform.GetComponent<SpriteRenderer>();
        cobraRB = transform.GetComponent<Rigidbody2D>();
        if(transform.position.x < 0)
        {
          cobraSR.flipY = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cobraRB.velocity = transform.right * -cobraSpeed;
    }
}
