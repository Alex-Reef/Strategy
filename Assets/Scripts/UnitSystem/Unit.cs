using NavigationSystem;
using UnityEngine;

namespace UnitSystem
{
    public class Unit : MonoBehaviour
    {
        public int Team;
        
        public void Select()
        {
            GetComponent<Renderer>().material.color = Color.green;
            Navigation.Instance.Show(UiPageNames.UnitInfo);
        }

        public void Unselect()
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        public void SetTarget(Vector3 pos)
        {
            GetComponent<UnitMovement>().Move(pos);
        }
    }
}