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
        GetComponent<Image>().material.SetFloat("_RobotMode", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RobotEnable()
    {
        robotModeActivated = true;
        GetComponent<Image>().material.SetFloat("_RobotMode", robotModeActivated ? 1.0f : 0.0f);
    }
    public void RobotDisable()
    {
        robotModeActivated = false;
        GetComponent<Image>().material.SetFloat("_RobotMode", robotModeActivated ? 1.0f : 0.0f);
    }
}
