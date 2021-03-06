﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Input.Handlers;
using osu.Game.Replays;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.Solosu.Objects.Drawables;
using osu.Game.Rulesets.Solosu.Replays;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.Solosu.UI
{
    [Cached]
    public class DrawableSolosuRuleset : DrawableScrollingRuleset<SolosuHitObject>
    {
        public DrawableSolosuRuleset(SolosuRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
            : base(ruleset, beatmap, mods)
        {
            Direction.Value = ScrollingDirection.Up;
            TimeRange.Value = 6000;
        }

        protected override Playfield CreatePlayfield() => new SolosuPlayfield();

        protected override ReplayInputHandler CreateReplayInputHandler(Replay replay) => new SolosuFramedReplayInputHandler(replay);

        //TODO: Include other types.
        public override DrawableHitObject<SolosuHitObject> CreateDrawableRepresentation(SolosuHitObject h)
        {
            switch (h)
            {
                case SolosuByteObject solosuByteObject:
                    return new DrawableByte(solosuByteObject);

                case SolosuBugObject solosuBugObject:
                    return null; // todo: change to DrawableBug when implemented.
            }

            return null;
        }

        protected override PassThroughInputManager CreateInputManager() => new SolosuInputManager(Ruleset?.RulesetInfo);
    }
}
