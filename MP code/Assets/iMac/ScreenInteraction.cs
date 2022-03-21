using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenInteraction : MonoBehaviour
{
    private bool enable;

    private int nbColonne;
    private int nbLingne;
    private int currentLigne;
    private int currentColonne;
    private string screen;
    private char[,] monitor;
    public TextMeshPro textDisplay;


    private bool playerCollision;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enable = false;
        currentLigne = 0;
        currentColonne = 0;
        nbLingne = 7;
        nbColonne = 26;
        screen = "ok";
        textDisplay.text = "Example Text";
        monitor = new char[nbLingne, nbColonne + 1];
        for (int i = 0; i < nbLingne; i++)
        {
            for (int j = 0; j < nbColonne + 1; j++)
            {
                if (j == nbColonne)
                    monitor[i, j] = (char)0;
                else
                    monitor[i, j] = ' ';
            }
        }

        string to_print = "";
        for (int i = 0; i < nbLingne; i++)
        {
            if (i == currentLigne)
                to_print += '>';
            for (int j = 0; j < nbColonne; j++)
            {

                to_print += monitor[i, j];
            }
            to_print += '\n';
        }
        textDisplay.text = to_print;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                enable = false;
                player.GetComponent<Move_Personnage>().setEnable(true);
                return;
            }

            string to_print = "";
            for (int i = 0; i < nbLingne; i++)
            {
                if (i == currentLigne)
                    to_print += '>';
                for (int j = 0; j < nbColonne; j++)
                {

                    to_print += monitor[i, j];
                }
                to_print += '\n';
            }
            textDisplay.text = to_print;

            screen = Input.inputString;
            foreach (char c in screen)
            {
                //print((int)c );
                if ((int)c == 13)
                {
                    monitor[currentLigne, nbColonne] = (char)currentColonne;
                    currentLigne = (currentLigne + 1) % nbLingne;
                    currentColonne = (int)monitor[currentLigne, nbColonne];
                }
                else if ((int)c == 8)
                {
                    if(currentColonne == nbColonne-1 && monitor[currentLigne, currentColonne] != ' ')
                        monitor[currentLigne, currentColonne] = ' ';
                    else
                    {
                        currentColonne = (currentColonne - 1 >= 0) ? currentColonne - 1 : 0;// (currentColonne - 1) % nbColonne;
                        monitor[currentLigne, currentColonne] = ' ';
                    }
                    
                }
                else
                {
                    monitor[currentLigne, currentColonne] = c;
                    if (currentColonne != nbColonne - 1)
                        currentColonne++; //= (currentColonne + 1) % nbColonne;
                }
                //print(c + " "+currentLigne.ToString()+ " " + currentColonne.ToString());
            }

            if (screen != "")
            {
                textDisplay.text = screen;

            }
        }
        else
        {
            if(playerCollision && Input.GetKeyDown(KeyCode.E))
            {
                enable = true;
                player.GetComponent<Move_Personnage>().setEnable(false);
            }
        }
    }

    public void setPlayerTriggerEnter(GameObject p)
    {
        player = p;
        playerCollision = true;
    }

    public void setPlayerTriggerEExit()
    {
        playerCollision = false;
    }

}
