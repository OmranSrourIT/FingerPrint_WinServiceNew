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

    [DataContract(Name = "Hand")]
    public class Hand
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="Hand" /> class.
        /// </summary>
        /// <param name="image">image.</param>
        /// <param name="fingerprints">fingerprints.</param>
        /// <param name="missingFingerprints">missingFingerprints.</param>
        public Hand( HandPositionEnum? position = default(HandPositionEnum?), Image image = default(Image), List<Fingerprint> fingerprints = default(List<Fingerprint>), List<MissingFingerprint> missingFingerprints = default(List<MissingFingerprint>))
        {
            this.Position = position;
            this.Image = image;
            this.Fingerprints = fingerprints;
            this.MissingFingerprints = missingFingerprints;
        }


        /// <summary>
        /// Enumeration of Hand positions.
        /// </summary>
        /// <value>Enumeration of Hand positions.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum HandPositionEnum
        {
            /// <summary>
            /// Enum RightHand for value: RightHand
            /// </summary>
            [EnumMember(Value = "RightHand")]
            RightHand = 1,

            /// <summary>
            /// Enum LeftHand for value: LeftHand
            /// </summary>
            [EnumMember(Value = "LeftHand")]
            LeftHand = 2
        }



        /// <summary>
        /// Enumeration of Hand positions.
        /// </summary>
        /// <value>Enumeration of Hand positions.
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public HandPositionEnum? Position { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = false)]
        public Image Image { get; set; }


        /// <summary>
        /// Gets or Sets Fingerprints
        /// </summary>
        [DataMember(Name = "fingerprints", EmitDefaultValue = false)]
        public List<Fingerprint> Fingerprints { get; set; }

        /// <summary>
        /// Gets or Sets MissingFingerprints
        /// </summary>
        [DataMember(Name = "missingFingerprints", EmitDefaultValue = false)]
        public List<MissingFingerprint> MissingFingerprints { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Hand {\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Fingerprints: ").Append(Fingerprints).Append("\n");
            sb.Append("  MissingFingerprints: ").Append(MissingFingerprints).Append("\n");
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
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        } 
    }
}
