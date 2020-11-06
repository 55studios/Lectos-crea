using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public static string User;
    public static string Password;

    public UserInfo(string UserName_, string Password_) {

        User = UserName_;
        PlayerPrefs.SetString("keyName",User);
        Password = Password_;
        PlayerPrefs.SetString("keyPassword",Password);
        Debug.Log(User + " " + Password + " " + "Data is saved successful");
        PlayerPrefs.Save();
    }
}
