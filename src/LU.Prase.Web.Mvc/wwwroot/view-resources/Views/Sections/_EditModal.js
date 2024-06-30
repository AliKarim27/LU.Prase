(function ($) {
    var _sectionService = abp.services.app.section,
        l = abp.localization.getSource('Prase'),
        _$modal = $('#SectionEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }
        var section = _$form.serializeFormToObject();
        section.Responsibles = [];
        var _$responsibleSelected = $('#Responsibles-Edit').find('option:selected');
        if (_$responsibleSelected) {
            for (var responsibleIndex = 0; responsibleIndex < _$responsibleSelected.length; responsibleIndex++) {
                var responsible = $(_$responsibleSelected[responsibleIndex]);
                section.Responsibles.push({ id: responsible.val() });
            }
        }



        abp.ui.setBusy(_$form);
        _sectionService.update(section).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('section.edited', section);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
