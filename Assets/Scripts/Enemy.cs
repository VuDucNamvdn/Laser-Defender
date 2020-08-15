using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dealer = other.gameObject.GetComponent<DamageDealer>();
        if (!dealer)
            return;
        health -= dealer.getDamgage();
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
