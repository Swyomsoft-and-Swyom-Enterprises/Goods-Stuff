//	Program Name: - ToneGen.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  When Open the Door the music is on
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 2 December 2K8 4.10 PM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


//    Microsoft Small Basic - Tone Generator extension by Rushworks

using Microsoft.SmallBasic.Library;
using System;

namespace ToneGen
{
    /// <summary>
    /// Extension to play sounds with the internal speaker.
    /// </summary>
    [SmallBasicType]    
    public static class ToneGenerator
    {
        /// <summary>
        /// Plays musical notes through the internal speaker.
        /// </summary>
        /// <param name="commandString">
        /// Commands:
        /// O (1-6) =  sets the octave   ex. O3
        /// L (1-9)=  sets the length the note is played   ex. L2
        /// P (1-9)=  Pauses string   ex. P7
        /// Music notes:
        /// C, C#, D, D#, E, F, F#, G, G#, A, A#, B
        /// </param>
        public static void PlayString(Primitive commandString)
        {
            string s, note, n;
            int oct = 3, noteLength = 640, pauseNoteLength = 640;
            
            s = commandString + ".";
            s = s.ToUpper();
            for (int i = 0; i <= s.Length; i++)
            {
                note = s.Substring(i, 1);
                if (note == ".")
                {
                    //the string is over use 'return' to avoid error
                    return;
                }
                if (i < s.Length)
                {
                    if (s.Substring(i + 1, 1) == "#")
                    {
                        note = note + "#";
                        i++;
                    }
                    if (note.ToUpper() == "O")
                    {
                        i++;
                        n = s.Substring(i, 1);
                        switch (n)
                        {
                            case "1": oct = 1; break;
                            case "2": oct = 2; break;
                            case "3": oct = 3; break;
                            case "4": oct = 4; break;
                            case "5": oct = 5; break;
                            case "6": oct = 6; break;

                            // Octave not recognized, don't change
                            // back i up to previous spot
                            default:
                                i--; break;
                        }
                    }
                    if (note == "L")
                    {
                        i++;
                        n = s.Substring(i, 1);
                        switch (n)
                        {
                            case "1": noteLength = 320; break;
                            case "2": noteLength = 480; break;
                            case "3": noteLength = 640; break;
                            case "4": noteLength = 800; break;
                            case "5": noteLength = 960; break;
                            case "6": noteLength = 1120; break;
                            case "7": noteLength = 1280; break;
                            case "8": noteLength = 1440; break;
                            case "9": noteLength = 1600; break;

                            // Length not recognized, don't change
                            // back i up to previous spot
                            default:
                                i--; break;
                        }
                    }
                    if (note == "P")
                    {
                        i++;
                        n = s.Substring(i, 1);
                        switch (n)
                        {
                            case "1": pauseNoteLength = 320; break;
                            case "2": pauseNoteLength = 480; break;
                            case "3": pauseNoteLength = 640; break;
                            case "4": pauseNoteLength = 800; break;
                            case "5": pauseNoteLength = 960; break;
                            case "6": pauseNoteLength = 1120; break;
                            case "7": pauseNoteLength = 1280; break;
                            case "8": pauseNoteLength = 1440; break;
                            case "9": pauseNoteLength = 1600; break;
                            
                            // Pause not recognized, don't change
                            // back i up to previous spot
                            default:
                                i--; break;
                        }
                        // set frequency so high, no one will hear it for pause
                        System.Console.Beep(32000, pauseNoteLength);
                    }
                }//end if
                switch (note)
                {
                    case "C":  System.Console.Beep(65 * (oct * oct), noteLength); break;
                    case "C#": System.Console.Beep(69 * (oct * oct), noteLength); break;
                    case "D":  System.Console.Beep(73 * (oct * oct), noteLength); break;
                    case "D#": System.Console.Beep(78 * (oct * oct), noteLength); break;
                    case "E":  System.Console.Beep(82 * (oct * oct), noteLength); break;
                    case "F":  System.Console.Beep(87 * (oct * oct), noteLength); break;
                    case "F#": System.Console.Beep(92 * (oct * oct), noteLength); break;
                    case "G":  System.Console.Beep(98 * (oct * oct), noteLength); break;
                    case "G#": System.Console.Beep(104 * (oct * oct), noteLength); break;
                    case "A":  System.Console.Beep(110 * (oct * oct), noteLength); break;
                    case "A#": System.Console.Beep(116 * (oct * oct), noteLength); break;
                    case "B": System.Console.Beep(123 * (oct * oct), noteLength); break;
                    case ">": if (oct < 6) { oct++; } break;
                    case "<": if (oct > 1) { oct--; } break;
                    default: break;
                }
            }//end for
        }//end playstring

        /// <summary>Plays the sound of a beep of a specified frequency and duration through the console speaker.</summary>
        /// <param name="frequency">  The frequency of the beep, ranging from 37 to 32767 hertz.</param>
        /// <param name="duration">  The duration of the beep measured in milliseconds.</param>
        public static void PlayTone(Primitive frequency, Primitive duration)
        {
            System.Console.Beep(frequency, duration);
        }//end PlaySound

    }//end class ToneGenerator
}//end namespace ToneGen
