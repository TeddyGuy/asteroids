using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentLevel;
    public float timeUntilEndOfLevel;
    private int maxLevelOfAsteroids;
    public int currentNumberOfAsteroids;
    public Player player;
    public Asteroid mediumAsteroid, bigAsteroid;
    public Tirailleur tirailleur;
    public Brigand brigands;
    public Timer timerPrefab;
    private Timer timer;
    public TextMeshProUGUI textMesh;
    public bool asteroidsGenerated;
    void Start()
    {
        Instantiate(player);
        currentLevel = 1;
        timer = Instantiate(timerPrefab);
        timer.StartTimer();
        maxLevelOfAsteroids = 2;
        currentNumberOfAsteroids = 0;
        asteroidsGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentLevel();
        if (timer.currentTime > (15 * currentLevel/2)) {
            
           
        }

        if (!asteroidsGenerated)
        {
            while (maxLevelOfAsteroids > currentNumberOfAsteroids)
            {
                var asteroidPosition = transform.position;
                asteroidPosition.x = Random.Range(-8f, 8f);
                asteroidPosition.y = Random.Range(-4f, 4f);
                if (System.Math.Truncate(Random.Range(0f, 2f)) == 1)
                {
                    createAsteroid(mediumAsteroid, asteroidPosition);
                }
                else
                {
                    createAsteroid(bigAsteroid, asteroidPosition);
                }

            }
            asteroidsGenerated = true;
        }
        else {
            if (currentNumberOfAsteroids < 1) {
                timer.ResetTimer();
                currentLevel++;
                asteroidsGenerated = false;
                maxLevelOfAsteroids = (int)(currentLevel * 2.5);
            }
        }

        
    }

    public void createAsteroid(Asteroid asteroid, Vector3 position)
    {
        asteroid = Instantiate(asteroid, position, new Quaternion());
        asteroid.manager = this;
        currentNumberOfAsteroids++;
    }
    public void DisplayCurrentLevel() {
        textMesh.text = "Level " + currentLevel;
    }

}
