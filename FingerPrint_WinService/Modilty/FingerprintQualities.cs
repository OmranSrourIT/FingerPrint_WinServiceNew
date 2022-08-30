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

namespace FingerPrint_WinService.Modilty

{   /// <summary>
    /// FingerprintQualities
    /// </summary>
    [DataContract(Name = "FingerprintQualities")]
    public  class FingerprintQualities
    {
            /// <summary>
            /// Initializes a new instance of the <see cref="FingerprintQualities" /> class.
            /// </summary>
            /// <param name="idkit">idkit.</param>
            /// <param name="nfiq">nfiq.</param>
            /// <param name="placementScore">placementScore.</param>
            public FingerprintQualities(int idkit = default(int), int nfiq = default(int), int placementScore = default(int))
            {
                this.Idkit = idkit;
                this.Nfiq = nfiq;
                this.PlacementScore = placementScore;
            }

            /// <summary>
            /// Gets or Sets Idkit
            /// </summary>
            [DataMember(Name = "idkit", EmitDefaultValue = false)]
            public int Idkit { get; set; }

            /// <summary>
            /// Gets or Sets Nfiq
            /// </summary>
            [DataMember(Name = "nfiq", EmitDefaultValue = false)]
            public int Nfiq { get; set; }

            /// <summary>
            /// Gets or Sets PlacementScore
            /// </summary>
            [DataMember(Name = "placementScore", EmitDefaultValue = false)]
            public int PlacementScore { get; set; }

            /// <summary>
            /// Returns the string presentation of the object
            /// </summary>
            /// <returns>String presentation of the object</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("class FingerprintQualities {\n");
                sb.Append("  Idkit: ").Append(Idkit).Append("\n");
                sb.Append("  Nfiq: ").Append(Nfiq).Append("\n");
                sb.Append("  PlacementScore: ").Append(PlacementScore).Append("\n");
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
                return this.Equals(input as FingerprintQualities);
            }

            /// <summary>
            /// Returns true if FingerprintQualities instances are equal
            /// </summary>
            /// <param name="input">Instance of FingerprintQualities to be compared</param>
            /// <returns>Boolean</returns>
            public bool Equals(FingerprintQualities input)
            {
                if (input == null)
                {
                    return false;
                }
                return
                    (
                        this.Idkit == input.Idkit ||
                        this.Idkit.Equals(input.Idkit)
                    ) &&
                    (
                        this.Nfiq == input.Nfiq ||
                        this.Nfiq.Equals(input.Nfiq)
                    ) &&
                    (
                        this.PlacementScore == input.PlacementScore ||
                        this.PlacementScore.Equals(input.PlacementScore)
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
                    hashCode = (hashCode * 59) + this.Idkit.GetHashCode();
                    hashCode = (hashCode * 59) + this.Nfiq.GetHashCode();
                    hashCode = (hashCode * 59) + this.PlacementScore.GetHashCode();
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
                yield break;
            }
        }

    }


