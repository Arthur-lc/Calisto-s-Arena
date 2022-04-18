using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiperLink : MonoBehaviour
{
    public string url;

    public void OpenURL() {
        Application.OpenURL(url);
    }
}
