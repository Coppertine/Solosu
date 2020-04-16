// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Replays;
using osu.Game.Rulesets.Solosu.Objects;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Solosu.Replays
{
    public class SolosuAutoGenerator : AutoGenerator
    {
        protected Replay Replay;
        protected List<ReplayFrame> Frames => Replay.Frames;

        public new Beatmap<SolosuHitObject> Beatmap => (Beatmap<SolosuHitObject>)base.Beatmap;

        public SolosuAutoGenerator(IBeatmap beatmap)
            : base(beatmap)
        {
            Replay = new Replay();
        }

        public override Replay Generate()
        {
            Frames.Add(new SolosuReplayFrame());

            foreach (SolosuHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new SolosuReplayFrame
                {
                    Time = hitObject.StartTime
                    // todo: add required inputs and extra frames.
                });
            }

            return Replay;
        }
    }
}
