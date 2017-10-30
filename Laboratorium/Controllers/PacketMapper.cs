using System;
using System.Linq;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Helpers;
using Laboratorium.Models.DataModels;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Controllers
{
    internal class PacketMapper
    {
        private readonly Executor _executor;
        private readonly DataMapper _dataMapper;

        public PacketMapper(Executor executor, DataMapper dataMapper)
        {
            _executor = executor;
            _dataMapper = dataMapper;
        }

        internal Packet Map(PacketEntity packetEntity)
        {
            var emptyPacket = _executor.GetNewEmptyPacket();

            var result = _dataMapper.Map<PacketEntity, Packet>(packetEntity);
            result.Modules = emptyPacket.Modules;
            result.Packets = emptyPacket.Packets;

            var packets = packetEntity.Packets.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var packetId in packets)
            {
                var targetPacket = result.Packets.FirstOrDefault(p => p.Id.ToString() == packetId);

                if (targetPacket == null)
                {
                    result.Result.Add($"Зависимый пакет(id={packetId}) не найден");
                    result.IsError = true;
                }
                else
                {
                    targetPacket.IsEnadled = true;
                }
            }

            var modules = packetEntity.Modules.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var moduleName in modules)
            {
                var targetModule = result.Modules.FirstOrDefault(p => p.Name == moduleName);

                if (targetModule == null)
                {
                    result.Result.Add($"Зависимый модуль(name={moduleName}) не найден");
                    result.IsError = true;
                }
                else
                {
                    targetModule.IsEnadled = true;
                }
            }

            return result;
        }

        internal PacketEntity Map(PacketViewModel packet)
        {
            var packetEntity = _dataMapper.Map<PacketViewModel, PacketEntity>(packet);

            packetEntity.Packets = string.Join(";", packet.Packets.Where(p => p.IsEnadled).Select(p => p.Id).ToList());
            packetEntity.Modules = string.Join(";", packet.Modules.Where(p => p.IsEnadled).Select(p => p.Name).ToList());

            return packetEntity;
        }
    }
}