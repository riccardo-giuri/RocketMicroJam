using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RG_FrameworkMenu
{
    public class UI_ManagerGame : UI_ManagerBase
    {
        public UI_MenuBase FirstActiveMenu;

        // Start is called before the first frame update
        void Start()
        {
            Setup();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnSetup()
        {
            base.OnSetup();

            currentMenu = FirstActiveMenu;
            currentMenu.ToggleMenu(true);

            foreach(UI_MenuBase menu in menues)
            {
                if(menu != currentMenu)
                {
                    menu.ToggleMenu(false);
                }
            }
        }

        public void ActiveNewMenu(UI_MenuBase newMenu)
        {
            //cambio menu solo se il nuovo menu è diverso da quello corrente
            if(newMenu != currentMenu)
            {
                //deattivo il menu corrente
                currentMenu.ToggleMenu(false);
                //setto il nuovo menu come corrente
                currentMenu = newMenu;
                //lo attivo
                currentMenu.ToggleMenu(true);

            }
        }

    }
}

