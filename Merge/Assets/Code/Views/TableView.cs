using TMPro;
using UnityEngine;

public class TableView : MonoBehaviour
{
    [SerializeField] private GameObject Table;
    [SerializeField] private SpawnController _spawnController;

    public void OpenTable()
    {
        Table.SetActive(true);
        _spawnController.ActiveGameplay = false;
    }

    public void CloseTable()
    {
        Table.SetActive(false);
        _spawnController.ActiveGameplay = true;
    }
}
