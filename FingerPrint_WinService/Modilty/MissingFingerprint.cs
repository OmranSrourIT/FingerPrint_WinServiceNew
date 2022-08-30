using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;


namespace FingerPrint_WinService.Modilty
{

    /// <summary>
    /// MissingFingerprint
    /// </summary>
    [DataContract(Name = "MissingFingerprint")]
    public class MissingFingerprint
    {


            /// <summary>
            /// Enumeration of fingerprint positions. This includes also palm and latent positions.
            /// </summary>
            /// <value>Enumeration of fingerprint positions. This includes also palm and latent positions.</value>
            [JsonConverter(typeof(StringEnumConverter))]
            public enum PositionEnum
            {
                /// <summary>
                /// Enum UnknownFinger for value: UnknownFinger
                /// </summary>
                [EnumMember(Value = "UnknownFinger")]
                UnknownFinger = 1,

                /// <summary>
                /// Enum RightThumb for value: RightThumb
                /// </summary>
                [EnumMember(Value = "RightThumb")]
                RightThumb = 2,

                /// <summary>
                /// Enum RightIndex for value: RightIndex
                /// </summary>
                [EnumMember(Value = "RightIndex")]
                RightIndex = 3,

                /// <summary>
                /// Enum RightMiddle for value: RightMiddle
                /// </summary>
                [EnumMember(Value = "RightMiddle")]
                RightMiddle = 4,

                /// <summary>
                /// Enum RightRing for value: RightRing
                /// </summary>
                [EnumMember(Value = "RightRing")]
                RightRing = 5,

                /// <summary>
                /// Enum RightLittle for value: RightLittle
                /// </summary>
                [EnumMember(Value = "RightLittle")]
                RightLittle = 6,

                /// <summary>
                /// Enum LeftThumb for value: LeftThumb
                /// </summary>
                [EnumMember(Value = "LeftThumb")]
                LeftThumb = 7,

                /// <summary>
                /// Enum LeftIndex for value: LeftIndex
                /// </summary>
                [EnumMember(Value = "LeftIndex")]
                LeftIndex = 8,

                /// <summary>
                /// Enum LeftMiddle for value: LeftMiddle
                /// </summary>
                [EnumMember(Value = "LeftMiddle")]
                LeftMiddle = 9,

                /// <summary>
                /// Enum LeftRing for value: LeftRing
                /// </summary>
                [EnumMember(Value = "LeftRing")]
                LeftRing = 10,

                /// <summary>
                /// Enum LeftLittle for value: LeftLittle
                /// </summary>
                [EnumMember(Value = "LeftLittle")]
                LeftLittle = 11,

                /// <summary>
                /// Enum PlainRightThumb for value: PlainRightThumb
                /// </summary>
                [EnumMember(Value = "PlainRightThumb")]
                PlainRightThumb = 12,

                /// <summary>
                /// Enum PlainLeftThumb for value: PlainLeftThumb
                /// </summary>
                [EnumMember(Value = "PlainLeftThumb")]
                PlainLeftThumb = 13,

                /// <summary>
                /// Enum PlainRightFourFingers for value: PlainRightFourFingers
                /// </summary>
                [EnumMember(Value = "PlainRightFourFingers")]
                PlainRightFourFingers = 14,

                /// <summary>
                /// Enum PlainLeftFourFingers for value: PlainLeftFourFingers
                /// </summary>
                [EnumMember(Value = "PlainLeftFourFingers")]
                PlainLeftFourFingers = 15,

                /// <summary>
                /// Enum PlainThumbsTogether for value: PlainThumbsTogether
                /// </summary>
                [EnumMember(Value = "PlainThumbsTogether")]
                PlainThumbsTogether = 16,

                /// <summary>
                /// Enum UnknownPalm for value: UnknownPalm
                /// </summary>
                [EnumMember(Value = "UnknownPalm")]
                UnknownPalm = 17,

