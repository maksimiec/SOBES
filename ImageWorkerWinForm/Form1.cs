
//I know I know, this program is horrible or like Barinov would say :"This is pornography!!!". From beginning i was interested, can you make the program without variables (spoiler - nupe). Btw it was interesting and usefull in some cases
using System.Diagnostics.Eventing.Reader;
using System;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Drawing;
using System.Windows.Forms;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using ImageTransformationApp;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Diagnostics;
//using System.Drawing.Drawing2D;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using static ImageTransformationApp.NoiseProcessor;
using static ImageTransformationApp.ImageProcessor;
using SixLabors.ImageSharp;
using System.Linq.Expressions;
using Paper;
using SimplexNoise;
using System.Drawing.Imaging;
using LibNoise;
using LibNoise.Modifiers;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
//using SixLabors.ImageSharp.PixelFormats;
///

namespace ImageWorkerWinForm
{


    public partial class Form1 : Form
    {
        //   private System.Drawing.Color keyColor;
        //private int tol ;
        //public Color keycolor;
        public Form1()
        {
            InitializeComponent();
        }


        private void CBGreen_Click(object sender, EventArgs e)
        {
            CBRed.Checked = false;
            CBBlue.Checked = false;
        }

        private void CBBlue_Click(object sender, EventArgs e)
        {
            CBRed.Checked = false;
            CBGreen.Checked = false;
        }

        private void CBRed_Click(object sender, EventArgs e)
        {
            CBBlue.Checked = false;
            CBGreen.Checked = false;
        }

        private void TrBNoiseIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBNoiseIntensity.Text = TrBNoiseIntensity.Value.ToString();
        }

        private void TrBMosaicNoiseCells_ValueChanged(object sender, EventArgs e)
        {
            TeBMosaicNoiseCells.Text = TrBMosaicNoiseCells.Value.ToString();
        }

        private void TrBNoiseAmount_ValueChanged(object sender, EventArgs e)
        {


            TeBNoiseAmount.Text = Convert.ToString((float)TrBNoiseAmount.Value / 100 * (100 / TrBNoiseAmount.Maximum));
        }

