class MyJobsController {
  constructor($http){
    console.log("foo");
    this._$http=$http;
    this.getData();

  }

  getData() {
  this._$http
    .get(`http://tiyjobtracker.azurewebsites.net`)
    .then((response) => {
      console.log(response);
    });
  }
}

export default MyJobsController;