                /// <summary>
                /// Enum RightFullPalm for value: RightFullPalm
                /// </summary>
                [EnumMember(Value = "RightFullPalm")]
                RightFullPalm = 18,

                /// <summary>
                /// Enum RightWritersPalm for value: RightWritersPalm
                /// </summary>
                [EnumMember(Value = "RightWritersPalm")]
                RightWritersPalm = 19,

                /// <summary>
                /// Enum LeftFullPalm for value: LeftFullPalm
                /// </summary>
                [EnumMember(Value = "LeftFullPalm")]
                LeftFullPalm = 20,

                /// <summary>
                /// Enum LeftWritersPalm for value: LeftWritersPalm
                /// </summary>
                [EnumMember(Value = "LeftWritersPalm")]
                LeftWritersPalm = 21,

                /// <summary>
                /// Enum RightLowerPalm for value: RightLowerPalm
                /// </summary>
                [EnumMember(Value = "RightLowerPalm")]
                RightLowerPalm = 22,

                /// <summary>
                /// Enum RightUpperPalm for value: RightUpperPalm
                /// </summary>
                [EnumMember(Value = "RightUpperPalm")]
                RightUpperPalm = 23,

                /// <summary>
                /// Enum LeftLowerPalm for value: LeftLowerPalm
                /// </summary>
                [EnumMember(Value = "LeftLowerPalm")]
                LeftLowerPalm = 24,

                /// <summary>
                /// Enum LeftUpperPalm for value: LeftUpperPalm
                /// </summary>
                [EnumMember(Value = "LeftUpperPalm")]
                LeftUpperPalm = 25,

                /// <summary>
                /// Enum RightOther for value: RightOther
                /// </summary>
                [EnumMember(Value = "RightOther")]
                RightOther = 26,

                /// <summary>
                /// Enum LeftOther for value: LeftOther
                /// </summary>
                [EnumMember(Value = "LeftOther")]
                LeftOther = 27,

                /// <summary>
                /// Enum RightInterdigital for value: RightInterdigital
                /// </summary>
                [EnumMember(Value = "RightInterdigital")]
                RightInterdigital = 28,

                /// <summary>
                /// Enum RightThenar for value: RightThenar
                /// </summary>
                [EnumMember(Value = "RightThenar")]
                RightThenar = 29,

                /// <summary>
                /// Enum RightHypothenar for value: RightHypothenar
                /// </summary>
                [EnumMember(Value = "RightHypothenar")]
                RightHypothenar = 30,

                /// <summary>
                /// Enum LeftInterdigital for value: LeftInterdigital
                /// </summary>
                [EnumMember(Value = "LeftInterdigital")]
                LeftInterdigital = 31,

                /// <summary>
                /// Enum LeftThenar for value: LeftThenar
                /// </summary>
                [EnumMember(Value = "LeftThenar")]
                LeftThenar = 32,

                /// <summary>
                /// Enum LeftHypothenar for value: LeftHypothenar
                /// </summary>
                [EnumMember(Value = "LeftHypothenar")]
                LeftHypothenar = 33,

                /// <summary>
                /// Enum LatentPrint for value: LatentPrint
                /// </summary>
                [EnumMember(Value = "LatentPrint")]
                LatentPrint = 34

            }


