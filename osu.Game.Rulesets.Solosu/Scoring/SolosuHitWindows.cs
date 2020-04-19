// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Solosu.Scoring
{
    public class SolosuHitWindows : HitWindows
    {
        public override bool IsHitResultAllowed(HitResult result)
        {
            switch (result)
            {
                case HitResult.Great:
                case HitResult.Meh:
                case HitResult.Ok:
                case HitResult.Miss:
                    return true;
            }

            return false;
        }

        protected override DifficultyRange[] GetRanges() => new[]
        {
            new DifficultyRange(HitResult.Great, 22.4, 19.4, 13.9),
            new DifficultyRange(HitResult.Good, 64.0, 49.0, 34.0),
            new DifficultyRange(HitResult.Ok, 97.0, 82.0, 67.0),
            new DifficultyRange(HitResult.Meh, sbyte.MaxValue, 112.0, 97.0),
            new DifficultyRange(HitResult.Miss, 151.0, 136.0, 121.0),
        };
    }
}
