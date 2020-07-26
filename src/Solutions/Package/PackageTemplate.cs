using System;
using System.ComponentModel.Composition;
using Microsoft.Uii.Common.Entities;
using Microsoft.Xrm.Tooling.PackageDeployment.CrmPackageExtentionBase;


namespace Package
{
    /// <summary>
    /// Import package starter frame.
    /// </summary>
    [Export(typeof(ImportExtension))]
    public class PackageTemplate : ImportExtension
    {
        #region Properties

        /// <summary>
        /// Folder Name for the Package data.
        /// WARNING this value directly correlates to the folder name in the Solution Explorer where the ImportConfig.xml and sub content is located.
        /// Changing this name requires that you also change the correlating name in the Solution Explorer
        /// </summary>
        public override string GetImportPackageDataFolderName => "Sample";

        /// <summary>
        /// Description of the package, used in the package selection UI
        /// </summary>
        public override string GetImportPackageDescriptionText => "Sample Dynamics 365 Package";

        /// <summary>
        /// Long name of the Import Package.
        /// </summary>
        public override string GetLongNameOfImport => "A Sample Package to install D365 solutions, data and perform pre and post deployment operations";


        #endregion

        /// <summary>
        /// Name of the Import Package to Use
        /// </summary>
        /// <param name="plural">if true, return plural version</param>
        /// <returns>Name of solution import.</returns>
        public override string GetNameOfImport(bool plural)
        {
            return "Sample";
        }

        /// <summary>
        /// Called When the package is initialized.
        /// </summary>
        public override void InitializeCustomExtension()
        {
        }

        /// <summary>
        /// Called Before Import Completes.
        /// </summary>
        /// <returns>True if stage is before solution import. Otherwise, false.</returns>
        public override bool BeforeImportStage()
        {
            return true;
        }

        /// <summary>
        /// Called for each UII record imported into the system
        /// This is UII Specific and is not generally used by Package Developers
        /// </summary>
        /// <param name="app">App Record</param>
        /// <returns>Application return object.</returns>
        public override ApplicationRecord BeforeApplicationRecordImport(ApplicationRecord app)
        {
            return app;  // do nothing here.
        }

        /// <summary>
        /// Called during a solution upgrade while both solutions are present in the target CRM instance.
        /// This function can be used to provide a means to do data transformation or upgrade while a solution update is occurring.
        /// </summary>
        /// <param name="solutionName">Name of the solution</param>
        /// <param name="oldVersion">version number of the old solution</param>
        /// <param name="newVersion">Version number of the new solution</param>
        /// <param name="oldSolutionId">Solution ID of the old solution</param>
        /// <param name="newSolutionId">Solution ID of the new solution</param>
        public override void RunSolutionUpgradeMigrationStep(string solutionName, string oldVersion, string newVersion, Guid oldSolutionId, Guid newSolutionId)
        {
            base.RunSolutionUpgradeMigrationStep(solutionName, oldVersion, newVersion, oldSolutionId, newSolutionId);
        }

        /// <summary>
        /// Called after Import completes.
        /// </summary>
        /// <returns>True if stage is after primary import. Otherwise, false.</returns>
        public override bool AfterPrimaryImport()
        {
            return true;
        }

        /// <summary>
        /// Override default decision made by PD.
        /// </summary>
        /// <param name="solutionUniqueName">Solution unique name.</param>
        /// <param name="organizationVersion">Organization version.</param>
        /// <param name="packageSolutionVersion">Package solution version.</param>
        /// <param name="inboundSolutionVersion">Inbound solution version.</param>
        /// <param name="deployedSolutionVersion">Deployed solution version.</param>
        /// <param name="systemSelectedImportAction">Import action.</param>
        /// <returns>Import action object.</returns>
        public override UserRequestedImportAction OverrideSolutionImportDecision(string solutionUniqueName, Version organizationVersion, Version packageSolutionVersion, Version inboundSolutionVersion, Version deployedSolutionVersion, ImportAction systemSelectedImportAction)
        {
            // Perform “Update” to the existing solution
            // instead of “Delete And Promote” when a new version
            // of an existing solution is detected.
            if (systemSelectedImportAction == ImportAction.Import)
            {
                return UserRequestedImportAction.ForceUpdate;
            }

            return base.OverrideSolutionImportDecision(solutionUniqueName, organizationVersion, packageSolutionVersion, inboundSolutionVersion, deployedSolutionVersion, systemSelectedImportAction);
        }
    }
}
