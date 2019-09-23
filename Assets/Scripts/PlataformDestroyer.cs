using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformDestroyer : MonoBehaviour
{
    public GameObject plataformDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        plataformDestructionPoint = GameObject.Find("PlataformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < plataformDestructionPoint.transform.position.x)
        {
           // Destroy(gameObject);
            gameObject.SetActive(false);

        }
        
    }
}
