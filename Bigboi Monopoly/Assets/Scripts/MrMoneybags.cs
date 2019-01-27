using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MrMoneybags : MonoBehaviour
{
    private float timeSinceRotation = 1.0f;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceRotation += Time.deltaTime;
        if (timeSinceRotation >= 1.0f)
        {
            GetComponent<Transform>().rotation = targetRotation;
            targetRotation = Quaternion.Euler(Random.onUnitSphere * 180.0f);
            timeSinceRotation = 0.0f;
        }
        GetComponent<Transform>().rotation = Quaternion.Slerp(GetComponent<Transform>().rotation, targetRotation, timeSinceRotation);
    }
}
