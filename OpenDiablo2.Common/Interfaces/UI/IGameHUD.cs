﻿/*  OpenDiablo 2 - An open source re-implementation of Diablo 2 in C#
 *  
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>. 
 */

using OpenDiablo2.Common.Enums;

namespace OpenDiablo2.Common.Interfaces
{
    public interface IGameHUD
    {
        bool IsRunningEnabled { get; }
        bool IsLeftPanelVisible { get; }
        bool IsRightPanelVisible { get; }

        bool IsMouseOver();
        void TogglePanel(ePanelType panelType);
        void TogglePanel(IPanel panel);
        void OpenPanels(IPanel leftPanel, IPanel rightPanel);
        void ClosePanels();

        void Render();
        void Update();
    }
}