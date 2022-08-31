using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingPlacement : MonoBehaviour
{
    public GameObject building;
    private GameManager gameManager;
    public RaycastHit2D rayCast;
    public TMP_Text text;
    public int destroyCost;

    private void Start()
    {
        gameManager = this.GetComponent<GameManager>();
    }

    private void Update()
    {
        Vector3 mousePosition = new Vector3(gameManager.grid.worldTextPositionsX[gameManager.findDistance(gameManager.mouseX, gameManager.mouseY)[0]], gameManager.grid.worldTextPositionsY[gameManager.findDistance(gameManager.mouseX, gameManager.mouseY)[1]], 0);
        int xPosition = gameManager.findDistance(gameManager.mouseX, gameManager.mouseY)[0];
        int yPosition = gameManager.findDistance(gameManager.mouseX, gameManager.mouseY)[1];

        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.grid.IsPointerOverUI() == false)
            {
                if (building != null)
                {
                    if (building.GetComponent<BuildingScript>().Cost < gameManager.money)
                    {
                        if (gameManager.grid.GetValue(GridScript.GetMouseWorldPosition()) == 0)
                        {
                            mousePosition.z = 1;
                            Debug.Log(mousePosition);
                            Instantiate(building, mousePosition, Quaternion.identity);
                            gameManager.money = gameManager.money - building.GetComponent<BuildingScript>().Cost;
                            gameManager.moneyText.text = gameManager.money.ToString();
                            gameManager.grid.SetValue(GridScript.GetMouseWorldPosition(), 1);
                        }
                        else
                        {
                            text.text = "Can’t place here!";
                        }
                    }
                    else
                    {
                        text.text = "Not enough money!";
                    }


                }
                else
                {
                    text.text = "No building selected!";
                }
            }
            else
            {
                text.text = "";
            }
            
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gameManager.grid.GetValue(GridScript.GetMouseWorldPosition()) != 0)
            {
                if (destroyCost < gameManager.money)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null)
                    {
                        gameManager.grid.SetValue(GridScript.GetMouseWorldPosition(), 0);
                        Destroy(hit.collider.gameObject);
                        gameManager.money = gameManager.money - destroyCost;
                        gameManager.moneyText.text = gameManager.money.ToString();
                    }
                    else
                    {
                        text.text = "Nothing to destroy!";
                    }
                }
                else
                {
                    text.text = "Not enough money!";
                }
                
            }
            else 
            {
                text.text = "Nothing to destroy!";
            }

            
        }





    }
}


