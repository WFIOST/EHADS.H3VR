using System.Collections.Generic;
using BepInEx.Configuration;

namespace EHADS.Core
{
    public struct EHADSConfig
    {
        public static FallDamageConfig        FallDamage        { get; }
        public static EnhancedHealthConfig    EnhancedHealth    { get; }
        public static EnhancedMovementConfig  EnhancedMovement  { get; }

        public class ConfigEntry
        {
            public bool Enabled => EnabledEntry.Value;
            protected ConfigEntry<bool> EnabledEntry;
        }
        
        public class FallDamageConfig : ConfigEntry
        {
            private const string CATEGORY_NAME = "Fall Damages";

            public float FallHeight => _fallHeightEntry.Value;
            private readonly ConfigEntry<float> _fallHeightEntry;

            public float DamageMultiplier => _damageMultiplierEntry.Value;
            private readonly ConfigEntry<float> _damageMultiplierEntry;

            public FallDamageConfig()
            {
                EnabledEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Enabled",
                    true,
                    "If enabled, the player will take Fall Damage based off how far they fall from (configurable)"
                );

                _fallHeightEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Height",
                    20f,
                    "How far you need to fall to take fall damage"
                );

                _damageMultiplierEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Multiplier",
                    1.5f,
                    "The multiplier is multiplied by your velocity (distance traveled between 2 points in 1 second) and is what damages you"
                );
            }
        }

        public class EnhancedHealthConfig : ConfigEntry
        {
            private const string CATEGORY_NAME = "Enhanced Health";

            public float RegenCap => _regenCapEntry.Value;
            private readonly ConfigEntry<float> _regenCapEntry;

            public float RegenDelay => _regenDelayEntry.Value;
            private readonly ConfigEntry<float> _regenDelayEntry;

            public float RegenSpeed => _regenSpeedEntry.Value;
            private readonly ConfigEntry<float> _regenSpeedEntry;

            public EnhancedHealthConfig()
            {
                EnabledEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Enabled",
                    true,
                    "If enabled, Enhanced Health will be active."
                );

                _regenCapEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Regeneration Cap",
                    0.10f,
                    "Limit to how much you may regenerate (Note: this is a percentage so 1 is 100%!)"
                );

                _regenDelayEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Regeneration Delay",
                    10f,
                    "Number of seconds before the regeneration will start"
                );

                _regenSpeedEntry = Plugin.Mod.Config.Bind
                (
                    CATEGORY_NAME,
                    "Regeneration Speed",
                    5f,
                    "How long does it take to regenerate to the regeneration cap"
                );
            }
        }

        public class EnhancedMovementConfig : ConfigEntry
        {
            
        }
        
        static EHADSConfig()
        {
            FallDamage = new FallDamageConfig();
            EnhancedHealth = new EnhancedHealthConfig();
            EnhancedMovement = new EnhancedMovementConfig();
        }
    }
}