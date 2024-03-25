using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("bullet hit");
            health--;
            Destroy(collision.gameObject);
        }
    }
}
