using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scenes.Lighthouse.Сharacters.NPC
{
    public class NPC : MonoBehaviour
    {
        [Range(0, 10)] public float speed = 3.5f;

        [Range(0, 10)] public float minDistance = 1f;

        protected GameObject _playerObject;

        protected PlayerController _player;

        [SerializeField] private Transform[] _wayPoints;

        NavMeshAgent agent;

        private int _currentPoint = 0;

        private int points = 0;



        //TelephoneScript phone;


        public void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            //phone = GameObject.FindGameObjectWithTag("Telephone").GetComponent<TelephoneScript>();
        }



        public void GetPlayer()
        {
            _playerObject = GameObject.FindWithTag("Player");
            _player = _playerObject.GetComponent<PlayerController>();
        }

        public void FollowCharacter()
        {
            if (_player.isHide == true) return;


            //phone.Zvonok();

            if (Vector3.Distance(transform.position, _playerObject.transform.position) >= minDistance)
            {
                agent.SetDestination(_playerObject.transform.position);
            }
        }


        public void Walk(bool follow)
        {
            if (follow)
                FollowCharacter();
            else
            {
                if (Vector3.Distance(transform.position, _wayPoints[_currentPoint].position) < 0.7f)
                {
                    _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
                }

                agent.SetDestination(_wayPoints[_currentPoint].transform.position);
            }
        }

    }
}
