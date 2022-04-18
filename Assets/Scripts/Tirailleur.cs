using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirailleur : MonoBehaviour
{
    public Player player;
    public float movementSpeed = 1f;
    public GameObject canon, missile;
    public GameObject explosion;
    public int hp = 3;
    public float shootingInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot",2.0f,shootingInterval);
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsPlayer(4f);
    }

    private void moveTowardsPlayer(float distanceFromPlayer)
    {
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

        if (Vector3.Distance(player.transform.position, transform.position) > distanceFromPlayer)
        {
            transform.Translate(0, movementSpeed * Time.deltaTime, 0, Space.Self);
        }
        else {
            transform.Translate(0, -movementSpeed * 1.5f * Time.deltaTime, 0, Space.Self);
        }
    }

    private void shoot() {
        Instantiate(missile, canon.transform.position, canon.transform.rotation);
    }
}
