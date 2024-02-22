A .NET Core Web Application that can manage related services in your organization

Application Responsibilities:

    Consume service status health reports
    Take action on failing services for remote shutdown
    Alert interested parties to service health anomolies
    Monitor CloudAMQP queue message backlogs
    Manage CloudAMQP alarms and notification settings
    Place services into a temporary 'Maintenance Mode' as needed

Management UI Responsibilities:

    Service definitions and their underlying operating type (ie. IIS Application, Windows Service, Docker Container)
    Alert notification profiles
    Maintenance Mode definition template management (standard + ad hoc)
    Historical service health status
    Historical Maintenance Mode requests

