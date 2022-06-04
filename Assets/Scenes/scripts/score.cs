using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void change(int score)
    {
        Text = transform.GetComponent<TextMeshProUGUI>();
        Text.text = "the" + score.ToString() + "floor";
    }
}
