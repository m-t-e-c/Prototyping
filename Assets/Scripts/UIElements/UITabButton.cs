using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    public class UITabButton : Button
    {
        public int tabIndex;
        
        [SerializeField] TextMeshProUGUI tabName;
        [SerializeField] GameObject unselectedState;
        [SerializeField] GameObject selectedState;

        UITabMenu _tabMenu;
  
        public void Init(string tabTitle, UITabMenu tabMenu)
        {
            tabName.text = tabTitle;
            _tabMenu = tabMenu;
            
            onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            _tabMenu.ChangeSelectedTab(tabIndex);
        }
        
        public void SetSelected(bool selected)
        {
            selectedState.SetActive(selected);
            unselectedState.SetActive(!selected);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            onClick.RemoveListener(OnClick);
        }
    }
}