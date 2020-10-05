﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition CompetitionData { get; set; }

        public static Race CurrentRace { get; set; }

        public static event EventHandler<RaceStartEventArgs> VisualizationNextRaceEventHandler;

        public static void Initialize()
        {
            CompetitionData = new Competition();
            addParticipants();
            addTracks();
        }

        public static void addParticipants()
        {
            CompetitionData.Participants.Add(new Driver("Jaap", 0, new Car(10, 10, 5, false), TeamColors.Red));
            CompetitionData.Participants.Add(new Driver("Sjaak", 0, new Car(10, 10, 10, false), TeamColors.Green));
            CompetitionData.Participants.Add(new Driver("Manus", 0, new Car(10, 10, 11, false), TeamColors.Blue));
            CompetitionData.Participants.Add(new Driver("Arie", 0, new Car(10, 10, 10, false), TeamColors.Red));
            CompetitionData.Participants.Add(new Driver("Lars", 0, new Car(10, 10, 12, false), TeamColors.Green));
            CompetitionData.Participants.Add(new Driver("Elsa", 0, new Car(10, 10, 15, false), TeamColors.Blue));
        }

        public static void addTracks()
        {
            CompetitionData.Tracks.Enqueue(new Track("Baan1", new SectionTypes[]
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight
            }));

            CompetitionData.Tracks.Enqueue(new Track("Ovaal", new SectionTypes[] 
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner
            }));

            CompetitionData.Tracks.Enqueue(new Track("Baan3", new SectionTypes[]
            {
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.StartGrid,
                SectionTypes.Finish,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.Straight,
                SectionTypes.LeftCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner,
                SectionTypes.Straight,
                SectionTypes.RightCorner
            })); ;
        }

        public static void NextRace()
        {
            // cleanup previous race
            if (CurrentRace != null) // this is because first time there is no previous race to clean up
            {
                CurrentRace.CleanUp();
            }

            // get next track from competitionData, then perform null check. when not null create a new race.
            Track currentTrack = CompetitionData.NextTrack();
            if (currentTrack != null)
            {
                CurrentRace = new Race(currentTrack, CompetitionData.Participants);
                CurrentRace.RaceFinished += OnRaceFinished;
                VisualizationNextRaceEventHandler?.Invoke(null, new RaceStartEventArgs() { Race = CurrentRace});
                CurrentRace.Start();

            }
        }

        public static void OnRaceFinished(object sender, EventArgs e)
        {
            NextRace();
        }
    }
}
