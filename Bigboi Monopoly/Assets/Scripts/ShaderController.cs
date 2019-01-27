using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderController : MonoBehaviour
{
    public static bool robotModeActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        robotModeActivated = false;
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
    public void RobotDisable()
    {
        if(robotModeActivated == true)
        {
            ToggleRobotMode();
        }
        else
        {
            robotModeActivated = false;
        }
    }
}
