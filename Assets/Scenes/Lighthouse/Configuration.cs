using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Lighthouse
{
    public class Configuration : MonoBehaviour
    {
        public static Configuration Instance { get; private set; }
        public static GameObject PlayerObject { get; set; }
        public static PlayerController PlayerController { get; set; }
        public static UnityEngine.Canvas InteractionCanvas { get; set; }
        public static UnityEngine.Canvas ScrollViewCanvas { get; set; }
        public static Image ScrollView { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            PlayerObject = GameObject.FindGameObjectWithTag("Player");
            PlayerController = PlayerObject.GetComponent<PlayerController>();

            InteractionCanvas = GameObject.FindGameObjectWithTag("InteractionCanvas")
                .GetComponent<UnityEngine.Canvas>();

            DontDestroyOnLoad(gameObject);





            ScrollViewCanvas = GameObject.FindGameObjectWithTag("Bar").GetComponent<UnityEngine.Canvas>();
        }

        private void Start()
        {
            ScrollView = GameObject.FindGameObjectWithTag("ScrollContent").GetComponent<Image>();
            if (ScrollView == null)
            {
                Debug.Log("нулевой");
            }
            ScrollViewCanvas.enabled = false;
        }
    }
}