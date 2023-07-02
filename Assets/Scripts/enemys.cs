using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemys : MonoBehaviour
{

    public AudioClip audioHit;

    public AudioClip audioDead;

    public int enemyXP;

    public int life;

    private Animator enemyAnim;

    private SpriteRenderer enemySprite;

    void Start() 
    {
        enemyAnim = transform.GetComponent<Animator>();
        enemySprite = transform.GetComponent<SpriteRenderer>();
        StartCoroutine("setTag");
    }

    IEnumerator setTag()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
           DOTween.Kill(transform);  
           player.playerXP = player.playerXP + enemyXP;
           AudioController.instance.PlayFX(audioDead);
           Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("fire"))
        {
           enemyAnim.SetTrigger("hit");
           AudioController.instance.PlayFX(audioHit);
           life = life - player.fireDamage;
           //Destroy(other.gameObject);
        } 
    }
}
