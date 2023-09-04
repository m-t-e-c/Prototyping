using System.Collections.Generic;
using UnityEngine;

namespace UIElements
{
    public class UITabMenu : MonoBehaviour
    {
        [SerializeField] GameObject defaultTabButtonPrefab;
        readonly List<GameObject> _tabs = new();
        readonly List<UITabButton> _tabButtons = new();

        int _selectedTabIndex;


        public void CreateTab(string tabName, GameObject tabContent)
        {
            GameObject button = Instantiate(defaultTabButtonPrefab, transform);
            UITabButton tabButton = button.GetComponent<UITabButton>();
            tabButton.Init(tabName, this);
            tabButton.tabIndex = _tabs.Count;

            _tabs.Add(tabContent);
            _tabButtons.Add(tabButton);
        }

        public void ChangeSelectedTab(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < _tabs.Count)
            {
                _tabs[_selectedTabIndex].SetActive(false);
                _tabs[tabIndex].SetActive(true);
                _selectedTabIndex = tabIndex;

                for (int i = 0; i < _tabButtons.Count; i++)
                {
                    _tabButtons[i].SetSelected(i == _selectedTabIndex);
                }
            }
        }
    }
}