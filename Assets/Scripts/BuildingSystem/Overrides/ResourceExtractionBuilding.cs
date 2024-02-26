using System.Collections;
using BuildingSystem.Interfaces;
using UnityEngine;

namespace BuildingSystem.Overrides
{
    public enum ResourceTypes
    {
        Coal,
        Iron
    }
    
    public class ResourceExtractionBuilding : BuildingBase, IPassiveResExtractorBuilding
    {
        [SerializeField] private ResourceTypes resourceType;

        private void Start()
        {
            StartExtract();
        }

        public void StartExtract()
        {
            StartCoroutine(Extraction());
        }

        private IEnumerator Extraction()
        {
            while (true)
            {
                yield return new WaitForSeconds(2);
                OnResourceExtracted();
            }
        }

        public void OnResourceExtracted()
        {
            Debug.Log("Extracted: " + resourceType);
        }
    }
}