﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using grapher.Models.Calculations;
using grapher.Models.Options;
using grapher.Models.Serialized;
using grapher.Models;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace grapher
{
    public partial class RawAcceleration : Form
    {

        #region Constructor


        public RawAcceleration()
        {
            InitializeComponent();

            Version driverVersion = VersionHelper.ValidOrThrow();

            ToolStripMenuItem HelpMenuItem = new ToolStripMenuItem("&Help");

            HelpMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                    new ToolStripMenuItem("&About", null, (s, e) => {
                        using (var form = new AboutBox(driverVersion))
                        {
                            form.ShowDialog();
                        }
                    })
            });

            menuStrip1.Items.AddRange(new ToolStripItem[] { HelpMenuItem });

            AccelGUI = AccelGUIFactory.Construct(
                this,
                AccelerationChart,
                AccelerationChartY,
                VelocityChart,
                VelocityChartY,
                GainChart,
                GainChartY,
                accelTypeDropX,
                accelTypeDropY,
                XLutApplyDropdown,
                YLutApplyDropdown,
                CapTypeDropdownXClassic,
                CapTypeDropdownYClassic,
                CapTypeDropdownXPower,
                CapTypeDropdownYPower,
                writeButton,
                toggleButton,
                showVelocityGainToolStripMenuItem,
                showLastMouseMoveToolStripMenuItem,
                streamingModeToolStripMenuItem,
                AutoWriteMenuItem,
                DeviceMenuItem,
                ScaleMenuItem,
                DPITextBox,
                PollRateTextBox,
                DirectionalityPanel,
                sensitivityBoxX,
                VertHorzRatioBox,
                rotationBox,
                inCapBoxXClassic,
                inCapBoxYClassic,
                outCapBoxXClassic,
                outCapBoxYClassic,
                inCapBoxXPower,
                inCapBoxYPower,
                outCapBoxXPower,
                outCapBoxYPower,
                inputJumpBoxX,
                inputJumpBoxY,
                outputJumpBoxX,
                outputJumpBoxY,
                inputOffsetBoxX,
                inputOffsetBoxY,
                outputOffsetBoxX,
                outputOffsetBoxY,
                accelerationBoxX,
                accelerationBoxY,
                decayRateBoxX,
                decayRateBoxY,
                growthRateBoxX,
                growthRateBoxY,
                smoothBoxX,
                smoothBoxY,
                scaleBoxX,
                scaleBoxY,
                limitBoxX,
                limitBoxY,
                powerBoxX,
                powerBoxY,
                expBoxX,
                expBoxY,
                midpointBoxX,
                midpointBoxY,
                DomainBoxX,
                DomainBoxY,
                RangeBoxX,
                RangeBoxY,
                LpNormBox,
                sensXYLock,
                ByComponentXYLock,
                FakeBox,
                WholeCheckBox,
                ByComponentCheckBox,
                gainSwitchX,
                gainSwitchY,
                XLutActiveValuesBox,
                YLutActiveValuesBox,
                XLutPointsBox,
                YLutPointsBox,
                LockXYLabel,
                sensitivityLabel,
                VertHorzRatioLabel,
                rotationLabel,
                inCapLabelXClassic,
                inCapLabelYClassic,
                outCapLabelXClassic,
                outCapLabelYClassic,
                CapTypeLabelXClassic,
                CapTypeLabelYClassic,
                inCapLabelXPower,
                inCapLabelYPower,
                outCapLabelXPower,
                outCapLabelYPower,
                CapTypeLabelXPower,
                CapTypeLabelYPower,
                inputJumpLabelX,
                inputJumpLabelY,
                outputJumpLabelX,
                outputJumpLabelY,
                inputOffsetLabelX,
                inputOffsetLabelY,
                outputOffsetLabelX,
                outputOffsetLabelY,
                constantOneLabelX,
                constantOneLabelY,
                decayRateLabelX,
                decayRateLabelY,
                growthRateLabelX,
                growthRateLabelY,
                smoothLabelX,
                smoothLabelY,
                scaleLabelX,
                scaleLabelY,
                limitLabelX,
                limitLabelY,
                powerLabelX,
                powerLabelY,
                expLabelX,
                expLabelY,
                LUTTextLabelX,
                LUTTextLabelY,
                constantThreeLabelX,
                constantThreeLabelY,
                ActiveValueTitle,
                ActiveValueTitleY,
                SensitivityMultiplierActiveLabel,
                VertHorzRatioActiveLabel,
                RotationActiveLabel,
                InCapActiveXLabelClassic,
                InCapActiveYLabelClassic,
                OutCapActiveXLabelClassic,
                OutCapActiveYLabelClassic,
                CapTypeActiveXLabelClassic,
                CapTypeActiveYLabelClassic,
                InCapActiveXLabelPower,
                InCapActiveYLabelPower,
                OutCapActiveXLabelPower,
                OutCapActiveYLabelPower,
                CapTypeActiveXLabelPower,
                CapTypeActiveYLabelPower,
                InputJumpActiveXLabel,
                InputJumpActiveYLabel,
                OutputJumpActiveXLabel,
                OutputJumpActiveYLabel,
                InputOffsetActiveXLabel,
                InputOffsetActiveYLabel,
                OutputOffsetActiveXLabel,
                OutputOffsetActiveYLabel,
                AccelerationActiveLabelX,
                AccelerationActiveLabelY,
                DecayRateActiveXLabel,
                DecayRateActiveYLabel,
                GrowthRateActiveXLabel,
                GrowthRateActiveYLabel,
                SmoothActiveXLabel,
                SmoothActiveYLabel,
                ScaleActiveXLabel,
                ScaleActiveYLabel,
                LimitActiveXLabel,
                LimitActiveYLabel,
                PowerClassicActiveXLabel,
                PowerClassicActiveYLabel,
                ExpActiveXLabel,
                ExpActiveYLabel,
                MidpointActiveXLabel,
                MidpointActiveYLabel,
                AccelTypeActiveLabelX,
                AccelTypeActiveLabelY,
                gainSwitchActiveLabelX,
                gainSwitchActiveLabelY,
                OptionSetXTitle,
                OptionSetYTitle,
                MouseLabel,
                DirectionalityLabel,
                DirectionalityX,
                DirectionalityY,
                DirectionalityActiveValueTitle,
                LPNormLabel,
                LpNormActiveValue,
                DirectionalDomainLabel,
                DomainActiveValueX,
                DomainActiveValueY,
                DirectionalityRangeLabel,
                RangeActiveValueX,
                RangeActiveValueY,
                XLutApplyLabel,
                YLutApplyLabel,
                LutApplyActiveXLabel,
                LutApplyActiveYLabel);

            ResizeAndCenter();
        }

        #endregion Constructor

        #region Properties

        public AccelGUI AccelGUI { get; }

        #endregion Properties

        #region Methods

        protected override void WndProc(ref Message m)
        {
            if (!(AccelGUI is null))
            {
                if (m.Msg == 0x00ff) // WM_INPUT
                {
                    AccelGUI.MouseWatcher.ReadMouseMove(m);
                }
                else if (m.Msg == 0x00fe) // WM_INPUT_DEVICE_CHANGE
                {
                    AccelGUI.Settings.OnDeviceChangeMessage();
                }
            }

            base.WndProc(ref m);
        }

        public void ResetAutoScroll()
        {
            chartsPanel.AutoScrollPosition = Constants.Origin;
        }

        public void ResizeAndCenter()
        {
            ResetAutoScroll();

            var workingArea = Screen.FromControl(this).WorkingArea;
            var chartsPreferredSize = chartsPanel.GetPreferredSize(Constants.MaxSize);

            Size = new Size
            {
                Width = optionsPanel.Size.Width + chartsPreferredSize.Width + 13,
                Height = chartsPreferredSize.Height + 36
            };

            Location = Properties.Settings.Default.WindowLocation;

            if (Properties.Settings.Default.WindowMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void RawAcceleration_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Properties.Settings.Default.WindowMaximized = true;
                    Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
                    break;
                case FormWindowState.Minimized:
                    Properties.Settings.Default.WindowMaximized = false;
                    Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
                    break;
                case FormWindowState.Normal:
                    Properties.Settings.Default.WindowMaximized = false;
                    Properties.Settings.Default.WindowLocation = Location;
                    break;
            }

            Properties.Settings.Default.Save();
        }

        #endregion Method

        static void MakeStartupShortcut(bool gui)
        {
            var startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            if (string.IsNullOrEmpty(startupFolder))
            {
                throw new Exception("Startup folder does not exist");
            }

            //Windows Script Host Shell Object
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
            dynamic shell = Activator.CreateInstance(t);

            try
            {
                // Delete any other RA related startup shortcuts
                var candidates = new[] { "rawaccel", "raw accel", "writer" };

                foreach (string path in Directory.EnumerateFiles(startupFolder, "*.lnk")
                    .Where(f => candidates.Any(f.Substring(startupFolder.Length).ToLower().Contains)))
                {
                    var link = shell.CreateShortcut(path);
                    try
                    {
                        string targetPath = link.TargetPath;

                        if (!(targetPath is null) && 
                            (targetPath.EndsWith("rawaccel.exe") ||
                                targetPath.EndsWith("writer.exe") &&
                                    new FileInfo(targetPath).Directory.GetFiles("rawaccel.exe").Any()))
                        {
                            File.Delete(path);
                        }
                    }
                    finally
                    {
                        Marshal.FinalReleaseComObject(link);
                    }
                }

                var name = gui ? "rawaccel" : "writer";

                var lnk = shell.CreateShortcut($@"{startupFolder}\{name}.lnk");

                try
                {
                    if (!gui) lnk.Arguments = Constants.DefaultSettingsFileName;
                    lnk.TargetPath = $@"{Application.StartupPath}\{name}.exe";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }

            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
        }
	}
}
