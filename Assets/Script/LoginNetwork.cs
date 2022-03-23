//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using System.Text;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class LoginNetwork : MonoBehaviour
//{
//    public Text loginField;
//    public Text passwordField;


//    public void onLoginClick()
//    {
//        StartCoroutine(FindLogin(loginField.text, passwordField.text));
//    }

//    IEnumerator FindLogin(string login, string password)
//    {
//        WWWForm form = new WWWForm();
//        form.AddField("loginUser", login);
//        form.AddField("loginPass", password);

//        //Request.Get to get info, Request.Post to post info
//        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Login.php", form))
//        {
//            yield return www.Send();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);

//            }
//            else
//            {
//                Debug.Log(www.downloadHandler.text);

//                GlobalVar.currentUser = login;
//                Debug.Log(GlobalVar.currentUser);
//                SceneManager.LoadScene(0);

//            }

//        }
//    }

//    public void onRegisterClick()
//    {
//        StartCoroutine(Register(loginField.text, passwordField.text));
//    }

//    IEnumerator Register(string login, string password)
//    {
//        WWWForm form = new WWWForm();
//        form.AddField("loginUser", login);
//        form.AddField("loginPass", password);

//        //Request.Get to get info, Request.Post to post info
//        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/RegisterUser.php", form))
//        {
//            yield return www.Send();

//            if (www.isNetworkError || www.isHttpError)
//            {
//                Debug.Log(www.error);

//            }
//            else
//            {
//                Debug.Log(www.downloadHandler.text);
      
//            }

//        }
//    }
//}
