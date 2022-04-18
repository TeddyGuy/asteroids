using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public BonusManager manager;
    public int hpRestored = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void consummed() {
        Destroy(gameObject);
        manager.BonusEaten();
    }
}
