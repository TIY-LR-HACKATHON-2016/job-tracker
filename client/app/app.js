import angular from 'angular';
import uiRouter from 'angular-ui-router';

import jobs from './modules/jobs';

let App = angular.module('app', [
  'ui.router',

  'tiy.jobs'
]);



function config($stateProvider, $urlRouterProvider) {
  $urlRouterProvider.otherwise("/");
}

App.config(config);
