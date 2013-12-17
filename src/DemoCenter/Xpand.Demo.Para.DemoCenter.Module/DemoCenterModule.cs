using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using Xpand.Demo.Para.Model.BusinessObjects;

namespace Xpand.Demo.Para.DemoCenter
{
    public class DemoCenterModule : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(
                typeof(SystemModule)
                );
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            return Type.EmptyTypes;
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return new[]
            {
                typeof(LargeBusinessObject),
                typeof(XPViewBusinessObjectProxy),
                typeof(XPViewCalculationProxy),
            };
        }

        protected override void RegisterEditorDescriptors(List<EditorDescriptor> editorDescriptors)
        {

        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
        }
    }
}
