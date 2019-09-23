using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformGenesis : MonoBehaviour
{
    public GameObject thePlataform;
    public Transform generationPoint;
    private float distanceBetween; 

    public float plataformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int plataformSelector;

    private float[] plataformsWidths;

    private float minHeight;
    private float maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    private float heightChange;

    public ObjectPooler[] theObjectPools;

    private CoinGenerator theCoinGenerator;

    public float randomCoinsThreshold;

    public float randomSpikesThreshold;
    public ObjectPooler spikePool;

    void Start()
    {

        theCoinGenerator = FindObjectOfType<CoinGenerator>();

      plataformsWidths = new float[theObjectPools.Length];

      for(int i = 0; i < theObjectPools.Length; i++)
      {
          plataformsWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
      }

      minHeight = transform.position.y;
      maxHeight = maxHeightPoint.position.y;
    }

    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {

            plataformSelector = Random.Range(0, theObjectPools.Length);

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {

                    heightChange = maxHeight;

            }else if(heightChange < minHeight)
            {
                    heightChange = minHeight;

            }

            transform.position = new Vector3(transform.position.x + (plataformsWidths[plataformSelector] / 2) + distanceBetween, 
                                                heightChange, 
                                                transform.position.z);

            GameObject newPlataform = theObjectPools[plataformSelector].GetPooledObject();

            newPlataform.transform.position = transform.position;

            newPlataform.transform.rotation = transform.rotation;

            newPlataform.SetActive(true);

            if(Random.Range(0f, 100f) > randomCoinsThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if(Random.Range(0f, 100f) > randomSpikesThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-plataformsWidths[plataformSelector] / 2f + 1f, plataformsWidths[plataformSelector] / 2f -1f);

                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);

            }

            transform.position = new Vector3(transform.position.x + (plataformsWidths[plataformSelector] / 2), 
                                                transform.position.y, 
                                                transform.position.z);
        }
    }

}
