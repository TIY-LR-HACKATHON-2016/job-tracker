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

  // hasInterviews(){
  //   this.jobs.forEach((j) =>{
  //     if j.
  //   })

// }


  updateJob(job) {
    console.log(job);
    this._$http
      .post(`http://tiyjobtracker.azurewebsites.net/jobs/edit/${job.Id}`,
        {
        Status: job.Status
        })
      .then((response) => {
        job.editing = false;
      });
  }


  getData() {
  this._$http
    .get(`http://tiyjobtracker.azurewebsites.net/jobs/index`)
    .then((response) => {

      this.jobs = response.data;
      this.jobs.forEach((j) => {
        console.log(j);
      });
      // console.log(this.jobs);
    });

  }
}

export default MyJobsController;
