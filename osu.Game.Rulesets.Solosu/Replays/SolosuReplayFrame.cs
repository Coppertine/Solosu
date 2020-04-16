// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Rulesets.Replays;

namespace osu.Game.Rulesets.Solosu.Replays
{
    public class SolosuReplayFrame : ReplayFrame
    {
        public List<SolosuAction> Actions = new List<SolosuAction>();

        public SolosuReplayFrame(SolosuAction? button = null)
        {
            if (button.HasValue)
                Actions.Add(button.Value);
        }
    }
}
