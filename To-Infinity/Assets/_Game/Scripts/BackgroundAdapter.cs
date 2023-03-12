using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAdapter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spritesRenderer;

    private void Awake() 
    {
        float tempTransform = spritesRenderer[0].sprite.bounds.size.x;    

        for (int i = 0; i < spritesRenderer.Length; i++)
        {
            spritesRenderer[i].transform.position = new Vector2(tempTransform * i, transform.position.y);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
