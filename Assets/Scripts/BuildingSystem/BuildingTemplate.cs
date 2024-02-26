using Ui;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(fileName = "Building Template", menuName = "Building/BuildingTemplate", order = 0)]
    public class BuildingTemplate : ProductionItem
    {
        public BuildingBase buildingPrefab;
    }
}