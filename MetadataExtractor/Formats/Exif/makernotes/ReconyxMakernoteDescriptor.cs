#region License
//
// Copyright 2002-2016 Drew Noakes
// Ported from Java to C# by Yakov Danilov for Imazen LLC in 2014
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
// More information about this project is available at:
//
//    https://github.com/drewnoakes/metadata-extractor-dotnet
//    https://drewnoakes.com/code/exif/
//
#endregion

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace MetadataExtractor.Formats.Exif.Makernotes
{
    /// <summary>
    /// Provides human-readable string representations of tag values stored in a <see cref="ReconyxMakernoteDirectory"/>.
    /// </summary>
    /// <author>Todd West http://cascadescarnivoreproject.blogspot.com</author>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class ReconyxMakernoteDescriptor : TagDescriptor<ReconyxMakernoteDirectory>
    {
        public ReconyxMakernoteDescriptor([NotNull] ReconyxMakernoteDirectory directory)
            : base(directory)
        {
        }

        public override string GetDescription(int tagType)
        {
            switch (tagType)
            {
                case ReconyxMakernoteDirectory.TagMakernoteVersion:
                    return Directory.GetUInt16(tagType).ToString();
                case ReconyxMakernoteDirectory.TagFirmwareVersion:
                    // invokes Version.ToString()
                    return Directory.GetString(tagType);
                case ReconyxMakernoteDirectory.TagFirmwareDate:
                    int[] firmwareDate = Directory.GetInt32Array(tagType);
                    return string.Format("{0} {1}", firmwareDate[0], firmwareDate[1]);
                case ReconyxMakernoteDirectory.TagTriggerMode:
                    return Directory.GetString(tagType);
                case ReconyxMakernoteDirectory.TagSequence:
                    int[] sequence = Directory.GetInt32Array(tagType);
                    return string.Format("{0}/{1}", sequence[0], sequence[1]);
                case ReconyxMakernoteDirectory.TagEventNumber:
                    int[] eventNumber = Directory.GetInt32Array(tagType);
                    return string.Format("{0} {1}", eventNumber[0], eventNumber[1]);
                case ReconyxMakernoteDirectory.TagMotionSensitivity:
                    return Directory.GetUInt16(tagType).ToString();
                case ReconyxMakernoteDirectory.TagBatteryVoltage:
                    return Directory.GetDouble(tagType).ToString("0.000");
                case ReconyxMakernoteDirectory.TagDateTimeOriginal:
                    return Directory.GetDateTime(tagType).ToString("yyyy:MM:dd HH:mm:ss");
                case ReconyxMakernoteDirectory.TagMoonPhase:
                    return GetIndexedDescription(tagType, "New", "New Crescent", "First Quarter", "Waxing Gibbous", "Full", "Waning Gibbous", "Last Quarter", "Old Crescent");
                case ReconyxMakernoteDirectory.TagAmbientTemperatureFarenheit:
                case ReconyxMakernoteDirectory.TagAmbientTemperature:
                    return Directory.GetInt16(tagType).ToString();
                case ReconyxMakernoteDirectory.TagSerialNumber:
                    return Directory.GetString(tagType);
                case ReconyxMakernoteDirectory.TagContrast:
                case ReconyxMakernoteDirectory.TagBrightness:
                case ReconyxMakernoteDirectory.TagSharpness:
                case ReconyxMakernoteDirectory.TagSaturation:
                    return Directory.GetUInt16(tagType).ToString();
                case ReconyxMakernoteDirectory.TagInfraredIlluminator:
                    return GetIndexedDescription(tagType, "Off", "On");
                case ReconyxMakernoteDirectory.TagUserLabel:
                    return Directory.GetString(tagType);
                default:
                    return base.GetDescription(tagType);
            }
        }
    }
}
