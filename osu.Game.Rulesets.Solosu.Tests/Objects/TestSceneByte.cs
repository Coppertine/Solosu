// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Solosu.Tests.Objects
{
    [TestFixture]
    public class TestSceneByte : PlayerTestScene
    {
        public TestSceneByte()
            : base(new SolosuRuleset())
        {
        }
    }
}
