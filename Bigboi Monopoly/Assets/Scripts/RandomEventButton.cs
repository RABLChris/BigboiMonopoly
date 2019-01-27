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
        Gong.pitch = Random.Range(0.8f, 1.2f);
        Gong.Play(0);
    }
    public void RobotEvents()
    {

    }
    /*
     * 
     * Arrays
     * 
     */
    private string[] SpaceNames =
    {
        "Go",
        "Noctowl",
        "Trainer Battle",
        "Pidgeotto",
        "Your Rival Attacks",
        "Poke Ball",
        "Pinsir",
        "Professor Elm",
        "Heracross",
        "Scizor",
        "Jail",
        "Clefable",
        "Raikou",
        "Girafarig",
        "Miltank",
        "Great Ball",
        "Gastly",
        "Haunter",
        "Gengar",
        "Free Parking",
        "Hitmonchan",
        "Hitmonlee",
        "Primeape",
        "Ultra Ball",
        "Magnemite",
        "Skarmory",
        "Suicune",
        "Steelix",
        "Go to Jail",
        "Seel",
        "Dewgong",
        "Piloswine",
        "Master Ball",
        "Kingdra",
        "Team Rocket Attacks",
        "Dragonite",
    };
    private string[] ClosableSpaceNames =
    {
        "Go",
        "Noctowl",
        "Pidgeotto",
        "Poke Ball",
        "Pinsir",
        "Heracross",
        "Scizor",
        "Clefable",
        "Raikou",
        "Girafarig",
        "Miltank",
        "Great Ball",
        "Gastly",
        "Haunter",
        "Gengar",
        "Hitmonchan",
        "Hitmonlee",
        "Primeape",
        "Ultra Ball",
        "Magnemite",
        "Skarmory",
        "Suicune",
        "Steelix",
        "Seel",
        "Dewgong",
        "Piloswine",
        "Master Ball",
        "Kingdra",
        "Dragonite",
    };
    private string[] PropertyNames =
    {
        "Noctowl",
        "Pidgeotto",
        "Poke Ball",
        "Pinsir",
        "Heracross",
        "Scizor",
        "Clefable",
        "Raikou",
        "Girafarig",
        "Miltank",
        "Great Ball",
        "Gastly",
        "Haunter",
        "Gengar",
        "Hitmonchan",
        "Hitmonlee",
        "Primeape",
        "Ultra Ball",
        "Magnemite",
        "Skarmory",
        "Suicune",
        "Steelix",
        "Seel",
        "Dewgong",
        "Piloswine",
        "Master Ball",
        "Kingdra",
        "Dragonite",
    };
}
