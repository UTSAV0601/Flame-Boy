using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;
    Player playerScript;
    public int damage;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        // creating variable of the same type as the name of the script we are trying to access.
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform is use to move object inside the scene just as move tool. In the brackets we have to specify in which direction and at what speed we want to move object.
        //Vector2.down symbolizes that we want to move object in downward direction.Vector2.down = Vector2(0, -1).Time.deltaTime makes game frame rate independent.
        // Time.deltaTime makes game frame rate independent . it means it will run as fast as in new computer and in grandparent old computer too
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
    }

    // function to detect the collision between hazard and player
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            //to destroy the enemy after colliding with player
            Destroy(gameObject);
        }
        if(hitObject.tag == "land")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
