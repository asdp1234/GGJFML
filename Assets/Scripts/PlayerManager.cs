using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used by the AI (while attacheck to the 
// Player), which makes it easier for the AI to find the 
// GO needed
// So, attack this to the player, please
public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

}
