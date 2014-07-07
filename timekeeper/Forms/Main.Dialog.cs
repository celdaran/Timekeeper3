using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void Dialog_NewFile()
        {
            string FileName;
            FileCreateOptions CreateOptions;

            if (Options.Behavior_Annoy_UseNewDatabaseWizard) {
                Forms.Wizards.NewDatabase NewWizardDialog = new Forms.Wizards.NewDatabase();
                if (NewWizardDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewWizardDialog.CreateOptions.FileName;
                    CreateOptions = NewWizardDialog.CreateOptions;
                    if (NewWizardDialog.CreateOptions.UseActivities && NewWizardDialog.CreateOptions.UseProjects) {
                        Options.Behavior_TitleBar_Template = "%time - %activity for %project";
                    } else if (NewWizardDialog.CreateOptions.UseActivities) {
                        Options.Behavior_TitleBar_Template = "%time - %activity";
                    } else if (NewWizardDialog.CreateOptions.UseProjects) {
                        Options.Behavior_TitleBar_Template = "%time - %project";
                    }
                } else {
                    return;
                }
            } else {
                if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewFileDialog.FileName;
                    CreateOptions = new FileCreateOptions();
                    CreateOptions.UseProjects = true;
                    CreateOptions.UseActivities = false;
                    CreateOptions.ItemPreset = 0;
                    CreateOptions.LocationName = "Default";
                    CreateOptions.LocationDescription = "Default Location";
                    CreateOptions.LocationTimeZoneId = Timekeeper.CurrentTimeZoneId();
                    Options.Behavior_TitleBar_Template = "%time - %project";
                } else {
                    return;
                }
            }

            Application.DoEvents();

            Cursor.Current = Cursors.WaitCursor;

            Action_CloseFile();
            if (Action_CreateFile(FileName, CreateOptions)) {
                Action_OpenFile(FileName);

                // Override any earlier registry-based options
                // Fixes Ticket #1291 but see also Ticket #1301
                Options.Layout_UseProjects = CreateOptions.UseProjects;
                Options.Layout_UseActivities = CreateOptions.UseActivities;

                Action_UseProjects(Options.Layout_UseProjects);
                Action_UseActivities(Options.Layout_UseActivities);
            } else {
                Common.Warn("An error occurred creating the database");
            }

            Cursor.Current = Cursors.Default;
        }

        //---------------------------------------------------------------------

        private void Dialog_OpenFile()
        {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                Action_OpenFile(OpenFileDialog.FileName);
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_Options()
        {
            // Pass the instantiated options to the dialog box
            Forms.Options DialogBox = new Forms.Options(this.Options, this.MenuMain);

            // If the user clicked 'Save' . . .
            if (DialogBox.ShowDialog(this) == DialogResult.OK)
            {
                // Retrieve any options changes made on the dialog box
                this.Options = DialogBox.Values;

                // And save them back to the persistent store
                this.Options.SaveOptions();

                this.Dialog_ApplyOptions(DialogBox.InterfaceChanged);
            }
            else {
                // JUST FOR NOW
                //Application.Exit();
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_ApplyOptions(bool interfaceChanged)
        {
            StatusBar_SetVisibility();

            if (timerRunning) {
                DeferShortcutAssignment = true;
            } else {
                Action_SetShortcuts();
                Browser_SetShortcuts();
            }

            Action_UseProjects(Options.Layout_UseProjects);
            Action_UseActivities(Options.Layout_UseActivities);
            Action_UseLocations(Options.Layout_UseLocations);
            Action_UseCategories(Options.Layout_UseCategories);
            Action_AdjustControlPanel();

            TrayIcon.Visible = Options.Behavior_Window_ShowInTray;

            Action_SetBrowserOptions();

            MemoEditor.ToolbarVisible(Options.View_Other_MemoEditorToolbar);
            MemoEditor.SwitchMarkdown(Options.Advanced_Other_MarkupLanguage);

            if (interfaceChanged) {
                switch (Options.InterfacePreset) {
                    case 0:
                        Height = 200;
                        Width = 364;
                        break;
                    case 1:
                        Height = 460;
                        Width = 572;
                        break;
                    case 2:
                        Height = 460;
                        Width = 572;
                        break;
                }
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_SaveAsFile()
        {
            if (SaveAsDialog.ShowDialog(this) == DialogResult.OK) {
                Action_SaveAs(SaveAsDialog.FilterIndex);
            }
        }

        //---------------------------------------------------------------------

    }
}
