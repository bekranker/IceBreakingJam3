using System;
using UnityEngine;

public class ButtonEventTrigger : MonoBehaviour
{
    public static event Action<int> OnButtonClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClickedMethod(int i)
    {
        OnButtonClicked.Invoke(i);
    }
}
