using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSpawns : MonoBehaviour
{
   
    public static float spawnMultiplier;

    public Transform blackTransform;

    public GameObject voidPref;
    public GameObject rockPref;
    public GameObject cobraPref;
    public GameObject moscaPref;
    public GameObject cobraJacare;
    public GameObject poroPref;
    public GameObject dorminhocoPref;


    void Start() 
    {
        // StartCoroutine("instantiateCobra");
        // StartCoroutine("instantiateRock");
        // StartCoroutine("instantiateVoid");
        // StartCoroutine("instantiateJacare");
        spawnMultiplier = 1f;
        StartCoroutine("instantiateMosca");
        StartCoroutine("instantiatePoro");
    }

    IEnumerator instantiateDorminhoco()
    {
        yield return new WaitForSeconds(10f * spawnMultiplier);
        Vector2 black = blackTransform.position;
        GameObject childObject = Instantiate(dorminhocoPref, new Vector2(black.x + Random.Range(-4.5f, 4.5f), black.y + Random.Range(-3.8f, 3.8f)), Quaternion.identity) as GameObject;
        childObject.transform.parent = gameObject.transform;
        StartCoroutine("instantiateDorminhoco");
    }

    IEnumerator instantiateMosca()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(moscaPref, new Vector2(Random.Range(-4.5f, 7.9f), Random.Range(-4.3f, 4.3f)), Quaternion.identity);
        StartCoroutine("instantiateMosca");
    }

    IEnumerator instantiatePoro()
    {
        yield return new WaitForSeconds(10f);
        Vector2 black = blackTransform.position;
        GameObject childObject = Instantiate(poroPref, new Vector2(black.x + Random.Range(-4.5f, 4.5f), black.y + Random.Range(-3.8f, 3.8f)), Quaternion.identity) as GameObject;
        childObject.transform.parent = gameObject.transform;
        StartCoroutine("instantiatePoro");
    }

    public void Jacare()
    {
       float whatJacare = Random.Range(-4.3f,4.3f);
       Instantiate(cobraJacare, new Vector2(0f, whatJacare), Quaternion.identity);
       StartCoroutine("instantiateJacare");
    }

    public void Level2()
    {
       print("level2");
       Vector2 black = blackTransform.position;
       GameObject childObject = Instantiate(dorminhocoPref, new Vector2(black.x + Random.Range(-4.5f, 4.5f), black.y + Random.Range(-3.8f, 3.8f)), Quaternion.identity) as GameObject;
       childObject.transform.parent = gameObject.transform;
       StartCoroutine("instantiateRock");
       StartCoroutine("instantiateDorminhoco");
    }

    public void Level3()
    {
        int whatRock = Random.Range(0,6);
        switch (whatRock)
        {
        case 5:
            Instantiate(voidPref, new Vector2(0f, 0f), Quaternion.identity);
            break;
        case 4:
            Instantiate(voidPref, new Vector2(-5f, -2.5f), Quaternion.identity);
            break;
        case 3:
            Instantiate(voidPref, new Vector2(5f, -2.5f), Quaternion.identity);
            break;
        case 2:
            Instantiate(voidPref, new Vector2(-5f, 2.5f), Quaternion.identity);
            break;
        case 1:
            Instantiate(voidPref, new Vector2(5f, 2.5f), Quaternion.identity);
            break;
        default:
            break;
        }
        StartCoroutine("instantiateVoid");
    }

    public void Level4()
    {
        StartCoroutine("instantiateCobra");
    }

    IEnumerator instantiateJacare()
    {
        yield return new WaitForSeconds(20f / spawnMultiplier);
        float whatJacare = Random.Range(-4.3f,4.3f);
        Instantiate(cobraJacare, new Vector2(0f, whatJacare), Quaternion.identity);
        StartCoroutine("instantiateJacare");
    }

    IEnumerator instantiateVoid()
    {
        yield return new WaitForSeconds(20f * spawnMultiplier);
        int whatRock = Random.Range(0,6);
        switch (whatRock)
        {
        case 5:
            Instantiate(voidPref, new Vector2(0f, 0f), Quaternion.identity);
            break;
        case 4:
            Instantiate(voidPref, new Vector2(-5f, -2.5f), Quaternion.identity);
            break;
        case 3:
            Instantiate(voidPref, new Vector2(5f, -2.5f), Quaternion.identity);
            break;
        case 2:
            Instantiate(voidPref, new Vector2(-5f, 2.5f), Quaternion.identity);
            break;
        case 1:
            Instantiate(voidPref, new Vector2(5f, 2.5f), Quaternion.identity);
            break;
        default:
            break;
        }
        StartCoroutine("instantiateVoid");
    }


    IEnumerator instantiateCobra()
    {
        yield return new WaitForSeconds(10f * spawnMultiplier);
        int whatSnake = Random.Range(0,15);
        switch (whatSnake)
        {
        case 14:
            Instantiate(cobraPref, new Vector2(-12.3f, 4.5f), Quaternion.Euler(0f, 0f, 159f));
            break;
        case 13:
            Instantiate(cobraPref, new Vector2(-12.3f, 3f), Quaternion.Euler(0f, 0f, 166f));
            break;
        case 12:
            Instantiate(cobraPref, new Vector2(-12.3f, 1.5f), Quaternion.Euler(0f, 0f, 173f));
            break;
        case 11:
            Instantiate(cobraPref, new Vector2(-12.3f, 0f), Quaternion.Euler(0f, 0f, 180f));
            break;
        case 10:
            Instantiate(cobraPref, new Vector2(-12.3f, -1.5f), Quaternion.Euler(0f, 0f, 187));
            break;
        case 9:
            Instantiate(cobraPref, new Vector2(-12.3f, -3f), Quaternion.Euler(0f, 0f, 194f));
            break;
        case 8:
            Instantiate(cobraPref, new Vector2(-12.3f, -4.5f), Quaternion.Euler(0f, 0f, 201f));
            break;
        case 7:
            Instantiate(cobraPref, new Vector2(12.3f, 4.5f), Quaternion.Euler(0f, 0f, 21f));
            break;
        case 6:
            Instantiate(cobraPref, new Vector2(12.3f, 3f), Quaternion.Euler(0f, 0f, 14f));
            break;
        case 5:
            Instantiate(cobraPref, new Vector2(12.3f, 1.5f), Quaternion.Euler(0f, 0f, 7f));
            break;
        case 4:
            Instantiate(cobraPref, new Vector2(12.3f, 0f), Quaternion.Euler(0f, 0f, 0f));
            break;
        case 3:
            Instantiate(cobraPref, new Vector2(12.3f, -1.5f), Quaternion.Euler(0f, 0f, -7f));
            break;
        case 2:
            Instantiate(cobraPref, new Vector2(12.3f, -3f), Quaternion.Euler(0f, 0f, -14f));
            break;
        case 1:
            Instantiate(cobraPref, new Vector2(12.3f, -4.5f), Quaternion.Euler(0f, 0f, -21f));
            break;
        default:
            break;
        }
        StartCoroutine("instantiateCobra");
    }


    IEnumerator instantiateRock()
    {
        yield return new WaitForSeconds(3f * spawnMultiplier);
        int whatRock = Random.Range(0,6);
        switch (whatRock)
        {
        case 5:
            Instantiate(rockPref, new Vector2(6f, 6.5f), Quaternion.identity);
            break;
        case 4:
            Instantiate(rockPref, new Vector2(3f, 6.5f), Quaternion.identity);
            break;
        case 3:
            Instantiate(rockPref, new Vector2(0f, 6.5f), Quaternion.identity);
            break;
        case 2:
            Instantiate(rockPref, new Vector2(-3f, 6.5f), Quaternion.identity);
            break;
        case 1:
            Instantiate(rockPref, new Vector2(-6f, 6.5f), Quaternion.identity);
            break;
        default:
            break;
        }
        StartCoroutine("instantiateRock");
    }
}
