
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
    /// Image
    /// </summary>
    [DataContract(Name = "Image")]
    public class Image
    {
        /// <summary>
        /// Enumeration of image format.
        /// </summary>
        /// <value>Enumeration of image format.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatEnum
        {
            /// <summary>
            /// Enum BMP for value: BMP
            /// </summary>
            [EnumMember(Value = "BMP")]
            BMP = 1,

            /// <summary>
            /// Enum GIF for value: GIF
            /// </summary>
            [EnumMember(Value = "GIF")]
            GIF = 2,

            /// <summary>
            /// Enum ISOJPEG2K for value: ISO_JPEG_2_K
            /// </summary>
            [EnumMember(Value = "ISO_JPEG_2_K")]
            ISOJPEG2K = 3,

            /// <summary>
            /// Enum ISOPNG for value: ISO_PNG
            /// </summary>
            [EnumMember(Value = "ISO_PNG")]
            ISOPNG = 4,

            /// <summary>
            /// Enum ISOUNCOMPRESSED for value: ISO_UNCOMPRESSED
            /// </summary>
            [EnumMember(Value = "ISO_UNCOMPRESSED")]
            ISOUNCOMPRESSED = 5,

            /// <summary>
            /// Enum ISOWSQ for value: ISO_WSQ
            /// </summary>
            [EnumMember(Value = "ISO_WSQ")]
            ISOWSQ = 6,

            /// <summary>
            /// Enum JPEG2K for value: JPEG_2_K
            /// </summary>
            [EnumMember(Value = "JPEG_2_K")]
            JPEG2K = 7,

            /// <summary>
            /// Enum JPG for value: JPG
            /// </summary>
            [EnumMember(Value = "JPG")]
            JPG = 8,

            /// <summary>
            /// Enum PNG for value: PNG
            /// </summary>
            [EnumMember(Value = "PNG")]
            PNG = 9,

            /// <summary>
            /// Enum TIF for value: TIF
            /// </summary>
            [EnumMember(Value = "TIF")]
            TIF = 10,

            /// <summary>
            /// Enum WSQ for value: WSQ
            /// </summary>
            [EnumMember(Value = "WSQ")]
            WSQ = 11

        }


        /// <summary>
        /// Enumeration of image format.
        /// </summary>
        /// <value>Enumeration of image format.</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public FormatEnum? Format { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Image" /> class.
        /// </summary>
        /// <param name="captureDevice">captureDevice.</param>
        /// <param name="dataBytes">dataBytes.</param>
        /// <param name="dataUrl">dataUrl.</param>
        /// <param name="format">Enumeration of image format..</param>
        /// <param name="resolutionDpi">resolutionDpi.</param>
        public Image(string captureDevice = default(string), byte[] dataBytes = default(byte[]), string dataUrl = default(string), FormatEnum? format = default(FormatEnum?), int resolutionDpi = default(int)) ///byte[] dataBytebase64WSQ = default(byte[])
        {
            this.CaptureDevice = captureDevice;
            this.DataBytes = dataBytes;
            //this.DataBytebase64WSQ = dataBytebase64WSQ;
            this.DataUrl = dataUrl;
            this.Format = format;
            this.ResolutionDpi = resolutionDpi;
        }

        /// <summary>
        /// Gets or Sets CaptureDevice
        /// </summary>
        [DataMember(Name = "captureDevice", EmitDefaultValue = false)]
        public string CaptureDevice { get; set; }

        /// <summary>
        /// Gets or Sets DataBytes
        /// </summary>
        [DataMember(Name = "dataBytes", EmitDefaultValue = false)]
        public byte[] DataBytes { get; set; }


        //[DataMember(Name = "dataBytebase64WSQ", EmitDefaultValue = false)]
        //public byte[] DataBytebase64WSQ { get; set; }

        /// <summary>
        /// Gets or Sets DataUrl
        /// </summary>
        [DataMember(Name = "dataUrl", EmitDefaultValue = false)]
        public string DataUrl { get; set; }

        /// <summary>
        /// Gets or Sets ResolutionDpi
        /// </summary>
        [DataMember(Name = "resolutionDpi", EmitDefaultValue = false)]
        public int ResolutionDpi { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Image {\n");
            sb.Append("  CaptureDevice: ").Append(CaptureDevice).Append("\n");
            sb.Append("  DataBytes: ").Append(DataBytes).Append("\n");
            //sb.Append("  DataBytebase64WSQ: ").Append(DataBytebase64WSQ).Append("\n");
            sb.Append("  DataUrl: ").Append(DataUrl).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  ResolutionDpi: ").Append(ResolutionDpi).Append("\n");
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
            return this.Equals(input as Image);
        }

        /// <summary>
        /// Returns true if Image instances are equal
        /// </summary>
        /// <param name="input">Instance of Image to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Image input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.CaptureDevice == input.CaptureDevice ||
                    (this.CaptureDevice != null &&
                    this.CaptureDevice.Equals(input.CaptureDevice))
                ) &&
                (
                    this.DataBytes == input.DataBytes ||
                    (this.DataBytes != null &&
                    this.DataBytes.Equals(input.DataBytes))
                )
                //&& (
                // this.DataBytebase64WSQ == input.DataBytebase64WSQ ||
                //    (this.DataBytebase64WSQ != null &&
                //    this.DataBytebase64WSQ.Equals(input.DataBytebase64WSQ))
                //)
                &&
                (
                    this.DataUrl == input.DataUrl ||
                    (this.DataUrl != null &&
                    this.DataUrl.Equals(input.DataUrl))
                ) &&
                (
                    this.Format == input.Format ||
                    this.Format.Equals(input.Format)
                ) &&
                (
                    this.ResolutionDpi == input.ResolutionDpi ||
                    this.ResolutionDpi.Equals(input.ResolutionDpi)
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
                if (this.CaptureDevice != null)
                {
                    hashCode = (hashCode * 59) + this.CaptureDevice.GetHashCode();
                }
                if (this.DataBytes != null)
                {
                    hashCode = (hashCode * 59) + this.DataBytes.GetHashCode();
                }
                //if (this.DataBytebase64WSQ != null)
                //{
                //    hashCode = (hashCode * 59) + this.DataBytebase64WSQ.GetHashCode();
                //}
                if (this.DataUrl != null)
                {
                    hashCode = (hashCode * 59) + this.DataUrl.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Format.GetHashCode();
                hashCode = (hashCode * 59) + this.ResolutionDpi.GetHashCode();
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
