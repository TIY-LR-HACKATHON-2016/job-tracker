class MyJobsController {
  constructor($http){
    console.log("foo");
    this._$http = $http;
    this.getData();
    this.jobs = [];
    this.statuses = ['Saved', 'Interviewed', 'Scheduled', 'Applied', 'Declined'];
  }

  toggleEditStatus(job) {
    this.jobs.forEach((j) => {
      j.editing = false;
    });
    job.editing = true;
  }

  updateJob(job) {
    console.log(job);
    this._$http
      .post(`http://tiyjobtracker.azurewebsites.net/jobs/edit/${job.Id}`,
        {
        Status: job.Status
        })

      .then((response) => {
      });
      job.editing = false;

  }


  getData() {
  this._$http
    .get(`http://tiyjobtracker.azurewebsites.net/jobs/index`)
    .then((response) => {

      this.jobs = response.data;
      // console.log(this.jobs);
    });

  }
}

export default MyJobsController;
