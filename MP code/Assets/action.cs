using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PC
{
    SECU,
    TP
}

public class action : MonoBehaviour
{

    public PC pc;
    private int etat = 0;

    bool switchEnable = false;

    public void exec(string com)
    {
        var monito = this.GetComponent<ScreenInteraction>();
        var comSplit = com.Split(" ");
        print(comSplit[0]);
        switch(comSplit[0])
        {
            case "":
                return;
            case "clear":
                monito.clearScreen();
                return;
            case "ls":
                my_ls(monito);
                return;
            case "cat":
                my_cat(com,monito);
                return;
        }
        

        switch (pc)
        {
            case PC.SECU:
                defaultSecu(com, monito);
                return;
            case PC.TP:
                defaultTP(com, monito);
                return;
        }


        
        monito.nextCurrentLine("error");
        return;
    }

    private void defaultSecu(string com, ScreenInteraction monitor)
    {
        var comSplit = com.Split(" ");
        switch (etat)
        {
            case 0:
                switch (comSplit[0])
                {
                    case "bitE":
                        monitor.nextCurrentLine("UwU");
                        return;
                    case "enable":
                        if (etat == 0)//etat par default
                        {
                            etat = 1;//etat connecter switch cisco
                            monitor.changeHead("switch$");
                        }
                        return;
                    case "ssh":
                        if (!switchEnable && (comSplit[1] == "172.83.236.1" || (comSplit[1] == "-l" && comSplit[2] == "172.83.236.1")))
                        {
                            monitor.nextCurrentLine("ip unreachables");
                            break;
                        }
                        etat = 2;//ssh username
                        monitor.changeHead("user :");
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
                break;
            case 1: //connect switch
                switch (com)
                {
                    case "traceroute NACU.com":
                        if(!switchEnable)
                        {
                            monitor.nextCurrentLine("ip unreachables");
                            break;
                        }
                        monitor.nextCurrentLine("172.83.236.1");
                        break;
                    case "exit":
                        etat = 0;
                        monitor.changeHead("$");
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 2:
                if(com != "admin")
                {
                    monitor.nextCurrentLine("user invalid");
                    return;
                }
                etat = 3;//ssh password;
                monitor.changeHead("password :");
                break;
            case 3:
                if(com != "admin")
                {
                    monitor.nextCurrentLine("password invalid");
                    etat = 0;
                    monitor.changeHead("&");
                    return;
                }
                etat = 4;//ssh connected
                monitor.changeHead("PC Accueil$");
                break;
            case 4:
                switch(com)
                {
                    case "exit":
                        etat = 0;
                        monitor.changeHead("&");
                        break;
                }
                break;
        }
    }


    private void defaultTP(string com, ScreenInteraction monitor)
    {
        switch (com)
        {
            case "e621":
                monitor.nextCurrentLine("red rocket OwO");
                return;
            default:
                monitor.nextCurrentLine("error");
                return;
        }
    }


    private void my_ls(ScreenInteraction monitor)
    {
        switch(etat)
        {
            case 4:
                monitor.nextCurrentLine("code_porte_secu.txt");
                break;
        }
    }

    private void my_cat(string com, ScreenInteraction monitor)
    {
        switch(etat)
        {
            case 4:
                switch(com)
                {
                    case "cat code_porte_secu.txt":
                        monitor.nextCurrentLine("le code est 3621");
                        break;
                }
                break;
        }
    }

    public void enableSwitch(bool b)
    {
        switchEnable = b;
        print("switch state " + b.ToString());
    }

}
