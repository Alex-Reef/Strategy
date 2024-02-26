using BuildingSystem;
using InputHandler;
using UnityEngine;

namespace UnitSystem
{
    public class UnitInputHandler : BaseInputHandler
    {
        private Unit _selectedUnit;

        public override void OnLeftButtonClick()
        {
            if(_selectedUnit) _selectedUnit.Unselect();
            _selectedUnit = null;
            
            if (TryGetComponentFromHit<Unit>(out var component))
            {
                _selectedUnit = component;
                _selectedUnit.Select();
            }
        }

        public override void OnRightButtonClick()
        {
            if (!_selectedUnit) return;
            
            if (TryGetComponentFromHit<Unit>(out var unit))
            {
                if (unit.Team != _selectedUnit.Team)
                {
                    // set target
                    Debug.Log("Attack");
                    return;
                }
            }

            if (TryGetComponentFromHit<BuildingBase>(out var building))
            {
                if (building.Team != _selectedUnit.Team)
                {
                    Debug.Log("Attack building");
                }
                else
                {
                    Debug.Log("Sell in building");
                }
                return;
            }

            var pos = GetRaycastHit().point;
            _selectedUnit.SetTarget(pos);
            Debug.Log("Set position: " + pos);
        }
    }
}