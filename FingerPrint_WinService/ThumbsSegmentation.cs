using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Innovatrics.ISegLib;
using Innovatrics.ISegLib.Enums;
using Innovatrics.Sdk.Commons;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FingerPrint_WinService.Modilty;
using System.Drawing;
using System.Diagnostics;

namespace FingerPrint_WinService
{
    internal class ThumbsSegmentation
    {
        private static readonly TextWriter Output = Console.Out;
        public string base64String = "";
        List<MissingFingerprint.PositionEnum> postion = new List<MissingFingerprint.PositionEnum>();
       
        //Semntation Method
        public string OnThumbsSegmentation(Thumbs thumbs)
        {
            try
            {
                if (thumbs == null)
                {
                    // No Thumbs
                    return "104";
                }
                else if (thumbs.Fingerprints.Count == 0)
                {
                    // All FingerPrint is missing 
                    return "105";
                }
                else if (thumbs.Image.DataBytes.Length == 0)
                {
                    return "106";
                }

                ISegLib iSegLib = ISegLib.Instance;

                //get HWID of computer
                Console.Write("Hardware ID of this computer: {0}", ISegLib.GetHwid());

                //get version string
                Output.WriteLine("Using: {0}", iSegLib.GetVersionString());

                // Initialize ISegLib
                iSegLib.Init();


                //load image
                RawImage image;
                if (thumbs.Image.Format.Value.ToString() == "PNG")
                {
                    image = Innovatrics.ISegLib.RawImageExtension.ConvertImageToRaw(thumbs.Image.DataBytes, ISegLibImageFormat.Png);
                }
                else
                {
                    image = Innovatrics.ISegLib.RawImageExtension.ConvertImageToRaw(thumbs.Image.DataBytes, ISegLibImageFormat.Bmp);
                }




                int minimumFingersCount = 0;
                int maximumFingersCount = 2;
                int expectedFingersCount = 2;
                int maxRotation = 40;
                int outWidth = 512;//400
                int outHeight = 512;//500
                byte bcgValue = 255;

                using (SegmentationResult result = iSegLib.SegmentFingerprints(image, expectedFingersCount,
                        minimumFingersCount, maximumFingersCount, maxRotation, SegmentationOptions.None, 0, outWidth,
                        outHeight, bcgValue))
                {
                    int globalAngle = result.GlobalAngle;
                    int segmentedFingersCount = result.Fingerprints.Length;
                    IList<SegmentationInfoDefines> feedback = result.SegmentationFeedback;

                    System.Drawing.Image boxedImage = result.BoxedImage;

                    Output.WriteLine("Detected fingers count: {0}", segmentedFingersCount);
                    Output.WriteLine("Detected global rotation angle: {0}", globalAngle);

                    if (iSegLib.SegmentationFeedbackHasMissingFinger(feedback))
                    {
                        Output.WriteLine("Slap image does not contain all fingers.");
                        Output.WriteLine("Missing " + iSegLib.GetFingerName(feedback));
                    }

                    if (thumbs.Fingerprints.Count != 0)
                    {
                        Output.WriteLine("Detected Thumbs");
                        postion.Add(MissingFingerprint.PositionEnum.LeftThumb);
                        postion.Add(MissingFingerprint.PositionEnum.RightThumb);
                    }

                    if (thumbs.Fingerprints.Count == result.Fingerprints.Length)
                    {
                        int realPostion = 0;
                        for (int i = 0; i < 2; i++)
                        {

                            if (IsMissing(thumbs.MissingFingerprints, postion[i]))
                            {
                                Output.WriteLine("Missing Finger #{0}:{1}", i + 1, postion[i]);
                                continue;
                            }

                            var fingerprint = result.Fingerprints[realPostion];

                            Output.WriteLine("Finger #{0}:{1}", i + 1, postion[i]);
                            // quality
                            // int quality = fingerprint.RawImage.GetImageQuality();
                            // NFIQ score
                            //int nfiq = fingerprint.RawImage.GetNFIQScore();

                            //  int intensity = fingerprint.RawImage.GetImageIntensity();
                            //  Output.WriteLine("Image intensity: {0}", intensity);

                            var Quailty = fingerprint.RawImage.GetImageQuality();
                            var Score = fingerprint.RawImage.GetNFIQScore();
                            int intensity = fingerprint.RawImage.GetImageIntensity();

                            if ((Quailty < 50) || (Score > 4) || (intensity < 25) || (intensity > 75))
                            {
                                return "408";
                            }

                            if (intensity < ISegLib.INTENSITY_THRESHOLD_TOO_LIGHT)
                            {
                                Output.WriteLine("Image too light, low pressure or dry finger.");
                                //throw new Exception("please retry");
                            }

                            if (intensity > ISegLib.INTENSITY_THRESHOLD_TOO_DARK)
                                Output.WriteLine("Image too dark, too high pressure or wet finger.");
                            //throw new Exception("please retry");

                            using (System.Drawing.Image fpImage = fingerprint.RawImage.ConvertRawToImage())
                            {
                                using (var ms = new MemoryStream())
                                {
                                    fpImage.Save(ms, fpImage.RawFormat);
                                    for (int j = 0; j < thumbs.Fingerprints.Count; j++)
                                    {
                                        if (thumbs.Fingerprints[j].Position.ToString() == postion[i].ToString())
                                        {

                                            thumbs.Fingerprints[j].Image.DataBytes = RawImageExtension.ConvertRawToImage(fingerprint.RawImage, ISegLibImageFormat.Wsq, 13);
                                            //in the belwo to convert image to png 
                                            //thumbs.Fingerprints[j].Image.DataBytes = ms.ToArray();
                                            //in the belwo to convert image to wsq 
                                            //thumbs.Fingerprints[j].Image.DataBytebase64WSQ = RawImageExtension.ConvertRawToImage(fingerprint.RawImage, ISegLibImageFormat.Wsq, 15);
                                            Console.WriteLine(thumbs.Fingerprints[j].Image.DataBytes.Length);
                                            Console.WriteLine(thumbs.Fingerprints[j].Position);


                                        }
                                    }
                                    // base64String += "Finger " + postion[i] + " =\"" + Convert.ToBase64String(ms.ToArray()) + "\"" + "\n";
                                    // base64String += "Finger " + postion[i] + " =\"" + Convert.ToBase64String(RawImageExtension.ConvertRawToImage(fingerprint.RawImage, ISegLibImageFormat.Wsq, 13)) + "\"" + "\n";
                                }
                            }

                            if (!IsMissing(thumbs.MissingFingerprints, postion[i]))
                            {
                                realPostion++;
                            }
                        }
                    }
                    else
                    {
                        return "101";

                    }
                }
                iSegLib.Terminate();
              

            }
            catch(Exception ex)
            {
                var stackTrace = new StackTrace(ex, true);
                var frame = stackTrace.GetFrame(0);
                var line = frame.GetFileLineNumber();
                Logger.WriteLog("ErrorMessage" + Environment.NewLine + ex.Message + Environment.NewLine + stackTrace + "Line" + line);

            }
            return thumbs.ToJson();

        }

        public bool IsMissing(List<MissingFingerprint> list, MissingFingerprint.PositionEnum positionEnum)
        {
            try
            {
                if (list.Count == 0)
                {
                    return false;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Position == positionEnum)
                    {
                        return true;
                    }
                }


            }
            catch(Exception ex)
            {
                var stackTrace = new StackTrace(ex, true);
                var frame = stackTrace.GetFrame(0);
                var line = frame.GetFileLineNumber();
                Logger.WriteLog("ErrorMessage" + Environment.NewLine + ex.Message + Environment.NewLine + stackTrace + "Line" + line);


            }
            
            return false;
        }
    }
}
