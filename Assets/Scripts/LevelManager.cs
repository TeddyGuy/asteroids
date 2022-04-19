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
    public int currentNumberOfAlienShip;
    public Player playerPrefab;
    private Player player;
    public Asteroid mediumAsteroid, bigAsteroid;
    public Tirailleur tirailleur;
    public Brigand brigands;
    public Timer timerPrefab;
    private Timer timer;
    public TextMeshProUGUI textMesh;
    public bool asteroidsGenerated;
    public bool alienSwarmStarted;
    void Start()
    {
        player = Instantiate(playerPrefab);
        currentLevel = 1;
        timer = Instantiate(timerPrefab);
        timer.StartTimer();
        maxLevelOfAsteroids = 2;
        currentNumberOfAsteroids = 0;
        currentNumberOfAlienShip = 0;
        asteroidsGenerated = false;
        alienSwarmStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentLevel();
        if (timer.currentTime > (10f * (currentLevel/2f)) && !alienSwarmStarted) {
            InvokeRepeating("SpawnAlienShip",0f,3f);
            alienSwarmStarted = true;
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
            if (currentNumberOfAsteroids < 1 && currentNumberOfAlienShip < 1) {
                timer.ResetTimer();
                currentLevel++;
                asteroidsGenerated = false;
                alienSwarmStarted = false;
                CancelInvoke();
                maxLevelOfAsteroids = (int)(currentLevel * 1.7);
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

    public void createBrigand(Brigand brigand, Vector3 position) { 
        brigand = Instantiate(brigand, position, new Quaternion());
        brigand.levelManager = this;
        brigand.player = player;
        currentNumberOfAlienShip++;
    }

    public void createTiralleur(Tirailleur tirailleur, Vector3 position)
    {
        tirailleur = Instantiate(tirailleur, position, new Quaternion());
        tirailleur.levelManager = this;
        tirailleur.player = player;
        currentNumberOfAlienShip++;
    }

    public void SpawnAlienShip() {
        var alienShipPosition = transform.position;
        alienShipPosition.x = Random.Range(-8f, 8f);
        alienShipPosition.y = Random.Range(-4f, 4f);
        if (System.Math.Truncate(Random.Range(0f, 2f)) == 1)
        {
            createBrigand(brigands, alienShipPosition);
        }
        else
        {
            createTiralleur(tirailleur, alienShipPosition);
        }
    }
}
