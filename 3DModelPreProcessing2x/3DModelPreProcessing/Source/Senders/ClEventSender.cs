/*  Copyright (C) 2011 Przemyslaw Szeptycki <pszeptycki@gmail.com>, Ecole Centrale de Lyon,

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
/**************************************************************************
*
*                          ModelPreProcessing
*
* Copyright (C)         Przemyslaw Szeptycki 2007     All Rights reserved
*
***************************************************************************/

/**
*   @file       ClEventSender.cs
*   @brief      This is singleton class forwarding all events to proper objects
*   @author     Przemyslaw Szeptycki <pszeptycki@gmail.com>
*   @date       29-10-2007
*
*   @history
*   @item		29-10-2007 Przemyslaw Szeptycki     created at ECL (普查迈克) (بشاماك)
*/
namespace ModelPreProcessing
{
    public class ClEventSender
    {
        public enum eEvents
        {
            e_MouseButtonDown,
            e_MouseButtonUp,
            e_MouseMove,
            e_MouseWheel,
            e_KeyUp,
            e_KeyDown
        }
        //--------------------- Attributes -----------------
        private static ClEventSender m_instance = null;
        private List<IEventHandler> m_lMouseButtonDownObjectsList = new List<IEventHandler>();
        private List<IEventHandler> m_lMouseButtonUpObjectsList = new List<IEventHandler>();
        private List<IEventHandler> m_lMouseMoveObjectsList = new List<IEventHandler>();
        private List<IEventHandler> m_lMouseWheelObjectsList = new List<IEventHandler>();
        private List<IEventHandler> m_lKeyUpObjectsList = new List<IEventHandler>();
        private List<IEventHandler> m_lKeyDownObjectsList = new List<IEventHandler>();


        //----------------------- Methods ------------------
        static public ClEventSender getInstance()
        {
            if (m_instance == null)
                m_instance = new ClEventSender();

            return m_instance;
        }

        private ClEventSender()
        {
        }

        public void RegisterForEvent(eEvents p_eEvent, IEventHandler p_iObject)
        {
            switch (p_eEvent)
            {
                case eEvents.e_MouseButtonDown:
                    m_lMouseButtonDownObjectsList.Add(p_iObject);
                    break;
                case eEvents.e_MouseButtonUp:
                    m_lMouseButtonUpObjectsList.Add(p_iObject);
                    break;
                case eEvents.e_MouseMove:
                    m_lMouseMoveObjectsList.Add(p_iObject);
                    break;
                case eEvents.e_MouseWheel:
                    m_lMouseWheelObjectsList.Add(p_iObject);
                    break;
                case eEvents.e_KeyUp:
                    m_lKeyUpObjectsList.Add(p_iObject);
                    break;
                case eEvents.e_KeyDown:
                    m_lKeyDownObjectsList.Add(p_iObject);
                    break;
                default:
                    throw new Exception("Unsupported event type");
            }
        }

        public void DeRegisterForAllEvents(IEventHandler p_iObject)
        {
            m_lMouseButtonDownObjectsList.Remove(p_iObject);
            m_lMouseButtonUpObjectsList.Remove(p_iObject);
            m_lMouseMoveObjectsList.Remove(p_iObject);
            m_lMouseWheelObjectsList.Remove(p_iObject);
            m_lKeyUpObjectsList.Remove(p_iObject);
            m_lKeyDownObjectsList.Remove(p_iObject);
        }

        public void BroadcastMouseButtonDownEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_lMouseButtonDownObjectsList.Count; i++)
                m_lMouseButtonDownObjectsList[i].MouseButtonDown(sender, e);        
        }

        public void BroadcastMouseButtonUpEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_lMouseButtonUpObjectsList.Count; i++)
                m_lMouseButtonUpObjectsList[i].MouseButtonUp(sender, e);
        }

        public void BroadcastMouseMoveEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_lMouseMoveObjectsList.Count; i++)
                m_lMouseMoveObjectsList[i].MouseMove(sender, e);
        }

        public void BroadcastMouseWheelEvent(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_lMouseWheelObjectsList.Count; i++)
                m_lMouseWheelObjectsList[i].MouseWheel(sender, e);
        }

        public void BroadcastKeyDownEvent(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < m_lKeyDownObjectsList.Count; i++)
                m_lKeyDownObjectsList[i].KeyDown(sender, e);
        }

        public void BroadcastKeyUpEvent(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < m_lKeyUpObjectsList.Count; i++)
                m_lKeyUpObjectsList[i].KeyUp(sender, e);
        }
    }
}
