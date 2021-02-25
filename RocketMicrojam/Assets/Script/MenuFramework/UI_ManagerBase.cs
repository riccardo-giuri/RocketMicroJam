using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RG_FrameworkMenu 
{
    public class UI_ManagerBase : MonoBehaviour
    {
        /// <summary>
        /// lista menu
        /// </summary>
        protected List<UI_MenuBase> menues;

        /// <summary>
        /// Menu attualmente selezionato
        /// </summary>
        protected UI_MenuBase currentMenu;

        /// <summary>
        /// Ritorna il menu corrente
        /// </summary>
        /// <returns></returns>
        UI_MenuBase GetCurrentMenu()
        {
            return currentMenu;
        }

        /// <summary>
        /// funzione chiamata al setup della classe base
        /// </summary>
        public virtual void OnSetup()
        {

        }

        /// <summary>
        /// setup della classe
        /// </summary>
        public void Setup()
        {
            menues = GetComponentsInChildren<UI_MenuBase>().ToList();

            foreach (UI_MenuBase item in menues)
                item.Setup(this);

            OnSetup();
        }
    }
}

