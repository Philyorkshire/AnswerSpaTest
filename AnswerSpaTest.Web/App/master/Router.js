define([
  'backbone',
  'apps/people/controller'
], function(Backbone, peopleController) {
  'use strict';

  return Backbone.Router.extend({
    routes: {
      '': peopleController.list,
      'people': peopleController.list,
      'edit/:id': peopleController.edit
    }
  });
});