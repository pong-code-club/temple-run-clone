using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;

    void Awake()
    {
        if (WinManager.Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }
}
