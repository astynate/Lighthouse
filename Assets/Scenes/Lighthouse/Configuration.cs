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
        public static UnityEngine.Canvas InventoryCanvas { get; set; }
        public static UnityEngine.Canvas ReportCanvas { get; set; }
        public static Vector3 DragableItemTransform { get; set; }
        public static Cell DragableCell { get; set; }
        public static UnityEngine.Canvas ScrollViewCanvas { get; set; }
        public static Image ScrollView { get; set; }
        public static GameObject RightHand { get; set; }
        public static InventoryMenu InventoryMenuInstance { get; set; }

        public static bool isCall = false;

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

            RightHand = GameObject.FindWithTag("Arm");

            InventoryMenuInstance = GameObject.FindGameObjectWithTag("InventoryMenuScript").
                GetComponent<InventoryMenu>();

            InteractionCanvas = GameObject.FindGameObjectWithTag("InteractionCanvas")
                .GetComponent<UnityEngine.Canvas>();

            InventoryCanvas = GameObject.FindGameObjectWithTag("InventoryMenu")
                .GetComponent<UnityEngine.Canvas>();

            ReportCanvas = GameObject.FindGameObjectWithTag("ReportCanvas")
              .GetComponent<UnityEngine.Canvas>();

            ReportCanvas.enabled = false;

            DontDestroyOnLoad(gameObject);

            ScrollViewCanvas = GameObject.FindGameObjectWithTag("Bar")
                .GetComponent<UnityEngine.Canvas>();
        }

        private void Start()
        {
            ScrollView = GameObject.FindGameObjectWithTag("ScrollContent").GetComponent<Image>();
            ScrollViewCanvas.enabled = false;
            isCall = false;
        }
    }
}