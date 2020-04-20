// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Game.Rulesets.Solosu.Objects.Drawables;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Solosu.Tests.Objects
{
    [TestFixture]
    public class TestSceneByte : PlayerTestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(DrawableByte)
        };

        public TestSceneByte(Ruleset ruleset)
            : base(ruleset)
        {
        }
    }
}
