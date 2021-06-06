using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    [HideInInspector] public float runtimeValue;

    public float initialValue;

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }
}
