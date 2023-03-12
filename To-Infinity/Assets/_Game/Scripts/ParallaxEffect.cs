using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float parallaxSpeed;

    private void Awake() 
    {
        mainCamera = Camera.main.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (mainCamera.transform.position.x * (1 - parallaxSpeed));
        float dist = (mainCamera.transform.position.x * parallaxSpeed);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + length)
        {
            startPos += length;
        }
        else if(temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
