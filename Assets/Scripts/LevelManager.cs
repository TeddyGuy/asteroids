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
    public Timer timer;
    void Start()
    {
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
