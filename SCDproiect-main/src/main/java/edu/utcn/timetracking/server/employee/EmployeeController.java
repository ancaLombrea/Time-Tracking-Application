package edu.utcn.timetracking.server.employee;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("/employee")
@CrossOrigin
public class EmployeeController {

    @Autowired
    private EmployeeService employeeService;

    @PostMapping
    public Employee create(@RequestBody Employee employee)
    {
        return employeeService.create(employee);
    }

    @GetMapping
    public List<Employee> getAllEmployees(){
        return employeeService.findAllEmployees();
    }

    @GetMapping("/employeeById/{id}")
    public Employee findByID(@PathVariable int id){ return employeeService.findByID(id); }

    @GetMapping("/employeeByName/{name}")
    public List<Employee> findByName(@PathVariable String name){ return employeeService.findByName(name); }

    @GetMapping("/employeeByDate/{date}")
    public List<Employee> findByDate(@PathVariable @DateTimeFormat(pattern = "yyyy-MM-dd") Date date){ return employeeService.findByDate(date); }

    @GetMapping("/employeeByHour/{hour}")
    public List<Employee> getEmployeeByHourlyRate(@PathVariable int hour){ return employeeService.getEmployeeByHourlyRate(hour); }

    @PutMapping("/update")
    public Employee update(@RequestBody Employee employee)
    {
        return employeeService.update(employee);
    }  // RequestBody indica faptul ca Spring ar trebui sa deserializeze un request body intr-un obiect

    @DeleteMapping("/delete/{id}")
    public String delete(@PathVariable int id){ return  employeeService.delete(id); }


    @GetMapping("/employeeDateBetween/{name}")
    public Float getHoursForEmployee(
            @PathVariable int name,
            @RequestParam("from") @DateTimeFormat(pattern = "yyyy-MM-dd") Date from,  // LocalDate
            @RequestParam("to") @DateTimeFormat(pattern = "yyyy-MM-dd") Date to){

        return employeeService.WorkedHoursByEmployee(from, to);
    }

    @GetMapping("/employeeId")
    public Integer[] getEmployeeId(){    // extrage intr-un array id-urile angajatilor
        return employeeService.findAllAndSelectId();
    }
    @GetMapping("/employeeName")
    public String[] getEmployeeName(){    // extrage intr-un array numele angajatilor
        return employeeService.findAllName();
    }
    @GetMapping("/employeeHour")
    public String[] getEmployeeHour(){    // extrage intr-un array orele
        return employeeService.findAllHour();
    }
}
