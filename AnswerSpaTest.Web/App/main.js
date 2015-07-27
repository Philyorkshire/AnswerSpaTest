(function () {
  'use_strict';

  require.config({
    paths: {
      jquery: '/Scripts/jquery-2.1.4.min',
      underscore: '/Scripts/underscore-min',
      backbone: '/Scripts/backbone.min',
      marionette: '/Scripts/backbone.marionette.min',
      hbs: '/App/lib/require-handlebars-plugin/hbs',
      wreqr: '/Scripts/backbone.wreqr.min'
    },

    hbs: {
      templateExtension: 'html'
    }
  });

  require([
  'master/Application'
  ], function (App) {

    App.start();
  });
})();