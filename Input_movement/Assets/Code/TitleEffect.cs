using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleEffect : MonoBehaviour
{

    public TextMeshProUGUI title;
    public UnityEngine.UI.Image bgImage;

    // Start is called before the first frame update
    void Start()
    {
        title.text = "Super Awesom Game 2";


    }

    // Update is called once per frame
    void Update()
    {

        title.fontSize = 25 + Mathf.Sin(Time.time * 10) * 10;

    }

    public void Playbutton()
    {
        bgImage.color = Color.red;

    }

}
