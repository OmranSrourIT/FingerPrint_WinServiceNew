using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FingerPrint_WinService.Modilty;

namespace FingerPrint_WinService.Modilty
{

    /// <summary>
    /// Fingerprint
    /// </summary>
    [DataContract(Name = "Fingerprint")]
    public class Fingerprint
    {
            /// <summary>
            /// Enumeration of fingerprint and palm impression types.
            /// </summary>
            /// <value>Enumeration of fingerprint and palm impression types.</value>
            [JsonConverter(typeof(StringEnumConverter))]
            public enum ImpressionTypeEnum
            {
                /// <summary>
                /// Enum LivePlain for value: LivePlain
                /// </summary>
                [EnumMember(Value = "LivePlain")]
                LivePlain = 1,

                /// <summary>
                /// Enum LiveRolled for value: LiveRolled
                /// </summary>
                [EnumMember(Value = "LiveRolled")]
                LiveRolled = 2,

                /// <summary>
                /// Enum NonLivePlain for value: NonLivePlain
                /// </summary>
                [EnumMember(Value = "NonLivePlain")]
                NonLivePlain = 3,

                /// <summary>
                /// Enum NonLiveRolled for value: NonLiveRolled
                /// </summary>
                [EnumMember(Value = "NonLiveRolled")]
                NonLiveRolled = 4,

                /// <summary>
                /// Enum LatentImpression for value: LatentImpression
                /// </summary>
                [EnumMember(Value = "LatentImpression")]
                LatentImpression = 5,

                /// <summary>
                /// Enum LatentTracing for value: LatentTracing
                /// </summary>
                [EnumMember(Value = "LatentTracing")]
                LatentTracing = 6,

                /// <summary>
                /// Enum LatentPhoto for value: LatentPhoto
                /// </summary>
                [EnumMember(Value = "LatentPhoto")]
                LatentPhoto = 7,

                /// <summary>
                /// Enum LatentLift for value: LatentLift
                /// </summary>
                [EnumMember(Value = "LatentLift")]
                LatentLift = 8,

                /// <summary>
                /// Enum LiveSwipe for value: LiveSwipe
                /// </summary>
                [EnumMember(Value = "LiveSwipe")]
                LiveSwipe = 9,

                /// <summary>
                /// Enum VerticalRoll for value: VerticalRoll
                /// </summary>
                [EnumMember(Value = "VerticalRoll")]
                VerticalRoll = 10,

                /// <summary>
                /// Enum LiveContactless for value: LiveContactless
                /// </summary>
                [EnumMember(Value = "LiveContactless")]
                LiveContactless = 11,

                /// <summary>
                /// Enum Other for value: Other
                /// </summary>
                [EnumMember(Value = "Other")]
                Other = 12,

                /// <summary>
                /// Enum Unknown for value: Unknown
                /// </summary>
                [EnumMember(Value = "Unknown")]
                Unknown = 13

            }


            /// <summary>
            /// Enumeration of fingerprint and palm impression types.
            /// </summary>
            /// <value>Enumeration of fingerprint and palm impression types.</value>
            [DataMember(Name = "impressionType", EmitDefaultValue = false)]
            public ImpressionTypeEnum? ImpressionType { get; set; }
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
            /// Initializes a new instance of the <see cref="Fingerprint" /> class.
            /// </summary>
            /// <param name="image">image.</param>
            /// <param name="impressionType">Enumeration of fingerprint and palm impression types..</param>
            /// <param name="index">index.</param>
            /// <param name="position">Enumeration of fingerprint positions. This includes also palm and latent positions..</param>
            /// <param name="qualities">qualities.</param>
            /// <param name="template">template.</param>
            public Fingerprint(Image image = default(Image), ImpressionTypeEnum? impressionType = default(ImpressionTypeEnum?), int index = default(int), PositionEnum? position = default(PositionEnum?), FingerprintQualities qualities = default(FingerprintQualities), FingerprintTemplate template = default(FingerprintTemplate))
            {
                this.Image = image;
                this.ImpressionType = impressionType;
                this.Index = index;
                this.Position = position;
                this.Qualities = qualities;
                this.Template = template;
            }

            /// <summary>
            /// Gets or Sets Image
            /// </summary>
            [DataMember(Name = "image", EmitDefaultValue = false)]
            public Image Image { get; set; }

            /// <summary>
            /// Gets or Sets Index
            /// </summary>
            [DataMember(Name = "index", EmitDefaultValue = false)]
            public int Index { get; set; }

            /// <summary>
            /// Gets or Sets Qualities
            /// </summary>
            [DataMember(Name = "qualities", EmitDefaultValue = false)]
            public FingerprintQualities Qualities { get; set; }

            /// <summary>
            /// Gets or Sets Template
            /// </summary>
            [DataMember(Name = "template", EmitDefaultValue = false)]
            public FingerprintTemplate Template { get; set; }

            /// <summary>
            /// Returns the string presentation of the object
            /// </summary>
            /// <returns>String presentation of the object</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("class Fingerprint {\n");
                sb.Append("  Image: ").Append(Image).Append("\n");
                sb.Append("  ImpressionType: ").Append(ImpressionType).Append("\n");
                sb.Append("  Index: ").Append(Index).Append("\n");
                sb.Append("  Position: ").Append(Position).Append("\n");
                sb.Append("  Qualities: ").Append(Qualities).Append("\n");
                sb.Append("  Template: ").Append(Template).Append("\n");
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
                return this.Equals(input as Fingerprint);
            }

            /// <summary>
            /// Returns true if Fingerprint instances are equal
            /// </summary>
            /// <param name="input">Instance of Fingerprint to be compared</param>
            /// <returns>Boolean</returns>
            public bool Equals(Fingerprint input)
            {
                if (input == null)
                {
                    return false;
                }
                return
                    (
                        this.Image == input.Image ||
                        (this.Image != null &&
                        this.Image.Equals(input.Image))
                    ) &&
                    (
                        this.ImpressionType == input.ImpressionType ||
                        this.ImpressionType.Equals(input.ImpressionType)
                    ) &&
                    (
                        this.Index == input.Index ||
                        this.Index.Equals(input.Index)
                    ) &&
                    (
                        this.Position == input.Position ||
                        this.Position.Equals(input.Position)
                    ) &&
                    (
                        this.Qualities == input.Qualities ||
                        (this.Qualities != null &&
                        this.Qualities.Equals(input.Qualities))
                    ) &&
                    (
                        this.Template == input.Template ||
                        (this.Template != null &&
                        this.Template.Equals(input.Template))
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
                    if (this.Image != null)
                    {
                        hashCode = (hashCode * 59) + this.Image.GetHashCode();
                    }
                    hashCode = (hashCode * 59) + this.ImpressionType.GetHashCode();
                    hashCode = (hashCode * 59) + this.Index.GetHashCode();
                    hashCode = (hashCode * 59) + this.Position.GetHashCode();
                    if (this.Qualities != null)
                    {
                        hashCode = (hashCode * 59) + this.Qualities.GetHashCode();
                    }
                    if (this.Template != null)
                    {
                        hashCode = (hashCode * 59) + this.Template.GetHashCode();
                    }
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


