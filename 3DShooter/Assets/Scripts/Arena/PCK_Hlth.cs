﻿/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PCK_Hlth : PCK_Base
{
    protected override void PickupEvent()
    {
        TDC_EventManager.FBroadcast(TDC_GE.GE_PCK_HLT);
    }
}
