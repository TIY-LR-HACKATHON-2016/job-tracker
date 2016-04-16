function config($stateProvider) {
  $stateProvider
    .state('my_jobs', {
      url:'/',
      controller: 'MyJobsController as myJobsCtrl',
      template: require('./views/my_jobs.html')
    })
    .state('add_job', {
      url:'/add',
      controller: 'AddJobController as addJobCtrl',
      template: require('./views/add_job.html')
    })
    .state('job', {
      url:'/job',
      controller: 'JobController as jobCtrl',
      template: require('./views/job.html')
    });
  }

  export default config;
