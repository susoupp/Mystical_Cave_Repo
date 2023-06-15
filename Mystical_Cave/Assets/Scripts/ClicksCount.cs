using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClicksCount : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public IntValue ClickCount;
  
    

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        
    }

    private void Start()
    {
        ClickCount.value = 00;
    }

    private void Update()
    {
        UpdateTextWithNumbers(ClickCount.value);
       
    }

    public void UpdateTextWithNumbers(int value)
    {
        if (textMeshProUGUI != null) textMeshProUGUI.text = value.ToString();
    }

    
}