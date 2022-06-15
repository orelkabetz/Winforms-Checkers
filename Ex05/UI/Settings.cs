using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.UI
{
    public class Settings
    {
        private int m_BoardSize;
        private string m_PlayerOneName;
        private string m_PlayerTwoName;
        private int m_OneOrTwoPlayers;

        public Settings(int i_BoardSize, string i_PlayerOneName, string i_PlayerTwoName, int i_OneOrTwoPlayers)
        {
            m_BoardSize = i_BoardSize;
            m_PlayerOneName = i_PlayerOneName;
            m_PlayerTwoName = i_PlayerTwoName;
            m_OneOrTwoPlayers = i_OneOrTwoPlayers;
        }

        public int BoardSize
        {
            get { return m_BoardSize;}
        }
        public string PlayerOneName
        {
            get { return m_PlayerOneName;}
        }
        public string PlayerTwoName
        {
            get { return m_PlayerTwoName; }
        }
        public int OneOrTwoPlayers
        {
            get { return m_OneOrTwoPlayers;}
        }
    }
}
