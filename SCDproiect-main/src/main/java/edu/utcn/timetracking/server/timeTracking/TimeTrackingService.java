package edu.utcn.timetracking.server.timeTracking;

import edu.utcn.timetracking.server.employee.Employee;
import edu.utcn.timetracking.server.employee.EmployeeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;
import java.util.List;
import java.util.concurrent.atomic.AtomicReference;

@Service
public class TimeTrackingService {
    @Autowired
    private TimeTrackingRepository timeTrackingRepository;

    @Transactional
    public TimeTracking create(TimeTracking timeTracking) {
        return timeTrackingRepository.save(timeTracking);
    }

    public List<TimeTracking> findAllTimes(){
        return timeTrackingRepository.findAll();
    }

    public Float AllWorkedHours(){  // orele lucrate de toti angajatii

        List<TimeTracking> timeTrackingList = timeTrackingRepository.findAll();

        final float[] suma = {0};
        timeTrackingList.forEach((p) -> {
            suma[0]= suma[0] + (p.getMinutes());
        });
        suma[0]=suma[0]/60;

        return suma[0];
    }

    public Float WorkedHoursByEmployee(Date from, Date to, int id){  // orele lucrate intr-un anumit interval

        List<TimeTracking> timeTrackingList = timeTrackingRepository.findByDateBetween(from, to);

        final float[] suma = {0};
        timeTrackingList.forEach((p) -> {
            if(p.getEmployee().getId() == id) {
                suma[0] = suma[0] + (Float.valueOf(p.getMinutes()));
            }
        });
        suma[0]=suma[0]/60;

        return suma[0];
    }

    public Float AllWorkedHoursByOneEmployee(int id){  // orele lucrate de un anumit angajat in functie de id
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findByEmployeeId(id);
        final float[] suma = {0};
        timeTrackingList.forEach((p) -> {
            suma[0]= suma[0] + (Float.valueOf(p.getMinutes()));
        });
        suma[0]=suma[0]/60;

        return suma[0];
    }

/*
    public List<Integer> EmployeeIdBetweenDate(Date from, Date to){
        List<TimeTracking> timeTrackingList = timeTrackingRepository.findByDateBetween(from, to);
        Integer employeeList[]
    }
*/
}
