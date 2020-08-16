using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material myMat;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMat.mainTextureOffset += offset * Time.deltaTime;
    }
}
