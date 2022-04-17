using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brigand : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public float movementSpeed = 5f, rotationSpeed = 150f;
    void Start()
    {
        Debug.Log("HAHAHA");
    }

    // Update is called once per frame
    void Update()
    {

       // Debug.Log(transform.position);

        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);

        transform.rotation = new Quaternion(0, 0, newRotation.z, newRotation.w);
        if (newRotation.y > 0)
        {
            transform.Rotate(0, 0, -90);
        }
        else {
            transform.Rotate(0, 0, 90);
        }
        

        Debug.Log(newRotation);

        //transform.Translate(0, movementSpeed * Time.deltaTime, 0, Space.Self);

       // Debug.Log(transform.position);
        moveTowardsPlayer();
    }

    private void moveTowardsPlayer(){
        
    }
}
