using VRageMath;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Game.Components;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Game.Entity;
using Sandbox.ModAPI;
using System.IO;
using Sandbox.Game.Entities;
using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using VRage.Utils;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Library;
using VRage;
using Sandbox.Game.World;
using Sandbox.Definitions;
using VRage.Game.ObjectBuilders.ComponentSystem;
using System;

namespace Xariman.CargoTier
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), false,
        new string[]
        {
            "SmallBlockSmallContainerTier2",
            "SmallBlockMediumContainerTier2",
            "SmallBlockLargeContainerTier2",
            "LargeBlockSmallContainerTier2",
            "LargeBlockLargeContainerTier2",

            "SmallBlockSmallContainerTier3",
            "SmallBlockMediumContainerTier3",
            "SmallBlockLargeContainerTier3",
            "LargeBlockSmallContainerTier3",
            "LargeBlockLargeContainerTier3",

            "SmallBlockSmallContainerTier4",
            "SmallBlockMediumContainerTier4",
            "SmallBlockLargeContainerTier4",
            "LargeBlockSmallContainerTier4",
            "LargeBlockLargeContainerTier4"
        }
    )]
    public class ContainerTier : MyGameLogicComponent
    {
        IMyCubeBlock m_block;
        IMyCubeGrid m_grid;

        bool inited = false;

        bool withLevelsMod = false;

        public override MyObjectBuilder_EntityBase GetObjectBuilder(bool copy = false)
        {
            return Container.Entity.GetObjectBuilder(copy);
        }

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            var mods = MyAPIGateway.Session.GetCheckpoint("null").Mods;
            foreach (var mod in mods)
            {
                if (mod.PublishedFileId == 677790017)
                {
                    withLevelsMod = true;
                    break;
                }
            }

            if (!withLevelsMod)
                return;

            //MyAPIGateway.Entities.
            
            //foreach (var k in MyGameLogicComponent)
            //{
            //    if (k.ModId == "677790017")
            //    {
            //        MyAPIGateway.Utilities.ShowNotification($"{k.ModId} {k.ModName} {k.ModPath}", 10000);
            //    }
            //}


            NeedsUpdate |= MyEntityUpdateEnum.EACH_FRAME;

            m_block = (IMyCubeBlock)Entity;
            m_block.NeedsWorldMatrix = true;

            m_grid = m_block.CubeGrid;
        }

        private void InventoryContentsChanged(MyInventoryBase inv)
        {
            if (!string.IsNullOrEmpty(m_grid.Name))
            {
                bool isPowered = MyVisualScriptLogicProvider.HasPower(m_grid.Name) && m_block.IsWorking;

                //UpdateBar(isPowered);
            }
        }

        public override void Close()
        {
            
        }


        public override void UpdateAfterSimulation()
        {
            try
            {
                //if (m_display == null)
                //    m_display = LoadDisplay();

                //TryUpdateBar();
            }
            catch
            {
            }
        }

    }
}