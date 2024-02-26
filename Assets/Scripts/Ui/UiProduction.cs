using System;
using NavigationSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class UiProduction : UiPage
    {
        [SerializeField] private ProductionItemButton[] buttons;
        
        public void Init(ProductionItem[] productionItems, Action<int> onItemSelected)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Init(productionItems[i], i, (id) =>
                {
                    onItemSelected?.Invoke(id);
                });
            }
        }
    }

    [RequireComponent(typeof(Button))]
    public abstract class ProductionItemButton : MonoBehaviour
    {
        [SerializeField] private Image image;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public virtual void Init(ProductionItem productionItem, int id, Action<int> onClicked)
        {
            image.sprite = productionItem.itemImage;
            
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => onClicked?.Invoke(id));
        }
    }
}