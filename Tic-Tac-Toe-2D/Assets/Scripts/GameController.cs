using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int playerTurn; // 0 = X and 1 = O
    public int turnCount; // counts the number of turns played
    public GameObject[] turnIcons; // holds both turnIcons and displays who's turn it is
    public Sprite[] playerIcons; // 0 = X icon and 1 = O icon
    public Button[] tictactoeGridSpaces; // playable spaces on our grid

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
