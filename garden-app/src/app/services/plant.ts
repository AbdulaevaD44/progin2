import { Injectable } from '@angular/core';
import { Observable, of, delay } from 'rxjs';
import { Plant } from '../models/plant';

@Injectable({
  providedIn: 'root'
})
export class PlantService {
  private mockPlants: Plant[] = [
    { id: 1, name: '🍅 Помидоры', location: 'Теплица', plantingDate: '01.05.2026', needsWatering: true },
    { id: 2, name: '🥒 Огурцы', location: 'Грядка №3', plantingDate: '10.05.2026', needsWatering: false },
    { id: 3, name: '🍓 Клубника', location: 'Грядка №1', plantingDate: '15.04.2026', needsWatering: false },
    { id: 4, name: '🌶️ Перец', location: 'Веранда', plantingDate: '25.04.2026', needsWatering: true }
  ];

  constructor() { }

  getPlants(): Observable<Plant[]> {
    return of(this.mockPlants);
  }
}