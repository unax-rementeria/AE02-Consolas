using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class NpcAddressableLoader : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject npcPrefab; 
    [SerializeField] Transform spawnPoint;

    AsyncOperationHandle<GameObject> handle;
    bool loaded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Toggle();
    }

    void Toggle()
    {
        if (!loaded)
        {
            handle = npcPrefab.InstantiateAsync(spawnPoint.position, spawnPoint.rotation);
            loaded = true;
        }
        else
        {
            Addressables.ReleaseInstance(handle);
            loaded = false;
        }
    }
}