define([
  'jquery',
  'lib/reqres',
  'backbone',
  'marionette',
  'master/Router',
  'hbs!master/templates/layout'
], function($, reqres, Backbone, Marionette, Router, masterLayout) {
  'use strict';

  var ApplicationLayout = Marionette.LayoutView.extend({
    el: '#application',

    regions: {
      content: '#main-content'
    },

    template: masterLayout
  });

  var Application = Marionette.Application.extend({
    initialize: function() {
      this.layout = new ApplicationLayout();
      this.layout.render();
    }
  });

  var App = new Application();

  App.Router = new Router();

  App.on("start", function () {
    if (!Backbone.History.started) {
      Backbone.history.start({ pushState: false });
      if (Backbone.history.fragment === '') {
        Backbone.history.navigate('people');
      }
    }
  });

  reqres.setHandler("regions", function(name) {
    return App.layout.getRegion(name);
  });

  return App;
});