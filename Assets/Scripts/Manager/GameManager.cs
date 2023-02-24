using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ammoMaxCount = 3;
    public int ammoCurCount = 0;

    public int maxBirdsToSpawn = 10;
    public int totalBirdsToSpawn = 10;

    public int maxBirdsAlive = 2;
    public int curBirdsAlive;

    public int score = 0;
    public int perfectScore = 10000;

    public bool isOutOfAmmo = true;
    public bool areAllBirdsDead = true;

    [SerializeField] private List<GameObject> birdTypesList;
    public List<GameObject> birdsList;

    public Transform birdSpawnPos;

    public int birdsShot;
    public void Start()
    {
        SpawnBird();
    }
    public void Update()
    {
        if (areAllBirdsDead)
        {
            SpawnBird();
        }
        if (isOutOfAmmo)
        {
            DespawnBirds();
            SpawnBird();
        }
    }
    public void OnBirdShot(Bird bird)
    {
        score += bird.scoreValue;
        birdsShot++;
        birdsList.Remove(bird.gameObject);
        bird.KillSelf();
        curBirdsAlive--;
        if(curBirdsAlive == 0)
        {
            areAllBirdsDead = true;
        }
        if (ammoCurCount == 0)
        {
            isOutOfAmmo = true;
            DespawnBirds();
            SpawnBird();
        }
        else
            ammoCurCount -= 1;
    }
    public void OnMissShot()
    {
        if (ammoCurCount == 0)
        {
            isOutOfAmmo = true;
            DespawnBirds();
            SpawnBird();
        }
        else
            ammoCurCount -= 1;
    }
    public void SpawnBird()
    {
        if ((areAllBirdsDead || isOutOfAmmo) && totalBirdsToSpawn > 0)
        {
            curBirdsAlive = maxBirdsAlive;
            areAllBirdsDead = false;
            for (int i = 0; i < maxBirdsAlive; i++)
            {
                totalBirdsToSpawn -= 1;
                int rand = Random.Range(0, 2);
                GameObject birdGameObject = Instantiate(birdTypesList[rand], birdSpawnPos);
                birdGameObject.GetComponent<Bird>().gameManager = this;
                birdsList.Add(birdGameObject);
            }
            isOutOfAmmo = false;
            ammoCurCount = ammoMaxCount;
        }
        else
        {
            //When all 10 birds have been spawned
            totalBirdsToSpawn = 0;
            if (birdsShot == 10)
            {
                score += perfectScore;
                birdsShot = 0;
                Debug.Log("Perfect");
            }
            Debug.Log("Next Round");
        }
    }
    public void DespawnBirds()
    {
        foreach (GameObject bird in birdsList)
        {
            // this may bug out since kill self destroys the object it may not be able to remove the bird from list
            bird.GetComponent<Bird>().KillSelf();
            birdsList.Remove(bird);
        }
    }
}
