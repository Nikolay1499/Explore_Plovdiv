using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField inputFirstName;
    public InputField inputFamilyName;
    public InputField inputEmail;
    public InputField inputPassword;
    public InputField inputConfirmPassword;

    public Text firstNameError;
    public Text familyNameError;
    public Text emailError;
    public Text passwordError;
    public Text confirmError;

    private string url = "https://explore-plovdiv.000webhostapp.com/register.php";
    private string message;
    private int landmarksCount = 27;
    private int achievementsCount = 13;

    public void NewUser()
    {
        StartCoroutine(RegisterUser());
    }

    void ResetErrorText()
    {
        firstNameError.gameObject.SetActive(false);
        familyNameError.gameObject.SetActive(false);
        emailError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
        confirmError.gameObject.SetActive(false);
    }

    bool ValidateData()
    {
        bool valid = true;
        ResetErrorText();

        if (inputFirstName.text=="")
        {
            valid = false;
            firstNameError.gameObject.SetActive(true);
        }

        if(inputFamilyName.text == "")
        {
            valid = false;
            familyNameError.gameObject.SetActive(true);
        }

        if(inputEmail.text == "")
        {
            valid = false;
            emailError.gameObject.SetActive(true);
        }
        else if(!inputEmail.text.Contains("@")|| !inputEmail.text.Contains("."))
        {
            valid = false;
            emailError.text = "Невалиден имейл адрес!";
            emailError.gameObject.SetActive(true);
        }

        if(inputPassword.text == "")
        {
            valid = false;
            passwordError.gameObject.SetActive(true);
        }
        else if(inputPassword.text.Length<6)
        {
            valid = false;
            passwordError.text = "Паролата е твърде кратка!";
            passwordError.gameObject.SetActive(true);
        }
        else if (inputConfirmPassword.text == "" || inputConfirmPassword.text!=inputPassword.text)
        {
            valid = false;
            confirmError.gameObject.SetActive(true);
        }

        return valid;
    }

    IEnumerator RegisterUser()
    {
        if(ValidateData())
        {
            WWWForm form = new WWWForm();
            form.AddField("firstName", inputFirstName.text);
            form.AddField("familyName", inputFamilyName.text);
            form.AddField("email", inputEmail.text);
            form.AddField("password", inputPassword.text);
            form.AddField("landmarksCount", landmarksCount);
            form.AddField("achievementsCount", achievementsCount);
            WWW www = new WWW(url, form);
            yield return www;
            message = www.text;
            if(message== "Имейлът вече е зает!")
            {
                emailError.text = message;
                emailError.gameObject.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetString("userEmail", inputEmail.text);
                PlayerPrefs.SetInt("colourId", 0);
                PlayerPrefs.Save();
                SceneManager.LoadSceneAsync("MapScene");
            }
        }
    }

    void AddLandmarksRecords()
    {
  
    }
}
