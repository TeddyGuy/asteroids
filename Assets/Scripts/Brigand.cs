using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigand : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public float movementSpeed = 1f;
    public GameObject explosion;
    public int hp = 3;
    void Start()
    {
        Debug.Log("HAHAHA");
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsPlayer();
    }

    private void moveTowardsPlayer(){
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);

        transform.rotation = new Quaternion(0, 0, newRotation.z, newRotation.w);
        if (newRotation.y > 0)
        {
            transform.Rotate(0, 0, -90);
        }
        else
        {
            transform.Rotate(0, 0, 90);
        }

        transform.Translate(0, movementSpeed * Time.deltaTime, 0, Space.Self);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            hp--;
            if (hp == 0) {
                Destroy(gameObject);
            }
            other.transform.GetComponent<Asteroid>()?.Explode();
            Instantiate(explosion, other.transform.position, other.transform.rotation); // Creer une explosion
        }
        if (other.CompareTag("Player")) {
            other.transform.GetComponent<Player>()?.TakeDammage(2);
            Destroy(gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }

    public void TakeDammage(int dammage) {
        hp = hp - dammage;
        if (hp < 0)
        {
            Explode();
        }
    }
    public void Explode()
    {
        Destroy(gameObject);
    }
}
