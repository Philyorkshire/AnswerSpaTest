define([
  'backbone'
], function (Backbone) {
  'use strict';

  return Backbone.Model.extend({
    initialize: function () {
      this.set({ fullName: this.fullNameSet.bind(this) });
      this.set({ isPalindrome: this.palindromeSet.bind(this) });
    },

    url: function () {
      return 'api/people/' + this.get('id');
    },

    defaults: {
      firstName: "Not Set",
      lastName: "Not Set",
      isPalindrome: "Not Set",
      favouriteColours: "Not Set"
    },

    fullNameSet: function () {
      return this.get('firstName') + " " + this.get('lastName');
    },

    palindromeSet: function () {
      var fullNameJoined = (this.get('firstName') + this.get('lastName')).toLowerCase();
      var reversedName = fullNameJoined.split('').reverse().join('');

      return fullNameJoined === reversedName;
    }
  });
});