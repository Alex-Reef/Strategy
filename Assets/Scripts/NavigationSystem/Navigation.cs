using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace NavigationSystem
{
    public class Navigation : Singleton<Navigation>
    {
        [SerializeField] private KeyValue<UiPageNames, UiPage>[] pages;
        
        private Dictionary<UiPageNames, UiPage> _cashedPages;
        private UiPageNames _currentPage = UiPageNames.None;

        protected override void Awake()
        {
            base.Awake();

            _cashedPages = new Dictionary<UiPageNames, UiPage>();
            
            foreach (var pageInfo in pages)
            {
                if (!_cashedPages.TryAdd(pageInfo.key, null))
                {
                    Debug.LogError($"Key '{pageInfo.key}' already contains in Navigation.");
                }
            }
        }

        public UiPage Show(UiPageNames pageName)
        {
            Hide(_currentPage);
            if(_cashedPages.TryGetValue(pageName, out var page))
            {
                if (page == null)
                {
                    var prefab = pages.FirstOrDefault(x => x.key == pageName);
                    page = Instantiate(prefab?.value, transform);
                    _cashedPages[pageName] = page;
                }
                page.Show();
                _currentPage = pageName;
                return page;
            }

            return null;
        }

        public void Hide(UiPageNames pageName)
        {
            if (pageName != UiPageNames.None)
            {
                _cashedPages[pageName]?.Hide();
            }
        }
    }
}