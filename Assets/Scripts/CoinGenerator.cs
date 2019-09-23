using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public float distanceBeteweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        GameObject newCoin = coinPooler.GetPooledObject();
        newCoin.transform.position = startPosition;
        newCoin.SetActive(true);

        GameObject otherCoin = coinPooler.GetPooledObject();
        otherCoin.transform.position = new Vector3(startPosition.x - distanceBeteweenCoins, startPosition.y, startPosition.z);
        otherCoin.SetActive(true);

        GameObject anotherCoin = coinPooler.GetPooledObject();
        anotherCoin.transform.position = new Vector3(startPosition.x + distanceBeteweenCoins, startPosition.y, startPosition.z);
        anotherCoin.SetActive(true);
    }


}
