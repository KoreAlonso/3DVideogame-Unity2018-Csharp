using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public static RandomItem sharedInstance;

    public GameObject item;
    public GameObject instanceItem;
    Vector3 positionItem;
    Quaternion rotationItem;
    public float itemShotVelocity = 0.8f;
    public float itemEnergyIncrease = 2;

    LifeBarPlayer lifeBarPlayer;

    public float minTime = 0, currentTime, maxTime;

    void Start()
    {
        sharedInstance = this;
        item = GameObject.FindGameObjectWithTag("Item");
        positionItem = new Vector3(Random.Range(0, 100), 1, Random.Range(0, 100));
        rotationItem = new Quaternion(0, 0, 25, 0);

        lifeBarPlayer = FindObjectOfType<LifeBarPlayer>();

        currentTime = minTime;
        maxTime = Random.Range(50, 120);
    }

    void Update()
    {
        spawnItem();
    }

    void spawnItem()
    {
        if (lifeBarPlayer.currentLife < 0.25 * lifeBarPlayer.maxLife && currentTime == minTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxTime && instanceItem == null)
            {
                instanceItem = Instantiate(item, positionItem, rotationItem, item.transform);
            }
        }
    }

}
