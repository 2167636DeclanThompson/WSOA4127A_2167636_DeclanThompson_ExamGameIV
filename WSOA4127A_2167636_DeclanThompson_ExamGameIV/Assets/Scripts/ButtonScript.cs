using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    private BuildingScript buildingScript;
    public GameObject gameManager;
    public GameObject building;
    public TMP_Text Name;
    public Image image;
    public TMP_Text cost;
    public TMP_Text upkeep;
    public TMP_Text statUp;
    public TMP_Text statDown;
        
    public void PressButton()
    {
        gameManager.GetComponent<BuildingPlacement>().building = building;
        Name.text = building.GetComponent<BuildingScript>().Name;
        cost.text = building.GetComponent<BuildingScript>().Cost.ToString();
        image.sprite = building.GetComponent<SpriteRenderer>().sprite;
        upkeep.text = building.GetComponent<BuildingScript>().Upkeep.ToString();
        statUp.text = building.GetComponent<BuildingScript>().statUp;
        statDown.text = building.GetComponent<BuildingScript>().statDown;
    }
}
