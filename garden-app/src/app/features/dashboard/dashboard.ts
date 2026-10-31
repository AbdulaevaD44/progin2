import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; // <-- Добавили ChangeDetectorRef
import { CommonModule } from '@angular/common';
import { PlantService } from '../../services/plant';
import { Plant } from '../../models/plant';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {
  plants: Plant[] = [];

  constructor(private plantService: PlantService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.plantService.getPlants().subscribe({
      next: (data) => {
        console.log('Данные дошли в Ангуляр:', data);
        this.plants = data; 
        
        this.cdr.detectChanges(); 
      },
      error: (err) => {
        console.error('Ошибка:', err);
      }
    });
  }
}