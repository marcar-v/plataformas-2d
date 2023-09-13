using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float length, startPos;
    [SerializeField] GameObject mainCamera;
    [SerializeField] float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (mainCamera.transform.position.x * (1 - parallaxEffect));
        float dist = (mainCamera.transform.position.x * parallaxEffect);
        transform.position = new Vector2(startPos + dist, transform.position.y);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos + length) startPos -= length;
    }
}
