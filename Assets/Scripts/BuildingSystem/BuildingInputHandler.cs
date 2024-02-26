using InputHandler;

namespace BuildingSystem
{
    public class BuildingInputHandler : BaseInputHandler
    {
        private BuildingBase _selectedBuilding;
        
        public override void OnLeftButtonClick()
        {
            if(_selectedBuilding) _selectedBuilding.UnselectBuilding();
            _selectedBuilding = null;
            
            if (TryGetComponentFromHit<BuildingBase>(out var component))
            {
                _selectedBuilding = component;
                _selectedBuilding.SelectBuilding();
            }
        }
    }
}