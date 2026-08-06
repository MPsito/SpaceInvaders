using UnityEngine;
using UnityEngine.Events;

public class WinScreen : MonoBehaviour
{
  [SerializeField]
  private UnityEvent onShowWinScreen;
  [SerializeField]
  private TextMesh[] textMeshes;
  [SerializeField]
  private GameObject nextLevelButton;
  [SerializeField]
  private GameObject quitButton;
  [SerializeField]
  private LevelManager LevelManager;
  [SerializeField]
  private GameObject[] screnAssets;
  private void Awake()
  {
    ShowScreenAssets(false);
  }
  public void ShowWinScreen()
    {
      ShowScreenAssets(true);  
      onShowWinScreen?.Invoke();
      ChangeTextMeshes("You\nin!");
      LevelManager.NextLevel();
      nextLevelButton.SetActive(!LevelManager.IsPastLastLevel);
      quitButton.SetActive(true);
    }
    public void ShowloseScreen()
    {
        ShowScreenAssets(true); 
        onShowWinScreen?.Invoke();
        ChangeTextMeshes("You\nLose!");
        nextLevelButton.SetActive(true);
        quitButton.SetActive(true);
    }
  private void ChangeTextMeshes(string text)
  {
    foreach (TextMesh textMesh in textMeshes)
    {
        textMesh.text = text;
    }
  }
  private void ShowScreenAssets(bool show)
  {
    foreach (GameObject asset in screnAssets)
    {
        asset.SetActive(show);
    }
  }
}
