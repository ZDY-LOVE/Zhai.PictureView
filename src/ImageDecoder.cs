﻿using ImageMagick;
using SkiaSharp;
using SkiaSharp.Views.WPF;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Zhai.PictureView
{
    internal static partial class ImageDecoder
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool DeleteObject(IntPtr hObject);

        internal static BitmapSource GetBitmapSource(Bitmap bitmap)
        {
            if (bitmap == null) return null;

            IntPtr handle = IntPtr.Zero;

            BitmapSource bitmapSource;

            try
            {
                handle = bitmap.GetHbitmap();
                bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                bitmapSource.Freeze();
            }
            finally
            {
                if (handle != IntPtr.Zero)
                    DeleteObject(handle);
            }

            return bitmapSource;
        }



        internal static BitmapSource GetThumb(string filename)
        {
            if (File.Exists(filename))
            {
                return (Path.GetExtension(filename).ToUpperInvariant()) switch
                {
                    ".JPG" or ".JPEG" or ".JPE" or ".PNG" or ".BMP" or ".GIF" or ".ICO" or ".JFIF" => GetWindowsThumbnail(filename),
                    _ => GetMagickThumbnail(filename),
                };
            }

            return null;
        }

        internal static BitmapSource GetWindowsThumbnail(string filename)
        {
            try
            {
                var thumb = Microsoft.WindowsAPICodePack.Shell.ShellFile.FromFilePath(filename).Thumbnail.BitmapSource;

                if (!thumb.IsFrozen)
                {
                    thumb.Freeze();
                }

                return thumb;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"{nameof(ImageDecoder)} : GetWindowsThumbnail returned {filename} null  : {ex.Message}");
#endif
                return null;
            }
        }

        internal static BitmapSource GetMagickThumbnail(string filename, int quality = 80, int size = 256)
        {
            try
            {
                using var magickImage = new MagickImage();
                magickImage.Quality = quality;
                magickImage.ColorSpace = ColorSpace.Transparent;
                magickImage.Read(filename);
                magickImage.AdaptiveResize(size, size);

                BitmapSource thumb = magickImage.ToBitmapSource();

                thumb.Freeze();

                return thumb;
            }
            catch (MagickException e)
            {
#if DEBUG
                Trace.WriteLine("GetThumb returned " + filename + " null, \n" + e.Message);
#endif
                return null;
            }
        }



        internal static async Task<BitmapSource> GetBitmapSourceAsync(string filename)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filename);

                var extension = fileInfo.Extension.ToLowerInvariant();

                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".jpe":
                    case ".png":
                    case ".bmp":
                    case ".gif":
                    case ".jfif":
                    case ".ico":
                    case ".webp":
                    case ".wbmp":
                        return await GetWriteableBitmapAsync(fileInfo).ConfigureAwait(false);

                    case ".tga":
                        return await Task.FromResult(GetDefaultBitmapSource(fileInfo, true)).ConfigureAwait(false);

                    case ".svg":
                        return await GetTransparentBitmapSourceAsync(fileInfo, MagickFormat.Svg).ConfigureAwait(false);

                    case ".b64":
                        return await Base64StringToBitmap(fileInfo).ConfigureAwait(false);

                    default:
                        return await Task.FromResult(GetDefaultBitmapSource(fileInfo)).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.WriteLine($"{nameof(GetBitmapSourceAsync)} {filename} exception, \n {e.Message}");