        private void TrBReduceColorIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBReduceColorIntensity.Text = Convert.ToString((float)TrBReduceColorIntensity.Value / 100 * (100 / TrBReduceColorIntensity.Maximum));
        }

        private void TrBBlur_ValueChanged(object sender, EventArgs e)
        {
            TeBBlur.Text = TrBBlur.Value.ToString();
        }

        private void TrBPerlinNoiseScale_ValueChanged(object sender, EventArgs e)
        {
            TeBPerlinNoiseScale.Text = Convert.ToString((float)TrBPerlinNoiseScale.Value / 100 * (100 / TrBPerlinNoiseScale.Maximum));
        }

        private void TrBPerlinNoiseIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBPerlinNoiseIntensity.Text = Convert.ToString((float)TrBPerlinNoiseIntensity.Value / 100 * (100 / TrBPerlinNoiseIntensity.Maximum));
        }

        private void TrBFractalBrownNoiseScale_ValueChanged(object sender, EventArgs e)
        {
            TeBFractalBrownNoiseScale.Text = TrBFractalBrownNoiseScale.Value.ToString();
        }

        private void TrBFractalBrownNoiseIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBFractalBrownNoiseIntensity.Text = Convert.ToString((float)TrBFractalBrownNoiseIntensity.Value / 100 * (100 / TrBFractalBrownNoiseIntensity.Maximum));
        }

        private void TrBMosaicNoiseIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBMosaicNoiseIntensity.Text = Convert.ToString((float)TrBMosaicNoiseIntensity.Value / 100 * (100 / TrBMosaicNoiseIntensity.Maximum));
        }

        private void TrBRandomNoiseIntensity_ValueChanged(object sender, EventArgs e)
        {
            TeBRandomNoiseIntensity.Text = Convert.ToString((float)TrBRandomNoiseIntensity.Value / 100 * (100 / TrBRandomNoiseIntensity.Maximum));
        }

        private void TeBRotate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBRotate.Text) || TeBRotate.Text == "-") // check for empty & "-" to avoid false error
            {
                TeBRotate.BackColor = System.Drawing.Color.White;
            }
            else
            {

                try { Convert.ToInt32(TeBRotate.Text); TeBRotate.BackColor = System.Drawing.Color.LightGreen; } //  Checking TextBox input for Int format, if good coloring into white
                catch { TeBRotate.BackColor = System.Drawing.Color.DarkRed; } // error while converting, coloring TextBox into red
            }

        }

        private void TeBWarpWI_TextChanged(object sender, EventArgs e)
        {


            //TeBWarpWI.Text = TeBWarpWI.Text.Replace(",",".");
            if (string.IsNullOrEmpty(TeBWarpWI.Text) || TeBWarpWI.Text == "-")
            {
                TeBWarpWI.BackColor = System.Drawing.Color.White;
            }
            else
            {
                try { Convert.ToSingle(TeBWarpWI.Text); TeBWarpWI.BackColor = System.Drawing.Color.LightGreen; } // MessageBox.Show($"Input -- {s}");
                catch { TeBWarpWI.BackColor = System.Drawing.Color.DarkRed; }

            }
        }

        private void TeBWarpF_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBWarpF.Text) || TeBWarpF.Text == "-")
            { TeBWarpF.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBWarpF.Text); TeBWarpF.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBWarpF.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBRColorShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBRColorShift.Text) || TeBRColorShift.Text == "-")
            { TeBRColorShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBRColorShift.Text); TeBRColorShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBRColorShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBGColorShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBGColorShift.Text) || TeBGColorShift.Text == "-")
            { TeBGColorShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBGColorShift.Text); TeBGColorShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBGColorShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBBColorShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBBColorShift.Text) || TeBBColorShift.Text == "-") { TeBBColorShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBBColorShift.Text); TeBBColorShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBBColorShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBHUEShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBHUEShift.Text) || TeBHUEShift.Text == "-")
            { TeBHUEShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBHUEShift.Text); TeBHUEShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBHUEShift.BackColor = System.Drawing.Color.DarkRed; }

            }
        }

        private void TeBTiltX_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBTiltX.Text) || TeBTiltX.Text == "-")
            { TeBTiltX.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBTiltX.Text); TeBTiltX.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBTiltX.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBTiltY_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBTiltY.Text) || TeBTiltY.Text == "-")
            { TeBTiltY.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBTiltY.Text); TeBTiltY.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBTiltY.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBPerlinNoiseR1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBPerlinNoiseR1.Text) || TeBPerlinNoiseR1.Text == "-")
            { TeBPerlinNoiseR1.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBPerlinNoiseR1.Text); TeBPerlinNoiseR1.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBPerlinNoiseR1.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBPerlinNoiseR2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBPerlinNoiseR2.Text) || TeBPerlinNoiseR2.Text == "-")
            { TeBPerlinNoiseR2.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBPerlinNoiseR2.Text); TeBPerlinNoiseR2.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBPerlinNoiseR2.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBPerlinNoiseR3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBPerlinNoiseR3.Text) || TeBPerlinNoiseR3.Text == "-")
            { TeBPerlinNoiseR3.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToDouble(TeBPerlinNoiseR3.Text); TeBPerlinNoiseR3.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBPerlinNoiseR3.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBFractalBrownNoiseR1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBFractalBrownNoiseR1.Text) || TeBFractalBrownNoiseR1.Text == "-")
            { TeBFractalBrownNoiseR1.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBFractalBrownNoiseR1.Text); TeBFractalBrownNoiseR1.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBFractalBrownNoiseR1.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBFractalBrownNoiseR2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBFractalBrownNoiseR2.Text) || TeBFractalBrownNoiseR2.Text == "-")
            { TeBFractalBrownNoiseR2.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBFractalBrownNoiseR2.Text); TeBFractalBrownNoiseR2.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBFractalBrownNoiseR2.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBFractalBrownNoiseR3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBFractalBrownNoiseR3.Text) || TeBFractalBrownNoiseR3.Text == "-")
            { TeBFractalBrownNoiseR3.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToDouble(TeBFractalBrownNoiseR3.Text); TeBFractalBrownNoiseR3.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBFractalBrownNoiseR3.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBWaterRippledX_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBWaterRippledX.Text) || TeBWaterRippledX.Text == "-")
            { TeBWaterRippledX.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBWaterRippledX.Text); TeBWaterRippledX.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBWaterRippledX.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBWaterRippledY_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBWaterRippledY.Text) || TeBWaterRippledY.Text == "-")
            { TeBWaterRippledY.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBWaterRippledY.Text); TeBWaterRippledY.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBWaterRippledY.BackColor = System.Drawing.Color.DarkRed; }

            }
        }

        private void TeBWaveHorizontalAmplitude_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBWaveHorizontalAmplitude.Text) || TeBWaveHorizontalAmplitude.Text == "-")
            { TeBWaveHorizontalAmplitude.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBWaveHorizontalAmplitude.Text); TeBWaveHorizontalAmplitude.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBWaveHorizontalAmplitude.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBWaveVerticalAmplitude_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBWaveVerticalAmplitude.Text) || TeBWaveVerticalAmplitude.Text == "-")
            { TeBWaveVerticalAmplitude.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBWaveVerticalAmplitude.Text); TeBWaveVerticalAmplitude.BackColor = System.Drawing.Color.LightGreen; }

                catch { TeBWaveVerticalAmplitude.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBMosaicNoiseR1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBMosaicNoiseR1.Text) || TeBMosaicNoiseR1.Text == "-")
            { TeBMosaicNoiseR1.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBMosaicNoiseR1.Text); TeBMosaicNoiseR1.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBMosaicNoiseR1.BackColor = System.Drawing.Color.DarkRed; }

            }
        }

        private void TeBMosaicNoiseR2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBMosaicNoiseR2.Text) || TeBMosaicNoiseR2.Text == "-")
            { TeBMosaicNoiseR2.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBMosaicNoiseR2.Text); TeBMosaicNoiseR2.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBMosaicNoiseR2.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBMosaicNoiseR3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBMosaicNoiseR3.Text) || TeBMosaicNoiseR3.Text == "-")
            { TeBMosaicNoiseR3.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToDouble(TeBMosaicNoiseR3.Text); TeBMosaicNoiseR3.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBMosaicNoiseR3.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBRandomNoiseParameterR1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBRandomNoiseParameterR1.Text) || TeBRandomNoiseParameterR1.Text == "-")
            { TeBRandomNoiseParameterR1.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBRandomNoiseParameterR1.Text); TeBRandomNoiseParameterR1.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBRandomNoiseParameterR1.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBRandomNoiseParameterR2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBRandomNoiseParameterR2.Text) || TeBRandomNoiseParameterR2.Text == "-")
            { TeBRandomNoiseParameterR2.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBRandomNoiseParameterR2.Text); TeBRandomNoiseParameterR2.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBRandomNoiseParameterR2.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBRandomNoiseParameterR3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBRandomNoiseParameterR3.Text) || TeBRandomNoiseParameterR3.Text == "-")
            { TeBRandomNoiseParameterR3.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToDouble(TeBRandomNoiseParameterR3.Text); TeBRandomNoiseParameterR3.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBRandomNoiseParameterR3.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBBrShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBBrShift.Text) || TeBBrShift.Text == "-")
            { TeBBrShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBBrShift.Text); TeBBrShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBBrShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBGaShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBGaShift.Text) || TeBGaShift.Text == "-")
            { TeBGaShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBGaShift.Text); TeBGaShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBGaShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBCoShift_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBCoShift.Text) || TeBCoShift.Text == "-")
            { TeBCoShift.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToSingle(TeBCoShift.Text); TeBCoShift.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBCoShift.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void TeBSimplePerlinNoiseScale_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBSimplePerlinNoiseScale.Text) || TeBSimplePerlinNoiseScale.Text == "-")
            { TeBSimplePerlinNoiseScale.BackColor = System.Drawing.Color.White; }
            else
            {
                try { Convert.ToInt32(TeBSimplePerlinNoiseScale.Text); TeBSimplePerlinNoiseScale.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBSimplePerlinNoiseScale.BackColor = System.Drawing.Color.DarkRed; }
            }
        }

        private void DirBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DirBox.Text)) { DirBox.BackColor = System.Drawing.Color.White; }
            else if (!Directory.Exists(DirBox.Text)) { DirBox.BackColor = System.Drawing.Color.DarkRed; }
            else { DirBox.BackColor = System.Drawing.Color.LightGreen; }
            if (DirBox.Text == TeBSaveDir.Text && !string.IsNullOrEmpty(DirBox.Text)) { TeBSaveDir.BackColor = System.Drawing.Color.GreenYellow; }
            try { if (DirBox.Text[DirBox.Text.Length - 1] == '\\') DirBox.BackColor = System.Drawing.Color.DarkRed; }
            catch { }

        }

        private void TeBSaveDir_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBSaveDir.Text))
            { TeBSaveDir.BackColor = System.Drawing.Color.White; }
            else if (!Directory.Exists(TeBSaveDir.Text)) { TeBSaveDir.BackColor = System.Drawing.Color.GreenYellow; }
            else
            if (DirBox.Text == TeBSaveDir.Text && !string.IsNullOrEmpty(DirBox.Text)) { TeBSaveDir.BackColor = System.Drawing.Color.GreenYellow; } else { TeBSaveDir.BackColor = System.Drawing.Color.LightGreen; }
            //try { Directory.CreateDirectory(TeBSaveDir.Text); Directory.Delete(TeBSaveDir.Text); } Directory.Exists()
            //catch { TeBSaveDir.BackColor = System.Drawing.Color.DarkRed; }
            try { if (TeBSaveDir.Text[TeBSaveDir.Text.Length - 1] == '\\') TeBSaveDir.BackColor = System.Drawing.Color.DarkRed; }
            catch { }
        }

        private void TeBFrontDir_TextChanged(object sender, EventArgs e)
        {
            if (TeBFrontDir.Text == TeBBackDir.Text && !string.IsNullOrEmpty(TeBFrontDir.Text)) { TeBFrontDir.BackColor = System.Drawing.Color.DarkRed; TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
            else

             if (string.IsNullOrEmpty(TeBFrontDir.Text))
            {
                TeBFrontDir.BackColor = System.Drawing.Color.White; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }
            else if (!Directory.Exists(TeBFrontDir.Text))
            {
                TeBFrontDir.BackColor = System.Drawing.Color.DarkRed; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }
            else
            {
                TeBFrontDir.BackColor = System.Drawing.Color.LightGreen; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }






            try
            {
                if (TeBFrontDir.Text[TeBFrontDir.Text.Length - 1] == '\\') TeBFrontDir.BackColor = System.Drawing.Color.DarkRed;
                if (TeBBackDir.Text[TeBBackDir.Text.Length - 1] == '\\') TeBBackDir.BackColor = System.Drawing.Color.DarkRed;
            }
            catch { }
        }

        private void BuScenario1_Click(object sender, EventArgs e)
        {
            if (DirBox.BackColor == System.Drawing.Color.DarkRed || DirBox.BackColor == System.Drawing.Color.White) { MessageBox.Show("Check input folder, it'sn't exist"); }
            else
            {
                string sd = "";
                if (TeBSaveDir.BackColor == System.Drawing.Color.DarkRed || TeBSaveDir.BackColor == System.Drawing.Color.White) { MessageBox.Show("Check save directory, it'sn't correct"); }
                else if (string.IsNullOrEmpty(TeBSaveDir.Text)) { sd = DirBox.Text; }
                else if (TeBSaveDir.BackColor == System.Drawing.Color.GreenYellow) { sd = TeBSaveDir.Text; try { Directory.CreateDirectory(sd); } catch { MessageBox.Show("Check save directory, it'sn't correct"); } }
                else if (TeBSaveDir.BackColor == System.Drawing.Color.LightGreen) { sd = TeBSaveDir.Text; }
                //======================
                foreach (var file in FileHandler.GetPngFiles(DirBox.Text))
                {
                    using (Image<Rgba32> orimage = SixLabors.ImageSharp.Image.Load<Rgba32>(file))
                    {
                        if (CBGrayscale.Checked) FileHandler.SaveImage(sd, file, "_grayscale", ImageProcessor.ConvertToGrayscale(orimage));
                        if (CBEdge.Checked) FileHandler.SaveImage(sd, file, "_edges", ImageProcessor.ApplyEdgeDetection(orimage));
                        if (CBNegative.Checked) FileHandler.SaveImage(sd, file, "_negative", NegativeProcessor.ApplyNegative(orimage));
                        if (CBMirrorH.Checked) FileHandler.SaveImage(sd, file, "_mirror_h", ImageMirrorProcessor.MirrorH(orimage));
                        if (CBMirrorV.Checked) FileHandler.SaveImage(sd, file, "_mirror_v", ImageMirrorProcessor.MirrorV(orimage));
                        if (CBMirrorHV.Checked) FileHandler.SaveImage(sd, file, "_mirror_hv", ImageMirrorProcessor.MirrorH(ImageMirrorProcessor.MirrorV(orimage)));
                        // TeBNoiseAmount.Text = Convert.ToString((float)TrBNoiseAmount.Value / 100 * (100 / TrBNoiseAmount.Maximum));
                        //         TeBNoiseIntensity.Text = TrBNoiseIntensity.Value.ToString();
                        if (CBNoise.Checked) FileHandler.SaveImage(sd, file, $"noise_{Convert.ToString((float)TrBNoiseAmount.Value / 100 * (100 / TrBNoiseAmount.Maximum))}n_{TrBNoiseIntensity.Value.ToString()}i", NoiseProcessor.AddNoise(orimage, (float)TrBNoiseAmount.Value / 100 * (100 / TrBNoiseAmount.Maximum), TrBNoiseIntensity.Value));
                        if (CBRotate.Checked && TeBRotate.BackColor == System.Drawing.Color.LightGreen) FileHandler.SaveImage(sd, file, $"rotated_{TeBRotate.Text}", Rotator.ApllyRotation(orimage, Convert.ToInt32(TeBRotate.Text))); // Rotator.ApllyRotation( orimage, Convert.ToInt32(TeBRotate.Text))
                        if (CBWarp.Checked && TeBWarpWI.BackColor == System.Drawing.Color.LightGreen && TeBWarpF.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"warped_{Convert.ToString(float.Parse(TeBWarpWI.Text))}w_{Convert.ToString(float.Parse(TeBWarpF.Text))}f", ImageWarpProcessor.WarpImage(orimage, float.Parse(TeBWarpWI.Text), float.Parse(TeBWarpF.Text))); }  // float.Parse(TeBWarpWI.Text) ;
                        if (CBRGBShifted.Checked && TeBRColorShift.BackColor == System.Drawing.Color.LightGreen && TeBGColorShift.BackColor == System.Drawing.Color.LightGreen && TeBBColorShift.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"RGB_shft_{TeBRColorShift.Text}r_{TeBGColorShift.Text}g_{TeBBColorShift.Text}b", ColorShiftProcessor.ApplyColorShift(orimage, Convert.ToInt32(TeBRColorShift.Text), Convert.ToInt32(TeBGColorShift.Text), Convert.ToInt32(TeBBColorShift.Text))); }
                        if (CBBGCShift.Checked && TeBBrShift.BackColor == System.Drawing.Color.LightGreen && TeBGaShift.BackColor == System.Drawing.Color.LightGreen && TeBCoShift.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"BGC_shft_{TeBBrShift.Text}_{TeBGaShift.Text}_{TeBCoShift.Text}", ImageAdjustmentsProcessor.AdjustBGK(orimage, float.Parse(TeBBrShift.Text), float.Parse(TeBGaShift.Text), float.Parse(TeBCoShift.Text))); }
                        if (CBReduceColor.Checked)
                        {
                            if (CBRed.Checked) { FileHandler.SaveImage(sd, file, $"_rdcd_r", ColorIntensityReducer.ReduceCI(orimage, $"rred_{TeBReduceColorIntensity.Text}", (float)TrBReduceColorIntensity.Value / 100 * (100 / TrBReduceColorIntensity.Maximum))); }
                            else if (CBGreen.Checked) { FileHandler.SaveImage(sd, file, $"_rdcd_g", ColorIntensityReducer.ReduceCI(orimage, $"rgreen_{TeBReduceColorIntensity.Text}", (float)TrBReduceColorIntensity.Value / 100 * (100 / TrBReduceColorIntensity.Maximum))); }
                            else if (CBBlue.Checked) { FileHandler.SaveImage(sd, file, $"_rdcd_b", ColorIntensityReducer.ReduceCI(orimage, $"rblue_{TeBReduceColorIntensity.Text}", (float)TrBReduceColorIntensity.Value / 100 * (100 / TrBReduceColorIntensity.Maximum))); ; ; }
                        }
                        if (CBHUEShift.Checked && TeBHUEShift.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_HUEs_{TeBHUEShift.Text}", HueAdjuster.AdjustHue(orimage, float.Parse(TeBHUEShift.Text))); }
                        if (CBTiltX.Checked && TeBTiltX.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_tltd_{TeBTiltX.Text}X", TiltProcessor.ApplyTilt(orimage, Convert.ToSingle(TeBTiltX.Text), 0)); }
                        if (CBTiltY.Checked && TeBTiltY.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_tltd_{TeBTiltY.Text}Y", TiltProcessor.ApplyTilt(orimage, 0, Convert.ToSingle(TeBTiltY.Text))); }
                        if (CBTiltXY.Checked && TeBTiltX.BackColor == System.Drawing.Color.LightGreen && TeBTiltY.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_tltd_{TeBTiltX.Text}X_{TeBTiltY.Text}Y", TiltProcessor.ApplyTilt(orimage, Convert.ToSingle(TeBTiltX.Text), Convert.ToSingle(TeBTiltY.Text))); }

                    }

                    if (CBSimplePerlinNoise.Checked && TeBSimplePerlinNoiseScale.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"simper_{TeBSimplePerlinNoiseScale.Text}", Noiser.ApplyPerlinNoise(new Bitmap(file), Convert.ToInt32(TeBSimplePerlinNoiseScale.Text))); }
                    var pS = new NoiserS();
                    if (CBRandomNoise.Checked && TeBRandomNoiseParameterR1.BackColor == System.Drawing.Color.LightGreen && TeBRandomNoiseParameterR2.BackColor == System.Drawing.Color.LightGreen && TeBRandomNoiseParameterR3.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"ranois_{TrBRandomNoiseIntensity.Value}_{Convert.ToString((float)TrBRandomNoiseIntensity.Value / 100 * (100 / TrBRandomNoiseIntensity.Maximum))}_{TeBRandomNoiseParameterR1.Text}_{TeBRandomNoiseParameterR2.Text}_{TeBRandomNoiseParameterR3.Text}", pS.ApplyRandomNoise(new Bitmap(file), (float)TrBRandomNoiseIntensity.Value / 100 * (100 / TrBRandomNoiseIntensity.Maximum), float.Parse(TeBRandomNoiseParameterR1.Text), float.Parse(TeBRandomNoiseParameterR2.Text), Convert.ToDouble(TeBRandomNoiseParameterR3.Text))); }
                    if (CBBlur.Checked) { FileHandler.SaveImage(sd, file, $"_blr{TrBBlur.Value}", Blurer.Blur(new Bitmap(file), TrBBlur.Value)); }
                    var pT = new NoiserT();
                    if (PerlinNCB.Checked && TeBPerlinNoiseR1.BackColor == System.Drawing.Color.LightGreen && TeBPerlinNoiseR2.BackColor == System.Drawing.Color.LightGreen && TeBPerlinNoiseR3.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_prlns_{Convert.ToString((float)TrBPerlinNoiseScale.Value / 100 * (100 / TrBPerlinNoiseScale.Maximum))}s_{Convert.ToString((float)TrBPerlinNoiseIntensity.Value / 100 * (100 / TrBPerlinNoiseIntensity.Maximum))}i_{TeBPerlinNoiseR1.Text}_{TeBPerlinNoiseR2.Text}_{TeBPerlinNoiseR3.Text}", pT.ApplyPerlinNoise(new Bitmap(file), (float)TrBPerlinNoiseScale.Value / 100 * (100 / TrBPerlinNoiseScale.Maximum), (float)TrBPerlinNoiseIntensity.Value / 100 * (100 / TrBPerlinNoiseIntensity.Maximum), Convert.ToSingle(TeBPerlinNoiseR1.Text), Convert.ToSingle(TeBPerlinNoiseR2.Text), Convert.ToDouble(TeBPerlinNoiseR3.Text))); }
                    var pB = new NoiserB();
                    if (CBFractalBrownNoise.Checked && TeBFractalBrownNoiseR1.BackColor == System.Drawing.Color.LightGreen && TeBFractalBrownNoiseR2.BackColor == System.Drawing.Color.LightGreen && TeBFractalBrownNoiseR3.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_frctlbr_{Convert.ToString((float)TrBFractalBrownNoiseScale.Value)}s_{Convert.ToString((float)TrBFractalBrownNoiseIntensity.Value / 100 * (100 / TrBFractalBrownNoiseScale.Maximum))}i_{TeBFractalBrownNoiseR1.Text}_{TeBFractalBrownNoiseR2.Text}_{TeBFractalBrownNoiseR3.Text}", pB.ApplyFbmNoise(new Bitmap(file), (float)TrBFractalBrownNoiseScale.Value, (float)TrBFractalBrownNoiseIntensity.Value / 100 * (100 / TrBFractalBrownNoiseScale.Maximum), false, Convert.ToSingle(TeBFractalBrownNoiseR1.Text), Convert.ToSingle(TeBFractalBrownNoiseR2.Text), Convert.ToDouble(TeBFractalBrownNoiseR3.Text))); }
                    if (CBWaterRippleX.Checked && TeBWaterRippledX.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_wtr_{TeBWaterRippledX.Text}X", Noiser.ApplyWaterRippleEffect(new Bitmap(file), Convert.ToInt32(TeBWaterRippledX.Text), 0)); }
                    if (CBWaterRippleY.Checked && TeBWaterRippledY.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_wtr_{TeBWaterRippledY.Text}Y", Noiser.ApplyWaterRippleEffect(new Bitmap(file), 0, Convert.ToInt32(TeBWaterRippledY.Text))); }
                    if (CBWaterRippleXY.Checked && TeBWaterRippledY.BackColor == System.Drawing.Color.LightGreen && TeBWaterRippledX.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_wtr_{TeBWaterRippledX.Text}X_{TeBWaterRippledY.Text}Y", Noiser.ApplyWaterRippleEffect(new Bitmap(file), Convert.ToInt32(TeBWaterRippledX.Text), Convert.ToInt32(TeBWaterRippledY.Text))); }
                    if (CBWaveX.Checked && TeBWaveHorizontalAmplitude.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_waved_{TeBWaveHorizontalAmplitude.Text}X", Noiser.ApplyWaveEffect(new Bitmap(file), Convert.ToInt32(TeBWaveHorizontalAmplitude.Text), 0)); }
                    if (CBWaveY.Checked && TeBWaveVerticalAmplitude.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_waved_{TeBWaveVerticalAmplitude.Text}Y", Noiser.ApplyWaveEffect(new Bitmap(file), 0, Convert.ToInt32(TeBWaveVerticalAmplitude.Text))); }
                    if (CBWaveXY.Checked && TeBWaveHorizontalAmplitude.BackColor == System.Drawing.Color.LightGreen && TeBWaveVerticalAmplitude.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_waved_{TeBWaveHorizontalAmplitude.Text}X_{TeBWaveVerticalAmplitude.Text}Y", Noiser.ApplyWaveEffect(new Bitmap(file), Convert.ToInt32(TeBWaveHorizontalAmplitude.Text), Convert.ToInt32(TeBWaveVerticalAmplitude.Text))); }
                    var pM = new NoiserMo();
                    if (CBMosaicNoise.Checked && TeBMosaicNoiseR1.BackColor == System.Drawing.Color.LightGreen && TeBMosaicNoiseR2.BackColor == System.Drawing.Color.LightGreen && TeBMosaicNoiseR3.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"mscns_{TeBMosaicNoiseCells.Text}c_{TeBMosaicNoiseIntensity.Text}i_{TeBMosaicNoiseR1.Text}_{TeBMosaicNoiseR2.Text}_{TeBMosaicNoiseR3.Text}", pM.ApplyMosaicEffect(new Bitmap(file), Convert.ToInt32(TeBMosaicNoiseCells.Text), Convert.ToSingle(TeBMosaicNoiseIntensity.Text), Convert.ToSingle(TeBMosaicNoiseR1.Text), Convert.ToSingle(TeBMosaicNoiseR2.Text), Convert.ToDouble(TeBMosaicNoiseR3.Text))); }
                    if (CBSimpNoise.Checked && TeBSimpSeed.BackColor == System.Drawing.Color.LightGreen) { FileHandler.SaveImage(sd, file, $"_smplxns_{TeBSimpSeed.Text}sd_{TeBSimpGrid.Text}grd_{TeBSimpScale.Text}scl_{TeBSimpR.Text}rd_{TeBSimpG.Text}grn_{TeBSimpB.Text}bl_{TeBSimpTr.Text}trn", OverlayImages(new Bitmap(file), SimplexNoiser(Convert.ToInt32(TeBSimpSeed.Text), Convert.ToInt32(TeBSimpGrid.Text), Convert.ToSingle(TeBSimpScale.Text), new Bitmap(file).Height, new Bitmap(file).Width, Convert.ToSingle(TeBSimpR.Text), Convert.ToSingle(TeBSimpG.Text), Convert.ToSingle(TeBSimpB.Text)), Convert.ToSingle(TeBSimpTr.Text))); }
                    using (SixLabors.ImageSharp.Image oi = SixLabors.ImageSharp.Image.Load(file))
                    {
                        Random rnd = new();
                        //oi.Mutate(x => x.Resize(Convert.ToInt32(TeBResizeWidth.Text), Convert.ToInt32(TeBResizeRandomHeight.Text)));
                        //  if (CBResizeIm.Checked && TeBResizeRandomWidth.BackColor == System.Drawing.Color.LightGreen && TeBResizeRandomHeight.BackColor == System.Drawing.Color.LightGreen && !CBResizeImRandom.Checked) FileHandler.SaveImage(sd, file, $"rszd_{TeBResizeWidth.Text}w_{TeBResizeHeight.Text}h", oi);
                        if (CBResizeIm.Checked && TeBResizeWidth.BackColor == System.Drawing.Color.LightGreen && TeBResizeHeight.BackColor == System.Drawing.Color.LightGreen) { oi.Mutate(x => x.Resize(Convert.ToInt32(TeBResizeWidth.Text), Convert.ToInt32(TeBResizeHeight.Text))); FileHandler.SaveImage(sd, file, $"_rszd_{TeBResizeWidth.Text}w_{TeBResizeHeight.Text}h", oi); }
                        if (CBResizeImRandom.Checked && TeBResizeHeight.BackColor == System.Drawing.Color.LightGreen && TeBResizeRandomHeight.BackColor == System.Drawing.Color.LightGreen && TeBResizeRandomWidth.BackColor == System.Drawing.Color.LightGreen && TeBResizeWidth.BackColor == System.Drawing.Color.LightGreen) { oi.Mutate(x => x.Resize(Convert.ToInt32(TeBResizeWidth.Text) + rnd.Next(Convert.ToInt32(TeBResizeRandomWidth.Text) * -1, Convert.ToInt32(TeBResizeRandomWidth.Text)), Convert.ToInt32(TeBResizeHeight.Text) + rnd.Next(Convert.ToInt32(TeBResizeRandomHeight.Text) * -1, Convert.ToInt32(TeBResizeRandomHeight.Text)))); FileHandler.SaveImage(sd, file, $"_rszd_{TeBResizeWidth.Text}w+-{TeBResizeRandomWidth.Text}_{TeBResizeHeight.Text}h+-{TeBResizeRandomHeight.Text}", oi); }
                    }
                    IModule module; string qua = "";
                    if (CBSlowPerlin.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new Perlin();
                        ((Perlin)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((Perlin)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((Perlin)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((Perlin)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((Perlin)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((Perlin)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((Perlin)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((Perlin)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        ((Perlin)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_slwP_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }

                    if (CBFastPerlin.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new FastNoise();
                        ((FastNoise)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((FastNoise)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((FastNoise)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((FastNoise)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((FastNoise)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((FastNoise)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((FastNoise)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((FastNoise)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        ((FastNoise)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_fstP_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }
                    if (CBSlowBillow.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new Billow();
                        ((Billow)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((Billow)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((Billow)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((Billow)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((Billow)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((Billow)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((Billow)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((Billow)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        ((Billow)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_slwB_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }
                    if (CBFastBillow.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new FastBillow();
                        ((FastBillow)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((FastBillow)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((FastBillow)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((FastBillow)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((FastBillow)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((FastBillow)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((FastBillow)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((FastBillow)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        ((FastBillow)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_fstB_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }

                    if (CBSlowRid.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new RidgedMultifractal();
                        ((RidgedMultifractal)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((RidgedMultifractal)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((RidgedMultifractal)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((RidgedMultifractal)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((RidgedMultifractal)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((RidgedMultifractal)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((RidgedMultifractal)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((RidgedMultifractal)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        // ((RidgedMultifractal)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_slwRM_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }

                    if (CBFastRid.Checked && TeBNoiseSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new FastRidgedMultifractal();
                        ((FastRidgedMultifractal)module).Frequency = Convert.ToDouble(TeBFreq.Text);
                        if (CBQLow.Checked)
                        {
                            ((FastRidgedMultifractal)module).NoiseQuality = NoiseQuality.Low; qua = "lw";
                        }
                        else if (CBQStan.Checked)
                        {
                            ((FastRidgedMultifractal)module).NoiseQuality = NoiseQuality.Standard;
                        }
                        else if (CBQHigh.Checked) { ((FastRidgedMultifractal)module).NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else { ((FastRidgedMultifractal)module).NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        ((FastRidgedMultifractal)module).Seed = Convert.ToInt32(TeBNoiseSeed.Text);
                        ((FastRidgedMultifractal)module).OctaveCount = Convert.ToInt32(TeBOctav.Text);
                        ((FastRidgedMultifractal)module).Lacunarity = Convert.ToDouble(TeBLacun.Text);
                        // ((RidgedMultifractal)module).Persistence = Convert.ToDouble(TeBPers.Text);
                        FileHandler.SaveImage(sd, file, $"_fstRM_{TeBFreq.Text}f_{qua}q_{TeBNoiseSeed.Text}sd_{TeBOctav.Text}o_{TeBLacun.Text}l_{TeBPers.Text}p_{TeBManyNoiseTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBManyNoiseTr.Text)));

                    }
                    if (CBVoronoi.Checked && TeBVSeed.BackColor == System.Drawing.Color.LightGreen)
                    {
                        module = new Voronoi();
                        ((Voronoi)module).Seed = Convert.ToInt32(TeBVSeed.Text);
                        ((Voronoi)module).Displacement = Convert.ToDouble(TeBVFreq.Text);
                        ((Voronoi)module).DistanceEnabled = CBVDist.Checked;
                        ((Voronoi)module).Frequency = Convert.ToDouble(TeBVFreq.Text);
                        FileHandler.SaveImage(sd, file, $"_vrn_{TeBVDispl.Text}dsp_{TeBVFreq.Text}frq_{TeBVSeed.Text}sd_{CBVDist.Checked}dst", OverlayImages(new Bitmap(file), ManyNoise(module, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBVTr.Text)));

                    }

                    if (CBFastCombo.Checked && TeBCSeed.BackColor == System.Drawing.Color.LightGreen)
                    {

                        FastBillow nb = new FastBillow();
                        nb.Frequency = Convert.ToDouble(TeBCFreq.Text);
                        if (CBCQLw.Checked) { nb.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { nb.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { nb.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { nb.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        nb.Seed = Convert.ToInt32(TeBCSeed.Text);
                        nb.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        nb.Lacunarity = Convert.ToDouble(TeBCLac.Text);
                        nb.Persistence = Convert.ToDouble(TeBCPers.Text);

                        ScaleBiasOutput nsb = new ScaleBiasOutput(nb);
                        nsb.Bias = Convert.ToDouble(TeBCBias.Text);
                        nsb.Scale = Convert.ToDouble(TeBCScl.Text);

                        FastRidgedMultifractal nr = new FastRidgedMultifractal();
                        nr.Frequency = Convert.ToDouble(TeBCFreq.Text) / 2.0;
                        if (CBCQLw.Checked) { nr.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { nr.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { nr.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { nr.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        nr.Seed = Convert.ToInt32(TeBCSeed.Text);
                        nr.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        nr.Lacunarity = Convert.ToDouble(TeBCLac.Text);

                        FastNoise np = new FastNoise();
                        np.Frequency = Convert.ToDouble(TeBCFreq.Text) / 10.0;
                        if (CBCQLw.Checked) { np.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { np.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { np.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { np.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        np.Seed = Convert.ToInt32(TeBCSeed.Text);
                        np.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        np.Lacunarity = Convert.ToDouble(TeBCLac.Text);
                        np.Persistence = Convert.ToDouble(TeBCPers.Text);

                        Select ns = new Select(np, nr, nsb);
                        ns.SetBounds(0, 1000);
                        ns.EdgeFalloff = Convert.ToDouble(TeBCEdge.Text);

                        FileHandler.SaveImage(sd, file, $"_fstcmb_{TeBCFreq.Text}fr_{qua}qua_{TeBCSeed.Text}sd_{TeBCOctav.Text}octv_{TeBCLac.Text}lac_{TeBCPers.Text}pers_{TeBCBias.Text}bias_{TeBCScl.Text}scl_{TeBCTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(ns, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBCTr.Text)));
                    }

                    if (CBSlowCombo.Checked && TeBCSeed.BackColor == System.Drawing.Color.LightGreen)
                    {

                        Billow nb = new Billow();
                        nb.Frequency = Convert.ToDouble(TeBCFreq.Text);
                        if (CBCQLw.Checked) { nb.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { nb.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { nb.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { nb.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        nb.Seed = Convert.ToInt32(TeBCSeed.Text);
                        nb.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        nb.Lacunarity = Convert.ToDouble(TeBCLac.Text);
                        nb.Persistence = Convert.ToDouble(TeBCPers.Text);

                        ScaleBiasOutput nsb = new ScaleBiasOutput(nb);
                        nsb.Bias = Convert.ToDouble(TeBCBias.Text);
                        nsb.Scale = Convert.ToDouble(TeBCScl.Text);

                        RidgedMultifractal nr = new RidgedMultifractal();
                        nr.Frequency = Convert.ToDouble(TeBCFreq.Text) / 2.0;
                        if (CBCQLw.Checked) { nr.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { nr.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { nr.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { nr.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        nr.Seed = Convert.ToInt32(TeBCSeed.Text);
                        nr.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        nr.Lacunarity = Convert.ToDouble(TeBCLac.Text);

                        Perlin np = new Perlin();
                        np.Frequency = Convert.ToDouble(TeBCFreq.Text) / 10.0;
                        if (CBCQLw.Checked) { np.NoiseQuality = NoiseQuality.Low; qua = "lw"; }
                        else if (CBCQHgh.Checked) { np.NoiseQuality = NoiseQuality.High; qua = "hgh"; }
                        else if (CBCQStan.Checked) { np.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        else { np.NoiseQuality = NoiseQuality.Standard; qua = "stn"; }
                        np.Seed = Convert.ToInt32(TeBCSeed.Text);
                        np.OctaveCount = Convert.ToInt32(TeBCOctav.Text);
                        np.Lacunarity = Convert.ToDouble(TeBCLac.Text);
                        np.Persistence = Convert.ToDouble(TeBCPers.Text);

                        Select ns = new Select(np, nr, nsb);
                        ns.SetBounds(0, 1000);
                        ns.EdgeFalloff = Convert.ToDouble(TeBCEdge.Text);

                        FileHandler.SaveImage(sd, file, $"_slwcmb_{TeBCFreq.Text}fr_{qua}qua_{TeBCSeed.Text}sd_{TeBCOctav.Text}octv_{TeBCLac.Text}lac_{TeBCPers.Text}pers_{TeBCBias.Text}bias_{TeBCScl.Text}scl_{TeBCTr.Text}tr", OverlayImages(new Bitmap(file), ManyNoise(ns, new Bitmap(file).Width, new Bitmap(file).Height), Convert.ToSingle(TeBCTr.Text)));
                    }
                }

            }
        }
        public Bitmap ManyNoise(IModule module, int w, int h)
        {

            Bitmap bitmap = new Bitmap(w, h);
            System.Drawing.Color[,] colors = new System.Drawing.Color[w, h];
            LibNoise.Models.Sphere sphere = new LibNoise.Models.Sphere(module);

            for (int x = 0; x < w - 1; x++)
                for (int y = 0; y < h - 1; y++)
                {
                    double value;

                    value = (module.GetValue(x, y, 10) + 1) / 2.0;

                    if (value < 0) value = 0;
                    if (value > 1.0) value = 1.0;
                    byte intensity = (byte)(value * 255.0);
                    colors[x, y] = System.Drawing.Color.FromArgb(255, intensity, intensity, intensity);

                }


            for (int x = 0; x < w - 1; x++)
                for (int y = 0; y < h - 1; y++)
                    bitmap.SetPixel(x, y, colors[x, y]);

            return bitmap;
        }
        private void CBNoise_Click(object sender, EventArgs e)
        {
            TeBNoiseAmount.Text = Convert.ToString((float)TrBNoiseAmount.Value / 100 * (100 / TrBNoiseAmount.Maximum));
            TeBNoiseIntensity.Text = TrBNoiseIntensity.Value.ToString();

        }

        private void CBBlur_Click(object sender, EventArgs e)
        {
            TeBBlur.Text = TrBBlur.Value.ToString();
        }

        private void PerlinNCB_Click(object sender, EventArgs e)
        {
            TeBPerlinNoiseScale.Text = Convert.ToString((float)TrBPerlinNoiseScale.Value / 100 * (100 / TrBPerlinNoiseScale.Maximum));
            TeBPerlinNoiseIntensity.Text = Convert.ToString((float)TrBPerlinNoiseIntensity.Value / 100 * (100 / TrBPerlinNoiseIntensity.Maximum));
        }

        private void CBFractalBrownNoise_Click(object sender, EventArgs e)
        {
            TeBFractalBrownNoiseScale.Text = Convert.ToString((float)TrBFractalBrownNoiseScale.Value);
            TeBFractalBrownNoiseIntensity.Text = Convert.ToString((float)TrBFractalBrownNoiseIntensity.Value / 100 * (100 / TrBFractalBrownNoiseIntensity.Maximum));
        }

        private void CBMosaicNoise_Click(object sender, EventArgs e)
        {
            TeBMosaicNoiseCells.Text = TrBMosaicNoiseCells.Value.ToString();
            TeBMosaicNoiseIntensity.Text = Convert.ToString((float)TrBMosaicNoiseIntensity.Value / 100 * (100 / TrBMosaicNoiseIntensity.Maximum));
        }

        private void CBReduceColor_Click(object sender, EventArgs e)
        {
            TeBReduceColorIntensity.Text = Convert.ToString((float)TrBReduceColorIntensity.Value / 100 * (100 / TrBReduceColorIntensity.Maximum));
        }

        private void CBRandomNoise_Click(object sender, EventArgs e)
        {
            TeBRandomNoiseIntensity.Text = Convert.ToString((float)TrBRandomNoiseIntensity.Value / 100 * (100 / TrBRandomNoiseIntensity.Maximum));
        }

        private void TeBResizeWidth_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TeBResizeWidth.Text)) { TeBResizeWidth.BackColor = System.Drawing.Color.White; }
            else
            {
                try { if (Convert.ToInt32(TeBResizeWidth.Text) <= 0) TeBResizeWidth.BackColor = System.Drawing.Color.DarkRed; else TeBResizeWidth.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeWidth.BackColor = System.Drawing.Color.DarkRed; }
            }
            if (string.IsNullOrEmpty(TeBResizeRandomWidth.Text)) TeBResizeRandomWidth.BackColor = System.Drawing.Color.White;
            else try { if (Convert.ToInt32(TeBResizeRandomWidth.Text) <= 0 || Convert.ToInt32(TeBResizeRandomWidth.Text) >= Convert.ToInt32(TeBResizeWidth.Text)) TeBResizeRandomWidth.BackColor = System.Drawing.Color.DarkRed; else TeBResizeRandomWidth.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeRandomWidth.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TeBResizeHeight_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TeBResizeHeight.Text)) { TeBResizeHeight.BackColor = System.Drawing.Color.White; }
            else
            {

                try { if (Convert.ToInt32(TeBResizeHeight.Text) <= 0) TeBResizeHeight.BackColor = System.Drawing.Color.DarkRed; else TeBResizeHeight.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeHeight.BackColor = System.Drawing.Color.DarkRed; }
            }
            if (string.IsNullOrEmpty(TeBResizeRandomHeight.Text)) TeBResizeRandomHeight.BackColor = System.Drawing.Color.White;
            else try { if (Convert.ToInt32(TeBResizeRandomHeight.Text) <= 0 || Convert.ToInt32(TeBResizeRandomHeight.Text) >= Convert.ToInt32(TeBResizeHeight.Text)) TeBResizeRandomHeight.BackColor = System.Drawing.Color.DarkRed; else TeBResizeRandomHeight.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeRandomHeight.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TeBResizeRandomWidth_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBResizeRandomWidth.Text)) TeBResizeRandomWidth.BackColor = System.Drawing.Color.White;
            else try { if (Convert.ToInt32(TeBResizeRandomWidth.Text) <= 0 || Convert.ToInt32(TeBResizeRandomWidth.Text) >= Convert.ToInt32(TeBResizeWidth.Text)) TeBResizeRandomWidth.BackColor = System.Drawing.Color.DarkRed; else TeBResizeRandomWidth.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeRandomWidth.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TeBResizeRandomHeight_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBResizeRandomHeight.Text)) TeBResizeRandomHeight.BackColor = System.Drawing.Color.White;
            else try { if (Convert.ToInt32(TeBResizeRandomHeight.Text) <= 0 || Convert.ToInt32(TeBResizeRandomHeight.Text) >= Convert.ToInt32(TeBResizeHeight.Text)) TeBResizeRandomHeight.BackColor = System.Drawing.Color.DarkRed; else TeBResizeRandomHeight.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBResizeRandomHeight.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void BuChooseColor_Click(object sender, EventArgs e)
        {
            TrBTolerance_ValueChanged(sender, e);
            if (codi.ShowDialog() == DialogResult.OK)
            {
                BuChooseColor.BackColor = codi.Color; BuChooseColor.ForeColor = GetOppositeColor(codi.Color);


            }

        }
        private System.Drawing.Color GetOppositeColor(System.Drawing.Color color)
        {
            // Инвертируем значения RGB
            int r = 255 - color.R;
            int g = 255 - color.G;
            int b = 255 - color.B;

            // Возвращаем новый цвет
            return System.Drawing.Color.FromArgb(r, g, b);
        }
        private bool IsSimilarColor(System.Drawing.Color color1, System.Drawing.Color color2, int tolerance)
        {
            return System.Math.Abs(color1.R - color2.R) <= tolerance ||
                   System.Math.Abs(color1.G - color2.G) <= tolerance ||
                   System.Math.Abs(color1.B - color2.B) <= tolerance;
        }

        static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);

            using (Graphics resizeGraphics = Graphics.FromImage(result))
            {
                resizeGraphics.SmoothingMode = SmoothingMode.HighQuality;
                resizeGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                resizeGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                resizeGraphics.DrawImage(image, 0, 0, width, height);
            }

            return result;
        }

        private void BuScenario2_Click(object sender, EventArgs e)
        {
            //string[] fronti = FileHandler.GetPngFiles();
            if (TeBBackDir.BackColor != System.Drawing.Color.LightGreen && TeBFrontDir.BackColor != System.Drawing.Color.LightGreen)
                MessageBox.Show("Check directories, they'REN'T correct");
            else
            {

                string[] fis;
                string[] bis;
                try
                {
                    // MessageBox.Show("1");
                    fis = FileHandler.GetPngFiles(TeBFrontDir.Text);
                    //  MessageBox.Show("2");
                    bis = FileHandler.GetPngFiles(TeBBackDir.Text);
                    //     MessageBox.Show("3");
                    foreach (string fi in fis)
                    {
                        foreach (string bi in bis)
                        {
                            //MessageBox.Show("4");
                            Bitmap fim = new Bitmap(fi);
                            // MessageBox.Show("5");
                            Bitmap bim = new Bitmap(bi);
                            //MessageBox.Show("6");

                            bim = ResizeImage(bim, fim.Width, fim.Height);
                            //MessageBox.Show("7");
                            Bitmap mim = new Bitmap(fim.Width, fim.Height);
                            // MessageBox.Show("8");

                            for (int y = 0; y < fim.Height; y++)
                            {
                                for (int x = 0; x < fim.Width; x++)
                                {
                                    // MessageBox.Show("9");
                                    System.Drawing.Color fp = fim.GetPixel(x, y);
                                    // MessageBox.Show("10");
                                    if (IsSimilarColor(fp, BuChooseColor.BackColor, TrBTolerance.Value))
                                    {
                                        mim.SetPixel(x, y, bim.GetPixel(x, y));
                                    }
                                    else
                                    {
                                        mim.SetPixel(x, y, fp);
                                    }
                                }
                            }



                            //if (TeBSaveDir.BackColor != System.Drawing.Color.White || TeBSaveDir.BackColor != System.Drawing.Color.DarkRed) 
                            // FileHandler.SaveImage(TeBSaveDir.Text ,Path.GetFileNameWithoutExtension(fi)+Path.GetFileName(bi) , $"", mim);  
                            //   else
                            FileHandler.SaveImage(TeBFrontDir.Text, Path.GetFileNameWithoutExtension(fi) + Path.GetFileName(bi), $"_chrmk", mim);
                        }
                    }
                }
                catch { MessageBox.Show("Check directories, they'REN'T correct or something else gone wrong "); }

            }

        }

        private void TeBBackDir_TextChanged(object sender, EventArgs e)
        {
            if (TeBFrontDir.Text == TeBBackDir.Text && !string.IsNullOrEmpty(TeBFrontDir.Text)) { TeBFrontDir.BackColor = System.Drawing.Color.DarkRed; TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
            else

            if (string.IsNullOrEmpty(TeBFrontDir.Text))
            {
                TeBFrontDir.BackColor = System.Drawing.Color.White; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }
            else if (!Directory.Exists(TeBFrontDir.Text))
            {
                TeBFrontDir.BackColor = System.Drawing.Color.DarkRed; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }
            else
            {
                TeBFrontDir.BackColor = System.Drawing.Color.LightGreen; if (string.IsNullOrEmpty(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.White; }
                else if (!Directory.Exists(TeBBackDir.Text)) { TeBBackDir.BackColor = System.Drawing.Color.DarkRed; }
                else { TeBBackDir.BackColor = System.Drawing.Color.LightGreen; }
            }






            try
            {
                if (TeBBackDir.Text[TeBBackDir.Text.Length - 1] == '\\') TeBBackDir.BackColor = System.Drawing.Color.DarkRed;
                if (TeBFrontDir.Text[TeBFrontDir.Text.Length - 1] == '\\') TeBFrontDir.BackColor = System.Drawing.Color.DarkRed;
            }
            catch { }
        }

        private void TrBTolerance_ValueChanged(object sender, EventArgs e)
        {
            TeBChromaTolerance.Text = Convert.ToString(TrBTolerance.Value);
        }



        private void TeBSimpSeed_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBSimpSeed.Text) || TeBSimpSeed.Text == "-")
            { TeBSimpSeed.BackColor = System.Drawing.Color.White; }
            else try { Convert.ToInt32(TeBSimpSeed.Text); TeBSimpSeed.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBSimpSeed.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TrBSimpScale_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpScale.Text = ((float)TrBSimpScale.Value / TrBSimpScale.Maximum).ToString();
        }

        private void TrBSimpGrid_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpGrid.Text = TrBSimpGrid.Value.ToString();
        }

        public Bitmap SimplexNoiser(int seed, int grid, float scale, int h, int w, float r, float g, float b)
        {
            Bitmap simage = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            System.Drawing.Rectangle flagRect = new System.Drawing.Rectangle(0, 0, w, h);
            System.Drawing.Imaging.BitmapData flagData = simage.LockBits(flagRect, System.Drawing.Imaging.ImageLockMode.ReadWrite, simage.PixelFormat);
            int imageByteSize = flagData.Stride * flagData.Height;
            byte[] destinationData = new byte[imageByteSize];
            int bitsPerPixelElement = 32 / 8;
            float[,] values = Noise.Calc2D(w, h, scale);

            for (int x = 0; x < w; x += grid)
            {
                for (int y = 0; y < h; y += grid)
                {
                    for (int i = 0; i < grid; i++)
                    {
                        if ((x + i) >= w) break;
                        for (int j = 0; j < Height; y += grid)
                        {
                            if ((y + 1) >= h) break;
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement + 2] = (byte)(values[x, y] * r); // R
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement + 1] = (byte)(values[x, y] * g); // G
                            destinationData[(y + j) * flagData.Stride + (x + i) * bitsPerPixelElement] = (byte)(values[x, y] * b); // B
                        }

                    }
                    //Color col = Color.FromArgb((int)(cval*0.6f), (int)(cval*0.6f), cval);
                    //SolidBrush brush = new SolidBrush(col);

                    //Rectangle rect = new Rectangle(x, y, gridSize, gridSize);
                    //flagGraphics.FillRectangle(brush, rect);
                }

            }
            System.Runtime.InteropServices.Marshal.Copy(destinationData, 0, flagData.Scan0, destinationData.Length);
            simage.UnlockBits(flagData);

            return simage;


        }

        public Bitmap OverlayImages(Bitmap bi, Bitmap fi, float tr)
        {
            Bitmap ri = new Bitmap(bi);

            using (Graphics gr = Graphics.FromImage(ri))
            {
                System.Drawing.Imaging.ColorMatrix ma = new System.Drawing.Imaging.ColorMatrix();
                ma.Matrix33 = tr;
                ImageAttributes att = new ImageAttributes();
                att.SetColorMatrix(ma);

                gr.DrawImage(
                    fi,
                    new System.Drawing.Rectangle(0, 0, fi.Width, fi.Height),
                    0, 0, fi.Width, fi.Height,
                    GraphicsUnit.Pixel,
                    att
                    );
            }
            return ri;
        }
        private void TrBSimpR_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpR.Text = Convert.ToString((float)TrBSimpR.Value / TrBSimpR.Maximum);
        }

        private void TrBSimpG_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpG.Text = ((float)TrBSimpG.Value / TrBSimpG.Maximum).ToString();
        }

        private void TrBSimpB_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpB.Text = ((float)TrBSimpB.Value / TrBSimpB.Maximum).ToString();
        }

        private void TrBSimpTr_ValueChanged(object sender, EventArgs e)
        {
            TeBSimpTr.Text = ((float)TrBSimpTr.Value / TrBSimpTr.Maximum).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://github.com/WardBenjamin/SimplexNoise?tab=readme-ov-file
        }

        private void TrBOctav_ValueChanged(object sender, EventArgs e)
        {
            TeBOctav.Text = TrBOctav.Value.ToString();
        }

        private void TrBFreq_ValueChanged(object sender, EventArgs e)
        {
            TeBFreq.Text = Convert.ToString(Convert.ToDouble(TrBFreq.Value) / 100);
        }

        private void TrBLacun_ValueChanged(object sender, EventArgs e)
        {
            TeBLacun.Text = (Convert.ToDouble(TrBLacun.Value) / 10).ToString();
        }

        private void TrBPers_ValueChanged(object sender, EventArgs e)
        {
            TeBPers.Text = Convert.ToString(Convert.ToDouble(TrBPers.Value) / 10);
        }

        private void TeBNoiseSeed_TextChanged(object sender, EventArgs e)
        {
            if (TeBNoiseSeed.Text == "-" || String.IsNullOrEmpty(TeBNoiseSeed.Text)) TeBNoiseSeed.BackColor = System.Drawing.Color.White;
            else try { Convert.ToInt32(TeBNoiseSeed.Text); TeBNoiseSeed.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBNoiseSeed.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void CBQLow_Click(object sender, EventArgs e)
        {
            CBQLow.Checked = true;
            CBQStan.Checked = false;
            CBQHigh.Checked = false;
        }

        private void CBQStan_Click(object sender, EventArgs e)
        {
            CBQLow.Checked = false;
            CBQStan.Checked = true;
            CBQHigh.Checked = false;
        }

        private void CBQHigh_Click(object sender, EventArgs e)
        {
            CBQLow.Checked = false;
            CBQStan.Checked = false;
            CBQHigh.Checked = true;
        }

        private void TrBManyNoiseTr_ValueChanged(object sender, EventArgs e)
        {
            TeBManyNoiseTr.Text = Convert.ToString((float)TrBManyNoiseTr.Value / TrBManyNoiseTr.Maximum);
        }

        private void TrBCOctav_ValueChanged(object sender, EventArgs e)
        {
            TeBCOctav.Text = TrBCOctav.Value.ToString();
        }

        private void CBCQLw_Click(object sender, EventArgs e)
        {
            CBCQLw.Checked = true;
            CBCQStan.Checked = false;
            CBCQHgh.Checked = false;
        }

        private void CBCQStan_Click(object sender, EventArgs e)
        {
            CBCQLw.Checked = false;
            CBCQStan.Checked = true;
            CBCQHgh.Checked = false;
        }

        private void CBCQHgh_Click(object sender, EventArgs e)
        {
            CBCQLw.Checked = false;
            CBCQStan.Checked = false;
            CBCQHgh.Checked = true;
        }

        private void TrBCFreq_ValueChanged(object sender, EventArgs e)
        {
            TeBCFreq.Text = (Convert.ToDouble(TrBCFreq.Value) / 100).ToString();
        }

        private void TrBCLac_ValueChanged(object sender, EventArgs e)
        {
            TeBCLac.Text = (Convert.ToDouble(TrBCLac.Value) / 10).ToString();
        }

        private void TrBCPer_ValueChanged(object sender, EventArgs e)
        {
            TeBCPers.Text = (Convert.ToDouble(TrBCPer.Value) / 10).ToString();
        }

        private void TrBCTr_ValueChanged(object sender, EventArgs e)
        {
            TeBCTr.Text = ((float)TrBCTr.Value / 100).ToString();
        }

        private void TeBCSeed_TextChanged(object sender, EventArgs e)
        {
            if (TeBCSeed.Text == "-" || string.IsNullOrEmpty(TeBCSeed.Text)) TeBCSeed.BackColor = System.Drawing.Color.White;
            else try { Convert.ToInt32(TeBCSeed.Text); TeBCSeed.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBCSeed.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TrBCScl_ValueChanged(object sender, EventArgs e)
        {
            TeBCScl.Text = ((Convert.ToDouble(TrBCScl.Value)) / 10).ToString();
        }

        private void TrBCBias_ValueChanged(object sender, EventArgs e)
        {
            TeBCBias.Text = (Convert.ToDouble(TrBCBias.Value) / 100).ToString();
        }

        private void TrBCEdge_ValueChanged(object sender, EventArgs e)
        {
            TeBCEdge.Text = (Convert.ToDouble(TrBCEdge.Value) / 100).ToString();
        }

        private void TrBVFreq_ValueChanged(object sender, EventArgs e)
        {
            TeBVFreq.Text = (Convert.ToDouble(TrBVFreq.Value) / 100).ToString();
        }

        private void TrBVDispl_ValueChanged(object sender, EventArgs e)
        {
            TeBVDispl.Text = (Convert.ToDouble(TrBVDispl.Value) / 100).ToString();
        }

        private void TeBVSeed_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeBVSeed.Text) || TeBVSeed.Text == "-") TeBVSeed.BackColor = System.Drawing.Color.White;
            else try { Convert.ToInt32(TeBVSeed.Text); TeBVSeed.BackColor = System.Drawing.Color.LightGreen; }
                catch { TeBVSeed.BackColor = System.Drawing.Color.DarkRed; }
        }

        private void TrBVTr_ValueChanged(object sender, EventArgs e)
        {
            TeBVTr.Text = (Convert.ToSingle(TrBVTr.Value) / 100).ToString();
        }

        private void CBSimpNoise_Click(object sender, EventArgs e)
        {
            TrBSimpScale_ValueChanged(sender, e);
            TrBSimpGrid_ValueChanged(sender, e);
            TrBSimpR_ValueChanged(sender, e);
            TrBSimpG_ValueChanged(sender, e);
            TrBSimpB_ValueChanged(sender, e);
            TrBSimpTr_ValueChanged(sender, e);
        }

        private void CBFastPerlin_Click(object sender, EventArgs e)
        {
            TrBOctav_ValueChanged(sender, e);
            TrBFreq_ValueChanged(sender, e);
            TrBLacun_ValueChanged(sender, e);
            TrBPers_ValueChanged(sender, e);
            TrBManyNoiseTr_ValueChanged(sender, e);
        }

        private void CBVoronoi_Click(object sender, EventArgs e)
        {
            TrBVFreq_ValueChanged(sender, e);
            TrBVDispl_ValueChanged(sender, e);
            TrBVTr_ValueChanged(sender, e);

        }

        private void CBFastCombo_Click(object sender, EventArgs e)
        {
            TrBCOctav_ValueChanged(sender, e);
            TrBCFreq_ValueChanged(sender, e);
            TrBCLac_ValueChanged(sender, e);
            TrBCPer_ValueChanged(sender, e);
            TrBCTr_ValueChanged(sender, e);
            TrBCBias_ValueChanged(sender, e);
            TrBCScl_ValueChanged(sender,e);
            TrBCEdge_ValueChanged(sender, e);
        }
    }

}

