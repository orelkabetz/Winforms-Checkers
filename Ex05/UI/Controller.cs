using System;
using Ex05.Logic;

using Ex05.UI;

namespace Ex05.UI
{ 
    public class Controller
    {
        private FormGameSettings m_FormGameSettings;
        private FormDamka m_FormDamka;

        public Controller()
        {
            m_FormGameSettings = new FormGameSettings();
            m_FormGameSettings.ShowDialog();
        }

        public void Run()
        {
            if (m_FormGameSettings.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                m_FormDamka = new FormDamka(m_FormGameSettings.Settings);
                m_FormDamka.ShowDialog();
            }
        }
    }
}



