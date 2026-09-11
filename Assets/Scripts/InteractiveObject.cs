using System;

using UnityEngine;

public class InteractiveObject : MonoBehaviour // - Создать сущность “интерактивный предмет” (далее - “предмет”)
// Система спавна и логики нажимаемых предметов (телевизор, который можно испортить, нажав на него).
{
    [SerializeField] private InteractiveData[] _interactiveData; //- SO уровня, который содержит информацию обо всех предметах и позициях.
    [SerializeField] private Transform _transform;

    private ObjectSpawner _objectSpawner;

    private void Awake()
    {
        _objectSpawner = new ObjectSpawner(_interactiveData, _transform);
    }

    public void SpawnInteractiveObjects() // - Спавн предметов в заданных точках при старте
    {
        _objectSpawner?.SpawnObjects();
    }

    public void DestroyInteractiveObjects()
    {
        _objectSpawner?.DestroyObjects();
    }
}

public enum StateObject
{
    Operational, // исправен
    Broken // сломан
}
// - Логика самих предметов (наличие состояний “Исправно” и “Испорчено”, возможность испортить/починить)
// - По нажатию на ЛКМ ломаем предмет, по нажатию ПКМ чиним предмет.

