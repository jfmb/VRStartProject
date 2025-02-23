using DefaultNamespace.Services.Interfaces;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.Services.Adapters
{
    public class SceneLoaderWithSceneNameAdapter:ISceneLoader
    {
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}