            /// <summary>
            /// Enumeration of fingerprint positions. This includes also palm and latent positions.
            /// </summary>
            /// <value>Enumeration of fingerprint positions. This includes also palm and latent positions.</value>
            [DataMember(Name = "position", EmitDefaultValue = false)]
            public PositionEnum? Position { get; set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="MissingFingerprint" /> class.
            /// </summary>
            /// <param name="index">index.</param>
            /// <param name="missingReasonCode">missingReasonCode.</param>
            /// <param name="missingReasonText">missingReasonText.</param>
            /// <param name="position">Enumeration of fingerprint positions. This includes also palm and latent positions..</param>
            public MissingFingerprint(int index = default(int), string missingReasonCode = default(string), string missingReasonText = default(string), PositionEnum? position = default(PositionEnum?))
            {
                this.Index = index;
                this.MissingReasonCode = missingReasonCode;
                this.MissingReasonText = missingReasonText;
                this.Position = position;
            }

            /// <summary>
            /// Gets or Sets Index
            /// </summary>
            [DataMember(Name = "index", EmitDefaultValue = false)]
            public int Index { get; set; }

            /// <summary>
            /// Gets or Sets MissingReasonCode
            /// </summary>
            [DataMember(Name = "missingReasonCode", EmitDefaultValue = false)]
            public string MissingReasonCode { get; set; }

            /// <summary>
            /// Gets or Sets MissingReasonText
            /// </summary>
            [DataMember(Name = "missingReasonText", EmitDefaultValue = false)]
            public string MissingReasonText { get; set; }

            /// <summary>
            /// Returns the string presentation of the object
            /// </summary>
            /// <returns>String presentation of the object</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("class MissingFingerprint {\n");
                sb.Append("  Index: ").Append(Index).Append("\n");
                sb.Append("  MissingReasonCode: ").Append(MissingReasonCode).Append("\n");
                sb.Append("  MissingReasonText: ").Append(MissingReasonText).Append("\n");
                sb.Append("  Position: ").Append(Position).Append("\n");
                sb.Append("}\n");
                return sb.ToString();
            }

            /// <summary>
            /// Returns the JSON string presentation of the object
            /// </summary>
            /// <returns>JSON string presentation of the object</returns>
            public virtual string ToJson()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            }

            /// <summary>
            /// Returns true if objects are equal
            /// </summary>
            /// <param name="input">Object to be compared</param>
            /// <returns>Boolean</returns>
            public override bool Equals(object input)
            {
                return this.Equals(input as MissingFingerprint);
            }

            /// <summary>
            /// Returns true if MissingFingerprint instances are equal
            /// </summary>
            /// <param name="input">Instance of MissingFingerprint to be compared</param>
            /// <returns>Boolean</returns>
            public bool Equals(MissingFingerprint input)
            {
                if (input == null)
                {
                    return false;
                }
                return
                    (
                        this.Index == input.Index ||
                        this.Index.Equals(input.Index)
                    ) &&
                    (
                        this.MissingReasonCode == input.MissingReasonCode ||
                        (this.MissingReasonCode != null &&
                        this.MissingReasonCode.Equals(input.MissingReasonCode))
                    ) &&
                    (
                        this.MissingReasonText == input.MissingReasonText ||
                        (this.MissingReasonText != null &&
                        this.MissingReasonText.Equals(input.MissingReasonText))
                    ) &&
                    (
                        this.Position == input.Position ||
                        this.Position.Equals(input.Position)
                    );
            }

            /// <summary>
            /// Gets the hash code
            /// </summary>
            /// <returns>Hash code</returns>
            public override int GetHashCode()
            {
                unchecked // Overflow is fine, just wrap
                {
                    int hashCode = 41;
                    hashCode = (hashCode * 59) + this.Index.GetHashCode();
                    if (this.MissingReasonCode != null)
                    {
                        hashCode = (hashCode * 59) + this.MissingReasonCode.GetHashCode();
                    }
                    if (this.MissingReasonText != null)
                    {
                        hashCode = (hashCode * 59) + this.MissingReasonText.GetHashCode();
                    }
                    hashCode = (hashCode * 59) + this.Position.GetHashCode();
                    return hashCode;
                }
            }

            /// <summary>
            /// To validate all properties of the instance
            /// </summary>
            /// <param name="validationContext">Validation context</param>
            /// <returns>Validation Result</returns>
            public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
            {
                // Index (int) minimum
                if (this.Index < (int)0)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value greater than or equal to 0.", new[] { "Index" });
                }

                yield break;
            }
        }

    }

