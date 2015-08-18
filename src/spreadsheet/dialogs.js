(function(f, define){
    define([ "../kendo.core", "../kendo.binder" ], f);
})(function(){

(function(kendo) {
    var $ = kendo.jQuery;
    var ObservableObject = kendo.data.ObservableObject;

    var registry = {};
    kendo.spreadsheet.dialogs = {
        register: function(name, dialogClass) {
            registry[name] = dialogClass;
        },
        create: function(name, options) {
            var dialogClass = registry[name];

            if (dialogClass) {
                return new dialogClass(options);
            }
        }
    };

    var SpreadsheetDialog = kendo.spreadsheet.SpreadsheetDialog = kendo.Class.extend({
        init: function(options) {
            this.options = $.extend(true, {}, this.options, options);
        },
        dialog: function() {
            if (!this._dialog) {
                this._dialog = $("<div class='k-spreadsheet-window k-action-window' />")
                    .addClass(this.options.className || "")
                    .append(this.options.template)
                    .appendTo(document.body)
                    .kendoWindow({
                        scrollable: false,
                        resizable: false,
                        maximizable: false,
                        modal: true,
                        visible: false,
                        width: 320,
                        title: this.options.title,
                        open: function() {
                            this.center();
                        },
                        deactivate: function() {
                            this._dialog.destroy();
                            this._dialog = null;
                        }.bind(this)
                    })
                    .data("kendoWindow");
            }

            return this._dialog;
        },
        destroy: function() {
            if (this._dialog) {
                this._dialog.destroy();
                this._dialog = null;
            }
        },
        open: function() {
            this.dialog().open();
        },
        apply: function() {
            this.close();
        },
        close: function() {
            this.dialog().close();
        }
    });

    function cultureToFormat(format, currencyInfo) {
        return format
                .replace(/\$/g, currencyInfo.symbol)
                .replace(/n/g, "?");
    }

    var FormatCellsViewModel = kendo.spreadsheet.FormatCellsViewModel = ObservableObject.extend({
        init: function(options) {
            ObservableObject.fn.init.call(this, options);

            this.useCategory(this.category);
        },
        useCategory: function(category) {
            var type = category && category.type || "number";
            this.category = category;
            this.set("formatCurrency", type == "currency");

            if (!this.formatCurrency) {
                this.set("formats", this.allFormats[type + "Formats"]);
            } else {
                this.currency(this.currencies[0]);
            }
        },
        currency: function(currency) {
            if (currency !== undefined) {
                this._currency = currency;

                var currencyInfo = currency.value;

                // TODO: convert culture info to spreadsheet formats
                var positive = currencyInfo.pattern[1];
                var format = cultureToFormat(positive, currencyInfo);

                this.set("formats", [
                    // generate:
                    // $1,000.00    / 1 000,00 лв.  / £1,000.00
                    // USD 1,000.00 / BGN 1 000,00  / GBP 1,000.00
                    // $1,000       / 1 000 лв.     / £1,000
                    // { value: format, name: apply(format, 1000) }
                    { value: format, name: format }
                ]);
                this.set("format", this.formats[0].value);
            }

            return this._currency || this.currencies[0];
        },
        categoryFilter: function(category) {
            if (category !== undefined) {
                this.useCategory(category);
            }

            return this.category;
        },
        preview: function() {
            var format = this.get("format");
            var value = this.value || 0;

            if (format && format.length) {
                // get formatted text from virtual dom node
                value = kendo.spreadsheet.formatting.format(value, format);
                return value.children[0].nodeValue;
            } else {
                return value;
            }
        }
    });

    var FormatCellsDialog = SpreadsheetDialog.extend({
        init: function(options) {
            SpreadsheetDialog.fn.init.call(this, options);
        },
        options: {
            title: "Format number",
            className: "k-spreadsheet-format-cells",
            categories: [
                { type: "number", name: "Number" },
                { type: "currency", name: "Currency" },
                { type: "date", name: "Date" }
            ],
            numberFormats: [
                { value: "?.00%", name: "100.00%" }
            ],
            currencies: $.map(kendo.cultures, function(culture, name) {
                if (name != culture.name) {
                    return;
                }

                var currency = culture.numberFormat.currency;
                var description = kendo.format(
                    "{0} ({1}, {2})",
                    currency.name,
                    currency.abbr,
                    currency.symbol
                );

                return { description: description, value: currency };
            }),
            dateFormats: [
                { value: "m/d", name: "3/14" },
                { value: "m/d/yy", name: "3/14/01" },
                { value: "mm/dd/yy", name: "03/14/01" },
                { value: "d-mmm", name: "14-Mar" },
                { value: "d-mmm-yy", name: "14-Mar-01" },
                { value: "dd-mmm-yy", name: "14-Mar-01" },
                { value: "mmm-yy", name: "Mar-01" },
                { value: "mmmm-yy", name: "March-01" },
                { value: "mmmm dd, yyyy", name: "March 14, 2001" },
                { value: "m/d/yy hh:mm AM/PM", name: "3/14/01 1:30 PM" },
                { value: "m/d/yy h:mm", name: "3/14/01 13:30" },
                { value: "mmmmm", name: "M" },
                { value: "mmmmm-yy", name: "M-01" },
                { value: "m/d/yyyy", name: "3/14/2001" },
                { value: "d-mmm-yyyy", name: "14-Mar-2001" }
            ],
            template:
                "<div class='k-root-tabs' data-role='tabstrip' " +
                     "data-text-field='name' " +
                     "data-bind='source: categories, value: categoryFilter' " +
                     "data-animation='false' />" +

                "<div class='k-spreadsheet-preview' data-bind='text: preview' />" +

                "<script type='text/x-kendo-template' id='format-item-template'>" +
                    "#: data.name #" +
                "</script>" +

                "<select data-role='dropdownlist' class='k-format-filter' " +
                    "data-text-field='description' " +
                    "data-value-field='value' " +
                    "data-bind='visible: formatCurrency, value: currency, source: currencies' />" +

                "<ul data-role='staticlist' tabindex='0' " +
                    "class='k-list k-reset' " +
                    "data-template='format-item-template' " +
                    "data-value-primitive='true' " +
                    "data-value-field='value' " +
                    "data-bind='source: formats, value: format' />" +

                "<div class='k-action-buttons'>" +
                    "<button class='k-button k-primary' data-bind='click: apply'>Apply</button>" +
                    "<button class='k-button' data-bind='click: close'>Cancel</button>" +
                "</div>"
        },
        open: function(range) {
            var options = this.options;
            var value = range.value();
            var categories = options.categories.slice(0);
            var element;

            this.viewModel = new FormatCellsViewModel({
                currencies: options.currencies.slice(0),
                allFormats: {
                    numberFormats: options.numberFormats.slice(0),
                    dateFormats: options.dateFormats.slice(0)
                },
                categories: categories,
                format: range.format(),
                category: value instanceof Date ? categories[2] : categories[0],
                apply: this.apply.bind(this),
                close: this.close.bind(this),
                value: value
            });

            SpreadsheetDialog.fn.open.call(this);

            element = this.dialog().element;

            kendo.bind(element, this.viewModel);

            if (options.currencies.length > 10) {
                element.find(".k-format-filter").data("kendoDropDownList").setOptions({
                    filter: "contains"
                });
            }

            element.find(kendo.roleSelector("staticlist")).parent().addClass("k-list-wrapper");
        },
        apply: function() {
            var format = this.viewModel.format;

            SpreadsheetDialog.fn.apply.call(this);

            this.toolbar.trigger("execute", {
                commandType: "PropertyChangeCommand",
                property: "format",
                value: format
            });
        }
    });

    kendo.spreadsheet.dialogs.register("formatCells", FormatCellsDialog);

    var MessageDialog = SpreadsheetDialog.extend({
        options: {
            className: "k-spreadsheet-message",
            title: "",
            text: "",
            template:
                "<div class='k-spreadsheet-message-content' />" +
                "<div class='k-action-buttons'>" +
                    "<button class='k-button k-primary' data-bind='click: close'>OK</button>" +
                "</div>"
        },
        open: function() {
            var element = this.dialog().element;
            var content = element.find(".k-spreadsheet-message-content");

            content.text(this.options.text);

            SpreadsheetDialog.fn.open.call(this);
        }
    });

    kendo.spreadsheet.dialogs.register("message", MessageDialog);

})(window.kendo);
}, typeof define == 'function' && define.amd ? define : function(_, f){ f(); });
