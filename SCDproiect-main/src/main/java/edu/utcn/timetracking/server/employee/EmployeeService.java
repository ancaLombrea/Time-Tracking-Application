package edu.utcn.timetracking.server.employee;

import edu.utcn.timetracking.server.timeTracking.TimeTracking;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.sql.Time;
import java.util.Date;
import java.util.List;
import java.util.concurrent.atomic.AtomicReference;

@Service
public class EmployeeService {

    @Autowired
    private EmployeeRepository employeeRepository;

    @Transactional
    public Employee create(Employee employee) {
        return employeeRepository.save(employee);
    }

    public List<Employee> findAllEmployees(){
        return employeeRepository.findAll();
    }

    public Employee findByID(int id){ return employeeRepository.findById(id); }

    public List<Employee> findByName(String name){ return employeeRepository.findByName(name); }

    public List<Employee> findByDate(Date date) { return employeeRepository.findByEnrollDate(date); }

    public List<Employee> getEmployeeByHourlyRate (int hour ) { return employeeRepository.findByHourlyRate(hour); }

    public String delete(int id) {
        employeeRepository.deleteById(id);
        return "Employee deleted!";
    }

    public Employee update(Employee employee){
        Employee employeeUpdated = employeeRepository.findById(employee.getId()).orElse(null);
        employeeUpdated.setName(employee.getName());
        employeeUpdated.setEnrollDate(employee.getEnrollDate());
        employeeUpdated.setHourlyRate(employee.getHourlyRate());
        return employeeRepository.save(employeeUpdated);
    }


    public Float WorkedHoursByEmployee(Date from, Date to){

        List<Employee> timeTrackingList = employeeRepository.findByEnrollDateBetween(from, to);
        AtomicReference<Float> sum = new AtomicReference<>((float) 0);
        timeTrackingList.forEach((t) -> {
            sum.set(Float.valueOf(sum.get() + t.getHourlyRate()));
        });
        sum.set(sum.get()/60);

        return sum.get();
    }

    public Integer[] findAllAndSelectId (){  // extrage intr-un array id-urile angajatilor
        List<Employee> employees = employeeRepository.findAll();
        Integer list[] = new Integer[employees.toArray().length];
        final int[] i = {0};
        employees.forEach((p) -> {
            list[i[0]] = p.getId();
            i[0] = i[0] +1;
        });
        return list;
    }

    public String[] findAllName (){  // extrage intr-un array numele angajatilor
        List<Employee> employees = employeeRepository.findAll();
        String list[] = new String[employees.toArray().length];
        final int[] i = {0};
        employees.forEach((p) -> {
            list[i[0]] = p.getName();
            i[0] = i[0] +1;
        });
        return list;
    }

    public String[] findAllHour (){  // extrage intr-un array numele angajatilor
        List<Employee> employees = employeeRepository.findAll();
        String list[] = new String[employees.toArray().length];
        final int[] i = {0};
        employees.forEach((p) -> {
            list[i[0]] = p.getHourlyRate();
            i[0] = i[0] +1;
        });
        return list;
    }

}
