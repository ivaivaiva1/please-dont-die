using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public AudioClip audioDano;

    public AudioClip fireAudio;

    public AudioClip audioLevel;

    public bool tripleFire = false;

    public GameObject playerCanvas;
 
    public GameObject levelUpObject;

    public float dashForce;

    public float dashTime;

    public static int fireDamage;

    public float playerSpeed;

    private Rigidbody2D playerRB;

    private float life;

    public float maxLife;

    public bool isDeadFloor;

    public Image lifeBar;

    private Animator playerAnim;

    public bool intangible = false;

    public Transform aim;

    public GameObject firePref;
    
    public GameObject triplePref;

    public static float cooldown;

    private float lastShot = 0;

    public static int playerXP;

    public int playerLevel;

    public GameObject controllerSpawn;


    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        playerRB = transform.GetComponent<Rigidbody2D>();
        playerAnim = transform.GetComponent<Animator>();
        fireDamage = 1;
        cooldown = 0.7f;
        playerXP = 0;
        //playerCollider = transform.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoviment();
        Life();
        playerLimits();
        Fire();
        dash();
        print(playerLevel);
        print(playerXP);
        if(playerXP >= 3 && playerLevel == 0)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } else
        if(playerXP >= 15 && playerLevel == 1)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } else
        if(playerXP >= 50 && playerLevel == 2)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } else
        if(playerXP >= 100 && playerLevel == 3)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } else
        if(playerXP >= 200 && playerLevel == 4)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } else
        if(playerXP >= 300 && playerLevel == 5)
        {
          playerLevel = playerLevel +1;
          AudioController.instance.PlayFX(audioLevel);
          LevelUP();
        } 
    }

    void LevelUP()
    {
      GameObject childObject = Instantiate(levelUpObject,transform.position + new Vector3(-0.8f, -6f, 0f), Quaternion.identity) as GameObject;
      childObject.transform.parent = playerCanvas.gameObject.transform;
      if(playerLevel == 6 && playerXP >= 300)
      {
        print("level6");
        controllerSpawns.spawnMultiplier = 0.2f;
      } else
      if(playerLevel == 5 && playerXP >= 200)
      {
        print("level5");
        controllerSpawns.spawnMultiplier = 0.3f;
      } else
      if(playerLevel == 4 && playerXP >= 100)
      {
        print("level4");
        controllerSpawn.GetComponent<controllerSpawns>().Level4();
        controllerSpawns.spawnMultiplier = 0.4f;
        cooldown = 0.35f;
        fireDamage = 7;
        tripleFire = true;  
      } else
      if(playerLevel == 3 && playerXP >= 50)
      {
        print("level3");
        controllerSpawn.GetComponent<controllerSpawns>().Level3();
        controllerSpawns.spawnMultiplier = 0.7f;
        cooldown = 0.45f;
      } else
      if(playerLevel == 2 && playerXP >= 15)
      {
        print("level2");
        controllerSpawn.GetComponent<controllerSpawns>().Level2();
        controllerSpawns.spawnMultiplier = 0.8f;
        fireDamage = 5;
        cooldown = 0.55f;
      } else
      if(playerLevel == 1 && playerXP >= 3)
      {
        print("level1");
        controllerSpawn.GetComponent<controllerSpawns>().Jacare();
        controllerSpawns.spawnMultiplier = 0.9f;
        fireDamage = 3;
      } 
      //animLevelUp
    }

    void dash()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
          if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
          {
              transform.DOMoveY(transform.position.y + dashForce, dashTime)
              .SetEase(Ease.OutCubic);
          } else
          if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
          {
              transform.DOMoveY(transform.position.y + -dashForce, dashTime)
              .SetEase(Ease.OutCubic);
          } else
          if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
          {
              transform.DOMoveX(transform.position.x + -dashForce, dashTime)
              .SetEase(Ease.OutCubic);
          } else
          if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
          {
              transform.DOMoveX(transform.position.x + dashForce, dashTime)
              .SetEase(Ease.OutCubic);
          } 
        }
    }

    void playerLimits()
    {
        if(transform.position.y > 4.36f)
        {
          transform.position = new Vector3(transform.position.x, 4.36f);
        } else
        if(transform.position.y < -4.2f)
        {
          transform.position = new Vector3(transform.position.x, -4.2f);
        } 
        if(transform.position.x > 9.2f)
        {
          transform.position = new Vector3(9.2f, transform.position.y);
        } else
        if(transform.position.x < -9.2f)
        {
          transform.position = new Vector3(-9.2f, transform.position.y);
        } 
    }
    void Fire()
    {
        if(Time.time > lastShot)
        {
          if(tripleFire == false)
          {
            if(Input.GetKey(KeyCode.Mouse0))
            {
              AudioController.instance.PlayFX(fireAudio);
              lastShot = Time.time + cooldown;
              float aimZ = aim.transform.eulerAngles.z;
              Instantiate(firePref, transform.position, Quaternion.Euler(0f, 0f, aimZ));
              playerAnim.SetTrigger("fire");
            }
          } else
          if(tripleFire)
          { 
            if(Input.GetKey(KeyCode.Mouse0))
            {
              lastShot = Time.time + cooldown;
              float aimZ = aim.transform.eulerAngles.z;
              Instantiate(triplePref, transform.position, Quaternion.Euler(0f, 0f, aimZ));
              playerAnim.SetTrigger("fire");
            }
          }
        }
    }

    void Life()
    {
       lifeBar.fillAmount = life / maxLife;
       if(isDeadFloor && intangible == false)
       {
         lifeBar.enabled = true;
         life = life - 10f * Time.deltaTime;
       }
       if(life <= 0)
       {
         if(PlayerPrefs.GetInt("HighScore") < playerXP)
         {
           PlayerPrefs.SetInt("HighScore", playerXP);
         }
         SceneManager.LoadScene("Menu");
       }
    }

    void playerMoviment()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        playerRB.velocity = new Vector2(playerSpeed * X, playerRB.velocity.y);
        playerRB.velocity = new Vector2(playerRB.velocity.x, playerSpeed * Y);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("deadFloor"))
        {
           lifeBar.enabled = true;
           isDeadFloor = true;
        } 
        if(other.CompareTag("enemy"))
        {
           if(intangible == false)
           {
             lifeBar.enabled = true;
             life = life - 10;
             AudioController.instance.PlayFX(audioDano);
             playerAnim.SetTrigger("hit");
        //    playerCollider.enabled = false;
             intangible = true;
             StartCoroutine("activeCollider");
           }
        } 
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("deadFloor"))
        {
           lifeBar.enabled = false;
           isDeadFloor = false;
        } 
    }

    IEnumerator activeCollider()
    {
        yield return new WaitForSeconds(1.25f);
        // playerCollider.enabled = true;
        intangible = false;
        yield return new WaitForSeconds(1f);
        if(isDeadFloor == false)
        {
          lifeBar.enabled = false;
        }
    }
}
