using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace UnitSystem
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Coroutine _moveCoroutine;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3 targetPos)
        {
            if (_moveCoroutine != null)
            {
                _agent.ResetPath();
               StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(MoveCoroutine(targetPos, () => { Debug.Log("End"); }));
        }

        private IEnumerator MoveCoroutine(Vector3 targetPos, Action onComplete)
        {
            NavMeshPath path = new NavMeshPath();
            if (_agent.CalculatePath(targetPos, path))
            {
                _agent.SetPath(path);
                bool hasPath = _agent.hasPath;
                yield return new WaitUntil(() => hasPath && _agent.remainingDistance <= _agent.stoppingDistance + 0.1f);
                hasPath = false;
                onComplete?.Invoke();
            }
        }
    }
}