namespace BuildingSystem.Interfaces
{
    public interface IProductionBuilding
    {
        public void SelectItemForProduction(int itemId);
        public void OnItemProduced();
    }
}