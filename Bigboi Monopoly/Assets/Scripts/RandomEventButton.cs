using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventButton : MonoBehaviour
{
    public string[] RandomEvents;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void TextChanger()
    {
        int index = Random.Range(0, RandomEvents.Length);
        GetComponent<Text>().text = RandomEvents[index];
    }
}
