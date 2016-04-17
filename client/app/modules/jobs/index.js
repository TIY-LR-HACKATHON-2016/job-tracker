import angular from 'angular';

import config from './config';

import jobController from './controllers/job';
import addController from './controllers/add_job';
import jobsController from './controllers/my_jobs';
import interviewController from './controllers/add_interview';

let jobs = angular.module('tiy.jobs', []);

jobs.config(config);
jobs.controller('JobController', jobController);
jobs.controller('AddJobController', addController);
jobs.controller('MyJobsController', jobsController);
jobs.controller('InterviewController', interviewController);

export default jobs;
