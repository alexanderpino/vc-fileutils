﻿using EnvDTE;
using FilterSynchronizer.Helpers;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.VCProjectEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilterSynchronizer.Integration.Commands
{
    class SetProjectRootCommand : BaseCommand
    {
        #region Constructors

        public SetProjectRootCommand(FilterSynchronizerPackage package)
            : base(package, new CommandID(GuidList.GuidFilterSynchronizerCommandSet, (int)PkgCmdIDList.CmdIDSetProjectRoot))
        {

        }

        #endregion

        #region BaseCommand Members

        protected override void OnBeforeQueryStatus()
        {
            Visible = SolutionHelper.GetProjectOfSelection(Package).Object is VCProject;
        }

        protected override void OnExecute()
        {
            Project project = SolutionHelper.GetProjectOfSelection(Package);

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Path.GetDirectoryName(project.FullName);
            dlg.ShowNewFolderButton = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        #endregion BaseCommand Members
    }
}
