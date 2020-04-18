// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.Solosu.UI;
using osu.Game.Tests.Visual;
using osuTK;

namespace osu.Game.Rulesets.Solosu.Tests.UI
{
    [TestFixture]
    public class TestScenePlayfield : OsuTestScene
    {
        private const double default_duration = 1000;
        private const float scroll_time = 1000;
        protected override double TimePerAction => default_duration * 2;
        private readonly Random rng = new Random(1337);
        private DrawableSolosuRuleset drawableRuleset;
        private Container playfieldContainer;

        [BackgroundDependencyLoader]
        private void load()
        {
            //TODO: Add hitobject steps. (e.g. AddStep("Packet"))

            AddStep("Width test 1", () => changePlayfieldSize(1));
            AddStep("Width test 2", () => changePlayfieldSize(2));
            AddStep("Width test 3", () => changePlayfieldSize(3));
            AddStep("Width test 4", () => changePlayfieldSize(4));
            AddStep("Width test 5", () => changePlayfieldSize(5));
            AddStep("Reset Width", () => changePlayfieldSize(6));

            var controlPointInfo = new ControlPointInfo();
            controlPointInfo.Add(0, new TimingControlPoint());

            WorkingBeatmap beatmap = CreateWorkingBeatmap(new Beatmap
            {
                HitObjects = new List<HitObject> { new SolosuByteObject() },
                BeatmapInfo = new BeatmapInfo
                {
                    BaseDifficulty = new BeatmapDifficulty(),
                    Metadata = new BeatmapMetadata
                    {
                        Artist = "Unknown",
                        Title = "Sample Beatmap",
                        AuthorString = "Coppertine"
                    },
                    Ruleset = new SolosuRuleset().RulesetInfo
                },
                ControlPointInfo = controlPointInfo
            });

            Add(playfieldContainer = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Y,
                Width = 768,
                Children = new[] 
                {
                    drawableRuleset = new DrawableSolosuRuleset(new SolosuRuleset(),
                        beatmap.GetPlayableBeatmap(new SolosuRuleset().RulesetInfo))
                }
            });
        }

        private void changePlayfieldSize(int step)
        {
            double delay = 0;
            //TODO: Add in hitobjects to simulate situation when playfield does change size.

            switch (step)
            {
                default:
                    playfieldContainer.Delay(delay).ResizeTo(new Vector2(rng.Next(25, 400),1), 500);
                    break;

                case 6:
                    playfieldContainer.Delay(delay).ResizeTo(new Vector2(SolosuPlayfield.DEFAULT_WIDTH, 1), 500);
                    break;
            }
        }
    }
}
