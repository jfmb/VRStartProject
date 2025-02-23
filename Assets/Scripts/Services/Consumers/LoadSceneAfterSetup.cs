using System.Collections;
using DefaultNamespace.Services.Interfaces;
using ScriptableObjects.Scripts.Ids;
using UnityEngine;

public class LoadSceneAfterSetup : MonoBehaviour
{
    [SerializeField] private SceneId nextSceneId;
    
    private void Start()
    {
        StartCoroutine(LoadNextSceneAfterSeconds());
    }

    private IEnumerator LoadNextSceneAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        ServiceLocator.GetService<ISceneLoader>().LoadScene(nextSceneId.Id);
    }
}
