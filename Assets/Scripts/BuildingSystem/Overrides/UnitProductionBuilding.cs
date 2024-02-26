using System.Collections;
using System.Collections.Generic;
using BuildingSystem.Interfaces;
using NavigationSystem;
using UnitSystem;
using UnityEngine;

namespace BuildingSystem.Overrides
{
    public class UnitProductionBuilding : BuildingBase, IProductionBuilding
    {
        [SerializeField] private Transform instantiatePosition;
        [SerializeField] private UnitTemplate[] productionItemsTemplate;

        private Coroutine _producedCoroutine;
        private List<int> _producedQueue;
        private int _currentProduceId;

        private void Awake()
        {
            _producedQueue = new List<int>();
        }

        public override void SelectBuilding()
        {
            base.SelectBuilding();
            Navigation.Instance.Show(UiPageNames.UnitProduction);
        }
        
        public void SelectItemForProduction(int itemId)
        {
            _producedQueue.Add(itemId);
            _producedCoroutine ??= StartCoroutine(Produce());
        }

        public void RemoveItemForProduction(int itemId)
        {
            _producedQueue.RemoveAt(itemId);
        }

        private IEnumerator Produce()
        {
            while (_producedQueue.Count > 0)
            {
                _currentProduceId = _producedQueue[0];
                _producedQueue.RemoveAt(0);
                yield return new WaitForSeconds(productionItemsTemplate[_currentProduceId].time);
                OnItemProduced();
            }

            _producedCoroutine = null;
        }

        public void OnItemProduced()
        {
            Instantiate(productionItemsTemplate[_currentProduceId].unitPrefab.gameObject, instantiatePosition.position, Quaternion.identity);
        }
    }
}