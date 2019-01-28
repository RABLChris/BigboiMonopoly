using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNewProperty : MonoBehaviour
{
    public TextAsset PlaceNames;
    public TextAsset PlaceFormats;

    // Start is called before the first frame update
    void Start()
    {
        SetPlaceName();
    }

    void SetPlaceName()
    {
        Text propertyText = transform.Find("Property Bar").transform.Find("Property Name").GetComponent<Text>();

        string[] placeFormatsRaw = PlaceFormats.text.Split('\n');
        string placeFormat = placeFormatsRaw[Random.Range(0, placeFormatsRaw.Length)];

        string[] placeNamesRaw = PlaceNames.text.Split('\n');
        string placeName = placeNamesRaw[Random.Range(0, placeNamesRaw.Length)];

        propertyText.text = ReplaceFirstOccurrence(placeFormat, "%", placeName);
    }

    private string ReplaceFirstOccurrence(string Source, string Find, string Replace)
    {
        int Place = Source.IndexOf(Find);
        string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
