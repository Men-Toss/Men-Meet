using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySoundScript : MonoBehaviour
{
    public AudioSource LobbyAudio;
    public void setSound(int index)
    {
        // 0: 0 / 1 : 33 / 2 : 66 / 3 : 99 
        switch (index)
        {
            case 0: LobbyAudio.volume = 0f; break;
            case 1: LobbyAudio.volume = 0.33f; break;
            case 2: LobbyAudio.volume = 0.66f; break;
            case 3: LobbyAudio.volume = 0.99f; break;
        }
    }
}
