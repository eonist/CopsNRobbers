using System;
using System.Collections.Generic;
using CopsNRobbers_shared.DataModels;
using GTANetworkAPI;

namespace Server.DataModels.Teams
{
    internal static class TeamMethods
    {
        private static readonly Random Random = new Random();

        private static readonly Dictionary<Team, int> ClientTeam = new Dictionary<Team, int>
        {
            {Team.None, 1},
            {Team.Cops, 2},
            {Team.Robbers, 3}
        };

        private static readonly Dictionary<Team, PedHash[]> Skins = new Dictionary<Team, PedHash[]>
        {
            {Team.None, new[] {PedHash.Devin}},
            {
                Team.Cops, new[]
                {
                    PedHash.Cop01SMY,
                    PedHash.Cop01SFY
                }
            },
            {
                Team.Robbers, new[]
                {
                    PedHash.JewelThief,
                    PedHash.Antonb,
                    PedHash.Jesus01
                }
            }
        };

        private static readonly Spawn SpawnSomeBuilding =
            new Spawn(new Vector3(384.2621, -1025.798, 29.49788), new Vector3(0, 0, 0));

        private static readonly Dictionary<Team, Spawn[]> Spawns = new Dictionary<Team, Spawn[]>
        {
            {Team.None, new[] {SpawnSomeBuilding}},
            {
                Team.Cops, new[]
                {
                    new Spawn(new Vector3(459.4314, -992.6832, 30.68961),
                        new Vector3(0, 0, 193.0178)), // locker_room_corner
                    new Spawn(new Vector3(456.2621, -993.128, 30.68961),
                        new Vector3(0, 0, 0.01944129)), // locker_room_towels
                    new Spawn(new Vector3(454.4992, -989.4376, 30.68961),
                        new Vector3(0, 0, 359.9846)), // locker_room_mirror
                    new Spawn(new Vector3(459.5041, -989.277, 30.6896),
                        new Vector3(0, 0, 273.7247)), // locker_room_water_cooler
                    new Spawn(new Vector3(451.2793, -988.895, 30.6896),
                        new Vector3(0, 0, 88.09474)), // locker_room_note_board
                    new Spawn(new Vector3(469.2402, -987.1256, 30.68958),
                        new Vector3(0, 0, 356.0968)), // stairwell
                    new Spawn(new Vector3(457.2933, -985.8042, 30.68959),
                        new Vector3(0, 0, 175.7606)), // locker_room_corridor_note_board
                    new Spawn(new Vector3(447.0266, -976.1878, 30.6896),
                        new Vector3(0, 0, 352.0185)), // captains_office_table
                    new Spawn(new Vector3(452.1702, -976.0577, 30.6896),
                        new Vector3(0, 0, 263.2614)), // captains_office_diplomas
                    new Spawn(new Vector3(452.3714, -980.2695, 30.6896),
                        new Vector3(0, 0, 265.6098)), // armory_reception
                    new Spawn(new Vector3(441.1688, -978.6996, 30.6896),
                        new Vector3(0, 0, 204.5098)), // reception_front
                    new Spawn(new Vector3(440.7785, -975.723, 30.6896),
                        new Vector3(0, 0, 6.804764)), // reception_whiteboard
                    new Spawn(new Vector3(443.7887, -975.9213, 30.6896),
                        new Vector3(0, 0, 355.5812)), // reception_bookshelf
                    new Spawn(new Vector3(436.0973, -979.0249, 30.68961),
                        new Vector3(0, 0, 5.065526)), // reception_water_cooler
                    new Spawn(new Vector3(436.6555, -986.5029, 30.68962),
                        new Vector3(0, 0, 95.77424)), // reception_soda_machine
                    new Spawn(new Vector3(437.6434, -991.1364, 30.6896),
                        new Vector3(0, 0, 358.6295)), // briefing_room_tv
                    new Spawn(new Vector3(439.9313, -990.4321, 30.6896),
                        new Vector3(0, 0, 2.807566)), // briefing_room_water_cooler
                    new Spawn(new Vector3(439.1449, -993.2102, 30.6896),
                        new Vector3(0, 0, 85.91879)), // briefing_room_projector
                    new Spawn(new Vector3(441.8389, -995.6826, 30.6896),
                        new Vector3(0, 0, 275.985)), // briefing_room_note_board
                    new Spawn(new Vector3(449.6859, -987.5282, 26.67421),
                        new Vector3(0, 0, 188.9095)), // downstairs_corridor_coffee_machine
                    new Spawn(new Vector3(459.5276, -989.3241, 24.91484),
                        new Vector3(0, 0, 263.054)), // cells_desk
                    new Spawn(new Vector3(461.7723, -988.942, 24.91488),
                        new Vector3(0, 0, 90.83815)), // cells_desk_waiting
                    new Spawn(new Vector3(464.0397, -991.5659, 24.91488),
                        new Vector3(0, 0, 161.4064)) // cells_door
                }
            },
            {Team.Robbers, new[] {SpawnSomeBuilding}}
        };

        private static readonly Dictionary<Team, LoadOutWeapon[]> LoadOuts = new Dictionary<Team, LoadOutWeapon[]>
        {
            {
                Team.None, new[]
                {
                    new LoadOutWeapon(WeaponHash.Snowball)
                }
            },
            {
                Team.Cops, new[]
                {
                    new LoadOutWeapon(WeaponHash.Nightstick),
                    new LoadOutWeapon(WeaponHash.Flashlight),
                    new LoadOutWeapon(WeaponHash.Pistol, 120)
                }
            },
            {
                Team.Robbers, new[]
                {
                    new LoadOutWeapon(WeaponHash.Bat)
                }
            }
        };

        private static readonly Dictionary<Team, Vehicle[]> Vehicles = new Dictionary<Team, Vehicle[]>
        {
            {
                Team.None, new[]
                {
                    new Vehicle(VehicleHash.Asea),
                    new Vehicle(VehicleHash.Asterope),
                    new Vehicle(VehicleHash.Emperor),
                    new Vehicle(VehicleHash.Premier)
                }
            },
            {
                Team.Cops, new[]
                {
                    new Vehicle(VehicleHash.Police, 111, 1),
                    new Vehicle(VehicleHash.Police2, 111, 1),
                    new Vehicle(VehicleHash.Police3, 111, 1)
                }
            },
            {
                Team.Robbers, new[]
                {
                    new Vehicle(VehicleHash.Fugitive),
                    new Vehicle(VehicleHash.Tailgater),
                    new Vehicle(VehicleHash.Superd),
                    new Vehicle(VehicleHash.Schafter5),
                    new Vehicle(VehicleHash.Intruder)
                }
            }
        };

        public static int GetClientTeam(this Team team)
        {
            return ClientTeam[team];
        }

        public static PedHash GetSkin(this Team team)
        {
            var randomizedIndex = Random.Next(0, Skins[team].Length);
            return Skins[team][randomizedIndex];
        }

        public static Spawn GetSpawn(this Team team)
        {
            var randomizedIndex = Random.Next(0, Spawns[team].Length);
            return Spawns[team][randomizedIndex];
        }

        public static LoadOutWeapon[] GetLoadOut(this Team team)
        {
            return LoadOuts[team];
        }

        public static Vehicle GetVehicle(this Team team)
        {
            var randomizedIndex = Random.Next(0, Vehicles[team].Length);
            return Vehicles[team][randomizedIndex];
        }
    }
}