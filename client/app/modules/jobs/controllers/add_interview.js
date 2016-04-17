class InterviewController{
  constructor($http, $state, $stateParams){
    this._$http = $http;
    this._$state = $state;
    this.$stateParams = $stateParams;
    this.id = $stateParams.Id;
    // console.log(this.id);
  }

  addInterview(){
    // console.log(this.id);
    this._$http
    .post(`http://tiyjobtracker.azurewebsites.net/jobs/createinterview`,
    {
      JobId: this.id,
      Date: this.date
    })
    .then((response) => {
      this._$state.go(`job`, { Id: this.id });
      console.log(response);
    });
  }
}

export default InterviewController;
