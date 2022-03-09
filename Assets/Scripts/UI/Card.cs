using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Ability ability;
    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    void Start()
    {
        image.sprite = ability.icon;
        title.text = ability.name;
        description.text = ability.description;
    }
}
