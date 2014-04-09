/// <reference path="jquery-ui-1.10.4.js" />
/// <reference path="jquery-2.1.0.js" />
/// <reference path="knockout-3.1.0.js" />
/// <reference path="ko-protected-observable.js" />

$(function () {
    $.getJSON("/api/administrator/GetLaptopCategory", function (data) {
        var viewModel = {
            categories: ko.observableArray(ko.toProtectedObservableItemArray(data)),
            laptops: ko.observableArray([]),
            selectedCategory: ko.observable(""),
            categoryToAdd: ko.observable(""),
            selectedLaptop: ko.observable(""),
            laptopToAdd: ko.observable(""),
            ID: ko.observable(""),
            Name: ko.observable(""),
            Description: ko.observable(""),
            Summary: ko.observable(""),
            Memory: ko.observable(""),
            HardDisk: ko.observable(""),
            ScreenSize: ko.observable(""),
            Processor: ko.observable(""),
            OperatingSystem: ko.observable(""),
            Price: ko.observable(""),
            ImageUrl: ko.observable(""),
            editConfiguration: ko.observable(false),

            addCategory: function () {
                this.categories.push(new ko.protectedObservableItem({ Name: this.categoryToAdd() }));
                this.categoryToAdd("");
            },

            selectCategory: function () {
                viewModel.selectedCategory(this);
            },

            selectLaptop: function () {
                viewModel.selectedLaptop(this);
            },

            editConfigurationClick: function () {
                viewModel.editConfiguration(true);
            },


            cancelEditConfiguration: function () {
                viewModel.editConfiguration(false);
            },

            saveEditConfiguration: function () {
                viewModel.editConfiguration(false);
            },
        };

        $(document).on("click", ".tag-delete", function () {
            var categoryToRemove = ko.dataFor(this);
            viewModel.categories.remove(categoryToRemove);
        });

        $(document).on("click", ".tag-edit", function () {
            $("#categoryDialog").dialog({
                dialogClass: "editCategory",
                modal: true,
                clostText: "x",
                buttons: {
                    Save: function () {
                        $(this).dialog("close");
                        viewModel.selectedCategory().commit();
                    },
                    Close: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        ko.computed(function () {
            if (this.selectedCategory() === "") return;

            var category = ko.toJS(this.selectedCategory());
            var url = "/api/administrator/GetLaptopDetails/" + category.Name;
            $.getJSON(url, function (data) {
                viewModel.laptops(ko.toProtectedObservableItemArray(data));
            });
        }, viewModel);

        ko.computed(function () {
            if (this.selectedLaptop() === "") return;

            var laptop = ko.toJS(this.selectedLaptop());
            var url = "/api/administrator/GetLaptopConfiguration/" + laptop.ID;
            $.getJSON(url, function (data) {
                var laptop = ko.toJS(data);

                viewModel.ID(laptop.ID);
                viewModel.Name  (laptop.Name);
                viewModel.Description(laptop.Description);
                viewModel.Summary(laptop.Summary);
                viewModel.Memory(laptop.Memory);
                viewModel.HardDisk(laptop.HardDisk);
                viewModel.ScreenSize(laptop.ScreenSize);
                viewModel.Processor(laptop.Processor);
                viewModel.OperatingSystem(laptop.OperatingSystem);
                viewModel.Price(laptop.Price);
                viewModel.ImageUrl(laptop.ImageUrl);

            });
        }, viewModel);

        ko.applyBindings(viewModel);
    });
});