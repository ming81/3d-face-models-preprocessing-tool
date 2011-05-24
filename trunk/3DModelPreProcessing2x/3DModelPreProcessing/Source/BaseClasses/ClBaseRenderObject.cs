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
*   @file       ClBaseRenderObject.cs
*   @brief      Base class to reander objects, we can register in it to Eavents
*   @author     Przemyslaw Szeptycki <pszeptycki@gmail.com>
*   @date       26-10-2007
*
*   @history
*   @item		26-10-2007 Przemyslaw Szeptycki     created at ECL (普查迈克) (بشاماك)
*/
namespace ModelPreProcessing
{
    public abstract class ClBaseRenderObject : ClBaseEaventHandler, IRenderObject
    {
        //---------------------------- Attribites -------------------------
        private static int sm_iGlobalID = 0;
        protected string m_sObjectName = "";
        protected int m_iId = 0;

        //----------------------------- Methods ---------------------------
        public ClBaseRenderObject(string p_sObjectName)
        {
            m_sObjectName = p_sObjectName;
            m_iId = sm_iGlobalID++;
        }

        public abstract void Render(Device p_dDevice, Control p_cRenderWindow);

        public string GetObjectName()
        {
            return m_sObjectName;
        }

        public int GetObjectID()
        {
            return m_iId;
        }
    }
}
