using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    private int currentAmountOfBonus;
    public GameObject Bonus;
    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfBonus = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmountOfBonus < 1) {
            SpawnBonus();
            currentAmountOfBonus++;
        }
    }

    private void SpawnBonus() {
        var newPos = transform.position;
        newPos.y = Random.Range(-5f, 5f);
        newPos.x = Random.Range(-9f, 9f);
        Instantiate(Bonus,newPos,new Quaternion());
    }
}
