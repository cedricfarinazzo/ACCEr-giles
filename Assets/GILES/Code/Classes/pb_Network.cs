using SMNetwork.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pb_Network : MonoBehaviour {

    public SMNetwork.Client.Client smClient;

    public void Start()
    {
        try
        {
            smClient = new Client();
            SMNetwork.Client.DataClient.Email = SaveData.SaveData.GetString("DataClient.Email");
            SMNetwork.Client.DataClient.Token = SaveData.SaveData.GetString("DataClient.Token");
            SMNetwork.Client.DataClient.User = SaveData.SaveData.GetObject<SMNetwork.DataUser>("DataClient.User");
            if (smClient.AskMyProfil() == null)
            {
                SceneManager.LoadScene("connexion");
            }
        }
        catch (UnityException)
        {
            Debug.Log("failed to join server");
            SceneManager.LoadScene("failedNetwork");
        }
        catch (Exception)
        {
            Debug.Log("Failed to join server");
            SceneManager.LoadScene("failedNetwork");

        }
    }
}
