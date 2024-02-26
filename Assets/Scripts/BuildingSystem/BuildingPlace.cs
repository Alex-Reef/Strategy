using System.Collections;
using BuildingSystem.Interfaces;
using NavigationSystem;
using Ui;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingPlace : BuildingBase, IProductionBuilding
    {
        [SerializeField] private ProductionItem[] buildingTemplates;
        private BuildingBase _currentBuild;
        private BuildingTemplate _currentBuilding;
        
        public override void SelectBuilding()
        {
            base.SelectBuilding();
            if (_currentBuild)
            {
                _currentBuild.SelectBuilding();
            }
            else
            {
                var page = (UiProduction)Navigation.Instance.Show(UiPageNames.BuildingPlace);
                page.Init(buildingTemplates, SelectItemForProduction);
            }
        }

        public void SelectItemForProduction(int itemId)
        {
            _currentBuilding = buildingTemplates[itemId] as BuildingTemplate;
            StartCoroutine(Produce());
        }

        private IEnumerator Produce()
        {
            yield return new WaitForSeconds(_currentBuilding.time);
            OnItemProduced();
        }

        public void OnItemProduced()
        {
            _currentBuild = Instantiate(_currentBuilding.buildingPrefab, transform);
        }
    }
}