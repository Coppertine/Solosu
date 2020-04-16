// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Solosu.Judgements;

namespace osu.Game.Rulesets.Solosu.Objects
{
    /// <summary>
    /// Represents a hit object which has a single hit press.
    /// </summary>
    public class SolosuByteObject : SolosuHitObject
    {
        public override Judgement CreateJudgement() => new SolosuJudgement();
    }
}
