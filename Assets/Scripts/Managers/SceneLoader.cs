using UnityEngine;

namespace MobileCarGame
{
    public class SceneLoader : MonoBehaviour
    {
        public string sceneToLoad;

        public void Load()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadScene(sceneToLoad);
            }
        }
    }
}
