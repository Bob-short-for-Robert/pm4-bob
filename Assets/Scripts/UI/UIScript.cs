using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIScript : MonoBehaviour
{
    public GameType gameType = GameType.Score;

    // If the scoreToWin is -1, the game becomes endless (no win conditions, but you could do game over)
    public int scoreToWin = 5;


    [Header("References (don't touch)")]
    //Right is used for the score in P1 games
    public Text numberLabels;

    public Text rightLabel, leftLabel;
    public Text winLabel;
    public GameObject statsPanel, gameOverPanel, winPanel;
    public Transform inventory;
    public GameObject resourceItemPrefab;


    // Internal variables to keep track of score, health, and resources, win state
    private int scores = 0;
    private int playersHealth = 12;

    private Dictionary<int, ResourceStruct>
        resourcesDict =
            new Dictionary<int, ResourceStruct>(); //holds a reference to all the resources collected, and to their UI

    private bool gameOver = false; //this gets changed when the game is won OR lost

    //version of the one below with one parameter to be able to connect UnityEvents
    public void AddOnePoint(int playerNumber)
    {
        AddPoints(playerNumber, 1);
    }


    public void AddPoints(int playerNumber, int amount = 1)
    {
        scores += amount;
        
        numberLabels.text = scores.ToString();

        if (gameType == GameType.Score
            && scores >= scoreToWin)
        {
            GameWon(playerNumber);
        }
    }

    //currently unused by other Playground scripts
    public void RemoveOnePoint(int playerNumber)
    {
        scores--;

        numberLabels.text = scores.ToString(); //with one player, the score is on the right
    }


    public void GameWon(int playerNumber)
    {
        // only set game over UI if game is not over
        if (!gameOver)
        {
            gameOver = true;
            winLabel.text = "Player " + ++playerNumber + " wins!";
            statsPanel.SetActive(false);
            winPanel.SetActive(true);
        }
    }


    public void GameOver()
    {
        // only set game over UI if game is not over
        if (!gameOver)
        {
            gameOver = true;
            statsPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }


    public void SetHealth(int amount)
    {
        playersHealth = amount;
        numberLabels.text = playersHealth.ToString();
    }


    public void ChangeHealth(int change)
    {
        SetHealth(playersHealth + change);

        if (gameType != GameType.Endless
            && playersHealth <= 0)
        {
            GameOver();
        }
    }


    //Adds a resource to the dictionary, and to the UI
    public void AddResource(int resourceType, int pickedUpAmount, Sprite graphics)
    {
        if (resourcesDict.ContainsKey(resourceType))
        {
            //update the dictionary key
            int newAmount = resourcesDict[resourceType].amount + pickedUpAmount;
            resourcesDict[resourceType].UIItem.ShowNumber(newAmount);
            resourcesDict[resourceType].amount = newAmount;
        }
        else
        {
            //create the UIItemScript and display the icon
            UIItemScript newUIItem = Instantiate<GameObject>(resourceItemPrefab).GetComponent<UIItemScript>();
            newUIItem.transform.SetParent(inventory, false);

            resourcesDict.Add(resourceType, new ResourceStruct(pickedUpAmount, newUIItem));

            resourcesDict[resourceType].UIItem.ShowNumber(pickedUpAmount);
            resourcesDict[resourceType].UIItem.DisplayIcon(graphics);
        }
    }


    //checks if a certain resource is in the inventory, in the needed quantity
    public bool CheckIfHasResources(int resourceType, int amountNeeded = 1)
    {
        if (resourcesDict.ContainsKey(resourceType))
        {
            if (resourcesDict[resourceType].amount >= amountNeeded)
            {
                return true;
            }
            else
            {
                //not enough
                return false;
            }
        }
        else
        {
            //resource not present
            return false;
        }
    }


    //to use only before checking that the resource is in the dictionary
    public void ConsumeResource(int resourceType, int amountNeeded = 1)
    {
        resourcesDict[resourceType].amount -= amountNeeded;
        resourcesDict[resourceType].UIItem.ShowNumber(resourcesDict[resourceType].amount);
    }

    public enum GameType
    {
        Score = 0,
        Life,
        Endless
    }
}


//just a virtual representation of the resources for the private dictionary
public class ResourceStruct
{
    public int amount;
    public UIItemScript UIItem;

    public ResourceStruct(int a, UIItemScript uiRef)
    {
        amount = a;
        UIItem = uiRef;
    }
}