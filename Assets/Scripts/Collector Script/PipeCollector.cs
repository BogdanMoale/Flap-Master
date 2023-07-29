using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour {

    private GameObject[] pipeHolders;
    private float distance = 3f;
    private float lastPipesX;
    private float pipeMin = -1.5f;
    private float pipeMax = 2.4f;

    void Awake()
    {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for(int i=0; i<pipeHolders.Length; i++)
        {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }

        lastPipesX = pipeHolders[0].transform.position.x;

        for (int i = 1; i < pipeHolders.Length; i++)
        {
            if(lastPipesX < pipeHolders[i].transform.position.x)
            {
                lastPipesX = pipeHolders[i].transform.position.x;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeHolder")
        {
            Vector3 temp = collision.transform.position;
            temp.x = lastPipesX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            collision.transform.position = temp;

            lastPipesX = temp.x;
        }
    }
}
