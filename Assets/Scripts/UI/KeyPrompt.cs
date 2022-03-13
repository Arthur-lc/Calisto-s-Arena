using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyPrompt : MonoBehaviour
{
    public TextMeshProUGUI keyText;

    [NonSerialized] public KeyCode key;

    private void OnEnable() {
        key = KeyCode.None;
        keyText.text = "- Press a key -";
    }

    private void Update() {
        key = KeyPressed();
        if (key != KeyCode.None)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Events.onKeySelected.Invoke(key);
                gameObject.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
            }
            else 
            {
                keyText.text = "- Press " + key + " -";
            }
        }
    }

    //return witch key was pressed
    private KeyCode KeyPressed() {
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey))
            {
                if (vKey == KeyCode.Escape || vKey == KeyCode.Return)
                    return key;
                return vKey;
            }
        }
        return key;
    }
}
