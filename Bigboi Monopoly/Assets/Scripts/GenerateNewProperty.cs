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
        SetMoneyValues();
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

    void SetMoneyValues()
    {
        int rent = Random.Range(1, 100);
        int house1 = (int)((float)rent * Random.Range(4.5f, 5.5f));
        int house2 = (int)((float)house1 * Random.Range(2.5f, 3.5f));
        int house3 = (int)((float)house2 * Random.Range(2.5f, 3.5f));
        int house4 = (int)((float)house3 * Random.Range(1.5f, 2.5f));
        int hotel = (int)((float)house4 * Random.Range(1.2f, 1.3f));
        int mortgage = (int)((float)hotel * Random.Range(0.075f, 0.125f));
        int price = (int)((float)house2 * Random.Range(0.75f, 0.85f));
        int houseCost = (int)((float)((rent / 25) * 50) * Random.Range(0.75f, 1.25f));
        int hotelCost = houseCost;

        Text priceText = transform.GetChild(1).transform.Find("Price Text").GetComponent<Text>();
        Text rentText = transform.GetChild(1).transform.Find("Rent Text").GetComponent<Text>();
        Text house1Text = transform.GetChild(1).transform.Find("House Text 1").GetComponent<Text>();
        Text house2Text = transform.GetChild(1).transform.Find("House Text 2").GetComponent<Text>();
        Text house3Text = transform.GetChild(1).transform.Find("House Text 3").GetComponent<Text>();
        Text house4Text = transform.GetChild(1).transform.Find("House Text 4").GetComponent<Text>();
        Text hotelText = transform.GetChild(1).transform.Find("Hotel Text").GetComponent<Text>();
        Text mortgageText = transform.GetChild(1).transform.Find("Mortgage Text").GetComponent<Text>();
        Text houseCostText = transform.GetChild(1).transform.Find("House Cost Text").GetComponent<Text>();
        Text hotelCostText = transform.GetChild(1).transform.Find("Hotel Cost Text").GetComponent<Text>();

        priceText.text = ReplaceFirstOccurrence(priceText.text, "$9999", "$" + price.ToString());
        rentText.text = ReplaceFirstOccurrence(rentText.text, "$9999", "$" + rent.ToString());
        house1Text.text = ReplaceFirstOccurrence(house1Text.text, "$9999", "$" + house1.ToString());
        house2Text.text = ReplaceFirstOccurrence(house2Text.text, "$9999", "$" + house2.ToString());
        house3Text.text = ReplaceFirstOccurrence(house3Text.text, "$9999", "$" + house3.ToString());
        house4Text.text = ReplaceFirstOccurrence(house4Text.text, "$9999", "$" + house4.ToString());
        hotelText.text = ReplaceFirstOccurrence(hotelText.text, "$9999", "$" + hotel.ToString());
        mortgageText.text = ReplaceFirstOccurrence(mortgageText.text, "$9999", "$" + mortgage.ToString());
        houseCostText.text = ReplaceFirstOccurrence(houseCostText.text, "$9999", "$" + houseCost.ToString());
        hotelCostText.text = ReplaceFirstOccurrence(hotelCostText.text, "$9999", "$" + hotelCost.ToString());
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

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
