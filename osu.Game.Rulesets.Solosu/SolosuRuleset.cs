﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Solosu.Beatmaps;
using osu.Game.Rulesets.Solosu.Mods;
using osu.Game.Rulesets.Solosu.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Solosu
{
    public class SolosuRuleset : Ruleset
    {
        public override string Description => "solosu";

        public override DrawableRuleset CreateDrawableRulesetWith(IBeatmap beatmap, IReadOnlyList<Mod> mods = null) => new DrawableSolosuRuleset(this, beatmap, mods);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new SolosuBeatmapConverter(beatmap, this);

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) => new SolosuDifficultyCalculator(this, beatmap);

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Automation:
                    return new[] { new SolosuModAutoplay() };

                default:
                    return new Mod[] { null };
            }
        }

        public override string ShortName => "solosu";
        public override string PlayingVerb => "Collecting Bytes";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Left, SolosuAction.LeftButton),
            new KeyBinding(InputKey.Right, SolosuAction.RightButton),
            new KeyBinding(InputKey.Z, SolosuAction.Button1),
            new KeyBinding(InputKey.X, SolosuAction.Button2),
        };

        public override Drawable CreateIcon() => new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Text = ShortName[0].ToString(),
            Font = OsuFont.Default.With(size: 18),
        };
    }
}
