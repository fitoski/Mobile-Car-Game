using UnityEngine;

namespace MobileCarGame
{
    public class SceneLoader : MonoBehaviour
    {
        public GameState sceneToLoad;

        public void Load()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadScene(sceneToLoad);
            }
        }
    }
}
