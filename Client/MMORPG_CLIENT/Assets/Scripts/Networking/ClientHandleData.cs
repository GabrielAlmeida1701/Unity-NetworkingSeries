using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientHandleData : MonoBehaviour
{

    public static ClientHandleData instance;

    private void Awake()
    {
        instance = this;
    }

    void HandleMessages(int packetNum, byte[] data)
    {
        switch (packetNum)
        {
            case 1:
                HandleAlertMsg(packetNum, data);
                break;
            case 2:
                
                break;
            case 3:
                break;
        }
    }

    public void HandleData(byte[] data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        buffer = null;
        if (packetnum == 0)
            return;

        HandleMessages(packetnum, data);
    }

    void HandleAlertMsg(int packetNum, byte[]data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();

        string AlertMsg = buffer.ReadString();

        Debug.Log(AlertMsg);
    }
}
