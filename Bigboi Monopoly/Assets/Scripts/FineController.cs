using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FineController : MonoBehaviour
{
    // Start is called before the first frame update
    private float TimeSinceFineLastUpdated;
    private bool WillFineGenerate = false;
    private bool RobotInCharge = false;
    public void FineGenerator()
    {
        if (RobotInCharge == false)
        {
            GetComponent<Text>().text = ("The fine rests at $" + Random.Range(0, 10000).ToString());
        }
        else
        {
            GetComponent<Text>().text = ("The robot decrees that the fine rests at $" + Random.Range(0, 10000).ToString());
        }
    }
    public void RobotDeactivator()
    {
        RobotInCharge = false;
    }
    public void RandomFine()
    {
        RobotInCharge = true;
        WillFineGenerate = !WillFineGenerate;
        TimeSinceFineLastUpdated = 61;
    }
    void Update()
    {
        TimeSinceFineLastUpdated += Time.deltaTime;
        if(TimeSinceFineLastUpdated >= 60 && WillFineGenerate == true)
        {
            TimeSinceFineLastUpdated = 0;
            FineGenerator();
        }
    }
}
