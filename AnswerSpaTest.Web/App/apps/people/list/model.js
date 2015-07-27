define([
  'backbone',
  'apps/people/edit/model'
], function (Backbone, person) {
  'use strict';

  return Backbone.Collection.extend({
    url: 'api/people',
    model: person
  });
});