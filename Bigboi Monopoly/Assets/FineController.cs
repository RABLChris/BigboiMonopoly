using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FineController : MonoBehaviour
{
    // Start is called before the first frame update
    private float TimeSinceFineLastUpdated;
    private bool WillFineGenerate = false;
    public void FineGenerator()
    {
        Random.Range(0, 10000);
    }
    void RandomFine()
    {

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
