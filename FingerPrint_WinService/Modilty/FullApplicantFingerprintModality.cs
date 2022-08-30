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
    /// FullApplicantFingerprintModality
    /// </summary>
    [DataContract(Name = "FullApplicantFingerprintModality")]
    public class FullApplicantFingerprintModality
    {
            /// <summary>
            /// Initializes a new instance of the <see cref="FullApplicantFingerprintModality" /> class.
            /// </summary>
            /// <param name="fingerprints">fingerprints.</param>
            /// <param name="missingFingerprints">missingFingerprints.</param>
            public FullApplicantFingerprintModality(List<Fingerprint> fingerprints = default(List<Fingerprint>), List<MissingFingerprint> missingFingerprints = default(List<MissingFingerprint>))
            {
                this.Fingerprints = fingerprints;
                this.MissingFingerprints = missingFingerprints;
            }

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
                sb.Append("class FullApplicantFingerprintModality {\n");
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
            /// Returns true if objects are equal
            /// </summary>
            /// <param name="input">Object to be compared</param>
            /// <returns>Boolean</returns>
            public override bool Equals(object input)
            {
                return this.Equals(input as FullApplicantFingerprintModality);
            }

            /// <summary>
            /// Returns true if FullApplicantFingerprintModality instances are equal
            /// </summary>
            /// <param name="input">Instance of FullApplicantFingerprintModality to be compared</param>
            /// <returns>Boolean</returns>
            public bool Equals(FullApplicantFingerprintModality input)
            {
                if (input == null)
                {
                    return false;
                }
                return
                    (
                        this.Fingerprints == input.Fingerprints ||
                        this.Fingerprints != null &&
                        input.Fingerprints != null &&
                        this.Fingerprints.SequenceEqual(input.Fingerprints)
                    ) &&
                    (
                        this.MissingFingerprints == input.MissingFingerprints ||
                        this.MissingFingerprints != null &&
                        input.MissingFingerprints != null &&
                        this.MissingFingerprints.SequenceEqual(input.MissingFingerprints)
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
                    if (this.Fingerprints != null)
                    {
                        hashCode = (hashCode * 59) + this.Fingerprints.GetHashCode();
                    }
                    if (this.MissingFingerprints != null)
                    {
                        hashCode = (hashCode * 59) + this.MissingFingerprints.GetHashCode();
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
                yield break;
            }
        }

    }
