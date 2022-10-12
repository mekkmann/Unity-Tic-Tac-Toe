using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

    public int playerTurn; // 0 = X and 1 = O
    public int turnCount; // counts the number of turns played
    public GameObject[] turnIcons; // holds both turnIcons and displays who's turn it is
    public Sprite[] playerIcons; // 0 = X icon and 1 = O icon
    public Button[] tictactoeGridSpaces; // playable spaces on our grid
    public int[] markedSpaces; // ID's which space was marked by who
    public TMP_Text winnerText; // holds the text component of the winner text
    public GameObject[] winningLines; // holds all different lines for showing when someone wins
    public GameObject winnerPanel; // holds the winner panel
    public int xScore; // holds player x total score for the session
    public int oScore; // holds player o total score for the session
    public TMP_Text xPlayerScoreText; // holds text for player x score
    public TMP_Text oPlayerScoreText; // holds text for player o score


    // Start is called before the first frame updates
    void Start()
    {
        GameSetup();
    }

    private void GameSetup()
    {
        playerTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0; i < tictactoeGridSpaces.Length; i++)
        {
            tictactoeGridSpaces[i].interactable = true;
            tictactoeGridSpaces[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseField(int chosenField)
    {
        tictactoeGridSpaces[chosenField].image.sprite = playerIcons[playerTurn];
        tictactoeGridSpaces[chosenField].interactable = false;

        markedSpaces[chosenField] = playerTurn + 1;

        turnCount++;

        if(turnCount > 4)
        {
            WinnerCheck();
        }

        ChangePlayerTurn();
    }

    private void ChangePlayerTurn()
    {
        if(playerTurn == 0)
        {
            playerTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);

        } 
        else
        {
            playerTurn = 0;
            turnIcons[1].SetActive(false);
            turnIcons[0].SetActive(true);
        }
    }

    private void WinnerCheck()
    {
        var solution1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2]; //H1
        var solution2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5]; //H2
        var solution3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8]; //H3
        var solution4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6]; //V1
        var solution5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7]; //V2
        var solution6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8]; //V3
        var solution7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8]; //D1
        var solution8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6]; //D2

        var solutions = new int[] {solution1, solution2, solution3, solution4, solution5, solution6, solution7, solution8 };
    
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (playerTurn + 1))
            {
                WinnerDisplay(i);
                return;
            }
        }
    }

    private void WinnerDisplay(int solutionIndex)
    {
        if (playerTurn == 0)
        {
            xScore++;
            xPlayerScoreText.text = xScore.ToString();
            winnerText.text = "Player X wins!";
        }
        if (playerTurn == 1) 
        { 
            oScore++;
            oPlayerScoreText.text = oScore.ToString();
            winnerText.text = "Player O wins!";
        }
        winnerPanel.SetActive(true);
        winningLines[solutionIndex].SetActive(true);
    }

    public void Rematch()
    {
        GameSetup();
        for(int i = 0; i < winningLines.Length; i++)
        {
            winningLines[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
    }

    public void Restart()
    {
        Rematch();
        xScore = 0;
        oScore = 0;
        xPlayerScoreText.text = "0";
        oPlayerScoreText.text = "0";
    }
}
