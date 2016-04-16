import angular from 'angular';

import config from './config';

import jobController from './controllers/job';
import addController from './controllers/add_job';
import jobsController from './controllers/my_jobs';

let jobs = angular.module('tiy.jobs', []);

jobs.config(config);
jobs.controller('JobController', jobController);
jobs.controller('AddJobController', addController);
jobs.controller('MyJobsController', jobsController);

export default jobs;
