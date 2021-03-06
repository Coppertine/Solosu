﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.Solosu.Replays;
using osu.Game.Scoring;
using osu.Game.Users;

namespace osu.Game.Rulesets.Solosu.Mods
{
    public class SolosuModAutoplay : ModAutoplay<SolosuHitObject>
    {
        public override Score CreateReplayScore(IBeatmap beatmap) => new Score
        {
            ScoreInfo = new ScoreInfo
            {
                User = new User { Username = "Solosu" },
            },
            Replay = new SolosuAutoGenerator(beatmap).Generate(),
        };
    }
}
