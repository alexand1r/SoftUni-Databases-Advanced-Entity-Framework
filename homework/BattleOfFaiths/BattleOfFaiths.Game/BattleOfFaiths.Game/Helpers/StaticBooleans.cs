﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleOfFaiths.Game.Helpers
{
    public class StaticBooleans
    {
        public static bool IsLoadGamesOn;
        public static bool HasNewGame;

        public static bool IsShopOpen;
        public static bool IsGameMenuInitialized;

        public static void SetLoadGamesBool(bool value)
        {
            IsLoadGamesOn = value;
        }

        public static void SetHasNewGame(bool value)
        {
            HasNewGame = value;
        }

        public static void SetOpenShopBool(bool value)
        {
            IsShopOpen = value;
        }

        public static void SetIsGameMenuInitializedBool(bool value)
        {
            IsGameMenuInitialized = value;
        }
    }
}
