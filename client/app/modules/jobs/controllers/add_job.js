class AddJobController{
  constructor($http, $state){
    this._$http = $http;
    this._$state = $state;

    this.jobTitle = "";
    this.companyTitle="";
    this.description="";
    // this.date="01/01/2001";

  }
  addJob() {
  this._$http
    .post(`http://tiyjobtracker.azurewebsites.net/jobs/create`,
    {
      JobTitle: this.jobTitle,
      CompanyTitle: this.companyTitle,
      Description: this.description,
      // Date: this.date
    })
    .then((response) => {
      this._$state.go('my_jobs');
      console.log(response);
    });
}
}




export default AddJobController;
// {
//     "CompanyTitle" : "Where you gonna work",
//     "Date" : "10/10/2015",
//     "JobTitle" : "What you gonna do",
//     "Description" : "Doing more stuff"
// }
