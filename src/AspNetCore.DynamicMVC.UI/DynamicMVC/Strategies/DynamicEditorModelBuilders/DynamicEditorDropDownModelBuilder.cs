using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicEditorViewModels;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Strategies.DynamicEditorModelBuilders
{
    public class DynamicEditorDropDownModelBuilder : IDynamicEditorModelBuilder
    {
        private readonly ISelectListItemManager _selectListItemManager;

        public DynamicEditorDropDownModelBuilder(ISelectListItemManager selectListItemManager)
        {
            _selectListItemManager = selectListItemManager;
        }

        public string DynamicEditorName()
        {
            return "DynamicEditorDropDown";
        }

        public void Build(DynamicPropertyMetadata dynamicPropertyMetadata, DynamicPropertyEditorViewModel dynamicPropertyViewModel, dynamic item)
        {
            var dynamicForiegnKeyPropertyMetadata = ((DynamicForiegnKeyPropertyMetadata)dynamicPropertyMetadata);
            var type = dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.EntityTypeFunction()();
            var dataTextField = dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.DefaultProperty().PropertyName();
            var dataValueField = dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.KeyProperty().PropertyName();
            var dynamicEditorDropDownViewModel = new DynamicEditorDropDownViewModel(dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.EntityTypeFunction()(), dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.DefaultProperty().PropertyName(), dynamicForiegnKeyPropertyMetadata.ComplexDynamicEntityMetadata.KeyProperty().PropertyName());
            var value = dynamicPropertyMetadata.GetValueFunction()(item);
            
            dynamicEditorDropDownViewModel.SelectListItems = _selectListItemManager.GetSelectListItems(type, dataValueField, dataTextField, value);

            dynamicPropertyViewModel.DynamicEditorDropDownViewModel = dynamicEditorDropDownViewModel;

            dynamicPropertyViewModel.DisplayName = dynamicForiegnKeyPropertyMetadata.ComplexEntityPropertyMetadata.PropertyName();
        }

       
    }
}