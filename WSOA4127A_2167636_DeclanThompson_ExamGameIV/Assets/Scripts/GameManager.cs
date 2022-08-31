using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GridScript grid;
    public float mouseX;
    public float mouseY;
    private float distance;
    public int money;
    public int populationLimit;
    public int population;
    public int date;
    private int startDate = 1;
    public int officeNumber;
    public TMP_Text moneyText;
    public TMP_Text popLimit;    
    public TMP_Text dateText;
    public int upkeepTotal;
    public TMP_Text upkeepText;

    private void Start()
    {
        grid = new GridScript(20, 20, 0.5f, new Vector3(-5f, -5));       
        moneyText.text = money.ToString();
        dateText.text = date.ToString();        
        date = startDate;
        StartCoroutine(Day());
        StartCoroutine(PopIncrease());
        StartCoroutine(Income());
    }

    private void Update()
    {
        popLimit.text = population.ToString() + "/" + populationLimit.ToString();
        upkeepText.text = upkeepTotal.ToString();
        moneyText.text = money.ToString();        

        if (Input.GetMouseButtonDown(0))
        {
            mouseX = GridScript.GetMouseWorldPosition().x;
            mouseY = GridScript.GetMouseWorldPosition().y;

            Debug.Log(grid.GetValue(GridScript.GetMouseWorldPosition()));         
            


        }

        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public int[] findDistance(float mouseX, float mouseY)
    {
        float shortestDistance = 1000, tmp;
        int[] shortestIndex = { -1, -1 };
        for (int i = 0; i < grid.worldTextPositionsX.Length; i++)
        {
            for (int k = 0; k < grid.worldTextPositionsY.Length; k++)
            {
                tmp = Mathf.Sqrt(Mathf.Pow((grid.worldTextPositionsX[i] - mouseX), 2) + Mathf.Pow((grid.worldTextPositionsY[k] - mouseY), 2));
                if (shortestDistance > tmp)
                {
                    shortestDistance = tmp;
                    shortestIndex[0] = i;
                    shortestIndex[1] = k;
                }
            }
        }
        return shortestIndex;
    }

    IEnumerator Day()
    {
        yield return new WaitForSeconds(24f);
        money = money - upkeepTotal;
        date += 1;
        dateText.text = date.ToString();
        StartCoroutine(Day());

    }

    public IEnumerator PopIncrease()
    {
        yield return new WaitForSeconds(1f);

        if (population < populationLimit)
        {
            
            population += 1;            
        }

        StartCoroutine(PopIncrease());

    }

    public IEnumerator Income()
    {
        yield return new WaitForSeconds(1f);

        money += (officeNumber * population * (this.GetComponent<SliderScript>().happiness/10));

        StartCoroutine(Income());
    }

}
