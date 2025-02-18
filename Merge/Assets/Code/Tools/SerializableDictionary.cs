using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField] private List<TKey> keys;
    [SerializeField] private List<TValue> values;

    public Dictionary<TKey, TValue> Dictionary
    {
        get
        {
            // Возвращаем словарь, собрав его из ключей и значений
            Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
            {
                dictionary.Add(keys[i], values[i]);
            }
            return dictionary;
        }
    }
}