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
    internal class HandSegmentation
    {
        private static readonly TextWriter Output = Console.Out;
        public string base64String = "";
        List<MissingFingerprint.PositionEnum> postion = new List<MissingFingerprint.PositionEnum>();

        
       
        //Semntation Method
        public string OneHandSegmentation(Hand hand)
        {
            try
            {

                if (hand == null)
                {
                    throw new ArgumentNullException(nameof(hand));
                }

                ISegLib iSegLib = ISegLib.Instance;

                //get HWID of computer
                Output.WriteLine("Hardware ID of this computer: {0}", ISegLib.GetHwid());

                //get version string
                Output.WriteLine("Using: {0}", iSegLib.GetVersionString());

                // Initialize ISegLib
                iSegLib.Init();


                //load image
                RawImage image;

                if (hand.Image.Format.Value.ToString() == "PNG")
                {
                    image = Innovatrics.ISegLib.RawImageExtension.ConvertImageToRaw(hand.Image.DataBytes, ISegLibImageFormat.Png);
                }
                else
                {
                    image = Innovatrics.ISegLib.RawImageExtension.ConvertImageToRaw(hand.Image.DataBytes, ISegLibImageFormat.Bmp);
                }




                int minimumFingersCount = 0;
                int maximumFingersCount = 4;
                int expectedFingersCount = 4;
                int maxRotation = 40;
                int outWidth = 400;
                int outHeight = 500;
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

                    if (hand.Position == Hand.HandPositionEnum.LeftHand)
                    {
                        Output.WriteLine("Detected hand position: LEFT HAND");

                        postion.Add(MissingFingerprint.PositionEnum.LeftLittle);
                        postion.Add(MissingFingerprint.PositionEnum.LeftRing);
                        postion.Add(MissingFingerprint.PositionEnum.LeftMiddle);
                        postion.Add(MissingFingerprint.PositionEnum.LeftIndex);

                    }

                    if (hand.Position == Hand.HandPositionEnum.RightHand)
                    {
                        Output.WriteLine("Detected hand position: RIGHT HAND");
                        postion.Add(MissingFingerprint.PositionEnum.RightIndex);
                        postion.Add(MissingFingerprint.PositionEnum.RightMiddle);
                        postion.Add(MissingFingerprint.PositionEnum.RightRing);
                        postion.Add(MissingFingerprint.PositionEnum.RightLittle);
                    }


                    if (hand.Fingerprints.Count == result.Fingerprints.Length)
                    {
                        int realPostion = 0;
                        for (int i = 0; i < 4; i++)
                        {

                            if (IsMissing(hand.MissingFingerprints, postion[i]))
                            {
                                Output.WriteLine("Missing Finger #{0}:{1}", i + 1, postion[i]);
                                continue;
                            }

                            var fingerprint = result.Fingerprints[realPostion];

                            Output.WriteLine("Finger #{0}:{1}", i + 1, postion[i]);
                            Output.WriteLine("Quality: " + fingerprint.RawImage.GetImageQuality());
                            Output.WriteLine("NFIQ score: " + fingerprint.RawImage.GetNFIQScore());
                            var Quailty = fingerprint.RawImage.GetImageQuality();
                            var Score = fingerprint.RawImage.GetNFIQScore();
                            int intensity = fingerprint.RawImage.GetImageIntensity();


                            if ((Quailty < 50) || (Score > 4) || (intensity < 25) || (intensity > 75))
                            {
                                return "408";
                            }

                            Output.WriteLine("Image intensity: {0}", intensity);

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
                                    for (int j = 0; j < hand.Fingerprints.Count; j++)
                                    {
                                        if (hand.Fingerprints[j].Position.ToString() == postion[i].ToString())
                                        {
                                            // On code below to discrption how to extention image its is  wsq
                                            hand.Fingerprints[j].Image.DataBytes = RawImageExtension.ConvertRawToImage(fingerprint.RawImage, ISegLibImageFormat.Wsq, 13);
                                            //On code below to discrption how to extention image its is  bmp
                                            //hand.Fingerprints[j].Image.DataBytes = ms.ToArray();
                                            Console.WriteLine(hand.Fingerprints[j].Image.DataBytes.Length);
                                            Console.WriteLine(hand.Fingerprints[j].Position);

                                        }
                                    }
                                    //      base64String += "Finger " + postion[i] + " =\"" + Convert.ToBase64String(ms.ToArray()) + "\"" + "\n";

                                }
                            }

                            if (!IsMissing(hand.MissingFingerprints, postion[i]))
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
                return hand.ToJson();

            }
            catch(Exception ex)
            {
                var stackTrace = new StackTrace(ex, true);
                var frame = stackTrace.GetFrame(0);
                var line = frame.GetFileLineNumber();
                Logger.WriteLog("ErrorMessage" + Environment.NewLine + ex.Message + Environment.NewLine + stackTrace + "Line" + line);
            }
            return hand.ToJson();


        }

        public bool IsMissing(List<MissingFingerprint> list, MissingFingerprint.PositionEnum positionEnum)
        {
            try
            {
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
