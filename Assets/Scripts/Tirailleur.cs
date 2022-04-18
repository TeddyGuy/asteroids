using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirailleur : MonoBehaviour
{
    public Player player;
    public float movementSpeed = 1f;
    public GameObject explosion;
    public int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.Translate(0, -movementSpeed * Time.deltaTime, 0, Space.Self);
        }
    }
}
