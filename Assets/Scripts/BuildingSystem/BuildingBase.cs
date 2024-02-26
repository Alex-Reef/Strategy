using UnityEngine;

namespace BuildingSystem
{
    public abstract class BuildingBase : MonoBehaviour
    {
        public int Team;
        
        public virtual void SelectBuilding()
        {
            GetComponentInChildren<Renderer>().material.color = Color.green;
        }

        public virtual void UnselectBuilding()
        {
            GetComponentInChildren<Renderer>().material.color = Color.white;
        }
    }
}
