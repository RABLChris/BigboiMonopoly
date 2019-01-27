using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderController : MonoBehaviour
{
    bool robotModeActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleRobotMode()
    {
        robotModeActivated = !robotModeActivated;
        GetComponent<Image>().material.SetFloat("_RobotMode", robotModeActivated ? 1.0f : 0.0f);
    }
}
