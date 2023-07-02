using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class poro : MonoBehaviour
{
   
    public float jumpForce;

    public float jumpTime;

    void Start() 
    {
        transform.DOMoveY(transform.position.y + jumpForce, jumpTime)
        .SetEase(Ease.OutCubic)
        .SetLoops(-1,LoopType.Yoyo);
    }
   
    // Update is called once per frame
    void Update()
    {
        // transform.DOMoveY(transform.position.y + jumpForce, jumpTime)
        // .SetEase(Ease.OutSine)
        // .SetLoops(3);
    }
}
