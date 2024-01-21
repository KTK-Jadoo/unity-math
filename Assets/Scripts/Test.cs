using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    IEnumerator currentMoveCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        string[] messages = { "Welcome", "to", "this", "amazing", "game" };
        StartCoroutine(PrintMessages(messages, 0.5f));
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }

            currentMoveCoroutine = Move(Random.onUnitSphere * 5, 8);
            StartCoroutine(currentMoveCoroutine);
        }
    }

    IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach (string msg in messages) {
            print(msg);
            yield return new WaitForSeconds(delay);}
    }

    IEnumerator Move (Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }


}
