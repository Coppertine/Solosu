// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Solosu.UI.Packet;

namespace osu.Game.Rulesets.Solosu.Tests.UI
{
    [TestFixture]
    public class TestScenePlayerPacket : SolosuInputTestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(SolosuPacket)
        };

        public TestScenePlayerPacket()
            : base(0)
        {
            AddStep("Move Left", () => testMove(TestMovement.Left));
            AddStep("Move Right", () => testMove(TestMovement.Right));
        }

        private readonly Container content;
        protected override Container<Drawable> Content => content;
        private int depthIndex;

        private void testMove(TestMovement movement)
        {
        }

        private enum TestMovement
        {
            Left,
            Right
        }
    }
}
