export class appBase{
    public static AppName: string = "Ant Help"; //the app name
    public static DomainApi: string = "http://localhost:3999/";    //the web api Domain
    public static WebUrlDomain: string = "http://localhost:3998/";      //the web app Domain

    public static AppObject: any = { //the app global object
        centerStatus: 0, //personal center status
        managerStatus: 0 //manager status
    } //personal center 
}
