using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClientSendData : MonoBehaviour
{
    public static ClientSendData instance;
    public Network network;

    [Header("Registration")]
    public Text _username;
    public Text _password;

    [Header("Login")]
    public Text _loginUser;
    public Text _loginPass;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void SendDataToServer(byte[] data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        Network.instance.myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
        buffer = null;
    }

    public void SendNewAccount()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();

        buffer.WriteInteger(1);
        buffer.WriteString(_username.text);
        buffer.WriteString(_password.text);

        SendDataToServer(buffer.ToArray());
        buffer = null;
    }

    public void SendLogin()
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();

        buffer.WriteInteger(2);
        buffer.WriteString(_loginUser.text);
        buffer.WriteString(_loginPass.text);

        SendDataToServer(buffer.ToArray());
        buffer = null;
    }
}
