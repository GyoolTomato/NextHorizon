using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using MEC;

public class Manager_Addressable : Singleton<Manager_Addressable>
{
    //
    public AssetReference SpawnablePrefab;

    //
    Dictionary<EPanelType, GameObject> _dicPanels = null;
    Dictionary<string, TextAsset> _dicTables = null;
    Dictionary<string, Sprite> _dicSprites = null;

    //
    public bool pIsInit { private set; get; }
    public long pDownloadedBytes { private set; get; }
    public long pTotalBytes { private set; get; }
    public float pDownloadPercent { private set; get; }


    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
        //
        pIsInit = false;

        Timing.RunCoroutine(CoInitAddressable());
    }

    /// <summary>
    /// 
    /// </summary>
    IEnumerator<float> CoInitAddressable()
    {
        //
        Debug.Log("Addressables Init Start");

#if UNITY_ANDROID
        var catalogHandle = Addressables.LoadContentCatalogAsync("http://gyooltomato.iptime.org:50080/addressables/NextHorizon/Android/catalog_0.1.bin");
#else
        var catalogHandle = Addressables.LoadContentCatalogAsync("http://gyooltomato.iptime.org:50080/addressables/NextHorizon/PC/catalog_0.1.bin");
#endif
        while (catalogHandle.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }

        //
        var handle = Addressables.InitializeAsync();
        while (handle.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handle.IsValid() == false)
        {
            Debug.LogError("Addressables Init Valid Failed");

            yield break;
        }
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Init Failed");

            yield break;
        }

        //
        var handleCheck = Addressables.CheckForCatalogUpdates(false);
        while (handleCheck.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handleCheck.IsValid() == false)
        {
            Debug.LogError("Addressables Check Catalogs Valid Failed");

            yield break;
        }
        if (handleCheck.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Check Catalogs Failed");

            yield break;
        }

        //
        if (handleCheck.Result.Count > 0)
        {
            var handleUpdate = Addressables.UpdateCatalogs(handleCheck.Result);
            while (handleUpdate.IsDone == false)
            {
                yield return Timing.WaitForOneFrame;
            }
            if (handleUpdate.IsValid() == false)
            {
                Debug.LogError("Addressables Update Catalogs Valid Failed");

                yield break;
            }
            if (handleUpdate.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError("Addressables Update Catalogs Failed");

                yield break;
            }
        }        

        //
        var handleLoc = Addressables.LoadResourceLocationsAsync("Download");
        while (handleLoc.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handleLoc.IsValid() == false)
        {
            Debug.LogError("Addressables Resource Location Valid Failed");

            yield break;
        }
        if (handleLoc.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Resource Location Failed");

            yield break;
        }

        foreach (UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation loc in handleLoc.Result)
        {
            Debug.Log($"Key: {loc.PrimaryKey}, Type: {loc.ResourceType}, InternalId: {loc.InternalId}");
        }

        //
        var handleSize = Addressables.GetDownloadSizeAsync(handleLoc.Result);
        while (handleSize.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handleSize.IsValid() == false)
        {
            Debug.LogError("Addressables Download Size Valid Failed");

            yield break;
        }
        if (handleSize.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Download Size Failed");

            yield break;
        }

        pDownloadedBytes = handleSize.Result;

        //
        var isAcceptedDownload = false;
        var isConfirmMessage = false;
        if (pDownloadedBytes > 0)
        {
            //
            Manager_UI.Instance.ShowMessageBox($"{pDownloadedBytes}", Panel_MessageBox.EType.ConfirmCancel, () =>
            {
                isAcceptedDownload = true;
                isConfirmMessage = true;
            },
            () =>
            {
                isAcceptedDownload = false;
                isConfirmMessage = true;
            });

            //
            while (isConfirmMessage == false)
            {
                yield return Timing.WaitForOneFrame;
            }

            //
            if (isAcceptedDownload)
            {
                var handleDownload = Addressables.DownloadDependenciesAsync("Download");
                while (handleDownload.IsDone == false)
                {
                    var downloadStatus = handleDownload.GetDownloadStatus();
                    pDownloadedBytes = downloadStatus.DownloadedBytes;
                    pTotalBytes = downloadStatus.TotalBytes;
                    pDownloadPercent = downloadStatus.Percent * 100f;
                    yield return Timing.WaitForOneFrame;
                }
                if (handleDownload.IsValid() == false)
                {
                    Debug.LogError("Addressables Download Valid Failed");

                    yield break;
                }
                if (handleDownload.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError("Addressables Download Failed");

                    yield break;
                }
            }
            else
            {
                LogoScene.ChangeState(ELogoState.Logo);

                yield break;
            }
        }

        yield return Timing.WaitUntilDone(Timing.RunCoroutine(LoadAssets_Panel()));
        yield return Timing.WaitUntilDone(Timing.RunCoroutine(LoadAssets_Tables()));
        yield return Timing.WaitUntilDone(Timing.RunCoroutine(LoadAssets_Sprites()));

        pIsInit = true;
    }

    /// <summary>
    /// 
    /// </summary>
    IEnumerator<float> LoadAssets_Panel()
    {
        //
        _dicPanels ??= new Dictionary<EPanelType, GameObject>();
        _dicPanels.Clear();

        //
        for (EPanelType i = EPanelType.None + 1; i < EPanelType.End; i++)
        {
            //
            if (i == EPanelType.Title || i == EPanelType.MessageBox || i == EPanelType.Group_0 || i == EPanelType.Group_1 || i == EPanelType.Group_2)
            {
                continue;
            }

            //
            var key = $"Panel_{i}";
            var handle = Addressables.LoadAssetAsync<GameObject>(key);
            while (handle.IsDone == false)
            {
                yield return Timing.WaitForOneFrame;
            }
            if (handle.IsValid() == false)
            {
                Debug.LogError("Addressables Load Resource_Panel Valid Failed. Key : " + key);

                yield break;
            }
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError("Addressables Load Resource_Panel Failed. Key : " + key);

                yield break;
            }

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _dicPanels.Add(i, handle.Result);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator<float> LoadAssets_Tables()
    {
        //
        _dicTables ??= new Dictionary<string, TextAsset>();
        _dicTables.Clear();

        //
        var handle = Addressables.LoadResourceLocationsAsync("Tables");
        while (handle.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handle.IsValid() == false)
        {
            Debug.LogError("Addressables Load Resource_Table Valid Failed");

            yield break;
        }
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Load Resource_Table Failed");

            yield break;
        }

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var item in handle.Result)
            {
                var handleLoadAsset = Addressables.LoadAssetAsync<TextAsset>(item.PrimaryKey);
                while (handleLoadAsset.IsDone == false)
                {
                    yield return Timing.WaitForOneFrame;
                }

                if (handleLoadAsset.Status == AsyncOperationStatus.Succeeded)
                {
                    if (_dicTables.ContainsKey(item.PrimaryKey) == false)
                        _dicTables.Add(item.PrimaryKey, handleLoadAsset.Result);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator<float> LoadAssets_Sprites()
    {
        //
        _dicSprites ??= new Dictionary<string, Sprite>();
        _dicSprites.Clear();

        //
        var handle = Addressables.LoadResourceLocationsAsync("Sprites");
        while (handle.IsDone == false)
        {
            yield return Timing.WaitForOneFrame;
        }
        if (handle.IsValid() == false)
        {
            Debug.LogError("Addressables Load Resource_Sprites Valid Failed");

            yield break;
        }
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Addressables Load Resource_Sprites Failed");

            yield break;
        }

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var item in handle.Result)
            {
                var handleLoadAsset = Addressables.LoadAssetAsync<Sprite>(item.PrimaryKey);
                while (handleLoadAsset.IsDone == false)
                {
                    yield return Timing.WaitForOneFrame;
                }

                if (handleLoadAsset.Status == AsyncOperationStatus.Succeeded)
                {
                    var name = Path.GetFileName(item.PrimaryKey);
                    var extensionDot = name.IndexOf(".");
                    name = name.Substring(0, extensionDot);

                    if (_dicSprites.ContainsKey(name) == false)
                        _dicSprites.Add(name, handleLoadAsset.Result);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void CreatePrefab()
    {
        List<AsyncOperationHandle<GameObject>> handles = new List<AsyncOperationHandle<GameObject>>();

        AsyncOperationHandle<GameObject> handle = SpawnablePrefab.InstantiateAsync();
        handles.Add(handle);
    }

    /// <summary>
    /// 
    /// </summary>
    public void AssetDestruct(GameObject gameObject)
    {
        //
        Addressables.ReleaseInstance(gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="panelType"></param>
    /// <returns></returns>
    public GameObject GetPanel(EPanelType panelType)
    {
        //
        if (_dicPanels.ContainsKey(panelType) == false)
            return null;
        //
        return _dicPanels[panelType];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableKey"></param>
    /// <returns></returns>
    public TextAsset GetTable(string tableKey)
    {
        //
        if (_dicTables.ContainsKey(tableKey) == false)
            return null;

        //
        return _dicTables[tableKey];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="spriteKey"></param>
    /// <returns></returns>
    public Sprite GetSprite(string spriteKey)
    {
        //
        if (_dicSprites.ContainsKey(spriteKey) == false)
            return null;

        //
        return _dicSprites[spriteKey];
    }
}
