﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Zhai.PictureView.ShaderEffects
{

    /// <summary>An effect that inverts all colors.</summary>
    public class InvertColorEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(InvertColorEffect), 0);
        public InvertColorEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/InvertColorEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
    }
    /// <summary>A transition effect </summary>
    public class Transition_RippleEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Transition_RippleEffect), 0);
        public static readonly DependencyProperty Texture2Property = ShaderEffect.RegisterPixelShaderSamplerProperty("Texture2", typeof(Transition_RippleEffect), 1);
        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(double), typeof(Transition_RippleEffect), new UIPropertyMetadata(((double)(30D)), PixelShaderConstantCallback(0)));
        public Transition_RippleEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/Transition_RippleEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(Texture2Property);
            this.UpdateShaderValue(ProgressProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public Brush Texture2
        {
            get
            {
                return ((Brush)(this.GetValue(Texture2Property)));
            }
            set
            {
                this.SetValue(Texture2Property, value);
            }
        }
        /// <summary>The amount(%) of the transition from first texture to the second texture. </summary>
        public double Progress
        {
            get
            {
                return ((double)(this.GetValue(ProgressProperty)));
            }
            set
            {
                this.SetValue(ProgressProperty, value);
            }
        }
    }
    /// <summary>An effect that blends between partial desaturation and a two-color ramp.</summary>
    public class ColorToneEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ColorToneEffect), 0);
        public static readonly DependencyProperty DesaturationProperty = DependencyProperty.Register("Desaturation", typeof(double), typeof(ColorToneEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty TonedProperty = DependencyProperty.Register("Toned", typeof(double), typeof(ColorToneEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty LightColorProperty = DependencyProperty.Register("LightColor", typeof(Color), typeof(ColorToneEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 0), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty DarkColorProperty = DependencyProperty.Register("DarkColor", typeof(Color), typeof(ColorToneEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 128), PixelShaderConstantCallback(3)));
        public ColorToneEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/ColorToneEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(DesaturationProperty);
            this.UpdateShaderValue(TonedProperty);
            this.UpdateShaderValue(LightColorProperty);
            this.UpdateShaderValue(DarkColorProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The amount of desaturation to apply.</summary>
        public double Desaturation
        {
            get
            {
                return ((double)(this.GetValue(DesaturationProperty)));
            }
            set
            {
                this.SetValue(DesaturationProperty, value);
            }
        }
        /// <summary>The amount of color toning to apply.</summary>
        public double Toned
        {
            get
            {
                return ((double)(this.GetValue(TonedProperty)));
            }
            set
            {
                this.SetValue(TonedProperty, value);
            }
        }
        /// <summary>The first color to apply to input. This is usually a light tone.</summary>
        public Color LightColor
        {
            get
            {
                return ((Color)(this.GetValue(LightColorProperty)));
            }
            set
            {
                this.SetValue(LightColorProperty, value);
            }
        }
        /// <summary>The second color to apply to the input. This is usuall a dark tone.</summary>
        public Color DarkColor
        {
            get
            {
                return ((Color)(this.GetValue(DarkColorProperty)));
            }
            set
            {
                this.SetValue(DarkColorProperty, value);
            }
        }
    }
    /// <summary>An effect that turns the input into shades of a single color.</summary>
    public class MonochromeEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(MonochromeEffect), 0);
        public static readonly DependencyProperty FilterColorProperty = DependencyProperty.Register("FilterColor", typeof(Color), typeof(MonochromeEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 0), PixelShaderConstantCallback(0)));
        public MonochromeEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/MonochromeEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(FilterColorProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The color used to tint the input.</summary>
        public Color FilterColor
        {
            get
            {
                return ((Color)(this.GetValue(FilterColorProperty)));
            }
            set
            {
                this.SetValue(FilterColorProperty, value);
            }
        }
    }
    /// <summary>An effect that superimposes rippling waves upon the input.</summary>
    public class RippleEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RippleEffect), 0);
        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(RippleEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register("Amplitude", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(0.1D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty FrequencyProperty = DependencyProperty.Register("Frequency", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(70D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty PhaseProperty = DependencyProperty.Register("Phase", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(4)));
        public RippleEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/RippleEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterProperty);
            this.UpdateShaderValue(AmplitudeProperty);
            this.UpdateShaderValue(FrequencyProperty);
            this.UpdateShaderValue(PhaseProperty);
            this.UpdateShaderValue(AspectRatioProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The center point of the ripples.</summary>
        public Point Center
        {
            get
            {
                return ((Point)(this.GetValue(CenterProperty)));
            }
            set
            {
                this.SetValue(CenterProperty, value);
            }
        }
        /// <summary>The amplitude of the ripples.</summary>
        public double Amplitude
        {
            get
            {
                return ((double)(this.GetValue(AmplitudeProperty)));
            }
            set
            {
                this.SetValue(AmplitudeProperty, value);
            }
        }
        /// <summary>The frequency of the ripples.</summary>
        public double Frequency
        {
            get
            {
                return ((double)(this.GetValue(FrequencyProperty)));
            }
            set
            {
                this.SetValue(FrequencyProperty, value);
            }
        }
        /// <summary>The phase of the ripples.</summary>
        public double Phase
        {
            get
            {
                return ((double)(this.GetValue(PhaseProperty)));
            }
            set
            {
                this.SetValue(PhaseProperty, value);
            }
        }
        /// <summary>The aspect ratio (width / height) of the input.</summary>
        public double AspectRatio
        {
            get
            {
                return ((double)(this.GetValue(AspectRatioProperty)));
            }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
    }
    /// <summary>An effect that swirls the input in a spiral.</summary>
    public class SwirlEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SwirlEffect), 0);
        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(SwirlEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty SpiralStrengthProperty = DependencyProperty.Register("SpiralStrength", typeof(double), typeof(SwirlEffect), new UIPropertyMetadata(((double)(10D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(SwirlEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(2)));
        public SwirlEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/SwirlEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterProperty);
            this.UpdateShaderValue(SpiralStrengthProperty);
            this.UpdateShaderValue(AspectRatioProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The center point of the spiral. (1,1) is lower right corner</summary>
        public Point Center
        {
            get
            {
                return ((Point)(this.GetValue(CenterProperty)));
            }
            set
            {
                this.SetValue(CenterProperty, value);
            }
        }
        /// <summary>The amount of twist to the spiral.</summary>
        public double SpiralStrength
        {
            get
            {
                return ((double)(this.GetValue(SpiralStrengthProperty)));
            }
            set
            {
                this.SetValue(SpiralStrengthProperty, value);
            }
        }
        /// <summary>The aspect ratio (width / height) of the input.</summary>
        public double AspectRatio
        {
            get
            {
                return ((double)(this.GetValue(AspectRatioProperty)));
            }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
    }
    /// <summary>An effect that intensifies bright regions.</summary>
    public class BloomEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BloomEffect), 0);
        public static readonly DependencyProperty BloomIntensityProperty = DependencyProperty.Register("BloomIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register("BaseIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty BloomSaturationProperty = DependencyProperty.Register("BloomSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register("BaseSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(3)));
        public BloomEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/BloomEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(BloomIntensityProperty);
            this.UpdateShaderValue(BaseIntensityProperty);
            this.UpdateShaderValue(BloomSaturationProperty);
            this.UpdateShaderValue(BaseSaturationProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>Intensity of the bloom image.</summary>
        public double BloomIntensity
        {
            get
            {
                return ((double)(this.GetValue(BloomIntensityProperty)));
            }
            set
            {
                this.SetValue(BloomIntensityProperty, value);
            }
        }
        /// <summary>Intensity of the base image.</summary>
        public double BaseIntensity
        {
            get
            {
                return ((double)(this.GetValue(BaseIntensityProperty)));
            }
            set
            {
                this.SetValue(BaseIntensityProperty, value);
            }
        }
        /// <summary>Saturation of the bloom image.</summary>
        public double BloomSaturation
        {
            get
            {
                return ((double)(this.GetValue(BloomSaturationProperty)));
            }
            set
            {
                this.SetValue(BloomSaturationProperty, value);
            }
        }
        /// <summary>Saturation of the base image.</summary>
        public double BaseSaturation
        {
            get
            {
                return ((double)(this.GetValue(BaseSaturationProperty)));
            }
            set
            {
                this.SetValue(BaseSaturationProperty, value);
            }
        }
    }
    /// <summary>An effect that applies defogging, exposure, gamma, vignette, and blue shift corrections.</summary>
    public class ToneMappingEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ToneMappingEffect), 0);
        public static readonly DependencyProperty DefogProperty = DependencyProperty.Register("Defog", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(0.01D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty FogColorProperty = DependencyProperty.Register("FogColor", typeof(Color), typeof(ToneMappingEffect), new UIPropertyMetadata(Color.FromArgb(255, 255, 255, 255), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty ExposureProperty = DependencyProperty.Register("Exposure", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty GammaProperty = DependencyProperty.Register("Gamma", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(0.8D)), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty VignetteCenterProperty = DependencyProperty.Register("VignetteCenter", typeof(Point), typeof(ToneMappingEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(4)));
        public static readonly DependencyProperty VignetteRadiusProperty = DependencyProperty.Register("VignetteRadius", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(5)));
        public static readonly DependencyProperty VignetteAmountProperty = DependencyProperty.Register("VignetteAmount", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(-1D)), PixelShaderConstantCallback(6)));
        public static readonly DependencyProperty BlueShiftProperty = DependencyProperty.Register("BlueShift", typeof(double), typeof(ToneMappingEffect), new UIPropertyMetadata(((double)(0.25D)), PixelShaderConstantCallback(7)));
        public ToneMappingEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/ToneMappingEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(DefogProperty);
            this.UpdateShaderValue(FogColorProperty);
            this.UpdateShaderValue(ExposureProperty);
            this.UpdateShaderValue(GammaProperty);
            this.UpdateShaderValue(VignetteCenterProperty);
            this.UpdateShaderValue(VignetteRadiusProperty);
            this.UpdateShaderValue(VignetteAmountProperty);
            this.UpdateShaderValue(BlueShiftProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The amount of fog to remove.</summary>
        public double Defog
        {
            get
            {
                return ((double)(this.GetValue(DefogProperty)));
            }
            set
            {
                this.SetValue(DefogProperty, value);
            }
        }
        /// <summary>The fog color.</summary>
        public Color FogColor
        {
            get
            {
                return ((Color)(this.GetValue(FogColorProperty)));
            }
            set
            {
                this.SetValue(FogColorProperty, value);
            }
        }
        /// <summary>The exposure adjustment.</summary>
        public double Exposure
        {
            get
            {
                return ((double)(this.GetValue(ExposureProperty)));
            }
            set
            {
                this.SetValue(ExposureProperty, value);
            }
        }
        /// <summary>The gamma correction exponent.</summary>
        public double Gamma
        {
            get
            {
                return ((double)(this.GetValue(GammaProperty)));
            }
            set
            {
                this.SetValue(GammaProperty, value);
            }
        }
        /// <summary>The center of vignetting.</summary>
        public Point VignetteCenter
        {
            get
            {
                return ((Point)(this.GetValue(VignetteCenterProperty)));
            }
            set
            {
                this.SetValue(VignetteCenterProperty, value);
            }
        }
        /// <summary>The radius of vignetting.</summary>
        public double VignetteRadius
        {
            get
            {
                return ((double)(this.GetValue(VignetteRadiusProperty)));
            }
            set
            {
                this.SetValue(VignetteRadiusProperty, value);
            }
        }
        /// <summary>The amount of vignetting.</summary>
        public double VignetteAmount
        {
            get
            {
                return ((double)(this.GetValue(VignetteAmountProperty)));
            }
            set
            {
                this.SetValue(VignetteAmountProperty, value);
            }
        }
        /// <summary>The amount of blue shift.</summary>
        public double BlueShift
        {
            get
            {
                return ((double)(this.GetValue(BlueShiftProperty)));
            }
            set
            {
                this.SetValue(BlueShiftProperty, value);
            }
        }
    }
    /// <summary>An effect that intensifies dark regions.</summary>
    public class GloomEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GloomEffect), 0);
        public static readonly DependencyProperty GloomIntensityProperty = DependencyProperty.Register("GloomIntensity", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register("BaseIntensity", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty GloomSaturationProperty = DependencyProperty.Register("GloomSaturation", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register("BaseSaturation", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(3)));
        public GloomEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/GloomEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(GloomIntensityProperty);
            this.UpdateShaderValue(BaseIntensityProperty);
            this.UpdateShaderValue(GloomSaturationProperty);
            this.UpdateShaderValue(BaseSaturationProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>Intensity of the gloom image.</summary>
        public double GloomIntensity
        {
            get
            {
                return ((double)(this.GetValue(GloomIntensityProperty)));
            }
            set
            {
                this.SetValue(GloomIntensityProperty, value);
            }
        }
        /// <summary>Intensity of the base image.</summary>
        public double BaseIntensity
        {
            get
            {
                return ((double)(this.GetValue(BaseIntensityProperty)));
            }
            set
            {
                this.SetValue(BaseIntensityProperty, value);
            }
        }
        /// <summary>Saturation of the gloom image.</summary>
        public double GloomSaturation
        {
            get
            {
                return ((double)(this.GetValue(GloomSaturationProperty)));
            }
            set
            {
                this.SetValue(GloomSaturationProperty, value);
            }
        }
        /// <summary>Saturation of the base image.</summary>
        public double BaseSaturation
        {
            get
            {
                return ((double)(this.GetValue(BaseSaturationProperty)));
            }
            set
            {
                this.SetValue(BaseSaturationProperty, value);
            }
        }
    }
    public class TelescopicBlurPS3Effect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TelescopicBlurPS3Effect), 0);
        public static readonly DependencyProperty CenterXProperty = DependencyProperty.Register("CenterX", typeof(double), typeof(TelescopicBlurPS3Effect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty CenterYProperty = DependencyProperty.Register("CenterY", typeof(double), typeof(TelescopicBlurPS3Effect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty ZoomBlurAmountProperty = DependencyProperty.Register("ZoomBlurAmount", typeof(double), typeof(TelescopicBlurPS3Effect), new UIPropertyMetadata(((double)(2.5D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty EdgeSizeProperty = DependencyProperty.Register("EdgeSize", typeof(double), typeof(TelescopicBlurPS3Effect), new UIPropertyMetadata(((double)(2D)), PixelShaderConstantCallback(4)));
        public TelescopicBlurPS3Effect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/TelescopicBlurPS3Effect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterXProperty);
            this.UpdateShaderValue(CenterYProperty);
            this.UpdateShaderValue(ZoomBlurAmountProperty);
            this.UpdateShaderValue(EdgeSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>Center X of the Zoom.</summary>
        public double CenterX
        {
            get
            {
                return ((double)(this.GetValue(CenterXProperty)));
            }
            set
            {
                this.SetValue(CenterXProperty, value);
            }
        }
        /// <summary>Center Y of the Zoom.</summary>
        public double CenterY
        {
            get
            {
                return ((double)(this.GetValue(CenterYProperty)));
            }
            set
            {
                this.SetValue(CenterYProperty, value);
            }
        }
        /// <summary>Amount of zoom blur.</summary>
        public double ZoomBlurAmount
        {
            get
            {
                return ((double)(this.GetValue(ZoomBlurAmountProperty)));
            }
            set
            {
                this.SetValue(ZoomBlurAmountProperty, value);
            }
        }
        /// <summary>Fuzziness of edges.</summary>
        public double EdgeSize
        {
            get
            {
                return ((double)(this.GetValue(EdgeSizeProperty)));
            }
            set
            {
                this.SetValue(EdgeSizeProperty, value);
            }
        }
    }
    /// <summary>An effect that blurs the input using Poisson disk sampling.</summary>
    public class GrowablePoissonDiskEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrowablePoissonDiskEffect), 0);
        public static readonly DependencyProperty DiskRadiusProperty = DependencyProperty.Register("DiskRadius", typeof(double), typeof(GrowablePoissonDiskEffect), new UIPropertyMetadata(((double)(5D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty InputSizeProperty = DependencyProperty.Register("InputSize", typeof(Size), typeof(GrowablePoissonDiskEffect), new UIPropertyMetadata(new Size(600D, 400D), PixelShaderConstantCallback(1)));
        public GrowablePoissonDiskEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/GrowablePoissonDiskEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(DiskRadiusProperty);
            this.UpdateShaderValue(InputSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The radius of the Poisson disk (in pixels).</summary>
        public double DiskRadius
        {
            get
            {
                return ((double)(this.GetValue(DiskRadiusProperty)));
            }
            set
            {
                this.SetValue(DiskRadiusProperty, value);
            }
        }
        /// <summary>The size of the input (in pixels).</summary>
        public Size InputSize
        {
            get
            {
                return ((Size)(this.GetValue(InputSizeProperty)));
            }
            set
            {
                this.SetValue(InputSizeProperty, value);
            }
        }
    }
    /// <summary>An effect that blurs in a single direction.</summary>
    public class DirectionalBlurEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(DirectionalBlurEffect), 0);
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(DirectionalBlurEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BlurAmountProperty = DependencyProperty.Register("BlurAmount", typeof(double), typeof(DirectionalBlurEffect), new UIPropertyMetadata(((double)(0.003D)), PixelShaderConstantCallback(1)));
        public DirectionalBlurEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/DirectionalBlurEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(AngleProperty);
            this.UpdateShaderValue(BlurAmountProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The direction of the blur (in degrees).</summary>
        public double Angle
        {
            get
            {
                return ((double)(this.GetValue(AngleProperty)));
            }
            set
            {
                this.SetValue(AngleProperty, value);
            }
        }
        /// <summary>The scale of the blur (as a fraction of the input size).</summary>
        public double BlurAmount
        {
            get
            {
                return ((double)(this.GetValue(BlurAmountProperty)));
            }
            set
            {
                this.SetValue(BlurAmountProperty, value);
            }
        }
    }
    /// <summary>An effect that swirls the input in alternating clockwise and counterclockwise bands.</summary>
    public class BandedSwirlEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BandedSwirlEffect), 0);
        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(BandedSwirlEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BandsProperty = DependencyProperty.Register("Bands", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(10D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register("Strength", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(3)));
        public BandedSwirlEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/BandedSwirlEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterProperty);
            this.UpdateShaderValue(BandsProperty);
            this.UpdateShaderValue(StrengthProperty);
            this.UpdateShaderValue(AspectRatioProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The center of the swirl. (100,100) is lower right corner </summary>
        public Point Center
        {
            get
            {
                return ((Point)(this.GetValue(CenterProperty)));
            }
            set
            {
                this.SetValue(CenterProperty, value);
            }
        }
        /// <summary>The number of bands in the swirl.</summary>
        public double Bands
        {
            get
            {
                return ((double)(this.GetValue(BandsProperty)));
            }
            set
            {
                this.SetValue(BandsProperty, value);
            }
        }
        /// <summary>The strength of the effect.</summary>
        public double Strength
        {
            get
            {
                return ((double)(this.GetValue(StrengthProperty)));
            }
            set
            {
                this.SetValue(StrengthProperty, value);
            }
        }
        /// <summary>The aspect ratio (width / height) of the input.</summary>
        public double AspectRatio
        {
            get
            {
                return ((double)(this.GetValue(AspectRatioProperty)));
            }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
    }
    /// <summary>An effect that creates bands of bright regions.</summary>
    public class BandsEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BandsEffect), 0);
        public static readonly DependencyProperty BandDensityProperty = DependencyProperty.Register("BandDensity", typeof(double), typeof(BandsEffect), new UIPropertyMetadata(((double)(65D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BandIntensityProperty = DependencyProperty.Register("BandIntensity", typeof(double), typeof(BandsEffect), new UIPropertyMetadata(((double)(0.056D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty IsRightSideBandProperty = DependencyProperty.Register("IsRightSideBand", typeof(double), typeof(BandsEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(2)));
        public BandsEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/BandsEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(BandDensityProperty);
            this.UpdateShaderValue(BandIntensityProperty);
            this.UpdateShaderValue(IsRightSideBandProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The number of vertical bands to add to the output. The higher the value the more bands.</summary>
        public double BandDensity
        {
            get
            {
                return ((double)(this.GetValue(BandDensityProperty)));
            }
            set
            {
                this.SetValue(BandDensityProperty, value);
            }
        }
        /// <summary>Intensity of each band.</summary>
        public double BandIntensity
        {
            get
            {
                return ((double)(this.GetValue(BandIntensityProperty)));
            }
            set
            {
                this.SetValue(BandIntensityProperty, value);
            }
        }
        /// <summary>If set to 1, the wide border is on the ight side.</summary>
        public double IsRightSideBand
        {
            get
            {
                return ((double)(this.GetValue(IsRightSideBandProperty)));
            }
            set
            {
                this.SetValue(IsRightSideBandProperty, value);
            }
        }
    }
    /// <summary>An effect that embosses the input.</summary>
    public class EmbossedEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(EmbossedEffect), 0);
        public static readonly DependencyProperty EmbossedAmountProperty = DependencyProperty.Register("EmbossedAmount", typeof(double), typeof(EmbossedEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(EmbossedEffect), new UIPropertyMetadata(((double)(0.003D)), PixelShaderConstantCallback(1)));
        public EmbossedEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/EmbossedEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(EmbossedAmountProperty);
            this.UpdateShaderValue(WidthProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The amplitude of the embossing.</summary>
        public double EmbossedAmount
        {
            get
            {
                return ((double)(this.GetValue(EmbossedAmountProperty)));
            }
            set
            {
                this.SetValue(EmbossedAmountProperty, value);
            }
        }
        /// <summary>The separation between samples (as a fraction of input size).</summary>
        public double Width
        {
            get
            {
                return ((double)(this.GetValue(WidthProperty)));
            }
            set
            {
                this.SetValue(WidthProperty, value);
            }
        }
    }
    /// <summary>An effect mimics the look of glass tiles.</summary>
    public class GlassTilesEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GlassTilesEffect), 0);
        public static readonly DependencyProperty TilesProperty = DependencyProperty.Register("Tiles", typeof(double), typeof(GlassTilesEffect), new UIPropertyMetadata(((double)(5D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BevelWidthProperty = DependencyProperty.Register("BevelWidth", typeof(double), typeof(GlassTilesEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(double), typeof(GlassTilesEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty GroutColorProperty = DependencyProperty.Register("GroutColor", typeof(Color), typeof(GlassTilesEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 0), PixelShaderConstantCallback(2)));
        public GlassTilesEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/GlassTilesEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TilesProperty);
            this.UpdateShaderValue(BevelWidthProperty);
            this.UpdateShaderValue(OffsetProperty);
            this.UpdateShaderValue(GroutColorProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The approximate number of tiles per row/column.</summary>
        public double Tiles
        {
            get
            {
                return ((double)(this.GetValue(TilesProperty)));
            }
            set
            {
                this.SetValue(TilesProperty, value);
            }
        }
        public double BevelWidth
        {
            get
            {
                return ((double)(this.GetValue(BevelWidthProperty)));
            }
            set
            {
                this.SetValue(BevelWidthProperty, value);
            }
        }
        public double Offset
        {
            get
            {
                return ((double)(this.GetValue(OffsetProperty)));
            }
            set
            {
                this.SetValue(OffsetProperty, value);
            }
        }
        public Color GroutColor
        {
            get
            {
                return ((Color)(this.GetValue(GroutColorProperty)));
            }
            set
            {
                this.SetValue(GroutColorProperty, value);
            }
        }
    }
    /// <summary>An effect that magnifies a circular region with a smooth boundary.</summary>
    public class MagnifySmoothEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(MagnifySmoothEffect), 0);
        public static readonly DependencyProperty CenterPointProperty = DependencyProperty.Register("CenterPoint", typeof(Point), typeof(MagnifySmoothEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty InnerRadiusProperty = DependencyProperty.Register("InnerRadius", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty OuterRadiusProperty = DependencyProperty.Register("OuterRadius", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(0.4D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty MagnificationAmountProperty = DependencyProperty.Register("MagnificationAmount", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(2D)), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(MagnifySmoothEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(4)));
        public MagnifySmoothEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/MagnifySmoothEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(CenterPointProperty);
            this.UpdateShaderValue(InnerRadiusProperty);
            this.UpdateShaderValue(OuterRadiusProperty);
            this.UpdateShaderValue(MagnificationAmountProperty);
            this.UpdateShaderValue(AspectRatioProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The center point of the magnified region.</summary>
        public Point CenterPoint
        {
            get
            {
                return ((Point)(this.GetValue(CenterPointProperty)));
            }
            set
            {
                this.SetValue(CenterPointProperty, value);
            }
        }
        /// <summary>The inner radius of the magnified region.</summary>
        public double InnerRadius
        {
            get
            {
                return ((double)(this.GetValue(InnerRadiusProperty)));
            }
            set
            {
                this.SetValue(InnerRadiusProperty, value);
            }
        }
        /// <summary>The outer radius of the magnified region.</summary>
        public double OuterRadius
        {
            get
            {
                return ((double)(this.GetValue(OuterRadiusProperty)));
            }
            set
            {
                this.SetValue(OuterRadiusProperty, value);
            }
        }
        /// <summary>The magnification factor.</summary>
        public double MagnificationAmount
        {
            get
            {
                return ((double)(this.GetValue(MagnificationAmountProperty)));
            }
            set
            {
                this.SetValue(MagnificationAmountProperty, value);
            }
        }
        /// <summary>The aspect ratio (width / height) of the input.</summary>
        public double AspectRatio
        {
            get
            {
                return ((double)(this.GetValue(AspectRatioProperty)));
            }
            set
            {
                this.SetValue(AspectRatioProperty, value);
            }
        }
    }
    public class PaperFoldEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PaperFoldEffect), 0);
        public static readonly DependencyProperty FoldAmountProperty = DependencyProperty.Register("FoldAmount", typeof(double), typeof(PaperFoldEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(0)));
        public PaperFoldEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/PaperFoldEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(FoldAmountProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The Fold Amount, zero is no effect, 1 i full fold</summary>
        public double FoldAmount
        {
            get
            {
                return ((double)(this.GetValue(FoldAmountProperty)));
            }
            set
            {
                this.SetValue(FoldAmountProperty, value);
            }
        }
    }
    /// <summary>An effect that pivots the output around a center point.</summary>
    public class PivotEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PivotEffect), 0);
        public static readonly DependencyProperty PivotAmountProperty = DependencyProperty.Register("PivotAmount", typeof(double), typeof(PivotEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty EdgeProperty = DependencyProperty.Register("Edge", typeof(double), typeof(PivotEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
        public PivotEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/PivotEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(PivotAmountProperty);
            this.UpdateShaderValue(EdgeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The pivot amount</summary>
        public double PivotAmount
        {
            get
            {
                return ((double)(this.GetValue(PivotAmountProperty)));
            }
            set
            {
                this.SetValue(PivotAmountProperty, value);
            }
        }
        public double Edge
        {
            get
            {
                return ((double)(this.GetValue(EdgeProperty)));
            }
            set
            {
                this.SetValue(EdgeProperty, value);
            }
        }
    }
    /// <summary>Applies water defraction effect.</summary>
    public class UnderwaterEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(UnderwaterEffect), 0);
        public static readonly DependencyProperty TimerProperty = DependencyProperty.Register("Timer", typeof(double), typeof(UnderwaterEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty RefractonProperty = DependencyProperty.Register("Refracton", typeof(double), typeof(UnderwaterEffect), new UIPropertyMetadata(((double)(50D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty VerticalTroughWidthProperty = DependencyProperty.Register("VerticalTroughWidth", typeof(double), typeof(UnderwaterEffect), new UIPropertyMetadata(((double)(23D)), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty Wobble2Property = DependencyProperty.Register("Wobble2", typeof(double), typeof(UnderwaterEffect), new UIPropertyMetadata(((double)(23D)), PixelShaderConstantCallback(3)));
        public UnderwaterEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/UnderwaterEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TimerProperty);
            this.UpdateShaderValue(RefractonProperty);
            this.UpdateShaderValue(VerticalTroughWidthProperty);
            this.UpdateShaderValue(Wobble2Property);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public double Timer
        {
            get
            {
                return ((double)(this.GetValue(TimerProperty)));
            }
            set
            {
                this.SetValue(TimerProperty, value);
            }
        }
        /// <summary>Refraction Amount.</summary>
        public double Refracton
        {
            get
            {
                return ((double)(this.GetValue(RefractonProperty)));
            }
            set
            {
                this.SetValue(RefractonProperty, value);
            }
        }
        /// <summary>Vertical trough</summary>
        public double VerticalTroughWidth
        {
            get
            {
                return ((double)(this.GetValue(VerticalTroughWidthProperty)));
            }
            set
            {
                this.SetValue(VerticalTroughWidthProperty, value);
            }
        }
        /// <summary>Center X of the Zoom.</summary>
        public double Wobble2
        {
            get
            {
                return ((double)(this.GetValue(Wobble2Property)));
            }
            set
            {
                this.SetValue(Wobble2Property, value);
            }
        }
    }
    /// <summary>An effect that applies a wave pattern to the inputSampler.</summary>
    public class WaveWarperEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(WaveWarperEffect), 0);
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(double), typeof(WaveWarperEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty WaveSizeProperty = DependencyProperty.Register("WaveSize", typeof(double), typeof(WaveWarperEffect), new UIPropertyMetadata(((double)(64D)), PixelShaderConstantCallback(1)));
        public WaveWarperEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/WaveWarperEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TimeProperty);
            this.UpdateShaderValue(WaveSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public double Time
        {
            get
            {
                return ((double)(this.GetValue(TimeProperty)));
            }
            set
            {
                this.SetValue(TimeProperty, value);
            }
        }
        /// <summary>The distance between waves. (the higher the value the closer the waves are to their neighbor).</summary>
        public double WaveSize
        {
            get
            {
                return ((double)(this.GetValue(WaveSizeProperty)));
            }
            set
            {
                this.SetValue(WaveSizeProperty, value);
            }
        }
    }
    /// <summary>An effect that turns the inputSampler into shades of a single color.</summary>
    public class FrostyOutlineEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(FrostyOutlineEffect), 0);
        public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(FrostyOutlineEffect), new UIPropertyMetadata(((double)(500D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(FrostyOutlineEffect), new UIPropertyMetadata(((double)(300D)), PixelShaderConstantCallback(1)));
        public FrostyOutlineEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/FrostyOutlineEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(WidthProperty);
            this.UpdateShaderValue(HeightProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The width of the frost.</summary>
        public double Width
        {
            get
            {
                return ((double)(this.GetValue(WidthProperty)));
            }
            set
            {
                this.SetValue(WidthProperty, value);
            }
        }
        /// <summary>The height of the frost.</summary>
        public double Height
        {
            get
            {
                return ((double)(this.GetValue(HeightProperty)));
            }
            set
            {
                this.SetValue(HeightProperty, value);
            }
        }
    }
    /// <summary>Pixel shader which produces random scratches, noise and other FX like an old projector</summary>
    public class OldMovieEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(OldMovieEffect), 0);
        public static readonly DependencyProperty ScratchAmountProperty = DependencyProperty.Register("ScratchAmount", typeof(double), typeof(OldMovieEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty NoiseAmountProperty = DependencyProperty.Register("NoiseAmount", typeof(double), typeof(OldMovieEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty RandomCoord1Property = DependencyProperty.Register("RandomCoord1", typeof(Point), typeof(OldMovieEffect), new UIPropertyMetadata(new Point(0D, 0D), PixelShaderConstantCallback(2)));
        public static readonly DependencyProperty RandomCoord2Property = DependencyProperty.Register("RandomCoord2", typeof(Point), typeof(OldMovieEffect), new UIPropertyMetadata(new Point(0D, 0D), PixelShaderConstantCallback(3)));
        public static readonly DependencyProperty FrameProperty = DependencyProperty.Register("Frame", typeof(double), typeof(OldMovieEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(4)));
        public static readonly DependencyProperty NoiseSamplerProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("NoiseSampler", typeof(OldMovieEffect), 1);
        public OldMovieEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/OldMovieEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(ScratchAmountProperty);
            this.UpdateShaderValue(NoiseAmountProperty);
            this.UpdateShaderValue(RandomCoord1Property);
            this.UpdateShaderValue(RandomCoord2Property);
            this.UpdateShaderValue(FrameProperty);
            this.UpdateShaderValue(NoiseSamplerProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public double ScratchAmount
        {
            get
            {
                return ((double)(this.GetValue(ScratchAmountProperty)));
            }
            set
            {
                this.SetValue(ScratchAmountProperty, value);
            }
        }
        public double NoiseAmount
        {
            get
            {
                return ((double)(this.GetValue(NoiseAmountProperty)));
            }
            set
            {
                this.SetValue(NoiseAmountProperty, value);
            }
        }
        /// <summary>The random coordinate 1 that is used for lookup in the noise texture.</summary>
        public Point RandomCoord1
        {
            get
            {
                return ((Point)(this.GetValue(RandomCoord1Property)));
            }
            set
            {
                this.SetValue(RandomCoord1Property, value);
            }
        }
        /// <summary>The random coordinate 2 that is used for lookup in the noise texture.</summary>
        public Point RandomCoord2
        {
            get
            {
                return ((Point)(this.GetValue(RandomCoord2Property)));
            }
            set
            {
                this.SetValue(RandomCoord2Property, value);
            }
        }
        /// <summary>The current frame.</summary>
        public double Frame
        {
            get
            {
                return ((double)(this.GetValue(FrameProperty)));
            }
            set
            {
                this.SetValue(FrameProperty, value);
            }
        }
        public Brush NoiseSampler
        {
            get
            {
                return ((Brush)(this.GetValue(NoiseSamplerProperty)));
            }
            set
            {
                this.SetValue(NoiseSamplerProperty, value);
            }
        }
    }
    /// <summary>An effect that turns the input into blocky pixels.</summary>
    public class PixelateEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PixelateEffect), 0);
        public static readonly DependencyProperty PixelCountsProperty = DependencyProperty.Register("PixelCounts", typeof(Size), typeof(PixelateEffect), new UIPropertyMetadata(new Size(50D, 40D), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty BrickOffsetProperty = DependencyProperty.Register("BrickOffset", typeof(double), typeof(PixelateEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(1)));
        public PixelateEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/PixelateEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(PixelCountsProperty);
            this.UpdateShaderValue(BrickOffsetProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The number of horizontal and vertical pixel blocks.</summary>
        public Size PixelCounts
        {
            get
            {
                return ((Size)(this.GetValue(PixelCountsProperty)));
            }
            set
            {
                this.SetValue(PixelCountsProperty, value);
            }
        }
        /// <summary>The amount to shift alternate rows (use 1 to get a brick wall look).</summary>
        public double BrickOffset
        {
            get
            {
                return ((double)(this.GetValue(BrickOffsetProperty)));
            }
            set
            {
                this.SetValue(BrickOffsetProperty, value);
            }
        }
    }
    /// <summary>An paper sketch effect.</summary>
    public class SketchGraniteEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SketchGraniteEffect), 0);
        public static readonly DependencyProperty BrushSizeProperty = DependencyProperty.Register("BrushSize", typeof(double), typeof(SketchGraniteEffect), new UIPropertyMetadata(((double)(0.003D)), PixelShaderConstantCallback(0)));
        public SketchGraniteEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/SketchGraniteEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(BrushSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The brush size of the sketch effect.</summary>
        public double BrushSize
        {
            get
            {
                return ((double)(this.GetValue(BrushSizeProperty)));
            }
            set
            {
                this.SetValue(BrushSizeProperty, value);
            }
        }
    }
    /// <summary>A pencil stroke effect.</summary>
    public class SketchPencilStrokeEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SketchPencilStrokeEffect), 0);
        public static readonly DependencyProperty BrushSizeProperty = DependencyProperty.Register("BrushSize", typeof(double), typeof(SketchPencilStrokeEffect), new UIPropertyMetadata(((double)(0.005D)), PixelShaderConstantCallback(0)));
        public SketchPencilStrokeEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/SketchPencilStrokeEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(BrushSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The brush size of the sketch effect.</summary>
        public double BrushSize
        {
            get
            {
                return ((double)(this.GetValue(BrushSizeProperty)));
            }
            set
            {
                this.SetValue(BrushSizeProperty, value);
            }
        }
    }
    /// <summary>Pixel shader that samples the color from an image and draws every odd pixel transparent.</summary>
    public class TransparentAlternatingPixelsEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TransparentAlternatingPixelsEffect), 0);
        public static readonly DependencyProperty TextureSizeProperty = DependencyProperty.Register("TextureSize", typeof(Point), typeof(TransparentAlternatingPixelsEffect), new UIPropertyMetadata(new Point(512D, 512D), PixelShaderConstantCallback(0)));
        public TransparentAlternatingPixelsEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/TransparentAlternatingPixelsEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TextureSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The Size of the texture.</summary>
        public Point TextureSize
        {
            get
            {
                return ((Point)(this.GetValue(TextureSizeProperty)));
            }
            set
            {
                this.SetValue(TextureSizeProperty, value);
            }
        }
    }
    /// <summary>Pixel shader that samples the color from an image and draws every odd pixel transparent.</summary>
    public class TransparentAlternatingPixelsMultipliedEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TransparentAlternatingPixelsMultipliedEffect), 0);
        public static readonly DependencyProperty TextureSizeProperty = DependencyProperty.Register("TextureSize", typeof(Point), typeof(TransparentAlternatingPixelsMultipliedEffect), new UIPropertyMetadata(new Point(512D, 512D), PixelShaderConstantCallback(0)));
        public TransparentAlternatingPixelsMultipliedEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/TransparentAlternatingPixelsMultipliedEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TextureSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The Size of the texture.</summary>
        public Point TextureSize
        {
            get
            {
                return ((Point)(this.GetValue(TextureSizeProperty)));
            }
            set
            {
                this.SetValue(TextureSizeProperty, value);
            }
        }
    }
    /// <summary>Pixel shader that samples the color from an image and draws every odd row transparent.</summary>
    public class TransparentAlternatingScanlinesEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TransparentAlternatingScanlinesEffect), 0);
        public static readonly DependencyProperty TextureSizeProperty = DependencyProperty.Register("TextureSize", typeof(Point), typeof(TransparentAlternatingScanlinesEffect), new UIPropertyMetadata(new Point(512D, 512D), PixelShaderConstantCallback(0)));
        public TransparentAlternatingScanlinesEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/TransparentAlternatingScanlinesEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TextureSizeProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        /// <summary>The Size of the texture.</summary>
        public Point TextureSize
        {
            get
            {
                return ((Point)(this.GetValue(TextureSizeProperty)));
            }
            set
            {
                this.SetValue(TextureSizeProperty, value);
            }
        }
    }
    public class ReflectionEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ReflectionEffect), 0);
        public static readonly DependencyProperty ReflectionHeightProperty = DependencyProperty.Register("ReflectionHeight", typeof(Color), typeof(ReflectionEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 0), PixelShaderConstantCallback(1)));
        public static readonly DependencyProperty DdxUvDdyUvProperty = DependencyProperty.Register("DdxUvDdyUv", typeof(Color), typeof(ReflectionEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 0), PixelShaderConstantCallback(6)));
        public ReflectionEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/ReflectionEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(ReflectionHeightProperty);
            this.UpdateShaderValue(DdxUvDdyUvProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public Color ReflectionHeight
        {
            get
            {
                return ((Color)(this.GetValue(ReflectionHeightProperty)));
            }
            set
            {
                this.SetValue(ReflectionHeightProperty, value);
            }
        }
        public Color DdxUvDdyUv
        {
            get
            {
                return ((Color)(this.GetValue(DdxUvDdyUvProperty)));
            }
            set
            {
                this.SetValue(DdxUvDdyUvProperty, value);
            }
        }
    }

    public class GrayscaleEffect : ShaderEffect
    {
        public GrayscaleEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = new Uri("pack://application:,,,/ShaderEffects/PsEffects/GrayscaleEffect.ps");
            this.PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(DesaturationFactorProperty);
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GrayscaleEffect), 0);
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty DesaturationFactorProperty = DependencyProperty.Register("DesaturationFactor", typeof(double), typeof(GrayscaleEffect), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceDesaturationFactor));
        public double DesaturationFactor
        {
            get { return (double)GetValue(DesaturationFactorProperty); }
            set { SetValue(DesaturationFactorProperty, value); }
        }

        private static object CoerceDesaturationFactor(DependencyObject d, object value)
        {
            GrayscaleEffect effect = (GrayscaleEffect)d;
            double newFactor = (double)value;

            if (newFactor < 0.0 || newFactor > 1.0)
            {
                return effect.DesaturationFactor;
            }

            return newFactor;
        }
    }

}
