using UnityEngine;

public static class ValidationHelper
{
    public static bool CheckRefs(MonoBehaviour source, params Object[] refs)
    {
        bool result = true;

        foreach (Object reference in refs)
        {
            if (reference == null)
            {
                Debug.LogError($"В скрипте {source.GetType().Name} не найдены ссылки!");
                result = false;
            }
        }

        return result;
    }
}