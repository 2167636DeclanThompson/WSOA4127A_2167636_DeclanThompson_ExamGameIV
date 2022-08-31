using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingScript : MonoBehaviour
{
    public string Name;
    public int Cost;
    public int Upkeep;
    public string statUp;
    public string statDown;
    public GameObject gameManager;
    public bool isPopIncreasing = false;

    public enum BuildingType
    {
        Road,
        WaterTower,
        PowerPlant,
        Apartment,
        Office,
        Factory,
        Hospital,
        PoliceStation,
        FireStation,
        School,
        University,
        Library,
        Cinema,
        Bar,
        Park,
        GarbageDisposal
    }
    
    public BuildingType buildingType = BuildingType.Road;

    
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        if (buildingType == BuildingType.Apartment)
        {
            gameManager.GetComponent<GameManager>().populationLimit = gameManager.GetComponent<GameManager>().populationLimit + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;            
        }
        else if (buildingType == BuildingType.Office)
        {
            gameManager.GetComponent<GameManager>().officeNumber = gameManager.GetComponent<GameManager>().officeNumber + 2;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Factory)
        {
            gameManager.GetComponent<GameManager>().officeNumber = gameManager.GetComponent<GameManager>().officeNumber + 1;
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Hospital)
        {
            gameManager.GetComponent<SliderScript>().health = gameManager.GetComponent<SliderScript>().health + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.PoliceStation)
        {
            gameManager.GetComponent<SliderScript>().safety = gameManager.GetComponent<SliderScript>().safety + 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.FireStation)
        {
            gameManager.GetComponent<SliderScript>().safety = gameManager.GetComponent<SliderScript>().safety + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.School)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education + 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.University)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education + 15;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Library)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Cinema)
        {
            gameManager.GetComponent<SliderScript>().fun = gameManager.GetComponent<SliderScript>().fun + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Bar)
        {
            gameManager.GetComponent<SliderScript>().fun = gameManager.GetComponent<SliderScript>().fun + 10;
            gameManager.GetComponent<SliderScript>().health = gameManager.GetComponent<SliderScript>().health - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.Park)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.GarbageDisposal)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment + 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.PowerPlant)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment - 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
        else if (buildingType == BuildingType.WaterTower)
        {
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal + Upkeep;
        }
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (buildingType == BuildingType.Apartment)
        {
            gameManager.GetComponent<GameManager>().populationLimit = gameManager.GetComponent<GameManager>().populationLimit - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
            gameManager.GetComponent<GameManager>().population = gameManager.GetComponent<GameManager>().population - 5;
        }
        else if (buildingType == BuildingType.Office)
        {
            gameManager.GetComponent<GameManager>().officeNumber = gameManager.GetComponent<GameManager>().officeNumber - 2;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Factory)
        {
            gameManager.GetComponent<GameManager>().officeNumber = gameManager.GetComponent<GameManager>().officeNumber - 1;
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Hospital)
        {
            gameManager.GetComponent<SliderScript>().health = gameManager.GetComponent<SliderScript>().health - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.PoliceStation)
        {
            gameManager.GetComponent<SliderScript>().safety = gameManager.GetComponent<SliderScript>().safety - 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.FireStation)
        {
            gameManager.GetComponent<SliderScript>().safety = gameManager.GetComponent<SliderScript>().safety - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.School)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education - 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.University)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education - 15;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Library)
        {
            gameManager.GetComponent<SliderScript>().education = gameManager.GetComponent<SliderScript>().education - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Cinema)
        {
            gameManager.GetComponent<SliderScript>().fun = gameManager.GetComponent<SliderScript>().fun - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Bar)
        {
            gameManager.GetComponent<SliderScript>().fun = gameManager.GetComponent<SliderScript>().fun - 10;
            gameManager.GetComponent<SliderScript>().health = gameManager.GetComponent<SliderScript>().health + 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.Park)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment - 5;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.GarbageDisposal)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment - 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.PowerPlant)
        {
            gameManager.GetComponent<SliderScript>().environment = gameManager.GetComponent<SliderScript>().environment + 10;
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }
        else if (buildingType == BuildingType.WaterTower)
        {
            gameManager.GetComponent<GameManager>().upkeepTotal = gameManager.GetComponent<GameManager>().upkeepTotal - Upkeep;
        }

    }

    

}