#endif
                return null;
            }
        }

        /// <summary>
        /// Create MagickImage and make sure its transparent, return it as BitmapSource
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="magickFormat"></param>
        /// <returns></returns>
        private static async Task<BitmapSource> GetTransparentBitmapSourceAsync(FileInfo fileInfo, MagickFormat magickFormat)
        {
            FileStream? filestream = null;
            MagickImage magickImage = new()
            {
                Quality = 100,
                ColorSpace = ColorSpace.Transparent,
                BackgroundColor = MagickColors.Transparent,
                Format = magickFormat,
            };
            try
            {
                filestream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 4096, true);
                byte[] data = new byte[filestream.Length];
                await filestream.ReadAsync(data.AsMemory(0, (int)filestream.Length)).ConfigureAwait(false);

                magickImage.Read(data);
                magickImage.Settings.Format = magickFormat;
                magickImage.Settings.BackgroundColor = MagickColors.Transparent;
                magickImage.Settings.FillColor = MagickColors.Transparent;
            }
            catch (Exception e)
            {
                filestream?.Dispose();
                magickImage?.Dispose();
#if DEBUG
                Trace.WriteLine($"{nameof(GetTransparentBitmapSourceAsync)} {fileInfo.Name} exception, \n {e.Message}");
#endif
                return null;
            }

            await filestream.DisposeAsync().ConfigureAwait(false);

            var bitmap = magickImage.ToBitmapSource();
            magickImage.Dispose();
            bitmap.Freeze();
            return bitmap;
        }

        private static async Task<WriteableBitmap> GetWriteableBitmapAsync(FileInfo fileInfo)
        {
            try
            {
                using (var stream = File.OpenRead(fileInfo.FullName))
                {
                    var data = new byte[stream.Length];
                    await stream.ReadAsync(data.AsMemory(0, (int)stream.Length)).ConfigureAwait(false);
                    var sKBitmap = SKBitmap.Decode(data);
                    if (sKBitmap is null)
                    {
                        return null;
                    }

                    var skPic = sKBitmap.ToWriteableBitmap();
                    skPic.Freeze();
                    sKBitmap.Dispose();
                    return skPic;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.WriteLine($"{nameof(GetWriteableBitmapAsync)} {fileInfo.Name} exception, \n {e.Message}");
#endif
                return null;
            }
        }

        private static BitmapSource GetDefaultBitmapSource(FileInfo fileInfo, bool autoOrient = false)
        {
            var magick = new MagickImage();
            try
            {
                magick.Read(fileInfo);
                if (autoOrient)
                {
                    magick.AutoOrient();
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.WriteLine($"{nameof(GetDefaultBitmapSource)} {fileInfo.Name} exception, \n {e.Message}");
#endif
                return null;
            }

            magick.Quality = 100;

            var pic = magick.ToBitmapSource();
            magick.Dispose();
            pic.Freeze();

            return pic;
        }


        #region Base64

        /// <summary>
        /// Converts string from base64 value to BitmapSource
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        internal static Task<BitmapSource> Base64StringToBitmap(string base64String) => Task.Run(async () =>
        {
            byte[] binaryData = Convert.FromBase64String(base64String);
            return await Task.FromResult(Base64FromBytes(binaryData)).ConfigureAwait(false);
        });

        internal static Task<BitmapSource> Base64StringToBitmap(FileInfo fileInfo) => Task.Run(async () =>
        {
            var text = await File.ReadAllTextAsync(fileInfo.FullName).ConfigureAwait(false);
            byte[] binaryData = Convert.FromBase64String(text);
            return await Task.FromResult(Base64FromBytes(binaryData)).ConfigureAwait(false);
        });

        private static BitmapSource Base64FromBytes(byte[] binaryData)
        {
            using MagickImage magick = new MagickImage();
            var mrs = new MagickReadSettings
            {
                Density = new Density(300, 300),
                BackgroundColor = MagickColors.Transparent,
            };

            try
            {
                magick.Read(new MemoryStream(binaryData), mrs);
            }
            catch (MagickException)
            {
                return null;
            }
            // Set values for maximum quality
            magick.Quality = 100;
            magick.ColorSpace = ColorSpace.Transparent;

            var pic = magick.ToBitmapSource();
            pic.Freeze();
            return pic;
        }

        internal static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out _);
        }

        #endregion


        #region EXIF

        internal static async Task<PictureExif> GetExifAsync(string filename)
        {
            var exif = new PictureExif
            {
                { "图片名称", Path.GetFileName(filename) },
                { "图片路径", filename }
            };

            if (File.Exists(filename))
            {
                using (var magickImage = new MagickImage())
                {
                    await magickImage.ReadAsync(filename);

                    var profile = magickImage.GetExifProfile();

                    if (profile != null)
                    {
                        exif.Add("图片宽度", magickImage.Width.ToString());
                        exif.Add("图片高度", magickImage.Height.ToString());

                        foreach (var value in profile.Values)
                        {
                            if (TryGetExifValue(value, out string name, out string description))
                            {
                                if (!exif.ContainsKey(name))
                                {
                                    exif.Add(name, description);
                                }
                            }
                        }
                    }
                }
            }

            return exif;
        }

        internal static bool TryGetExifValue(IExifValue value, out string name, out string description)
        {
            name = string.Empty;

            description = value.ToString();

            switch (value.Tag.ToString())
            {
                case "Model":
                    name = "相机型号";
                    break;
                case "LensModel":
                    name = "镜头类型";
                    break;
                case "DateTime":
                    name = "拍摄时间";
                    break;
                case "ImageHeight":
                    name = "照片高度";
                    break;
                case "ImageWidth":
                    name = "照片宽度";
                    break;
                case "ColorSpace":
                    name = "色彩空间";
                    break;

                case "FNumber":
                    name = "光圈";
                    break;
                case "ISOSpeedRatings":
                    name = "ISO";
                    description = ((ushort[])value.GetValue())[0].ToString();
                    break;
                case "ExposureBiasValue":
                    name = "曝光补偿";
                    break;
                case "FocalLength":
                    name = "焦距";
                    break;
                case "ExposureTime":
                    name = "曝光时间";
                    break;

                case "ExposureProgram":
                    name = "曝光程序";
                    break;
                case "MeteringMode":
                    name = "测光模式";
                    break;
                case "FlashMode":
                    name = "闪光灯";
                    break;
                case "WhiteBalanceMode":
                    name = "白平衡";
                    break;
                case "ExposureMode":
                    name = "曝光模式";
                    break;
                case "ContinuousDriveMode":
                    name = "驱动模式";
                    break;
                case "FocusMode":
                    name = "对焦模式";
                    break;

                case "Artist":
                    name = "作者";
                    break;
                case "Copyright":
                    name = "版权信息";
                    break;
                case "FileModifiedDate":
                    name = "修改时间";
                    break;
            }

            return name != String.Empty;
        }

        #endregion

        public static async Task<bool> SaveImageAsync(Stream stream, string targetPath, int? quality = null, int? width = null, int? height = null)
        {
            try
            {
                using MagickImage magickImage = new();

                if (stream is not null)
                {
                   await magickImage.ReadAsync(stream);
                }
                else
                {
                    return false;
                }

                if (quality is not null)
                {
                    magickImage.Quality = quality.Value;
                }

                if (width is not null)
                {
                    magickImage.Resize(width.Value, 0);
                }
                else if (height is not null)
                {
                    magickImage.Resize(0, height.Value);
                }

                await magickImage.WriteAsync(targetPath);
            }
            catch (Exception e)
            {
#if DEBUG
                Trace.WriteLine($"{nameof(SaveImageAsync)} {targetPath} exception, \n {e.Message}");
#endif

                return false; 
            }

            return true;
        }
    }
}
