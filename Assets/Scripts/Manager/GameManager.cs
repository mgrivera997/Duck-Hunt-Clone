using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ammoMaxCount = 3;
    public int ammoCurCount = 0;

    public int birdMaxCount = 10;
    public int birdCurCount = 10;

    public int maxBirdsAlive = 2;

    public int score = 0;

    public bool isOutOfAmmo = true;
    public bool areAllBirdsDead = true;

    [SerializeField] private List<GameObject> birdTypesList;
    public List<GameObject> birdsList;

    public Transform birdSpawnPos;
    public void Start()
    {
        SpawnBird();
    }
    public void Update()
    {
       
        if (Input.anyKeyDown)
        {
            Debug.Log("Spent 1 Ammo");
            
           
                ammoCurCount -= 1;
        }

        if (ammoCurCount == 0)
        {
            DespawnBirds();
            SpawnBird();
        }
    }
    public void OnBirdShot(Bird bird)
    {
        birdCurCount -= 1;
        score += bird.scoreValue;

        if (ammoCurCount == 0)
        {
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
            DespawnBirds();
            SpawnBird();
        }
        else
            ammoCurCount -= 1;
    }
    public void SpawnBird()
    {
        if (areAllBirdsDead || isOutOfAmmo)
        {
            for (int i = 0; i < maxBirdsAlive; i++)
            {
                int rand = Random.Range(0, 2);
                GameObject birdGameObject = Instantiate(birdTypesList[rand], birdSpawnPos);
                birdsList.Add(birdGameObject);
            }
            isOutOfAmmo = false;
            ammoCurCount = ammoMaxCount;
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
