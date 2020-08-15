using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float minTimeBetweenShots = 1;
    [SerializeField] float maxTimeBetweenShots = 3;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    float shotCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter<=0)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        //Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed); ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dealer = other.gameObject.GetComponent<DamageDealer>();
        Destroy(other.gameObject);
        if (!dealer)
            return;
        ProcessHit(dealer);
    }

    private void ProcessHit(DamageDealer dealer)
    {
        health -= dealer.getDamgage();
        dealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public int getHealth()
    {
        return health;
    }
}
