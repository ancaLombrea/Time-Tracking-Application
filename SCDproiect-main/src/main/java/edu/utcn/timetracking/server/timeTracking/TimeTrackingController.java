package edu.utcn.timetracking.server.timeTracking;

import edu.utcn.timetracking.server.employee.Employee;
import edu.utcn.timetracking.server.employee.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.web.bind.annotation.*;

import java.sql.Time;
import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("/time_tracking")
@CrossOrigin
public class TimeTrackingController {
    @Autowired
    private TimeTrackingService timeTrackingService;

    @PostMapping
    public TimeTracking create(@RequestBody TimeTracking timeTracking)
    {
        return timeTrackingService.create(timeTracking);
    }
    @GetMapping
    public List<TimeTracking> getAllTimes(){
        return timeTrackingService.findAllTimes();
    }

    @GetMapping("/employeeDateBetween/{id}")
    public Float getHoursForEmployee(
            @PathVariable int id,
            @RequestParam("from") @DateTimeFormat(pattern = "yyyy-MM-dd") Date from,  // LocalDate
            @RequestParam("to") @DateTimeFormat(pattern = "yyyy-MM-dd") Date to){

        return timeTrackingService.WorkedHoursByEmployee(from, to, id);
    }

    @GetMapping("/employeeHours/{id}")
    public Float getHoursForEmployeeId(
            @PathVariable int id){
        return timeTrackingService.AllWorkedHoursByOneEmployee(id);
    }

    @GetMapping("/employeeHours")
    public Float getHoursForAllEmployee(){
        return timeTrackingService.AllWorkedHours();
    }



    /*
    @GetMapping("/employeeIdByDateBetween/")
    public List<Integer> getEmployeeIdByDate(
            @RequestParam("from") @DateTimeFormat(pattern = "yyyy-MM-dd") Date from,  // LocalDate
            @RequestParam("to") @DateTimeFormat(pattern = "yyyy-MM-dd") Date to){

        return timeTrackingService.WorkedHoursByEmployee(from, to);
    }
*/

}
