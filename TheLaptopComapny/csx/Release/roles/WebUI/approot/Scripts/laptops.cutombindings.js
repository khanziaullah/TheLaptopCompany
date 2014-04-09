/// <reference path="knockout-3.1.0.js" />
/// <reference path="jquery-2.1.0.js" />

ko.bindingHandlers.executeOnEnter = {
    init: function (element, valueAccessor, allBindingAccessor, viewModel) {
        var value = valueAccessor();
        $(element).keypress(function (event) {
            var keycode = (event.which ? event.which : event.keycode);
            if (keycode === 13) {
                value.call(viewModel);
                return false;
            }
            return true;
        });
    }
};