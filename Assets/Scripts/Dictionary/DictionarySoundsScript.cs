using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionarySoundsScript : DictionaryScript<AudioClip>
{
    public AudioClip GetValue(string key)
    {
        return myDictionary[key];
    }
}
