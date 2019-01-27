using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventButton : MonoBehaviour
{
    AudioSource Gong;
    public string[] RandomEvents;
    private bool RobotInCharge = false;

    public void TextChanger()
    {
        int index = Random.Range(0, RandomEvents.Length);
        GetComponent<Text>().text = RandomEvents[index];
        Gong = GetComponent<AudioSource>();
        Gong.Play(0);
    }
    public void RobotEvents()
    {

    }
}
