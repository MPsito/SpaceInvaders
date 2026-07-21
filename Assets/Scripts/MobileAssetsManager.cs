using UnityEngine;
 
public class MobileAssetsManager : MonoBehaviour
{
   [SerializeField]
   private GameObject[] mobileAssets;
   [SerializeField]
   private  GameObject[] desktopAssets;
   
   private void Awake()
   {
    if (Application.isEditor)
    {
        SetAciveAssets(desktopAssets, true);
    }
    else if ( Application.isMobilePlatform)
    {
        SetAciveAssets(mobileAssets, true);
    }
    else
    {
        SetAciveAssets(desktopAssets,true);
    }
   }
   private void SetAciveAssets(GameObject[] assets, bool isActive)
   {
    foreach (var asset in assets)
    {
        asset.SetActive(isActive);
       
    }
   }
}
