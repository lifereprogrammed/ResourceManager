﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace SurveyGridLibrary
{
    /// <summary>
    /// Alberta, Saskatchewan, and parts of Manitoba and parts of British Columbia are mapped on a grid system into townships of 
    /// approximately 36 square miles (6 mi. x 6mi.).  Each township consists of 36 sections (1 mi. x 1 mi).  
    /// Each section is further divided into 16 legal subdivisions (LSDs). The numbering system for sections 
    /// and LSDs uses a back-and-forth system where the numbers may be increasing either to the right or the left
    ///  in the grid. Since the DLS system is based on actual survey data, there can be gaps in the coverage.
    /// 
    /// Given the location: 04-11-082-04W6
    /// Legal Sub division	:04
    /// Section				:11
    /// Township			:082
    /// Range				:04
    /// Meridian			:W6
    /// </summary>
    public struct DlsSystem : IEquatable<DlsSystem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DlsSystem"/> class.
        /// </summary>
        /// <param name="legalSubdivision">The legal subdivision 1-16.</param>
        /// <param name="section">The section 1-36.</param>
        /// <param name="township">The township 1-127.</param>
        /// <param name="range">The range 1-34.</param>
        /// <param name="meridian">The meridian 1-6.</param>
        public DlsSystem(byte legalSubdivision, byte section, byte township, byte range, byte meridian)
        {
            if (legalSubdivision < 1 || legalSubdivision > 16 )
                throw new ArgumentOutOfRangeException(nameof(legalSubdivision), "Legal sub division must be in the range 1-16");
            if (section < 1 || section > 36)
                throw new ArgumentOutOfRangeException(nameof(section), "Section must be in the range 1-36");
            if (township < 1 || township > 127)
                throw new ArgumentOutOfRangeException(nameof(township), "Township must be in the range 1-127");
            if (range < 1 || range > 34)
                throw new ArgumentOutOfRangeException(nameof(range), "Range must be in the range 1-34");
            if (meridian < 1 || meridian > 6)
                throw new ArgumentOutOfRangeException(nameof(meridian), "Meridian must be in the range 1-6");

            LegalSubdivision = legalSubdivision;
            Section = section;
            Township = township;
            Range = range;
            Meridian = meridian;
        }
        
        /// <summary>
        /// Gets the quarter section based on the legal subdivision of this location.
        /// </summary>
        public string Quarter
        {
            get
            {
                //QUARTERS map to lsd as follows:

                //13|14 | 15|16      
                //12|11 | 10|09       NW | NE 
                //-------------      ---------
                //05|06 | 07|08       SW | SE
                //04|03 | 02|01
                
                // lsd are more fine grained than our coordinate, so we choose the appropriate Quarter section 
                string quarter;
                switch (LegalSubdivision)
                {
                    case 1:
                    case 2:
                    case 7:
                    case 8:
                        quarter = "SE";
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        quarter = "SW";
                        break;
                    case 9:
                    case 10:
                    case 15:
                    case 16:
                        quarter = "NE";
                        break;
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        quarter = "NW";
                        break;
                    default:
                        quarter = null;
                        break;
                }
                return quarter;
            }
        }

        /// <summary>
        /// Gets the legal subdivision.
        /// </summary>
        public byte LegalSubdivision { get; }

        /// <summary>
        /// Gets the section.
        /// </summary>
        public byte Section { get; }

        /// <summary>
        /// Gets the township.
        /// </summary>
        public byte Township { get; }

        /// <summary>
        /// Gets the range.
        /// </summary>
        public byte Range { get; }

        /// <summary>
        /// Gets the meridian.
        /// </summary>
        public byte Meridian { get; }

        /// <summary>
        /// Gets the direction identifier, for now only 'W' meridians are supported
        /// </summary>
        public char Direction
        {
            get { return 'W'; }
        }
        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{LegalSubdivision:d2}-{Section:d2}-{Township:d3}-{Range:d2}{Direction}{Meridian:d1}";
        }

        /// <summary>
        /// Parses the specified location into a dls structure, this routine assumes that the location is west of the prime meridian.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        /// <exception cref="CoordinateParseException"></exception>
        public static DlsSystem Parse(string location, ParseOptions options = ParseOptions.None)
        {
            // the incoming location can be a well identifier or a well location 
            // a location looks like:04-11-082-04W6
            // a unique well identifier:100/04-11-082-04W6/0
            if (location == null)
                throw new CoordinateParseException("Can not parse a null location.");
            
            if (string.IsNullOrWhiteSpace(location))
                throw new CoordinateParseException("Can not parse an empty location.");

            //parsing is easier when we only deal with a single case
            location = location.ToUpper();

            if (location.EndsWith("M"))
                location = location.TrimEnd('M');


            //determine the meridian
            int directionIndex = location.LastIndexOf('W');
            if (directionIndex == -1)
            {
                directionIndex = location.LastIndexOf('E');
                if (directionIndex == -1) 
                    throw new CoordinateParseException("DLS location must contain at least one direction as 'W' or 'E'.");
            }

            char direction = location[directionIndex];

            //look for the mer buff
            char merBuff = '\0';
            for (int y = directionIndex + 1; y < location.Length; y++ )
            {
                merBuff = location[y];
                if (char.IsDigit(merBuff) || merBuff == 'P')
                    break;
            }	
            
            byte mer;
            if (merBuff == 'P')
                mer = 1;
            else
            {
                if(!byte.TryParse(merBuff.ToString(), out mer))
                    throw new CoordinateParseException($"Meridian {merBuff} is not a valid number");
            }

            if (direction == 'W' && (mer < 1 || mer > 8))
                throw new CoordinateParseException("Meridian must be in the range 1 to 8.");

            if (direction == 'E')
                throw new CoordinateParseException("East Meridian is not supported.");
            
            location = location.Substring(0, directionIndex);

            //split the location into rng/twn/sec/lsd
            var parts = new List<string>(SplitString(location));
            if(parts.Count < 4)
                throw new CoordinateParseException("DLS location must have range/twp/sec/lsd.");

            //read the dls from right to left as this tends to be more robust when people enter garbage up front

            if(!byte.TryParse(parts[0].Trim(), out var rng))
                throw new CoordinateParseException($"Rng {parts[0]} is not valid.");
            if (mer != 1 && (rng < 1 || rng > 30))
                    throw new CoordinateParseException("Rng must be in the range 1 to 30.");
            if (mer == 1 && (rng < 1 || rng > 34))
                throw new CoordinateParseException("Rng must be in the range 1 to 34.");

            if (!byte.TryParse(parts[1].Trim(), out var twp))
                throw new CoordinateParseException($"Township {parts[1]} is not valid.");
            if (twp < 1 | twp > 126)
                throw new CoordinateParseException("Township must be in the range 1 to 126.");

            if (!byte.TryParse(parts[2].Trim(), out var sec))
                throw new CoordinateParseException($"Section {parts[2]} is not valid.");
            if (sec < 1 | sec > 36)
                throw new CoordinateParseException("Section must be in the range 1 to 36.");

            string lsdString = parts[3].Trim();
            if (!byte.TryParse(lsdString, out var lsd))
            {
                //if we allow quarters i.e. 'SW-12-065-04 W4M' then look for one now and translate it as an legal subdivision center
                // note that there is some loss of precision inherit in this process as each quarter contains 4 LSD's
                if ((options & ParseOptions.AllowQuarters) == ParseOptions.AllowQuarters)
                {
                    switch (lsdString)
                    {
                        case "NW":
                            lsd = 11;
                            break;
                        case "NE":
                            lsd = 10;
                            break;
                        case "SW":
                            lsd = 6;
                            break;
                        case "SE":
                            lsd = 7;
                            break;
                    }
                }

                if(lsd == 0)
                {
                    //occasionally we get an lsd like 'A06' or 'B2' so we attempt to tease it out here
                    for (byte b = 16; b >= 1; b--)
                    {
                        if(lsdString.Contains(b.ToString(CultureInfo.InvariantCulture)))
                        {
                            lsd = b;
                            break;
                        }
                    }

                    if(lsd==0)
                        throw new CoordinateParseException($"Legal Subdivision {parts[3]} is not valid.");
                }
            }
            if (lsd < 1 | lsd > 16)
                throw new CoordinateParseException("Legal Subdivision must be in the range 1 to 16.");
            
            return new DlsSystem(lsd, sec, twp, rng, mer);
        }

        private static IEnumerable<string> SplitString(string location)
        {
            int len = location.Length;
            string buff = string.Empty;
            for (int i = len - 1; i >= 0; i--)
            {
                char c = location[i];
                if ((c >= '0' && c <= '9') ||(c >='A' && c <='Z'))
                    buff = c + buff;
                else
                {
                    //push the number in buffer to the next place holder
                    if (buff.Length != 0)
                        yield return buff;
                    buff = string.Empty;
                }
            }

            if (buff.Length != 0)
                yield return buff;
        }
        
        #region Conversion

        /// <summary>
        /// Return lat/long for this dls
        /// </summary>
        /// <returns></returns>
        public LatLongCoordinate ToLatLong()
        {
            return DlsSystemConverter.ToLatLong(this);
        }
        public static LatLongCoordinate ToLatLong(DlsSystem system)
        {
            return DlsSystemConverter.ToLatLong(system);
        }

        #endregion

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(DlsSystem other)
        {
            return this == other;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public override bool Equals(object other)
        {
            return other is DlsSystem system && this == system;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Direction.GetHashCode() ^
                   LegalSubdivision.GetHashCode() ^
                   Meridian.GetHashCode() ^
                   Range.GetHashCode() ^
                   Section.GetHashCode() ^
                   Township.GetHashCode();
        }

        /// <summary>
        /// Returns true if the value of the unique well identifiers is the same
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(DlsSystem x, DlsSystem y)
        {
            return x.Direction == y.Direction &&
                   x.LegalSubdivision == y.LegalSubdivision &&
                   x.Meridian == y.Meridian &&
                   x.Range == y.Range &&
                   x.Section == y.Section &&
                   x.Township == y.Township;
        }

        /// <summary>
        /// Returns true if the value of the unique well identifiers is not the same
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(DlsSystem x, DlsSystem y)
        {
            return !(x == y);
        }
    }

    /// <summary>
    /// Enumeration of parsing options
    /// </summary>
    [Flags]
    public enum ParseOptions
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Allow Quarters
        /// </summary>
        AllowQuarters
    }
}
