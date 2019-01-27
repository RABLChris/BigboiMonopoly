using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventButton : MonoBehaviour
{
    public string[] RandomEvents;

    public void TextChanger()
    {
        int index = Random.Range(0, RandomEvents.Length);
        GetComponent<Text>().text = RandomEvents[index];
    }
}
