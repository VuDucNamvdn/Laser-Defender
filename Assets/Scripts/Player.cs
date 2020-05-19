using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1,1000)][SerializeField]
    int Velocity=1;
    [SerializeField]
    float padding = 1;
    [SerializeField]
    GameObject objectLaser;
    Vector2 minV, maxV;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCam = Camera.main;
        minV = mainCam.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3(padding,padding);
        maxV = mainCam.ViewportToWorldPoint(new Vector2(1, 1)) - new Vector3(padding, padding);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(objectLaser,transform.position,Quaternion.identity);
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
}
