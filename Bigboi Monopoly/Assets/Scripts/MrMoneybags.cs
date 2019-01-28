using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MrMoneybags : MonoBehaviour
{
    public float timeBetweenRotations = 1.0f;
    private float timeBetweenScreams = 30.0f;
    private float timeSinceScream = 0.0f;
    private float timeSinceRotation = 1.0f;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenScreams = Random.Range(30.0f, 500.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceRotation += Time.deltaTime;
        timeSinceScream += Time.deltaTime;
        if (timeSinceScream >= timeBetweenScreams && timeSinceRotation >= timeBetweenRotations)
        {
            OOH();
        }

        timeBetweenRotations = ShaderController.robotModeActivated ? 0.25f : 1.0f;
        if (timeSinceRotation >= timeBetweenRotations)
        {
            GetComponent<Transform>().rotation = targetRotation;
            targetRotation = Quaternion.Euler(Random.onUnitSphere * 180.0f);
            timeSinceRotation = 0.0f;
        }
        GetComponent<Transform>().rotation = Quaternion.Slerp(GetComponent<Transform>().rotation, targetRotation, timeSinceRotation);
    }

    public void OOH()
    {
        var voice = GetComponent<AudioSource>();
        voice.pitch = ShaderController.robotModeActivated ? Random.Range(1.2f, 1.8f) : Random.Range(0.8f, 1.2f);
        voice.Play(0);
        timeSinceScream = 0.0f;
        timeBetweenScreams = Random.Range(30.0f, 500.0f);
    }
}
