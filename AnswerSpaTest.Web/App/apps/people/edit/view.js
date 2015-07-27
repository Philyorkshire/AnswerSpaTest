define([
  'jquery',
  'backbone',
  'marionette',
  'hbs!apps/people/edit/templates/edit'
], function ($, Backbone, Marionette, personEditView) {
  'use strict';

  var selectedColourIds;

  return Marionette.ItemView.extend({
    template: personEditView,

    onShow: function () {
      selectedColourIds = [];

      var favouriteColours = this.model.get('favouriteColours').map(function(colour) {
        return colour.id;
      });

      var checkboxes = $('.colour-item');

      for (var i = 0; i < checkboxes.length; i++) {
        var checkbox = checkboxes[i];
        var checkboxId = $(checkbox).data('id');

        if (!$.inArray(checkboxId, favouriteColours)) {
          $(checkbox).prop('checked', true);
          selectedColourIds.push(checkboxId);
        }
      }
    },

    ui: {
      back: '[data-backbone]#back'
    },

    events: {
      'click back': 'backToList',
      'click [data-backbone]#save': 'saveChanges',
      'click [data-backbone]#reset': 'reset',
      'click .colour-item': 'toggleColour'
    },

    backToList: function (e) {
      e.preventDefault();
      Backbone.history.navigate('people', { trigger: true });
    },

    toggleColour: function (e) {
      var colourItem = $(e.currentTarget);
      var colourItemId = colourItem.data('id');

      if (colourItem.is(':checked')) {
        selectedColourIds.push(colourItemId);
      } else {
        selectedColourIds.pop(colourItemId);
      }
    },

    saveChanges: function (e) {
      e.preventDefault();

      var isAuthorised = $('input:checkbox[name=authorised]').is(':checked');
      var isEnabled = $('input:checkbox[name=enabled]').is(':checked');

      this.model.set({ isAuthorised: isAuthorised, isEnabled: isEnabled, favouriteColours: selectedColourIds });
      this.model.save().then(null, function () {
        Backbone.history.navigate('people', { trigger: true });
      });
    },

    reset: function (e) {
      e.preventDefault();
      Backbone.history.loadUrl(Backbone.history.fragment);
    }
  });
});