using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    [SerializeField] Animator ani;

    private void Start()
    {
        ani.enabled = false;
    }

    public void Press()
    {
        ani.enabled = true;
    }

}
