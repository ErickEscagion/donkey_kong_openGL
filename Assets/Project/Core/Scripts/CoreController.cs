using UnityEngine;

namespace Project.Core.Scripts
{
    public class CoreController : MonoBehaviour
    {
        #region Lifecycle

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion

        private static CoreController _instance;
    }
}
