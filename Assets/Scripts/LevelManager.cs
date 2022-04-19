using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentLevel;
    public float timeUntilEndOfLevel;
    public int maxLevelOfAsteroids;
    private int currentNumberOfAsteroids;
    public Player player;
    public Asteroid mediumAsteroid, bigAsteroid;
    public Tirailleur tirailleur;
    public Brigand brigands;
    public Timer timerPrefab;
    void Start()
    {
        Instantiate(player);
        
        var timer = Instantiate(timerPrefab);
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
