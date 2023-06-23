using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    [SerializeField] private string targetLayer = "Persistent";
    private string _originalLayer = string.Empty;

    private void Awake()
    {
        _originalLayer = LayerMask.LayerToName(gameObject.layer);
    }

    private void SwitchToLoadLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(targetLayer);
    }

    private void ResetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(_originalLayer);
    }
}
