using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f, rotationSpeed = 150f;

    public GameObject missile, canon;
    public GameObject explosion;
    private bool consummingABonus;

    public int hp = 5;

    // Start is called before the first frame update
    void Start()
    {
        consummingABonus = false;   
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(0, 0, -rotation * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(0, translation*Time.deltaTime, 0, Space.Self);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(missile, canon.transform.position, canon.transform.rotation);
        }
    }

    public void TakeDammage(int dammage) {
        hp = hp - dammage;
        if (hp < 0) { 
            Explode();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus")) {
                Debug.Log("YUM");
                Bonus bonus = other.transform.GetComponent<Bonus>();
                consume(bonus);
     
        }
    }

    public void OnTriggerExit(Collider other)
    {
       
        
    }


    public void Explode()
    {
        Destroy(gameObject);
    }

    public void consume(Bonus bonus) {
        hp += bonus.hpRestored;
        bonus.consummed();
    }
}
