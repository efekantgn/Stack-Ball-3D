using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameSystem : MonoBehaviour
{
    [SerializeField] private UserData userData;
    private TMP_InputField usernameInput;

    public TMP_InputField UsernameInput
    {
        get
        {
            if (usernameInput == null)
                usernameInput = GetComponent<TMP_InputField>();

            return usernameInput;
        }

    }
    private void Start()
    {
        if (UsernameInput.text == "")
        {
            if (userData.Username != "")
                UsernameInput.text = userData.Username;
            else
            {
                UsernameInput.text = "Player_" + Random.Range(int.MinValue, int.MaxValue);
            }
        }

    }

    public void SetUsername()
    {
        userData.Username = UsernameInput.text;
    }
}
