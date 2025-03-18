using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectColorMaterialChanger : MonoBehaviour
{
    [SerializeField] private string tagOfObjectToInteract;
    [SerializeField] private Color originalColor;
    [SerializeField] private Color colorWhenInteracts;

    private bool _isOriginalColorSet;
    
    private void Start()
    {
//        originalColor = gameObject.GetComponent<Renderer>().material.color;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tagOfObjectToInteract))
        {
            return;
        }

        gameObject.GetComponent<Renderer>().material.color = colorWhenInteracts;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(tagOfObjectToInteract))
        {
            return;
        }
        
        Reset();
    }

    private void Reset()
    {
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }

    private void OnEnable()
    {
        Reset();
    }
}
