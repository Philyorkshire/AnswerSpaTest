define([
  'lib/reqres',
  'marionette',
  'apps/people/list/model',
  'apps/people/list/view',
  'apps/people/edit/model',
  'apps/people/edit/view'
], function(reqres, Marionette, People, PeopleView, Person, PersonEditView) {
  'use strict';

  return {
    list: function() {
      var people = new People();
      var peopleView = new PeopleView({
        collection: people
      });

      var layout = reqres.request("regions", "content");

      people.fetch().success(function() {
        layout.show(peopleView);
      });
    },

    edit: function (id) {
      var person = new Person({ id: id });
      var personEditView = new PersonEditView({
        model: person
      });

      var layout = reqres.request("regions", "content");

      person.fetch().success(function() {
        layout.show(personEditView);
      });
    }
  }
});