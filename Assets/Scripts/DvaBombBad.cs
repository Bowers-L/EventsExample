using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvaBombBad : MonoBehaviour
{
    public float bombRadius;

    public Enemy[] listOfEnemies;

    public void DetonateBomb()
        {
            foreach(Enemy e in listOfEnemies) {
            //Send a Raycast 
                bool block = Physics.Raycast(new Ray(transform.position, e.transform.position - transform.position), 
                                            bombRadius, 
                                            LayerMask.GetMask("Ignore Raycast"));
                float dist = (e.transform.position - transform.position).magnitude;

                if(dist < bombRadius && !block) {
                    e.Die();
                }
            }
    }

    public void Start()
    {
        transform.localScale = Vector3.one * bombRadius * 0.5f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DetonateBomb();
        }
    }

}
