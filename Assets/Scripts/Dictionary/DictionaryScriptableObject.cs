using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Data Objects/Dictionary Storage Object")]
public class DictionaryScriptableObject<DictionaryValueType> : ScriptableObject
{
    [SerializeField]
    List<string> keys = new List<string>();
    [SerializeField]
    List<DictionaryValueType> values = new List<DictionaryValueType>();

    public List<string> Keys { get => keys; set => keys = value; }
    public List<DictionaryValueType> Values { get => values; set => values = value; }
}