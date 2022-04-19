using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro;

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
    private Timer timer;
    public TextMeshProUGUI textMesh;
    void Start()
    {
        Instantiate(player);
        currentLevel = 1;
        timer = Instantiate(timerPrefab);
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentLevel();
        if (timer.currentTime > (15 * currentLevel/2)) {
            timer.ResetTimer();
            currentLevel++;
        }
    }

    public void DisplayCurrentLevel() {
        textMesh.text = "Level " + currentLevel;
}
}
