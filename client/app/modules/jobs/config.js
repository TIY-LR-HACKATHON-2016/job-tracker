function config($stateProvider) {
  $stateProvider
    .state('my_jobs', {
      url:'/',
      controller: 'MyJobsController as jobsCtrl',
      template: require('./views/my_jobs.html')
    })
    .state('add_job', {
      url:'/add',
      controller: 'AddJobController as addJobCtrl',
      template: require('./views/add_job.html')
    })
    .state('job', {
      url:'/:Id',
      controller: 'JobController as jobCtrl',
      template: require('./views/job.html')
    })
    .state('add_interview', {
      url: '/:Id/add_interview',
      controller: 'InterviewController as intCtrl',
      template: require('./views/add_interview.html')
    });
  }

  export default config;
