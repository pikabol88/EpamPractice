using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryScript<DictionaryValueType> : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private DictionaryScriptableObject<DictionaryValueType> dictionaryData;

    [SerializeField]
    private List<string> keys = new List<string>();
    [SerializeField]
    private List<DictionaryValueType> values = new List<DictionaryValueType>();

    private Dictionary<string, DictionaryValueType> myDictionary = new Dictionary<string, DictionaryValueType>();

    public bool modifyValues;

    private void Awake()
    {
        for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++)
        {
            myDictionary.Add(dictionaryData.Keys[i], dictionaryData.Values[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        if (modifyValues == false)
        {
            keys.Clear();
            values.Clear();
            for (int i = 0; i < Mathf.Min(dictionaryData.Keys.Count, dictionaryData.Values.Count); i++)
            {
                keys.Add(dictionaryData.Keys[i]);
                values.Add(dictionaryData.Values[i]);
            }
        }
    }

    public void OnAfterDeserialize()
    {

    }

    public void DeserializeDictionary()
    {
        Debug.Log("DESERIALIZATION");
        myDictionary = new Dictionary<string, DictionaryValueType>();
        dictionaryData.Keys.Clear();
        dictionaryData.Values.Clear();
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            dictionaryData.Keys.Add(keys[i]);
            dictionaryData.Values.Add(values[i]);
            myDictionary.Add(keys[i], values[i]);
        }
        modifyValues = false;
    }

    public void PrintDictionary()
    {
        foreach (var pair in myDictionary)
        {
            Debug.Log("Key: " + pair.Key + " Value: " + pair.Value);
        }
    }
}