﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Utils
{
    public class GameHash
    {
        public static bool ValidateFile(string path, Game game)
        {
            using MD5 md5Hash = MD5.Create();
            using FileStream file = File.OpenRead(path);
            var gameHash = GetGameHash(game);
            return gameHash.Length == 0 || gameHash.SequenceEqual(md5Hash.ComputeHash(file));
        }

        private static byte[] GetGameHash(Game game)
        {
            return game switch
            {
                Game.Yakuza3 => new byte[] { 172, 112, 65, 90, 116, 185, 119, 107, 139, 148, 48, 80, 40, 13, 107, 113 },
                Game.Yakuza4 => new byte[] { 41, 89, 36, 15, 180, 25, 237, 66, 222, 176, 78, 130, 33, 146, 77, 132 },
                Game.Yakuza5 => new byte[] { 51, 96, 128, 207, 98, 131, 90, 216, 213, 88, 198, 186, 60, 99, 176, 201 },
                Game.Yakuza0 => new byte[] { 168, 70, 120, 237, 170, 16, 229, 118, 232, 54, 167, 130, 194, 37, 220, 14 },
                Game.YakuzaKiwami => new byte[] { 142, 39, 38, 133, 251, 26, 47, 181, 222, 56, 98, 207, 178, 123, 175, 8 },
                Game.Yakuza6 => new byte[] { 003 074 001 122 239 147 032 206 253 233 202 068 039 125 126 187 },
                Game.YakuzaKiwami2 => new byte[] { 143, 2, 192, 39, 60, 179, 172, 44, 242, 201, 155, 226, 50, 192, 204, 0 },
                Game.YakuzaLikeADragon => new byte[] { 188, 204, 133, 1, 251, 100, 190, 56, 10, 122, 164, 173, 244, 134, 246, 5 },
                _ => new byte[] { },
            };
        }
    }
}
