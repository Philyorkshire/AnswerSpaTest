define([
  'jquery',
  'marionette',
  'hbs!apps/people/list/templates/people',
  'hbs!apps/people/list/templates/personRow'
], function($, Marionette, PeopleView, PersonRowView) {
  'use strict';

  var personRowView = Marionette.ItemView.extend({
    template: PersonRowView,
    tagName: 'tr',

    events: {
      'click a' : 'navigateToEdit'
    },

    navigateToEdit: function(e) {
      e.preventDefault();
      var id = $(e.currentTarget).data('id');
      console.log('id: ' + id);
      Backbone.history.navigate('edit/' + id, { trigger: true });
    }
  });

  return Marionette.CompositeView.extend({
    template: PeopleView,
    childView: personRowView,
    childViewContainer: 'tbody'
  });
});