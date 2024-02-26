using Ui;
using UnityEngine;

namespace UnitSystem
{
    [CreateAssetMenu(fileName = "Unit Template", menuName = "Units/Unit Template")]
    public class UnitTemplate : ProductionItem
    {
        public Unit unitPrefab;
    }
}