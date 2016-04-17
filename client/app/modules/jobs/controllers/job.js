class JobController{
  constructor($http, $stateParams){
    this._$http = $http;
    this.$stateParams = $stateParams;
    this.id = $stateParams.Id;

    this.interviews=[];
        // console.log($stateParams);
    // this.id = $stateParams.id;
    console.log(this.id);

    this.getData();
  }
  getData(){

    this._$http
    .get(`http://tiyjobtracker.azurewebsites.net/jobs/details/${this.id}`)
    .then((response) => {
      console.log(response.data);
      this.job=response.data;
      this.interviews=this.job.Interviews;
    });

  }
}

export default JobController;
