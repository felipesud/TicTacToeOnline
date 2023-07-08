import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private baseUrl = 'http://localhost:5238/'; // Substitua pelo URL do seu backend

  constructor(private http: HttpClient) { }

  createNewGame(): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/api/game/new`, {});
  }

  makeMove(gameId: string, move: Move): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/api/game/${gameId}/move`, move);
  }
}
