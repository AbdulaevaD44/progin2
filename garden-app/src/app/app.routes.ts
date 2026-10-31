import { Routes } from '@angular/router';
import { Dashboard } from './features/dashboard/dashboard';
import { Diary } from './features/diary/diary';
import { Tasks } from './features/tasks/tasks';
import { Diagnosis } from './features/diagnosis/diagnosis';
import { Auth } from './features/auth/auth';
import { Settings } from './features/settings/settings';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'diary', component: Diary },
  { path: 'tasks', component: Tasks },
  { path: 'diagnosis', component: Diagnosis },
  { path: 'auth', component: Auth },
  { path: 'settings', component: Settings },
];