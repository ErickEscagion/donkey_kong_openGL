using UnityEngine;

namespace Project.Core.Scripts
{
    public class CoreController : MonoBehaviour
    {
        #region Properties

        public static CoreController Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                var nav = Resources.Load<CoreController>("_coreController");
                Instantiate(nav, Vector3.zero, Quaternion.identity);

                return _instance;
            }
        }

        #endregion

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
