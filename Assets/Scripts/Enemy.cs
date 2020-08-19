using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] int health = 100;
    [SerializeField] float minTimeBetweenShots = 1;
    [SerializeField] float maxTimeBetweenShots = 3;

    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] [Range(0, 1)] float shotVolume = 0.5f;

    [Header("Death")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float fxTime = 1;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathVolume = 1;
    [SerializeField] int point = 100;

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
        var laser = Instantiate(projectile, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shotSFX, Camera.main.transform.position, shotVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dealer = other.gameObject.GetComponent<DamageDealer>();
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
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVolume);
        Destroy(Instantiate(deathVFX, transform.position, Quaternion.identity).gameObject, fxTime);
        FindObjectOfType<GameSession>().addScore(point);
        Destroy(gameObject);
    }

    public int getHealth()
    {
        return health;
    }
}
