using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public int currentAmountOfBonus = 0;
    public Bonus bonus;
    // Start is called before the first frame update
    void Start()
    {
        currentAmountOfBonus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (currentAmountOfBonus < 1) {
            SpawnBonus();
            currentAmountOfBonus++;
        }
    }

    private void SpawnBonus() {
        var newPos = transform.position;
        newPos.y = Random.Range(-5f, 5f);
        newPos.x = Random.Range(-9f, 9f);
        bonus.manager = this;
        Instantiate(bonus.gameObject,newPos,new Quaternion());
    }

    public void BonusEaten() {
        Debug.Log(currentAmountOfBonus);
        currentAmountOfBonus--;
        Debug.Log(currentAmountOfBonus);
    }
}
