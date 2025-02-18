using UnityEngine;

[System.Serializable]
public class MergingData
{
    public Sprite newSprite; 
    public int newRating;     
}

[CreateAssetMenu(fileName = "MergingConfig", menuName = "Game/MergingConfig")]
public class MergingConfig : ScriptableObject
{
    [SerializeField] private SerializableDictionary<int, MergingData> mergingDictionary;

    public MergingData GetMergingData(int mergeCount)
    {
        if (mergingDictionary.Dictionary.TryGetValue(mergeCount, out MergingData mergingData))
        {
            return mergingData;
        }

        return null;
    }
}