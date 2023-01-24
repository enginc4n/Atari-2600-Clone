using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Vector2 slideSpeed;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        material.mainTextureOffset += Time.deltaTime * slideSpeed;
    }
}
