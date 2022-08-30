
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
    /// FingerprintTemplate
    /// </summary>
    [DataContract(Name = "FingerprintTemplate")]
    public class FingerprintTemplate
    {
            /// <summary>
            /// Initializes a new instance of the <see cref="FingerprintTemplate" /> class.
            /// </summary>
            /// <param name="dataBytes">One of dataBytes or dataUrl is required.</param>
            /// <param name="dataUrl">One of dataBytes or dataUrl is required.</param>
            public FingerprintTemplate(byte[] dataBytes = default(byte[]), string dataUrl = default(string))
            {
                this.DataBytes = dataBytes;
                this.DataUrl = dataUrl;
            }

            /// <summary>
            /// One of dataBytes or dataUrl is required
            /// </summary>
            /// <value>One of dataBytes or dataUrl is required</value>
            [DataMember(Name = "dataBytes", EmitDefaultValue = false)]
            public byte[] DataBytes { get; set; }

            /// <summary>
            /// One of dataBytes or dataUrl is required
            /// </summary>
            /// <value>One of dataBytes or dataUrl is required</value>
            [DataMember(Name = "dataUrl", EmitDefaultValue = false)]
            public string DataUrl { get; set; }

            /// <summary>
            /// Returns the string presentation of the object
            /// </summary>
            /// <returns>String presentation of the object</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("class FingerprintTemplate {\n");
                sb.Append("  DataBytes: ").Append(DataBytes).Append("\n");
                sb.Append("  DataUrl: ").Append(DataUrl).Append("\n");
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
                return this.Equals(input as FingerprintTemplate);
            }

            /// <summary>
            /// Returns true if FingerprintTemplate instances are equal
            /// </summary>
            /// <param name="input">Instance of FingerprintTemplate to be compared</param>
            /// <returns>Boolean</returns>
            public bool Equals(FingerprintTemplate input)
            {
                if (input == null)
                {
                    return false;
                }
                return
                    (
                        this.DataBytes == input.DataBytes ||
                        (this.DataBytes != null &&
                        this.DataBytes.Equals(input.DataBytes))
                    ) &&
                    (
                        this.DataUrl == input.DataUrl ||
                        (this.DataUrl != null &&
                        this.DataUrl.Equals(input.DataUrl))
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
                    if (this.DataBytes != null)
                    {
                        hashCode = (hashCode * 59) + this.DataBytes.GetHashCode();
                    }
                    if (this.DataUrl != null)
                    {
                        hashCode = (hashCode * 59) + this.DataUrl.GetHashCode();
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

