using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bar_gradiants : MonoBehaviour
{
    // Start is called before the first frame update
    public Image filledBar;
    public Gradient gradient;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
filledBar.color = gradient.Evaluate(filledBar.fillAmount);
    }
}
