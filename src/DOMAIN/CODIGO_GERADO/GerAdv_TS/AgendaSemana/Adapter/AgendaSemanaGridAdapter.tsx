'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AgendaSemanaGrid from '@/app/GerAdv_TS/AgendaSemana/Crud/Grids/AgendaSemanaGrid';
export class AgendaSemanaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AgendaSemanaGrid />;
  }
}