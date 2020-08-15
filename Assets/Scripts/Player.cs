using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1,1000)][SerializeField] int Velocity=1;
    [SerializeField] float padding = 1;
    [SerializeField] GameObject objectLaser;
    [SerializeField] float rateOfFire = 10;
    [SerializeField] int health = 1000;
    [SerializeField] float speed = 10;
    Vector2 minV, maxV;
    Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        GetViewBound();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        SetTimeSpeed();
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/rateOfFire);
            Instantiate(objectLaser, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {           
            StopCoroutine(firingCoroutine);
        }
    }
    private void Move()
    {
         
        var deltaX = Time.deltaTime * Input.GetAxis("Horizontal") * Velocity;
        var newXPos = Mathf.Clamp(transform.position.x+deltaX,minV.x,maxV.x);
        var deltaY = Time.deltaTime * Input.GetAxis("Vertical") * Velocity;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,minV.y,maxV.y);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetTimeSpeed()
    {
        if (Input.GetButtonDown("SpeedUp"))
        {
            Time.timeScale = 20f;
            Debug.Log("Pressed");
        }
        if (Input.GetButtonUp("SpeedUp"))
        {
            Time.timeScale = 1f;
        }
    }
    private void GetViewBound()
    {
        Camera mainCam = Camera.main;
        minV = mainCam.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3(padding, padding);
        maxV = mainCam.ViewportToWorldPoint(new Vector2(1, 1)) - new Vector3(padding, padding);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
