using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RG_FrameworkMenu
{
    public class UI_MenuBase : MonoBehaviour
    {
        /// <summary>
        /// Riferimento al proprio Manager
        /// </summary>
        protected UI_ManagerBase managerBase;

        /// <summary>
        /// Stato di attivo e disattivo del menu
        /// </summary>
        bool isActive;

        /// <summary>
        /// Funzione che attiva o disattiva il Gameobject del menu
        /// </summary>
        /// <param name="_value"></param>
        public virtual void ToggleMenu(bool _value)
        {
            if (isActive == _value)
                return;

            isActive = _value;
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// Setup del Menu
        /// </summary>
        /// <param name="_uiManagerBase"></param>
        public void Setup(UI_ManagerBase _uiManagerBase)
        {
            managerBase = _uiManagerBase;

            isActive = true;
        }

        /// <summary>
        /// Funzione chiamata al setup della classe base
        /// </summary>
        protected virtual void OnSetup()
        {

        }

        /// <summary>
        /// funzione che ritorna il valore true o flase del menu attivo
        /// </summary>
        /// <returns></returns>
        public bool IsMenuActive()
        {
            return isActive;
        }
    }
}

