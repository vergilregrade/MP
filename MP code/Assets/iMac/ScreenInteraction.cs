using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScreenInteraction : MonoBehaviour
{
    private bool enable = false;

    private int nbColonne = 26;
    private int nbLingne = 7;
    private int currentLigne = 0;
    private int currentColonne = 0;
    //private string screen;
    private char[,] monitor;
    public TextMeshPro textDisplay;

    private bool inSwitchMode;


    private bool playerCollision;
    private GameObject player;
    public GameObject o_monitor;


    string head = ">";
    string currentCommand = "";





    void Start()
    {
        monitor = new char[nbLingne, nbColonne + 1];
        clearScreen();
        printMonitor();
        
    }
    void Update()
    {
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                enable = false;
                player.GetComponent<Move_Personnage>().setEnable(true);
                player.GetComponent<Move_Personnage>().SetCamEnable(true);
                o_monitor.GetComponent<Mac_collision_trigger>().setCamEnable(false);
                return;
            }
            string screen = Input.inputString;
            switch(screen[0])
            {
                case (char) 0:
                    return;
                case (char) 13://enter
                    nextCurrentLine(currentCommand);
                    action();
                    currentCommand = "";
                    printToMonitor(head);
                    break;
                case (char) 8://bask space
                    currentCommand = currentCommand.Remove(currentCommand.Length - 1);
                    break;
                default:
                    currentCommand += screen[0];
                    break;
            }
            clearCurrentLine(); printToMonitor(head);
            printToMonitor(currentCommand);
            printMonitor();

        }
    }
    private void printToMonitor(String s)
    {
        string toPrint = "";
        int total_len = currentColonne + s.Length;
        toPrint += (total_len > nbColonne) ? s.Substring(total_len - nbColonne) : s;
        foreach (char c in toPrint)
        {
            monitor[currentLigne, currentColonne] = c;
            currentColonne++;
        }
        
    }
    private void printMonitor()
    {
        string to_print = "";
        for (int y = 0; y < nbLingne; y++)
        {
            for (int x = 0; x < nbColonne; x++)
            {
                to_print += monitor[y, x];
            }
            to_print += '\n';
        }
        textDisplay.text = to_print;
    }
    private void nextCurrentLine(string s)
    {
        clearCurrentLine();
        printToMonitor(s);
        currentLigne++;
        currentColonne = 0;
    }
    private void clearCurrentLine()
    {
        for(int x = 0; x < nbColonne; x++)
        {
            monitor[currentLigne, x] = ' ';
        }
        currentColonne = 0;        
    }
    private void action()
    {
        nextCurrentLine("Oki");

    }
    //void Start()
    //{
    //    inSwitchMode = false;
    //    enable = false;
    //    //currentLigne = 0;
    //    //currentColonne = 0;
    //    nbLingne = 7;
    //    nbColonne = 26;//-7;
    //    screen = "ok";
    //    textDisplay.text = "Example Text";
    //    monitor = new char[nbLingne, nbColonne + 1];
    //    //for (int i = 0; i < nbLingne; i++)
    //    //{
    //    //    for (int j = 0; j < nbColonne + 1; j++)
    //    //    {
    //    //        if (j == nbColonne)
    //    //            monitor[i, j] = (char)0;
    //    //        else
    //    //            monitor[i, j] = ' ';
    //    //    }
    //    //}
    //    clearScreen();
    //    string to_print = "";
    //    for (int i = 0; i < nbLingne; i++)
    //    {
    //        if (i == currentLigne)
    //            to_print += (inSwitchMode)? "switch>":">";
    //        for (int j = 0; j < nbColonne; j++)
    //        {

    //            to_print += monitor[i, j];
    //        }
    //        to_print += '\n';
    //    }
    //    textDisplay.text = to_print;
    //}


    //void Update()
    //{
    //    if (enable)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Escape))
    //        {
    //            enable = false;
    //            player.GetComponent<Move_Personnage>().setEnable(true);
    //            player.GetComponent<Move_Personnage>().SetCamEnable(true);
    //            o_monitor.GetComponent<Mac_collision_trigger>().setCamEnable(false);
    //            return;
    //        }

    //        string to_print = "";
    //        for (int i = 0; i < nbLingne; i++)
    //        {
    //            if (i == currentLigne)
    //                to_print += (inSwitchMode) ? "switch>" : ">";
    //            for (int j = 0; j < nbColonne; j++)
    //            {

    //                to_print += monitor[i, j];
    //            }
    //            to_print += '\n';
    //        }
    //        textDisplay.text = to_print;

    //        screen = Input.inputString;
    //        foreach (char c in screen)
    //        {
    //            //print((int)c );
    //            if ((int)c == 13)//enter
    //            {
    //                monitor[currentLigne, nbColonne] = (char)currentColonne;
    //                string ret = traitementLigne(currentLigne);
    //                if (ret == "clear")
    //                {
    //                    clearScreen();
    //                    return;
    //                }

    //                if (currentLigne + 2 == nbLingne || currentLigne + 1 == nbLingne)
    //                {
    //                    for (int i = 0; i < nbLingne; i++)
    //                    {
    //                        for (int j = 0; j < nbColonne + 1; j++)
    //                        {
    //                            if (i == nbLingne - 1 || i == nbLingne - 2)
    //                            {
    //                                monitor[i, j] = (j == nbColonne) ? (char)0 : ' ';
    //                            }
    //                            else
    //                                monitor[i, j] = monitor[i + 2, j];
    //                        }
    //                    }
    //                }
    //                else
    //                    currentLigne = (currentLigne + 2) % nbLingne;
    //                currentColonne = 0;//(int)monitor[currentLigne, nbColonne];
    //                for (int i = 0; i < nbColonne + 1; i++)
    //                {
    //                    monitor[currentLigne - 1, i] = (i < ret.Length) ? ret[i] : ' ';
    //                }
    //            }
    //            else if ((int)c == 8)//supr
    //            {
    //                if (currentColonne == nbColonne - 1 && monitor[currentLigne, currentColonne] != ' ')
    //                    monitor[currentLigne, currentColonne] = ' ';
    //                else
    //                {
    //                    currentColonne = (currentColonne - 1 >= 0) ? currentColonne - 1 : 0;// (currentColonne - 1) % nbColonne;
    //                    monitor[currentLigne, currentColonne] = ' ';
    //                }

    //            }
    //            else
    //            {
    //                monitor[currentLigne, currentColonne] = c;
    //                if (currentColonne != nbColonne - 1)
    //                    currentColonne++; //= (currentColonne + 1) % nbColonne;
    //            }
    //            //print(c + " "+currentLigne.ToString()+ " " + currentColonne.ToString());
    //        }

    //        if (screen != "")
    //        {
    //            textDisplay.text = screen;

    //        }
    //    }
    //    //else
    //    //{
    //    //    if(playerCollision && Input.GetKeyDown(KeyCode.E))
    //    //    {
    //    //        enable = true;
    //    //        player.GetComponent<Move_Personnage>().setEnable(false);
    //    //    }
    //    //}
    //}


    private string traitementLigne(int cL)
    {
        string ligne = "";
        for(int i=0;i<nbColonne;i++)
        {
            //if (monitor[cL, i] != ' ')
            //{
                ligne += monitor[cL, i];
            //}
        }
        string[] strList = ligne.Split(' ');

        if(strList.Length > 0)
        {

            switch(strList[0])
            {
                case "bitE":
                    return "UwU";
                case "enable":
                    return (enableCisco(strList, 1));
            }
        }
        


        if(ligne == "bitE")
        {
            return "UwU";
        }
        else if(ligne == "cimac")
        {
            if(inSwitchMode)
            {
                return "error";
            }
            inSwitchMode = true;
            return "clear";
        }
        else if(ligne == "tracertNACU.com")
        {
            if(inSwitchMode)
                return "NACU.com - 176.230.23.1";
            return "error";
        }
        else if(ligne == "clear")
        {
            return "clear";
        }


        return "error";
    }
    private void clearScreen()
    {
        currentLigne = 0;
        currentColonne = 0;
        //for (int i = 0; i < nbLingne; i++)
        //{
        //    for (int j = 0; j < nbColonne + 1; j++)
        //    {
        //        if (j == nbColonne)
        //            monitor[i, j] = (char)0;
        //        else
        //            monitor[i, j] = ' ';
        //    }
        //}
        for(int y = 0; y < nbLingne;y++)
        {
            for(int x = 0; x < nbLingne; x++)
            {
                monitor[y, x] = ' ';
            }
        }
        printToMonitor(head);
    }
    //public void setPlayerTriggerEnter(GameObject p)
    //{
    //    player = p;
    //    playerCollision = true;
    //}

    //public void setPlayerTriggerEExit()
    //{
    //    playerCollision = false;
    //}

    public void SetEnable(GameObject p)
    {
        player = p;
        enable = true;
    }

    private string enableCisco(string[] str, int i)
    {
        if (inSwitchMode)
        {
            return "error";
        }
        inSwitchMode = true;
        return "clear";
    }

}
