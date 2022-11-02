using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PC
{
    SECU,
    TP
}

public enum SUB_PC
{
    NO,
    TP1,
    TP2,
    TP3
}

public class action : MonoBehaviour
{

    public PC pc;
    public SUB_PC sub_pc;
    private int etat = 0;

    bool switchEnable = false;
    bool accessMasterConsole = false;
    bool routUp = false;

    bool net1 = false;
    bool net2 = false;

    private void Start()
    {
        if(pc == PC.TP)
        {
            this.GetComponent<ScreenInteraction>().changeHead("MasterConsole>");
        }
    }

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
        com = com.ToLower();
        var comSplit = com.Split(" ");
        switch (etat)
        {
            case 0:
                switch (com)
                {
                    case "e621":
                        monitor.nextCurrentLine("red rocket OwO");
                        return;
                    case "access master console":
                        if (sub_pc == SUB_PC.TP2 || sub_pc == SUB_PC.TP1)
                        {
                            etat = 1;//connection switch
                            monitor.changeHead("Password:");
                        }
                        return;
                    case "config router-1":
                        if (accessMasterConsole)
                        {
                            etat = 2;//rout 1
                            monitor.changeHead("Router-1>");
                        }
                        else
                        {
                            monitor.nextCurrentLine("error");
                        }
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 1:
                switch (com)
                {
                    case "lafauteathanhtong":
                        monitor.nextCurrentLine("Granted");
                        etat = 0;
                        accessMasterConsole = true;
                        monitor.changeHead("MasterConsole>");
                        return;
                    default:
                        monitor.nextCurrentLine("wrong password");
                        monitor.changeHead("MasterConsole>");
                        etat = 0;
                        return;
                }
            case 2:
                switch (com)
                {
                    case "enable":
                        monitor.changeHead("Router-1#");
                        etat = 3;
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 3:
                switch (com)
                {
                    case "configure terminal":
                        monitor.changeHead("Router-1(config)#");
                        etat = 4;
                        return;
                    case "conf t":
                        monitor.changeHead("Router-1(config)#");
                        etat = 4;
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 4:
                switch (com)
                {
                    case "interface fa0/0":
                        monitor.changeHead("Router-1(config-if)#");
                        etat = 5;
                        return;
                    case "router rip":
                        if (routUp)
                        {
                            monitor.changeHead("Router-1(config-rip)#");
                            etat = 7;
                            return;
                        }
                        monitor.nextCurrentLine("error");
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 5:
                if (comSplit.Length != 0)
                {
                    switch (comSplit[0])
                    {
                        case "ip":
                            if (comSplit.Length != 4)
                            {
                                monitor.nextCurrentLine("invalide format");
                                return;
                            }
                            if (comSplit[1] == "adresse" && (comSplit[2] != "192.168.1.254" || comSplit[3] != "255.255.255.0"))
                            {
                                monitor.nextCurrentLine("invalide ip");
                                return;
                            }
                            monitor.changeHead("Router-1(config-if)#");
                            etat = 6;
                            return;
                        case "exit":
                            monitor.changeHead("Router-1(config)#");
                            etat = 4;
                            return;
                        default:
                            monitor.nextCurrentLine("error");
                            return;
                    }
                }
                return;
            case 6:
                switch (com)
                {
                    case "no shutdown":
                        monitor.nextCurrentLine("Changed State of fa0/0");
                        monitor.nextCurrentLine("fa0/1 from DOWN to UP");
                        etat = 5;
                        routUp = true;
                        return;
                    case "no sh":
                        monitor.nextCurrentLine("Changed State of fa0/0");
                        monitor.nextCurrentLine("fa0/1 from DOWN to UP");
                        etat = 5;
                        routUp = true;
                        return;
                    case "exit":
                        monitor.changeHead("Router-1(config)#");
                        etat = 4;
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 7:
                switch (com)
                {
                    case "version 2":
                        etat = 9;
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 8:
                switch (com)
                {
                    case "version 2":
                        etat = 9;
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 9:
                switch (com)
                {
                    case "network 192.168.1.0":
                        net1 = true;

                        if (net1 && net2)
                        {
                            etat = 10;
                        }
                        return;
                    case "network 11.0.0.0":
                        net2 = true;

                        if (net1 && net2)
                        {
                            etat = 10;
                        }
                        return;
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
            case 10:
                switch (com)
                {
                    default:
                        monitor.nextCurrentLine("error");
                        return;
                }
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
