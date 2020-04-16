﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Input.StateChanges;
using osu.Game.Replays;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Solosu.Replays
{
    public class SolosuFramedReplayInputHandler : FramedReplayInputHandler<SolosuReplayFrame>
    {
        public SolosuFramedReplayInputHandler(Replay replay)
            : base(replay)
        {
        }

        protected override bool IsImportant(SolosuReplayFrame frame) => frame.Actions.Any();

        public override List<IInput> GetPendingInputs()
        {
            return new List<IInput>
            {
                new ReplayState<SolosuAction>
                {
                    PressedActions = CurrentFrame?.Actions ?? new List<SolosuAction>(),
                }
            };
        }
    }
}
