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

    public GameObject pc2actine = null; 
    

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
                    case "en":
                        if (etat == 0)//etat par default
                        {
                            etat = 1;//etat connecter switch cisco
                            monitor.changeHead("switch$");
                        }
                        return;
                    case "ssh":
                        if (!switchEnable && (comSplit[1] == "SSH" || (comSplit[2] == "-l" && comSplit[3] == "172.83.236.1")))
                        {
                            monitor.nextCurrentLine("ip unreachable");
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
                            monitor.nextCurrentLine("ip unreachable");
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
                        break;
                    case "access master console":
                        if (sub_pc == SUB_PC.TP2 || sub_pc == SUB_PC.TP1)
                        {
                            etat = 1;//connection switch
                            monitor.changeHead("Password:");
                        }
                        break;
                    case "config router-1":
                        if (accessMasterConsole && sub_pc == SUB_PC.TP1)
                        {
                            etat = 2;//rout 1
                            monitor.changeHead("Router-1>");
                        }
                        else
                        {
                            monitor.nextCurrentLine("error");
                        }
                        break;
                    case "config router-2":
                        if (accessMasterConsole && sub_pc == SUB_PC.TP2)
                        {
                            etat = 2;//rout 1
                            monitor.changeHead("Router-2>");
                        }
                        else
                        {
                            monitor.nextCurrentLine("error");
                        }
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 1:
                switch (com)
                {
                    case "lafauteathanhtong":
                        monitor.nextCurrentLine("Granted");
                        etat = 0;
                        accessMasterConsole = true;
                        monitor.changeHead("Master Console>");
                        break;
                    default:
                        monitor.nextCurrentLine("wrong password");
                        monitor.changeHead("Master Console>");
                        etat = 0;
                        break;
                }
                break;
            case 2:
                switch (com)
                {
                    case "enable":
                        if(sub_pc == SUB_PC.TP1)
                            monitor.changeHead("Router-1#");
                        else
                            monitor.changeHead("Router-2#");
                        etat = 3;
                        break;
                    case "en":
                        if (sub_pc == SUB_PC.TP1)
                            monitor.changeHead("Router-1#");
                        else
                            monitor.changeHead("Router-2#");
                        etat = 3;
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 3:
                switch (com)
                {
                    case "configure terminal":
                        if (sub_pc == SUB_PC.TP1)
                            monitor.changeHead("Router-1(config)#");
                        else
                            monitor.changeHead("Router-2(config)#");
                        etat = 4;
                        break;
                    case "conf t":
                        if (sub_pc == SUB_PC.TP1)
                            monitor.changeHead("Router-1(config)#");
                        else
                            monitor.changeHead("Router-2(config)#");
                        etat = 4;
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 4:
                switch (com)
                {
                    case "interface fa0/0":
                        if (sub_pc == SUB_PC.TP1)
                        {
                            monitor.changeHead("Router-1(config-if)#");
                            etat = 5;
                        }else
                            monitor.nextCurrentLine("error");
                        break;
                    case "int fa0/0":
                        if (sub_pc == SUB_PC.TP1)
                        {
                            monitor.changeHead("Router-1(config-if)#");
                            etat = 5;
                        }
                        else
                            monitor.nextCurrentLine("error");
                        break;
                    case "interface se0/0":
                        if (sub_pc == SUB_PC.TP2)
                        {
                            monitor.changeHead("Router-2(config-if)#");
                            etat = 5;
                        }
                        else
                            monitor.nextCurrentLine("error");
                        break;
                    case "int se0/0":
                        if (sub_pc == SUB_PC.TP2)
                        {
                            monitor.changeHead("Router-2(config-if)#");
                            etat = 5;
                        }
                        else
                            monitor.nextCurrentLine("error");
                        break;
                    case "router rip":
                        if (routUp)
                        {
                            if(sub_pc == SUB_PC.TP1)
                                monitor.changeHead("Router-1(config-rip)#");
                            else
                                monitor.changeHead("Router-2(config-rip)#");
                            etat = 7;
                            break;
                        }
                        monitor.nextCurrentLine("error");
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 5:
                if (comSplit.Length != 0)
                {
                    switch (comSplit[0])
                    {
                        case "ip":
                            if (comSplit.Length != 4)
                            {
                                monitor.nextCurrentLine("invalid format");
                                break;
                            }
                            if (sub_pc == SUB_PC.TP1 && 
                                comSplit[1] == "address" &&
                                comSplit[2] == "192.168.1.254" &&
                                comSplit[3] == "255.255.255.0")
                            {
                                monitor.changeHead("Router-1(config-if)#");
                                etat = 6;
                                break;
                            }
                            if (sub_pc == SUB_PC.TP2 &&
                                comSplit[1] == "address" &&
                                comSplit[2] == "11.0.0.254" &&
                                comSplit[3] == "255.0.0.0")
                            {
                                monitor.changeHead("Router-2(config-if)#");
                                etat = 6;
                                break;
                            }
                            monitor.nextCurrentLine("invalid format");
                            break;

                        case "exit":
                            if(sub_pc == SUB_PC.TP1)
                                monitor.changeHead("Router-1(config)#");
                            else
                                monitor.changeHead("Router-2(config)#");
                            etat = 4;
                            break;
                        default:
                            monitor.nextCurrentLine("error");
                            break;
                    }
                }
                break;
            case 6:
                switch (com)
                {
                    case "no shutdown":
                        if (sub_pc == SUB_PC.TP1)
                        {
                            monitor.nextCurrentLine("Changed State of fa0/0");
                            monitor.nextCurrentLine("fa0/1 from DOWN to UP");
                        }else
                        {
                            monitor.nextCurrentLine("Changed State of se0/0");
                            monitor.nextCurrentLine("se0/1 from DOWN to UP");
                        }
                        etat = 5;
                        routUp = true;
                        break;
                    case "no sh":
                        if (sub_pc == SUB_PC.TP1)
                        {
                            monitor.nextCurrentLine("Changed State of fa0/0");
                            monitor.nextCurrentLine("fa0/1 from DOWN to UP");
                        }
                        else
                        {
                            monitor.nextCurrentLine("Changed State of se0/0");
                            monitor.nextCurrentLine("se0/1 from DOWN to UP");
                        }
                        etat = 5;
                        routUp = true;
                        break;
                    case "exit":
                        if(sub_pc == SUB_PC.TP1)
                            monitor.changeHead("Router-1(config)#");
                        else
                            monitor.changeHead("Router-2(config)#");
                        etat = 4;
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 7:
                switch (com)
                {
                    case "version 2":
                        etat = 9;
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 8:
                switch (com)
                {
                    case "version 2":
                        etat = 9;
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 9:
                switch (com)
                {
                    case "network 192.168.1.0":
                        net1 = true;

                        if (net1 && net2)
                        {
                            etat = 10;
                        }
                        break;
                    case "network 11.0.0.0":
                        net2 = true;

                        if (net1 && net2)
                        {
                            etat = 10;
                        }
                        break;
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
            case 10:
                switch (com)
                {
                    default:
                        monitor.nextCurrentLine("error");
                        break;
                }
                break;
        }

        if (endConfig() && pc2actine != null)
        {
            pc2actine.GetComponent<ScreenInteraction>().changeEnableComputer();
        }
    }


    private void my_ls(ScreenInteraction monitor)
    {
        if(pc == PC.SECU)
            switch(etat)
            {
                case 4:
                    monitor.nextCurrentLine("code_porte_secu.txt");
                    break;
            }
        else if (sub_pc == SUB_PC.TP3)
        {
            monitor.nextCurrentLine("code_porte_tp.txt");
        }
    }

    private void my_cat(string com, ScreenInteraction monitor)
    {
        if (pc == PC.SECU)
            switch (etat)
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
        else if (sub_pc == SUB_PC.TP3 && com == "cat code_porte_tp.txt")
        {
            monitor.nextCurrentLine("le code est 1235");
        }
    }

    public void enableSwitch(bool b)
    {
        switchEnable = b;
    }

    public bool endConfig()
    {
        return routUp && net1 && net2;
    }

}
