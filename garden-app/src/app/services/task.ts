import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay } from 'rxjs/operators';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private mockTasks: Task[] = [
    { id: 1, description: 'Полить помидоры', dueDate: '10.05.2026', isCompleted: false },
    { id: 2, description: 'Прополоть грядки', dueDate: '11.05.2026', isCompleted: false },
    { id: 3, description: 'Собрать клубнику', dueDate: '12.05.2026', isCompleted: true }
  ];

  constructor() { }

  getTasks(): Observable<Task[]> {
    return of(this.mockTasks).pipe(delay(500));
  }
}